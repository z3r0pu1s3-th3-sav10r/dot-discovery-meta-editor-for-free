using Meta.Core;
using Meta.Core.Interfaces;
using Meta.Core.IO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Controls;

#nullable enable
namespace Meta.Editor.Controls
{
  public class MetaBaseControl : Control, INotifyPropertyChanged
  {
    private EngineVersion engineVersion = (EngineVersion) 0;
    protected ILogger logger;
    protected MetaAsset asset;
    public MetaEngineChangeCallback _onEngineChange;

    public event PropertyChangedEventHandler PropertyChanged;

    public MetaAsset Asset => this.asset;

    public virtual string Icon => "Folder";

    public EngineVersion Engine
    {
      get => this.engineVersion;
      set
      {
        if (value == this.engineVersion)
          return;
        this.engineVersion = value;
        this.OnPropertyChanged(nameof (Engine));
      }
    }

    public MetaBaseControl(ILogger inLogger) => this.logger = inLogger;

    public virtual void Closed()
    {
    }

    public virtual void OnEngineSet(EngineVersion version) => this._onEngineChange(version);

    public virtual void LoadAsset(string path) => this.asset = new MetaAsset(path, (Type) null);

    public virtual List<ToolbarItem> RegisterToolbarItems() => new List<ToolbarItem>();

    protected virtual void OnPropertyChanged(string propertyName)
    {
      PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
      if (propertyChanged == null)
        return;
      propertyChanged((object) this, new PropertyChangedEventArgs(propertyName));
    }
  }
}
