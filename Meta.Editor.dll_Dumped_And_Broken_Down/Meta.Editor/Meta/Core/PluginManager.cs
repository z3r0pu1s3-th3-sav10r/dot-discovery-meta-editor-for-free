using Meta.Core.Interfaces;
using Meta.Editor;
using Meta.Editor.Plugin.Attributes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;

#nullable enable
namespace Meta.Core
{
  public sealed class PluginManager
  {
    private List<Meta.Editor.Plugin.Plugin> m_plugins = new List<Meta.Editor.Plugin.Plugin>();
    private List<Meta.Editor.Plugin.Plugin> m_loadedPlugins = new List<Meta.Editor.Plugin.Plugin>();
    private List<MenuExtension> m_menuExtensions = new List<MenuExtension>();

    public IEnumerable<MenuExtension> MenuExtensions
    {
      get => (IEnumerable<MenuExtension>) this.m_menuExtensions;
    }

    public IEnumerable<Meta.Editor.Plugin.Plugin> Plugins => (IEnumerable<Meta.Editor.Plugin.Plugin>) this.m_plugins;

    public PluginManager(ILogger logger)
    {
      if (!Directory.Exists("plug-ins"))
      {
        logger.Log("The \"plug-ins\" directory could not be found", Array.Empty<object>());
      }
      else
      {
        this.LoadDefinitionsFromAssembly(Assembly.GetEntryAssembly());
        this.LoadDefinitionsFromAssembly(Assembly.GetExecutingAssembly());
        foreach (string enumerateFile in Directory.EnumerateFiles("plug-ins", "*.dll", SearchOption.AllDirectories))
          this.m_plugins.Add(this.LoadPlugin(new FileInfo(enumerateFile).FullName));
      }
    }

    public void Initialize()
    {
      foreach (Meta.Editor.Plugin.Plugin plugin in this.m_plugins)
      {
        this.LoadDefinitionsFromAssembly(plugin.Assembly);
        this.m_loadedPlugins.Add(plugin);
      }
    }

    public Assembly GetPluginAssembly(string name)
    {
      foreach (Meta.Editor.Plugin.Plugin plugin in this.m_plugins)
      {
        Assembly assembly = plugin.Assembly;
        if ((object) assembly != null && assembly.GetName().Name.Equals(name, StringComparison.OrdinalIgnoreCase))
          return plugin.Assembly;
      }
      return (Assembly) null;
    }

    public Meta.Editor.Plugin.Plugin LoadPlugin(string pluginPath)
    {
      Meta.Editor.Plugin.Plugin plugin = new Meta.Editor.Plugin.Plugin((Assembly) null, pluginPath);
      try
      {
        Assembly assembly = Assembly.LoadFile(plugin.SourcePath);
        this.LoadDefinitionsFromAssembly(assembly);
        plugin.Status = PluginLoadStatus.Loaded;
        ILogger logger = App.Logger;
        DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(15, 1);
        interpolatedStringHandler.AppendLiteral("Loaded plug-in ");
        interpolatedStringHandler.AppendFormatted<AssemblyName>(assembly.GetName());
        string stringAndClear = interpolatedStringHandler.ToStringAndClear();
        object[] objArray = Array.Empty<object>();
        logger.Log(stringAndClear, objArray);
        plugin.Assembly = assembly;
      }
      catch (Exception ex)
      {
        plugin.LoadException = ex;
      }
      return plugin;
    }

    private void LoadDefinitionsFromAssembly(Assembly assembly)
    {
      if (assembly == (Assembly) null)
        return;
      foreach (Attribute customAttribute in assembly.GetCustomAttributes())
      {
        if (customAttribute is RegisterMenuExtensionAttribute extensionAttribute)
        {
          if (!extensionAttribute.MenuExtensionType.IsSubclassOf(typeof (MenuExtension)))
            throw new Exception("Menu extensions must extend from MenuExtensions base class");
          this.m_menuExtensions.Add((MenuExtension) Activator.CreateInstance(extensionAttribute.MenuExtensionType));
        }
      }
    }
  }
}
