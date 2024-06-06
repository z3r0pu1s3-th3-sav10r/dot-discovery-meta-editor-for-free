using Meta.Core;
using Meta.Core.Interfaces;
using Meta.Core.IO;
using Meta.Editor.Commands;
using Meta.Editor.Extensions;
using Meta.Editor.Windows;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Threading;

#nullable enable
namespace Meta.Editor.Controls
{
  [TemplatePart(Name = "PART_FilterTextBox", Type = typeof (MetaWatermarkTextbox))]
  [TemplatePart(Name = "PART_DataGrid", Type = typeof (DataGrid))]
  [TemplatePart(Name = "PART_StringID", Type = typeof (TextBox))]
  [TemplatePart(Name = "PART_StringText", Type = typeof (TextBox))]
  [TemplatePart(Name = "PART_NewSDB", Type = typeof (Button))]
  public class MetaSDBControl : MetaBaseControl, INotifyPropertyChanged
  {
    private const string PART_DataGrid = "PART_DataGrid";
    private DataGrid dataGrid;
    private const string PART_FilterTextBox = "PART_FilterTextBox";
    private MetaWatermarkTextbox filterTb;
    private const string PART_StringID = "PART_StringID";
    private TextBox newStringID;
    private const string PART_StringText = "PART_StringText";
    private TextBox newStringText;
    private const string PART_NewSDB = "PART_NewSDB";
    private Button newSDBBtn;
    private Cache<ObservableCollection<SDBAsset>> sdbCache;
    private ObservableCollection<SDBAsset> StringsDatabase = new ObservableCollection<SDBAsset>();
    private bool firstTimeLoad = true;
    private MetaSDBControl.HeaderTags Type = MetaSDBControl.HeaderTags.SDB_NO_MANGLING;
    private bool _isGUIDOverride;

    public override string Icon => "CodeString";

    public bool GUIDOverride
    {
      get => this._isGUIDOverride;
      set
      {
        if (this._isGUIDOverride == value)
          return;
        this._isGUIDOverride = value;
        this.OnPropertyChanged(nameof (GUIDOverride));
      }
    }

    static MetaSDBControl()
    {
      FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof (MetaSDBControl), (PropertyMetadata) new FrameworkPropertyMetadata((object) typeof (MetaSDBControl)));
    }

    public MetaSDBControl(ILogger inLogger)
      : base(inLogger)
    {
    }

    public override List<ToolbarItem> RegisterToolbarItems()
    {
      List<ToolbarItem> toolbarItemList = base.RegisterToolbarItems();
      toolbarItemList.Add(new ToolbarItem("Save DB", "Save SDB changes", "ContentSaveCheck", new RelayCommand((Action<object>) (state => this.SaveStringDatabase((object) this, new RoutedEventArgs())))));
      toolbarItemList.Add(new ToolbarItem("Patch DB", "Patch SDB cache to current SDB", "DatabaseClock", new RelayCommand((Action<object>) (state => this.PatchStringDatabase((object) this, new RoutedEventArgs())))));
      return toolbarItemList;
    }

    public override void OnApplyTemplate()
    {
      base.OnApplyTemplate();
      this.dataGrid = this.GetTemplateChild("PART_DataGrid") as DataGrid;
      this.filterTb = this.GetTemplateChild("PART_FilterTextBox") as MetaWatermarkTextbox;
      this.newStringID = this.GetTemplateChild("PART_StringID") as TextBox;
      this.newStringText = this.GetTemplateChild("PART_StringText") as TextBox;
      this.newSDBBtn = this.GetTemplateChild("PART_NewSDB") as Button;
      this.Loaded += new RoutedEventHandler(this.SDBControl_Loaded);
      this.dataGrid.CellEditEnding += new EventHandler<DataGridCellEditEndingEventArgs>(this.DataGrid_CellEditEnding);
      this.filterTb.TextChanged += new TextChangedEventHandler(this.FilterTb_LostFocus);
      this.filterTb.LostFocus += new RoutedEventHandler(this.FilterTb_LostFocus);
      this.filterTb.KeyUp += new KeyEventHandler(this.FilterTb_KeyUp);
      this.newSDBBtn.Click += new RoutedEventHandler(this.NewSDBBtn_Click);
    }

    private void DataGrid_CellEditEnding(object? sender, DataGridCellEditEndingEventArgs e)
    {
      SDBAsset rowSDB = e.Row.Item as SDBAsset;
      if (rowSDB == null || !((e.Column is DataGridBoundColumn column ? column.Binding : (BindingBase) null) is Binding binding) || binding.Path == null)
        return;
      string path = binding.Path.Path;
      string text = ((TextBox) e.EditingElement).Text;
      if (!(rowSDB.GetType().GetProperty(path)?.GetValue((object) rowSDB, (object[]) null)?.ToString() != text))
        return;
      switch (path)
      {
        case "Id":
          uint result;
          if (uint.TryParse(text, out result))
          {
            rowSDB.Id = result;
            break;
          }
          int num = (int) MetaMessageBox.Show("ID is either too large or too small", "SDB Manager");
          return;
        case "String":
          rowSDB.String = text;
          break;
      }
      SDBAsset sdbAsset = this.sdbCache.CachedObject.FirstOrDefault<SDBAsset>((Func<SDBAsset, bool>) (s => (int) s.Id == (int) rowSDB.Id));
      if (sdbAsset != null)
      {
        switch (path)
        {
          case "Id":
            sdbAsset.Id = rowSDB.Id;
            break;
          case "String":
            sdbAsset.String = text;
            break;
        }
      }
      else
        this.sdbCache.CachedObject.Add(new SDBAsset()
        {
          Id = rowSDB.Id,
          String = text
        });
      this.logger.Log("Internal SDB cache for [{0}] was updated", new object[1]
      {
        (object) rowSDB.Id
      });
    }

