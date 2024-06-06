using Meta.Core.Interfaces;
using System;
using System.ComponentModel;
using System.Windows.Controls;

#nullable enable
namespace Meta.Editor.Controls.CreationSuite
{
  public class CreationEditor : Control, INotifyPropertyChanged
  {
    protected ILogger logger;

    public event PropertyChangedEventHandler PropertyChanged;

    public virtual string Title => "Empty Control";

    public virtual string Icon => "Folder";

    public CreationEditor(ILogger inLogger)
    {
      this.logger = inLogger;
      this.Initialized += new EventHandler(this.CreationEditor_Initialized);
    }

    protected virtual void CreationEditor_Initialized(object? sender, EventArgs e)
    {
    }

    public virtual void Shutdown()
    {
    }
  }
}
