using Meta.Editor.Controls;
using Meta.Structures.Flatbuffers;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

#nullable enable
namespace Meta.Editor.Windows
{
  public class SchemaWindow : MetaWindow, INotifyPropertyChanged, IComponentConnector
  {
    private MetaSchemaTaskCallback _callback;
    private MetaSchemaCancelCallback _cancelCallback;
    private MetaSchemaOkCallback _okCallback;
    private FlatbufferSchema selectedSchema;
    private IEnumerable<FlatbufferSchema> schemas;
    private string activeFile;
    internal 
    #nullable disable
    Button cancelButton;
    internal Button saveButton;
    private bool _contentLoaded;

    public event 
    #nullable enable
    PropertyChangedEventHandler? PropertyChanged;

    public string Active
    {
      get => this.activeFile;
      set
      {
        if (!(value != this.activeFile))
          return;
        this.activeFile = value;
        this.NotifyPropertyChanged(nameof (Active));
      }
    }

    public FlatbufferSchema SelectedSchema
    {
      get => this.selectedSchema;
      set
      {
        if (value == this.selectedSchema)
          return;
        this.selectedSchema = value;
        this.NotifyPropertyChanged(nameof (SelectedSchema));
      }
    }

    public IEnumerable<FlatbufferSchema> Schemas
    {
      get => this.schemas;
      set
      {
        if (value == this.schemas)
          return;
        this.schemas = value;
        this.NotifyPropertyChanged(nameof (Schemas));
      }
    }

    public SchemaWindow(
      Window owner,
      string file,
      IEnumerable<FlatbufferSchema> schemas,
      MetaSchemaTaskCallback callback,
      MetaSchemaCancelCallback cancelCallback = null,
      MetaSchemaOkCallback okCallback = null)
    {
      this.InitializeComponent();
      this._callback = callback;
      this._cancelCallback = cancelCallback;
      this._okCallback = okCallback;
      this.Schemas = schemas;
      this.activeFile = file;
      this.DataContext = (object) this;
      this.Title = "(Schema Library) Selected: " + Path.GetFileNameWithoutExtension(this.Active);
      this.Owner = owner;
      this.Loaded += new RoutedEventHandler(this.SchemaWindow_Loaded);
    }

    public static void Show(
      Window owner,
      string file,
      IEnumerable<FlatbufferSchema> schemas,
      MetaSchemaTaskCallback callback,
      MetaSchemaCancelCallback cancelCallback = null,
      MetaSchemaOkCallback okCallback = null)
    {
      new SchemaWindow(owner, file, schemas, callback, cancelCallback, okCallback).ShowDialog();
    }

    private void CancelButton_Click(object sender, RoutedEventArgs e)
    {
      this.cancelButton.IsEnabled = false;
      this._cancelCallback(this);
      this.Close();
    }

    private void OkButton_Click(object sender, RoutedEventArgs e)
    {
      this._okCallback(this);
      this.Close();
    }

    private async void SchemaWindow_Loaded(object sender, RoutedEventArgs e)
    {
      await Task.Run((Action) (() => this._callback(this)));
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
      Application.LoadComponent((object) this, new Uri("/Meta.Editor;V1.0.5.32;component/windows/schemawindow.xaml", UriKind.Relative));
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
          this.cancelButton = (Button) target;
          this.cancelButton.Click += new RoutedEventHandler(this.CancelButton_Click);
          break;
        case 2:
          this.saveButton = (Button) target;
          this.saveButton.Click += new RoutedEventHandler(this.OkButton_Click);
          break;
        default:
          this._contentLoaded = true;
          break;
      }
    }
  }
}
