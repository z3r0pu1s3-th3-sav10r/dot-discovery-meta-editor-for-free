using System;

#nullable enable
namespace Meta.Editor.Plugin.Attributes
{
  [AttributeUsage(AttributeTargets.Assembly, AllowMultiple = false)]
  public class PluginVersionAttribute : Attribute
  {
    public string Version { get; private set; }

    public PluginVersionAttribute(string version) => this.Version = version;
  }
}
