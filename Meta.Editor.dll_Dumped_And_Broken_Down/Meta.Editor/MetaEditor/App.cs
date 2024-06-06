using Meta.Core;
using Meta.Core.Interfaces;
using Meta.Structures.Flatbuffers;
using Microsoft.CSharp.RuntimeBinder;
using Newtonsoft.Json;
using Notification.Wpf;
using System;
using System.CodeDom.Compiler;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

#nullable enable
namespace MetaEditor
{
  public class App : Application
  {
    public static string Game = "";
    public static MetaGame CurrentGame;
    public static string Version = "";
    public static BlockingCollection<Action> EventQueue = new BlockingCollection<Action>();
    public static NotificationManager NotifyManager = new NotificationManager((Dispatcher) null);
    public static PluginManager PluginManager;
    public static SchemaManager SchemaManager;
    public static FlatbufferSerializeQueue SerializeQueue;
    public static DiscordRPCManager DiscordManager;
    public static Dictionary<string, Dictionary<string, object>> FileData = new Dictionary<string, Dictionary<string, object>>();
    private Config ini = new Config();
    public static MemManager MemoryManager = new MemManager();
    private static bool isGameRunning;
    private static Process GameProcess;
    private bool _contentLoaded;

    public static ILogger Logger
    {
      get => App.Logger;
      set => App.Logger = value;
    }

    public static float NotificationLifeTime => 5f;

    public App()
    {
      Assembly entryAssembly = Assembly.GetEntryAssembly();
      App.Version = "11.5.3";
      App.Version = entryAssembly.GetName().Version.ToString();
      AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(App.CurrentDomain_AssemblyResolve);
      App.Logger = (ILogger) new MetaLogger();
      App.Logger.Log("dot.Meta Editor v{0}", new object[1]
      {
        (object) App.Version
      });
      App.PluginManager = new PluginManager(App.Logger);
      App.SchemaManager = new SchemaManager(App.Logger);
      App.SerializeQueue = new FlatbufferSerializeQueue(App.Logger);
      App.Version += " (Developer)";
      App.DiscordManager = new DiscordRPCManager();
      App.DiscordManager.SetPresence("Viewing: Home Page");
    }

    public static bool GameActive => Process.GetProcessesByName(App.CurrentGame.Exe).Length != 0;

    public static Process ActiveGame => App.GameProcess;

    public static bool GameRunning
    {
      get => App.isGameRunning;
      set => App.isGameRunning = value;
    }

    private void Application_Startup(object sender, StartupEventArgs e)
    {
      Config.Load();
      MemManager.Load();
      foreach (string path in ((IEnumerable<string>) Directory.GetFiles("data", "*.json", SearchOption.AllDirectories)).ToList<string>())
      {
        string name = new DirectoryInfo(Path.GetDirectoryName(path)).Name;
        string withoutExtension = Path.GetFileNameWithoutExtension(path);
        if (!App.FileData.ContainsKey(name))
          App.FileData.Add(name, new Dictionary<string, object>());
        object obj = JsonConvert.DeserializeObject(File.ReadAllText(path));
        // ISSUE: reference to a compiler-generated field
        if (App.\u003C\u003Eo__27.\u003C\u003Ep__0 == null)
        {
          // ISSUE: reference to a compiler-generated field
          App.\u003C\u003Eo__27.\u003C\u003Ep__0 = CallSite<Action<CallSite, Dictionary<string, object>, string, object>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "Add", (IEnumerable<Type>) null, typeof (App), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[3]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        App.\u003C\u003Eo__27.\u003C\u003Ep__0.Target((CallSite) App.\u003C\u003Eo__27.\u003C\u003Ep__0, App.FileData[name], withoutExtension, obj);
      }
      Task.Run((Action) (() =>
      {
        while (!App.EventQueue.IsCompleted)
        {
          Action action = (Action) null;
          try
          {
            action = App.EventQueue.Take();
          }
          catch (InvalidOperationException ex)
          {
          }
          if (action != null)
          {
            action();
            Thread.Sleep(100);
          }
        }
      }));
    }

    private static void GameProcess_Exited(object? sender, EventArgs e) => App.GameRunning = false;

    public static bool InitiateWatchGame()
    {
      Process[] processesByName = Process.GetProcessesByName(App.CurrentGame.Exe);
      if (processesByName.Length == 0)
        return false;
      App.GameProcess = processesByName[0];
      App.GameProcess.EnableRaisingEvents = true;
      App.GameProcess.Exited += new EventHandler(App.GameProcess_Exited);
      App.GameRunning = true;
      App.Logger.Log("Now watching <{0}>", new object[1]
      {
        (object) App.CurrentGame.Exe
      });
      return true;
    }

    public static void Enqueue(Action action)
    {
      App.EventQueue.Add((Action) (() => Application.Current.Dispatcher.Invoke(action)));
    }

    private static Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
    {
      string name = args.Name.Contains(",") ? args.Name.Substring(0, args.Name.IndexOf(',')) : args.Name;
      if (name.StartsWith("FlatSharp") || name.StartsWith("Newtonsoft") || name.StartsWith("'Microsoft.CodeAnalysis"))
        return Assembly.LoadFile(new FileInfo(Assembly.GetExecutingAssembly().FullName).DirectoryName + "/ThirdParty/" + name + ".dll");
      return App.PluginManager != null ? App.PluginManager.GetPluginAssembly(name) : (Assembly) null;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("PresentationBuildTasks", "7.0.11.0")]
    public void InitializeComponent()
    {
      if (this._contentLoaded)
        return;
      this._contentLoaded = true;
      this.Startup += new StartupEventHandler(this.Application_Startup);
      this.StartupUri = new Uri("Windows/MainWindow.xaml", UriKind.Relative);
      Application.LoadComponent((object) this, new Uri("/Meta.Editor;V1.0.5.32;component/app.xaml", UriKind.Relative));
    }

    [STAThread]
    [DebuggerNonUserCode]
    [GeneratedCode("PresentationBuildTasks", "7.0.11.0")]
    public static void Main()
    {
      new SplashScreen("images/splashscreen.png").Show(true);
      App app = new App();
      app.InitializeComponent();
      app.Run();
    }
  }
}
