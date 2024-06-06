using Meta.Editor.Plugin.Attributes;
using System;
using System.IO;
using System.Reflection;

#nullable enable
namespace Meta.Editor.Plugin
{
  public class Plugin
  {
    public string Author
    {
      get
      {
        Assembly assembly = this.Assembly;
        string author = (object) assembly != null ? assembly.GetCustomAttribute<PluginAuthorAttribute>()?.Author : (string) null;
        return !string.IsNullOrEmpty(author) ? author : "Unknown";
      }
    }

    public Assembly Assembly { get; set; }

    public Exception LoadException { get; set; }

    public string Name
    {
      get
      {
        Assembly assembly = this.Assembly;
        string displayName = (object) assembly != null ? assembly.GetCustomAttribute<PluginDisplayNameAttribute>()?.DisplayName : (string) null;
        return !string.IsNullOrEmpty(displayName) ? displayName : Path.GetFileNameWithoutExtension(this.SourcePath);
      }
    }

    public string SourcePath { get; private set; }

    public string Icon
    {
      get
      {
        Assembly assembly = this.Assembly;
        string icon = (object) assembly != null ? assembly.GetCustomAttribute<PluginIconAttribute>()?.Icon : (string) null;
        return !string.IsNullOrEmpty(icon) ? icon : "Tools";
      }
    }

    public PluginLoadStatus Status { get; set; }

    public string Version
    {
      get
      {
        Assembly assembly = this.Assembly;
        string version = (object) assembly != null ? assembly.GetCustomAttribute<PluginVersionAttribute>()?.Version : (string) null;
        return !string.IsNullOrEmpty(version) ? version : "1.0.0.0";
      }
    }

    public Plugin(Assembly assembly, string sourcePath)
    {
      this.Assembly = assembly;
      this.SourcePath = sourcePath;
    }
  }
}
