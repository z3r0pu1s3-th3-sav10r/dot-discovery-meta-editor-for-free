using Meta.Core;
using Meta.Core.IO;
using Meta.Editor.Converters;
using Meta.Structures.Flatbuffers;
using MetaEditor;
using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Markup;
using System.Windows.Shell;

#nullable enable
namespace Meta.Editor.Windows
{
  public class MetaSchemaWindow : Window, IComponentConnector
  {
    private MetaSchemaCallback _callback;
    private MetaSchemaFailedCallback _failedCallback;
    private double progress;
    private FlatbufferSchema schema;
    private MetaAsset asset;
    private string status;
    internal 
    #nullable disable
    Grid taskWindow;
    internal TextBlock taskTextBlock;
    internal ProgressBar taskProgressBar;
    internal TextBlock statusTextBox;
    internal Button cancelButton;
    private bool _contentLoaded;

    private static 
    #nullable enable
    string Flatc => Path.Combine(App.ThirdPartyPath, "flatc.exe");

    public event PropertyChangedEventHandler PropertyChanged;

    public MetaAsset Asset
    {
      get => this.asset;
      set
      {
        if (value == this.asset)
          return;
        this.asset = value;
        this.NotifyPropertyChanged(nameof (Asset));
      }
    }

    public FlatbufferSchema Schema
    {
      get => this.schema;
      set
      {
        if (value == this.schema)
          return;
        this.schema = value;
        this.NotifyPropertyChanged(nameof (Schema));
      }
    }

    public double Progress
    {
      get => this.progress;
      set
      {
        if (value == this.progress)
          return;
        this.progress = value;
        this.NotifyPropertyChanged(nameof (Progress));
      }
    }

    public string Status
    {
      get => this.status;
      set
      {
        if (!(value != this.status))
          return;
        this.status = value;
        this.NotifyPropertyChanged(nameof (Status));
      }
    }

    public MetaSchemaWindow(
      Window owner,
      MetaAsset _asset,
      FlatbufferSchema _schema,
      MetaSchemaCallback callback = null,
      MetaSchemaFailedCallback failedCallback = null)
    {
      this.InitializeComponent();
      this.Asset = _asset;
      this.Schema = _schema;
      this.taskTextBlock.Text = "Deserializing " + this.Asset.DisplayName;
      this.Status = "This may take a while for containers with a large schema";
      this.Progress = 0.0;
      this._callback = callback;
      this._failedCallback = failedCallback;
      this.Loaded += new RoutedEventHandler(this.MetaSchemaWindow_Loaded);
      Application.Current.MainWindow.TaskbarItemInfo.ProgressState = TaskbarItemProgressState.Normal;
      BindingOperations.SetBinding((DependencyObject) Application.Current.MainWindow.TaskbarItemInfo, TaskbarItemInfo.ProgressValueProperty, (BindingBase) new Binding(nameof (Progress))
      {
        Converter = (IValueConverter) new DelegateBasedValueConverter(),
        ConverterParameter = (object) (Func<object, object>) (value => (object) ((double) value / 100.0)),
        Source = (object) this
      });
    }

    private async void Serialize()
    {
      await Task.Run((Action) (() =>
      {
        string tempPath = Path.GetTempPath();
        DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(4, 1);
        interpolatedStringHandler.AppendFormatted<Guid>(Guid.NewGuid());
        interpolatedStringHandler.AppendLiteral(".fbs");
        string stringAndClear = interpolatedStringHandler.ToStringAndClear();
        string path = Path.Combine(tempPath, stringAndClear);
        File.WriteAllBytes(path, this.Schema.schema);
        string destFileName = Path.Combine(App.CachePath, this.Asset.NameWithExt);
        File.Copy(this.Asset.Name, destFileName, true);
        interpolatedStringHandler = new DefaultInterpolatedStringHandler(25, 2);
        interpolatedStringHandler.AppendLiteral("-t --strict-json \"");
        interpolatedStringHandler.AppendFormatted(path);
        interpolatedStringHandler.AppendLiteral("\" -- \"");
        interpolatedStringHandler.AppendFormatted(destFileName);
        interpolatedStringHandler.AppendLiteral("\"");
        interpolatedStringHandler.ToStringAndClear();
      }));
    }

