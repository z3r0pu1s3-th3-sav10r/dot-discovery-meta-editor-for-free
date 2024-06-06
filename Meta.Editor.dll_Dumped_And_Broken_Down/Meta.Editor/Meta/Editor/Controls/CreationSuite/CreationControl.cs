using Meta.Core;
using Meta.Core.Interfaces;
using System;
using System.Collections.ObjectModel;
using System.Windows.Controls;

#nullable enable
namespace Meta.Editor.Controls.CreationSuite
{
  public class CreationControl : Control
  {
    public ObservableCollection<CreationEditor> Editors = new ObservableCollection<CreationEditor>();
    protected ILogger logger;
    protected MetaTabControl Tab;

    public CreationControl(ILogger inLogger, MetaTabControl tab)
    {
      this.logger = inLogger;
      this.Tab = tab;
    }

    public virtual void OpenAs(Profile profile)
    {
    }

    public virtual void SaveAs()
    {
    }

    public virtual void Closed()
    {
      foreach (CreationEditor editor in (Collection<CreationEditor>) this.Editors)
        editor.Shutdown();
      GC.Collect();
    }
  }
}
