using System;

#nullable enable
namespace Meta.Editor.Plugin.Attributes
{
  [AttributeUsage(AttributeTargets.Assembly, AllowMultiple = false)]
  public class PluginIconAttribute : Attribute
  {
    public string Icon { get; private set; }

    public PluginIconAttribute(string icon) => this.Icon = icon;
  }
}