    private async void MetaSchemaWindow_Loaded(object sender, RoutedEventArgs e)
    {
      await Task.Run((Action) (() =>
      {
        string tempPath = Path.GetTempPath();
        DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(4, 1);
        interpolatedStringHandler.AppendFormatted<Guid>(Guid.NewGuid());
        interpolatedStringHandler.AppendLiteral(".fbs");
        string stringAndClear1 = interpolatedStringHandler.ToStringAndClear();
        string path = Path.Combine(tempPath, stringAndClear1);
        File.WriteAllBytes(path, this.Schema.schema);
        string str = Path.Combine(App.CachePath, this.Asset.NameWithExt);
        File.Copy(this.Asset.Name, str, true);
        interpolatedStringHandler = new DefaultInterpolatedStringHandler(25, 2);
        interpolatedStringHandler.AppendLiteral("-t --strict-json \"");
        interpolatedStringHandler.AppendFormatted(path);
        interpolatedStringHandler.AppendLiteral("\" -- \"");
        interpolatedStringHandler.AppendFormatted(str);
        interpolatedStringHandler.AppendLiteral("\"");
        string stringAndClear2 = interpolatedStringHandler.ToStringAndClear();
        try
        {
          Process process = Process.Start(new ProcessStartInfo(MetaSchemaWindow.Flatc, stringAndClear2)
          {
            CreateNoWindow = true,
            WorkingDirectory = App.CachePath
          });
          process.WaitForExit();
          if (process.ExitCode.Equals(0))
          {
            this.Asset.Data = File.ReadAllBytes(Path.Combine(App.CachePath, this.Asset.NameWithoutExt) + ".json");
            this._callback(this);
            App.Logger.Log("Successfully deserialized <" + this.Asset.DisplayName + ">", Array.Empty<object>());
          }
          else
          {
            this._failedCallback(this);
            App.Logger.LogError("Deserialization failed for <" + this.Asset.DisplayName + ">", Array.Empty<object>());
          }
        }
        finally
        {
          File.Delete(path);
          File.Delete(str);
          File.Delete(Path.Combine(App.CachePath, this.Asset.NameWithoutExt) + ".json");
        }
      }));
      Application.Current.MainWindow.TaskbarItemInfo.ProgressState = TaskbarItemProgressState.None;
      this.Close();
    }

    public void SetIndeterminate(bool newIndeterminate)
    {
      Application.Current.Dispatcher.Invoke((Action) (() =>
      {
        this.taskProgressBar.IsIndeterminate = newIndeterminate;
        Application.Current.MainWindow.TaskbarItemInfo.ProgressState = newIndeterminate ? TaskbarItemProgressState.Indeterminate : TaskbarItemProgressState.Normal;
      }));
    }

    public void Update(string? status = null, double? progress = null)
    {
      if (status != null)
        this.Status = status;
      if (!progress.HasValue)
        return;
      this.Progress = progress.Value;
    }

    public static void Show(
      Window owner,
      MetaAsset _asset,
      FlatbufferSchema _schema,
      MetaSchemaCallback callback = null,
      MetaSchemaFailedCallback failedCallback = null)
    {
      new MetaSchemaWindow(owner, _asset, _schema, callback, failedCallback).ShowDialog();
    }

    public static void Show(
      MetaAsset _asset,
      FlatbufferSchema _schema,
      MetaSchemaCallback callback = null,
      MetaSchemaFailedCallback failedCallback = null)
    {
      MetaSchemaWindow.Show(Application.Current.MainWindow, _asset, _schema, callback, failedCallback);
    }

    private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
    {
      PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
      if (propertyChanged == null)
        return;
      propertyChanged((object) this, new PropertyChangedEventArgs(propertyName));
    }

    [DebuggerNonUserCode]
    [GeneratedCode("PresentationBuildTasks", "7.0.11.0")]
    public void InitializeComponent()
    {
      if (this._contentLoaded)
        return;
      this._contentLoaded = true;
      Application.LoadComponent((object) this, new Uri("/Meta.Editor;V1.0.5.32;component/windows/metaschemawindow.xaml", UriKind.Relative));
    }

    [DebuggerNonUserCode]
    [GeneratedCode("PresentationBuildTasks", "7.0.11.0")]
    internal 
    #nullable disable
    Delegate _CreateDelegate(Type delegateType, string handler)
    {
      return Delegate.CreateDelegate(delegateType, (object) this, handler);
    }

    [DebuggerNonUserCode]
    [GeneratedCode("PresentationBuildTasks", "7.0.11.0")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    void IComponentConnector.Connect(int connectionId, object target)
    {
      switch (connectionId)
      {
        case 1:
          this.taskWindow = (Grid) target;
          break;
        case 2:
          this.taskTextBlock = (TextBlock) target;
          break;
        case 3:
          this.taskProgressBar = (ProgressBar) target;
          break;
        case 4:
          this.statusTextBox = (TextBlock) target;
          break;
        case 5:
          this.cancelButton = (Button) target;
          break;
        default:
          this._contentLoaded = true;
          break;
      }
    }
  }
}