    private void NewSDBBtn_Click(object sender, RoutedEventArgs e)
    {
      if (!string.IsNullOrEmpty(this.newStringText.Text))
      {
        if (this.newStringID.Text.Length > 0)
        {
          ulong result;
          if (ulong.TryParse(this.newStringID.Text, out result) && result <= (ulong) uint.MaxValue)
          {
            SDBAsset sdbAsset = new SDBAsset()
            {
              Id = uint.Parse(this.newStringID.Text),
              String = this.newStringText.Text
            };
            this.StringsDatabase.Add(sdbAsset);
            this.dataGrid.SelectedItem = (object) sdbAsset;
            this.dataGrid.ScrollIntoView((object) sdbAsset);
            this.newStringID.Text = (this.StringsDatabase.Last<SDBAsset>().Id + 1U).ToString();
            this.sdbCache.CachedObject.Add(sdbAsset);
            this.logger.LogWarning("String database cache changed, [{0}] was added - save required", new object[1]
            {
              (object) sdbAsset.String
            });
          }
          else
          {
            int num = (int) MetaMessageBox.Show("ID exceeds the maximum capacity", "SDB Manager");
          }
        }
        else
        {
          int num1 = (int) MetaMessageBox.Show("Input is too short", "SDB Manager");
        }
      }
      else
      {
        int num2 = (int) MetaMessageBox.Show("String requires input", "SDB Manager");
      }
    }

    private void FilterTb_KeyUp(object sender, KeyEventArgs e)
    {
      if (e.Key == 6)
        this.filterTb.MoveFocus(new TraversalRequest((FocusNavigationDirection) 0));
      if (e.Key != 13)
        return;
      this.filterTb.Text = "";
    }

    private void FilterTb_LostFocus(object sender, RoutedEventArgs e)
    {
      if (this.filterTb.Text == "")
      {
        this.dataGrid.Items.Filter = (Predicate<object>) null;
      }
      else
      {
        if (string.IsNullOrEmpty(this.filterTb.Text))
          return;
        this.dataGrid.Items.Filter = (Predicate<object>) (o =>
        {
          SDBAsset sdbAsset = o as SDBAsset;
          string pattern = Regex.Escape(this.filterTb.Text.Replace("%", ".*").Replace("_", ".")) ?? "";
          return Regex.IsMatch(sdbAsset.String, pattern, RegexOptions.IgnoreCase) || Regex.IsMatch(sdbAsset.Id.ToString(), pattern, RegexOptions.IgnoreCase);
        });
      }
    }

    private void SaveStringDatabase(object sender, RoutedEventArgs e)
    {
      this.dataGrid.Items.Filter = (Predicate<object>) null;
      MetaTaskWindow.Show("Baking String Database", "", (MetaTaskCallback) (task =>
      {
        if (BackupManager.Backup(this.Asset.Name, Config.Get<int>("MaxBackups", 2)))
          this.logger.Log("Created backup for {0}", new object[1]
          {
            (object) this.Asset.DisplayName
          });
        using (NativeWriter nativeWriter = new NativeWriter((Stream) File.Open(this.Asset.Name, FileMode.Create), false, false))
        {
          ((BinaryWriter) nativeWriter).Write(new byte[4]);
          ((BinaryWriter) nativeWriter).Write(this.StringsDatabase.Count);
          int num = 8 + 12 * this.StringsDatabase.Count;
          for (int index = 0; index < this.StringsDatabase.Count; ++index)
          {
            byte[] bytes = Encoding.Latin1.GetBytes(this.StringsDatabase[index].String);
            ((BinaryWriter) nativeWriter).Write(num);
            ((BinaryWriter) nativeWriter).Write(bytes.Length);
            ((BinaryWriter) nativeWriter).Write(this.StringsDatabase[index].Id);
            num += bytes.Length + 1;
          }
          for (int index = 0; index < this.StringsDatabase.Count; ++index)
          {
            ((BinaryWriter) nativeWriter).Write(Encoding.Latin1.GetBytes(this.StringsDatabase[index].String));
            ((BinaryWriter) nativeWriter).Write((byte) 0);
          }
          this.sdbCache.Save();
          ((BinaryWriter) nativeWriter).Dispose();
        }
      }));
      this.logger.Log("Saved String Database [{0}]", new object[1]
      {
        (object) this.Asset.Name
      });
    }

