using Meta.Editor.Converters;
using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
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
  public class MetaTaskWindow : Window, IComponentConnector
  {
    private MetaTaskCallback _callback;
    private double progress;
    private string status;
    internal 
    #nullable disable
    Grid taskWindow;
    internal TextBlock taskTextBlock;
    internal ProgressBar taskProgressBar;
    internal TextBlock statusTextBox;
    internal Button cancelButton;
    private bool _contentLoaded;

    public event 
    #nullable enable
    PropertyChangedEventHandler PropertyChanged;

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

    private MetaTaskWindow(
      Window owner,
      string task,
      string initialStatus,
      MetaTaskCallback callback)
    {
      this.InitializeComponent();
      this.taskTextBlock.Text = task;
      this.Progress = 0.0;
      this.Status = initialStatus;
      this._callback = callback;
      this.Owner = owner;
      this.Loaded += new RoutedEventHandler(this.MetaTaskWindow_Loaded);
      Application.Current.MainWindow.TaskbarItemInfo.ProgressState = TaskbarItemProgressState.Normal;
      BindingOperations.SetBinding((DependencyObject) Application.Current.MainWindow.TaskbarItemInfo, TaskbarItemInfo.ProgressValueProperty, (BindingBase) new Binding(nameof (Progress))
      {
        Converter = (IValueConverter) new DelegateBasedValueConverter(),
        ConverterParameter = (object) (Func<object, object>) (value => (object) ((double) value / 100.0)),
        Source = (object) this
      });
    }

    private async void MetaTaskWindow_Loaded(object sender, RoutedEventArgs e)
    {
      await Task.Run((Action) (() => this._callback(this)));
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
      string task,
      string initialStatus,
      MetaTaskCallback callback)
    {
      new MetaTaskWindow(owner, task, initialStatus, callback).ShowDialog();
    }

    public static void Show(string task, string initialStatus, MetaTaskCallback callback)
    {
      MetaTaskWindow.Show(Application.Current.MainWindow, task, initialStatus, callback);
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
      Application.LoadComponent((object) this, new Uri("/Meta.Editor;V1.0.5.32;component/windows/metataskwindow.xaml", UriKind.Relative));
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
