using System;

#nullable enable
namespace Meta.Editor.Plugin.Attributes
{
  [AttributeUsage(AttributeTargets.Assembly, AllowMultiple = false)]
  public class PluginDisplayNameAttribute : Attribute
  {
    public string DisplayName { get; private set; }

    public PluginDisplayNameAttribute(string displayName) => this.DisplayName = displayName;
  }
}