    private void PatchStringDatabase(object sender, RoutedEventArgs e)
    {
      ObservableCollection<SDBAsset> storedCacheList = this.sdbCache.Load();
      if (storedCacheList == null || storedCacheList.Count <= 0)
        return;
      MetaTaskWindow.Show("Patching String Database", "", (MetaTaskCallback) (task =>
      {
        foreach (SDBAsset sdbAsset1 in storedCacheList.OrderBy<SDBAsset, uint>((Func<SDBAsset, uint>) (o => o.Id)).ToList<SDBAsset>())
        {
          SDBAsset sdb = sdbAsset1;
          SDBAsset sdbAsset2 = this.StringsDatabase.Where<SDBAsset>((Func<SDBAsset, bool>) (s => s.Id.Equals(sdb.Id))).FirstOrDefault<SDBAsset>();
          if (sdbAsset2 != null)
          {
            sdbAsset2.Id = sdb.Id;
            sdbAsset2.String = sdb.String;
          }
          else
            ((DispatcherObject) this).Dispatcher.Invoke((Action) (() => this.StringsDatabase.Add(new SDBAsset()
            {
              Id = sdb.Id,
              String = sdb.String
            })));
        }
      }));
      this.dataGrid.Items.Refresh();
      this.logger.Log("Patched String Database [{0}] successfully. SDB save required", new object[1]
      {
        (object) this.Asset.Name
      });
    }

    private void LoadCache()
    {
      if (this.sdbCache.CachedObject != null)
        return;
      this.sdbCache.CachedObject = new ObservableCollection<SDBAsset>();
      this.sdbCache.Save();
    }

    private void UnpackDatabase(out ObservableCollection<SDBAsset> SDataBase)
    {
      this.LoadCache();
      ObservableCollection<SDBAsset> sDB = new ObservableCollection<SDBAsset>();
      MetaTaskWindow.Show("Unpacking String Database", "", (MetaTaskCallback) (task =>
      {
        using (NativeReader nativeReader = new NativeReader((Stream) new MemoryStream(File.ReadAllBytes(this.Asset.Name))))
        {
          this.Type = (MetaSDBControl.HeaderTags) nativeReader.ReadUInt((Endian) 0);
          if (this.Type.Equals((object) MetaSDBControl.HeaderTags.SDB_MANGLED) || this.Type.Equals((object) MetaSDBControl.HeaderTags.SDB_NO_MANGLING))
          {
            uint num = nativeReader.ReadUInt((Endian) 0);
            for (int index = 0; (long) index < (long) num; ++index)
            {
              SDBAsset sdbAsset = new SDBAsset()
              {
                Index = (uint) index,
                Address = nativeReader.ReadUInt((Endian) 0),
                Size = nativeReader.ReadUInt((Endian) 0),
                Id = nativeReader.ReadUInt((Endian) 0)
              };
              long position = nativeReader.Position;
              nativeReader.Position = (long) sdbAsset.Address;
              sdbAsset.String = Encoding.Latin1.GetString(nativeReader.ReadByteArray((int) sdbAsset.Size));
              if (this.Type.Equals((object) MetaSDBControl.HeaderTags.SDB_MANGLED))
                sdbAsset.String = this.DemangleString(sdbAsset.String, sdbAsset.Address);
              nativeReader.Position = position;
              sDB.Add(sdbAsset);
            }
          }
          nativeReader.Dispose();
        }
      }));
      this.logger.Log("Unpacked String Database [{0}]", new object[1]
      {
        (object) this.Asset.Filename
      });
      SDataBase = sDB;
    }

    public string DemangleString(string target, uint address)
    {
      byte num1 = (byte) ((int) address & (int) byte.MaxValue ^ 205);
      char[] charArray = target.ToCharArray();
      for (int index = 0; index < charArray.Length; ++index)
      {
        byte num2 = (byte) charArray[index];
        charArray[index] = (char) ((uint) charArray[index] ^ (uint) num1);
        num1 = num2;
      }
      return new string(charArray);
    }

    private void SDBControl_Loaded(object sender, RoutedEventArgs e)
    {
      if (!this.firstTimeLoad)
        return;
      this.sdbCache = new Cache<ObservableCollection<SDBAsset>>(this.logger, this.Asset.Name);
      this.UnpackDatabase(out this.StringsDatabase);
      this.dataGrid.ItemsSource = (IEnumerable) this.StringsDatabase;
      this.newStringID.DataContext = (object) this.StringsDatabase;
      this.newStringID.SetBinding(TextBox.TextProperty, (BindingBase) new Binding()
      {
        Path = new PropertyPath("Id", Array.Empty<object>()),
        Source = (object) this.StringsDatabase.LastOrDefault<SDBAsset>(),
        Mode = BindingMode.OneWay,
        Converter = (IValueConverter) new MaxIdConverter(!this.GUIDOverride)
      });
      this.firstTimeLoad = false;
      this.DataContext = (object) this;
    }

    private enum HeaderTags
    {
      SDB_NO_MANGLING = 0,
      SDB_MANGLED = 256, // 0x00000100
    }
  }
}
