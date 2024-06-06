using Meta.Core;
using Meta.Core.Interfaces;
using Meta.Core.IO;
using Meta.Editor.Windows;
using Meta.Structures.Flatbuffers;
using MetaEditor;
using Microsoft.CSharp.RuntimeBinder;
using Microsoft.Win32;
using Newtonsoft.Json.Linq;
using Notification.Wpf;
using Notification.Wpf.Base;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Timers;
using System.Windows;

#nullable enable
namespace Meta.Editor.Controls
{
  public class Editor : IDisposable
  {
    protected ILogger logger;
    public FlatbufferControl FControl;
    protected MetaAsset asset;
    protected byte[] Resource;
    private FileSystemSafeWatcher watcher;
    private bool watching;
    private FlatbufferSchema schema;
    private object parent;

    public MetaAsset Asset
    {
      get => this.asset;
      set
      {
        if (value == this.asset)
          return;
        this.asset = value;
      }
    }

    public virtual string Icon { get; set; }

    public object Data { get; set; }

    public FlatbufferSchema Schema
    {
      get => this.schema;
      set
      {
        if (value == this.schema)
          return;
        this.schema = value;
      }
    }

    public bool IsWatching
    {
      get => this.watching;
      set
      {
        if (value == this.watching)
          return;
        this.watching = value;
      }
    }

    public object Parent
    {
      get => this.parent;
      set => this.parent = value;
    }

    public Editor(ILogger inLogger = null, FlatbufferSchema _schema = null, string file = null)
    {
      this.logger = inLogger;
      this.Schema = _schema;
    }

    public virtual void Initialize(object sender)
    {
      this.parent = sender;
      FlatbufferControl fcontrol = this.FControl;
      fcontrol._onEngineChange = fcontrol._onEngineChange + new MetaEngineChangeCallback(this.OnEngineChanged);
      CacheFile watch_file = Config.Get<CacheFile>(this.Asset.Name, (CacheFile) null);
      if (watch_file == null)
        return;
      if (File.Exists(watch_file.JSON_Path))
      {
        this.logger.Log("Now watching <{0}>", new object[1]
        {
          (object) watch_file.JSON_Path
        });
        this.FControl.Engine = watch_file.Engine;
        this.watcher = new FileSystemSafeWatcher(Path.GetDirectoryName(watch_file.JSON_Path));
        try
        {
          this.watcher.Filter = watch_file.Name + ".json";
          this.watcher.Changed += new FileSystemEventHandler(this.OnChanged);
          this.watcher.EnableRaisingEvents = true;
          this.IsWatching = true;
        }
        catch (Exception ex)
        {
          this.logger.LogError("Error: " + ex.Message, Array.Empty<object>());
        }
        if (Config.Get<bool>("WatchLoadEnabled", true) && !watch_file.LastModified.Equals(File.GetLastWriteTime(watch_file.JSON_Path)))
        {
          Timer timer = new Timer(1000.0);
          timer.AutoReset = false;
          timer.Elapsed += (ElapsedEventHandler) ((e, s) =>
          {
            this.logger.Log("File " + Path.GetFileName(watch_file.JSON_Path) + " has been changed. Serialization initiated.", Array.Empty<object>());
            this.OnEnterQueue();
          });
          timer.Start();
        }
      }
      else
      {
        this.logger.LogError("Watch file <{0}> no longer exists, removing from watch list", new object[1]
        {
          (object) watch_file.JSON_Path
        });
        Config.RemoveFile(watch_file);
        Config.Save();
      }
    }

    private ObservableCollection<MetaFlatbufferItem> BuildTreeNodes(object json)
    {
      ObservableCollection<MetaFlatbufferItem> observableCollection1 = new ObservableCollection<MetaFlatbufferItem>();
      switch (json)
      {
        case JArray _:
          // ISSUE: reference to a compiler-generated field
          if (Meta.Editor.Controls.Editor.\u003C\u003Eo__30.\u003C\u003Ep__4 == null)
          {
            // ISSUE: reference to a compiler-generated field
            Meta.Editor.Controls.Editor.\u003C\u003Eo__30.\u003C\u003Ep__4 = CallSite<Func<CallSite, object, IEnumerable>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (IEnumerable), typeof (Meta.Editor.Controls.Editor)));
          }
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          IEnumerator enumerator1 = Meta.Editor.Controls.Editor.\u003C\u003Eo__30.\u003C\u003Ep__4.Target((CallSite) Meta.Editor.Controls.Editor.\u003C\u003Eo__30.\u003C\u003Ep__4, json).GetEnumerator();
          try
          {
            while (enumerator1.MoveNext())
            {
              object current = enumerator1.Current;
              // ISSUE: reference to a compiler-generated field
              if (Meta.Editor.Controls.Editor.\u003C\u003Eo__30.\u003C\u003Ep__1 == null)
              {
                // ISSUE: reference to a compiler-generated field
                Meta.Editor.Controls.Editor.\u003C\u003Eo__30.\u003C\u003Ep__1 = CallSite<Func<CallSite, object, int>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (int), typeof (Meta.Editor.Controls.Editor)));
              }
              // ISSUE: reference to a compiler-generated field
              Func<CallSite, object, int> target1 = Meta.Editor.Controls.Editor.\u003C\u003Eo__30.\u003C\u003Ep__1.Target;
              // ISSUE: reference to a compiler-generated field
              CallSite<Func<CallSite, object, int>> p1 = Meta.Editor.Controls.Editor.\u003C\u003Eo__30.\u003C\u003Ep__1;
              // ISSUE: reference to a compiler-generated field
              if (Meta.Editor.Controls.Editor.\u003C\u003Eo__30.\u003C\u003Ep__0 == null)
              {
                // ISSUE: reference to a compiler-generated field
                Meta.Editor.Controls.Editor.\u003C\u003Eo__30.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "IndexOf", (IEnumerable<Type>) null, typeof (Meta.Editor.Controls.Editor), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
                {
                  CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
                  CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
                }));
              }
              // ISSUE: reference to a compiler-generated field
              // ISSUE: reference to a compiler-generated field
              object obj1 = Meta.Editor.Controls.Editor.\u003C\u003Eo__30.\u003C\u003Ep__0.Target((CallSite) Meta.Editor.Controls.Editor.\u003C\u003Eo__30.\u003C\u003Ep__0, json, current);
              int num = target1((CallSite) p1, obj1);
              ObservableCollection<MetaFlatbufferItem> observableCollection2 = observableCollection1;
              MetaFlatbufferItem metaFlatbufferItem1 = new MetaFlatbufferItem();
              metaFlatbufferItem1.Name = num.ToString();
              metaFlatbufferItem1.Icon = "CodeJson";
              metaFlatbufferItem1.IconExpand = "CodeJson";
              MetaFlatbufferItem metaFlatbufferItem2 = metaFlatbufferItem1;
              // ISSUE: reference to a compiler-generated field
              if (Meta.Editor.Controls.Editor.\u003C\u003Eo__30.\u003C\u003Ep__3 == null)
              {
                // ISSUE: reference to a compiler-generated field
                Meta.Editor.Controls.Editor.\u003C\u003Eo__30.\u003C\u003Ep__3 = CallSite<Func<CallSite, object, ObservableCollection<MetaFlatbufferItem>>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (ObservableCollection<MetaFlatbufferItem>), typeof (Meta.Editor.Controls.Editor)));
              }
              // ISSUE: reference to a compiler-generated field
              Func<CallSite, object, ObservableCollection<MetaFlatbufferItem>> target2 = Meta.Editor.Controls.Editor.\u003C\u003Eo__30.\u003C\u003Ep__3.Target;
              // ISSUE: reference to a compiler-generated field
              CallSite<Func<CallSite, object, ObservableCollection<MetaFlatbufferItem>>> p3 = Meta.Editor.Controls.Editor.\u003C\u003Eo__30.\u003C\u003Ep__3;
              // ISSUE: reference to a compiler-generated field
              if (Meta.Editor.Controls.Editor.\u003C\u003Eo__30.\u003C\u003Ep__2 == null)
              {
                // ISSUE: reference to a compiler-generated field
                Meta.Editor.Controls.Editor.\u003C\u003Eo__30.\u003C\u003Ep__2 = CallSite<Func<CallSite, Meta.Editor.Controls.Editor, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.InvokeSimpleName, nameof (BuildTreeNodes), (IEnumerable<Type>) null, typeof (Meta.Editor.Controls.Editor), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
                {
                  CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null),
                  CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
                }));
              }
              // ISSUE: reference to a compiler-generated field
              // ISSUE: reference to a compiler-generated field
              object obj2 = Meta.Editor.Controls.Editor.\u003C\u003Eo__30.\u003C\u003Ep__2.Target((CallSite) Meta.Editor.Controls.Editor.\u003C\u003Eo__30.\u003C\u003Ep__2, this, current);
              ObservableCollection<MetaFlatbufferItem> observableCollection3 = target2((CallSite) p3, obj2);
              metaFlatbufferItem2.Children = observableCollection3;
              MetaFlatbufferItem metaFlatbufferItem3 = metaFlatbufferItem1;
              observableCollection2.Add(metaFlatbufferItem3);
            }
            break;
          }
          finally
          {
            if (enumerator1 is IDisposable disposable)
              disposable.Dispose();
          }
        case Newtonsoft.Json.Linq.JObject _:
          // ISSUE: reference to a compiler-generated field
          if (Meta.Editor.Controls.Editor.\u003C\u003Eo__30.\u003C\u003Ep__11 == null)
          {
            // ISSUE: reference to a compiler-generated field
            Meta.Editor.Controls.Editor.\u003C\u003Eo__30.\u003C\u003Ep__11 = CallSite<Func<CallSite, object, IEnumerable>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (IEnumerable), typeof (Meta.Editor.Controls.Editor)));
          }
          // ISSUE: reference to a compiler-generated field
          Func<CallSite, object, IEnumerable> target3 = Meta.Editor.Controls.Editor.\u003C\u003Eo__30.\u003C\u003Ep__11.Target;
          // ISSUE: reference to a compiler-generated field
          CallSite<Func<CallSite, object, IEnumerable>> p11 = Meta.Editor.Controls.Editor.\u003C\u003Eo__30.\u003C\u003Ep__11;
          // ISSUE: reference to a compiler-generated field
          if (Meta.Editor.Controls.Editor.\u003C\u003Eo__30.\u003C\u003Ep__10 == null)
          {
            // ISSUE: reference to a compiler-generated field
            Meta.Editor.Controls.Editor.\u003C\u003Eo__30.\u003C\u003Ep__10 = CallSite<Func<CallSite, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "Properties", (IEnumerable<Type>) null, typeof (Meta.Editor.Controls.Editor), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
            {
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
            }));
          }
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          object obj3 = Meta.Editor.Controls.Editor.\u003C\u003Eo__30.\u003C\u003Ep__10.Target((CallSite) Meta.Editor.Controls.Editor.\u003C\u003Eo__30.\u003C\u003Ep__10, json);
          IEnumerator enumerator2 = target3((CallSite) p11, obj3).GetEnumerator();
          try
          {
            while (enumerator2.MoveNext())
            {
              object current = enumerator2.Current;
              ObservableCollection<MetaFlatbufferItem> observableCollection4 = observableCollection1;
              MetaFlatbufferItem metaFlatbufferItem4 = new MetaFlatbufferItem();
              MetaFlatbufferItem metaFlatbufferItem5 = metaFlatbufferItem4;
              // ISSUE: reference to a compiler-generated field
              if (Meta.Editor.Controls.Editor.\u003C\u003Eo__30.\u003C\u003Ep__6 == null)
              {
                // ISSUE: reference to a compiler-generated field
                Meta.Editor.Controls.Editor.\u003C\u003Eo__30.\u003C\u003Ep__6 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (string), typeof (Meta.Editor.Controls.Editor)));
              }
              // ISSUE: reference to a compiler-generated field
              Func<CallSite, object, string> target4 = Meta.Editor.Controls.Editor.\u003C\u003Eo__30.\u003C\u003Ep__6.Target;
              // ISSUE: reference to a compiler-generated field
              CallSite<Func<CallSite, object, string>> p6 = Meta.Editor.Controls.Editor.\u003C\u003Eo__30.\u003C\u003Ep__6;
              // ISSUE: reference to a compiler-generated field
              if (Meta.Editor.Controls.Editor.\u003C\u003Eo__30.\u003C\u003Ep__5 == null)
              {
                // ISSUE: reference to a compiler-generated field
                Meta.Editor.Controls.Editor.\u003C\u003Eo__30.\u003C\u003Ep__5 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "Name", typeof (Meta.Editor.Controls.Editor), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
                {
                  CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
                }));
              }
              // ISSUE: reference to a compiler-generated field
              // ISSUE: reference to a compiler-generated field
              object obj4 = Meta.Editor.Controls.Editor.\u003C\u003Eo__30.\u003C\u003Ep__5.Target((CallSite) Meta.Editor.Controls.Editor.\u003C\u003Eo__30.\u003C\u003Ep__5, current);
              string str = target4((CallSite) p6, obj4);
              metaFlatbufferItem5.Name = str;
              metaFlatbufferItem4.Icon = "CodeNotEqualVariant";
              metaFlatbufferItem4.IconExpand = "CodeNotEqualVariant";
              metaFlatbufferItem4.IsExpanded = true;
              MetaFlatbufferItem metaFlatbufferItem6 = metaFlatbufferItem4;
              // ISSUE: reference to a compiler-generated field
              if (Meta.Editor.Controls.Editor.\u003C\u003Eo__30.\u003C\u003Ep__9 == null)
              {
                // ISSUE: reference to a compiler-generated field
                Meta.Editor.Controls.Editor.\u003C\u003Eo__30.\u003C\u003Ep__9 = CallSite<Func<CallSite, object, ObservableCollection<MetaFlatbufferItem>>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (ObservableCollection<MetaFlatbufferItem>), typeof (Meta.Editor.Controls.Editor)));
              }
              // ISSUE: reference to a compiler-generated field
              Func<CallSite, object, ObservableCollection<MetaFlatbufferItem>> target5 = Meta.Editor.Controls.Editor.\u003C\u003Eo__30.\u003C\u003Ep__9.Target;
              // ISSUE: reference to a compiler-generated field
              CallSite<Func<CallSite, object, ObservableCollection<MetaFlatbufferItem>>> p9 = Meta.Editor.Controls.Editor.\u003C\u003Eo__30.\u003C\u003Ep__9;
              // ISSUE: reference to a compiler-generated field
              if (Meta.Editor.Controls.Editor.\u003C\u003Eo__30.\u003C\u003Ep__8 == null)
              {
                // ISSUE: reference to a compiler-generated field
                Meta.Editor.Controls.Editor.\u003C\u003Eo__30.\u003C\u003Ep__8 = CallSite<Func<CallSite, Meta.Editor.Controls.Editor, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.InvokeSimpleName, nameof (BuildTreeNodes), (IEnumerable<Type>) null, typeof (Meta.Editor.Controls.Editor), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
                {
                  CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null),
                  CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
                }));
              }
              // ISSUE: reference to a compiler-generated field
              Func<CallSite, Meta.Editor.Controls.Editor, object, object> target6 = Meta.Editor.Controls.Editor.\u003C\u003Eo__30.\u003C\u003Ep__8.Target;
              // ISSUE: reference to a compiler-generated field
              CallSite<Func<CallSite, Meta.Editor.Controls.Editor, object, object>> p8 = Meta.Editor.Controls.Editor.\u003C\u003Eo__30.\u003C\u003Ep__8;
              // ISSUE: reference to a compiler-generated field
              if (Meta.Editor.Controls.Editor.\u003C\u003Eo__30.\u003C\u003Ep__7 == null)
              {
                // ISSUE: reference to a compiler-generated field
                Meta.Editor.Controls.Editor.\u003C\u003Eo__30.\u003C\u003Ep__7 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "Value", typeof (Meta.Editor.Controls.Editor), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
                {
                  CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
                }));
              }
              // ISSUE: reference to a compiler-generated field
              // ISSUE: reference to a compiler-generated field
              object obj5 = Meta.Editor.Controls.Editor.\u003C\u003Eo__30.\u003C\u003Ep__7.Target((CallSite) Meta.Editor.Controls.Editor.\u003C\u003Eo__30.\u003C\u003Ep__7, current);
              object obj6 = target6((CallSite) p8, this, obj5);
              ObservableCollection<MetaFlatbufferItem> observableCollection5 = target5((CallSite) p9, obj6);
              metaFlatbufferItem6.Children = observableCollection5;
              MetaFlatbufferItem metaFlatbufferItem7 = metaFlatbufferItem4;
              observableCollection4.Add(metaFlatbufferItem7);
            }
            break;
          }
          finally
          {
            if (enumerator2 is IDisposable disposable)
              disposable.Dispose();
          }
        default:
          ObservableCollection<MetaFlatbufferItem> observableCollection6 = observableCollection1;
          MetaFlatbufferItem metaFlatbufferItem8 = new MetaFlatbufferItem();
          MetaFlatbufferItem metaFlatbufferItem9 = metaFlatbufferItem8;
          // ISSUE: reference to a compiler-generated field
          if (Meta.Editor.Controls.Editor.\u003C\u003Eo__30.\u003C\u003Ep__13 == null)
          {
            // ISSUE: reference to a compiler-generated field
            Meta.Editor.Controls.Editor.\u003C\u003Eo__30.\u003C\u003Ep__13 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (string), typeof (Meta.Editor.Controls.Editor)));
          }
          // ISSUE: reference to a compiler-generated field
          Func<CallSite, object, string> target7 = Meta.Editor.Controls.Editor.\u003C\u003Eo__30.\u003C\u003Ep__13.Target;
          // ISSUE: reference to a compiler-generated field
          CallSite<Func<CallSite, object, string>> p13 = Meta.Editor.Controls.Editor.\u003C\u003Eo__30.\u003C\u003Ep__13;
          // ISSUE: reference to a compiler-generated field
          if (Meta.Editor.Controls.Editor.\u003C\u003Eo__30.\u003C\u003Ep__12 == null)
          {
            // ISSUE: reference to a compiler-generated field
            Meta.Editor.Controls.Editor.\u003C\u003Eo__30.\u003C\u003Ep__12 = CallSite<Func<CallSite, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "ToString", (IEnumerable<Type>) null, typeof (Meta.Editor.Controls.Editor), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
            {
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
            }));
          }
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          object obj7 = Meta.Editor.Controls.Editor.\u003C\u003Eo__30.\u003C\u003Ep__12.Target((CallSite) Meta.Editor.Controls.Editor.\u003C\u003Eo__30.\u003C\u003Ep__12, json);
          string str1 = target7((CallSite) p13, obj7);
          metaFlatbufferItem9.Name = str1;
          metaFlatbufferItem8.Icon = "Wrench";
          MetaFlatbufferItem metaFlatbufferItem10 = metaFlatbufferItem8;
          observableCollection6.Add(metaFlatbufferItem10);
          break;
      }
      return observableCollection1;
    }

    public virtual MetaFlatbufferItem CreateRootNode()
    {
      object obj1 = this.Asset.Deserialize<object>();
      MetaFlatbufferItem rootNode = new MetaFlatbufferItem()
      {
        Name = "root"
      };
      MetaFlatbufferItem metaFlatbufferItem = rootNode;
      // ISSUE: reference to a compiler-generated field
      if (Meta.Editor.Controls.Editor.\u003C\u003Eo__31.\u003C\u003Ep__1 == null)
      {
        // ISSUE: reference to a compiler-generated field
        Meta.Editor.Controls.Editor.\u003C\u003Eo__31.\u003C\u003Ep__1 = CallSite<Func<CallSite, object, ObservableCollection<MetaFlatbufferItem>>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (ObservableCollection<MetaFlatbufferItem>), typeof (Meta.Editor.Controls.Editor)));
      }
      // ISSUE: reference to a compiler-generated field
      Func<CallSite, object, ObservableCollection<MetaFlatbufferItem>> target = Meta.Editor.Controls.Editor.\u003C\u003Eo__31.\u003C\u003Ep__1.Target;
      // ISSUE: reference to a compiler-generated field
      CallSite<Func<CallSite, object, ObservableCollection<MetaFlatbufferItem>>> p1 = Meta.Editor.Controls.Editor.\u003C\u003Eo__31.\u003C\u003Ep__1;
      // ISSUE: reference to a compiler-generated field
      if (Meta.Editor.Controls.Editor.\u003C\u003Eo__31.\u003C\u003Ep__0 == null)
      {
        // ISSUE: reference to a compiler-generated field
        Meta.Editor.Controls.Editor.\u003C\u003Eo__31.\u003C\u003Ep__0 = CallSite<Func<CallSite, Meta.Editor.Controls.Editor, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.InvokeSimpleName, "BuildTreeNodes", (IEnumerable<Type>) null, typeof (Meta.Editor.Controls.Editor), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj2 = Meta.Editor.Controls.Editor.\u003C\u003Eo__31.\u003C\u003Ep__0.Target((CallSite) Meta.Editor.Controls.Editor.\u003C\u003Eo__31.\u003C\u003Ep__0, this, obj1);
      ObservableCollection<MetaFlatbufferItem> observableCollection = target((CallSite) p1, obj2);
      metaFlatbufferItem.Children = observableCollection;
      rootNode.IsExpanded = true;
      return rootNode;
    }

    private void OnChanged(object source, FileSystemEventArgs e)
    {
      this.logger.Log("File " + Path.GetFileName(e.FullPath) + " has been changed. Serialization initiated", Array.Empty<object>());
      this.OnEnterQueue();
    }

    private void OnEngineChanged(EngineVersion version)
    {
      CacheFile cacheFile = Config.Current.EditorFiles.FirstOrDefault<CacheFile>((Func<CacheFile, bool>) (x => x.JSFB_Path.Equals(this.Asset.Name)));
      if (cacheFile == null || cacheFile.Engine == version)
        return;
      Config.UpdateFile(cacheFile, cacheFile.JSFB_Path, cacheFile.JSON_Path, cacheFile.LastModified, cacheFile.Game, cacheFile.Schema, this.FControl.Engine);
      this.logger.Log(this.Asset.Filename + " engine updated in config", Array.Empty<object>());
    }

    public virtual void Export(string exportLocation)
    {
      if (this.Asset.Data == null)
        return;
      string str1 = Path.GetDirectoryName(exportLocation) + "\\" + this.Asset.NameWithoutExt + ".json";
      try
      {
        File.WriteAllBytes(str1, this.Asset.Data);
        if (MetaMessageBox.Show("Would you like Meta to watch this JSON/JSFB?", "Meta File Manager", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
        {
          CacheFile cacheFile1 = Config.Current.EditorFiles.FirstOrDefault<CacheFile>((Func<CacheFile, bool>) (x => x.JSFB_Path.Equals(this.Asset.Name)));
          if (cacheFile1 != null)
          {
            if (MetaMessageBox.Show("Config already contains a watcher for this JSFB, update locations?", "Meta File Manager", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
              CacheFile cacheFile2 = cacheFile1;
              string name = this.Asset.Name;
              string str2 = str1;
              DateTime lastWriteTime = new FileInfo(str1).LastWriteTime;
              string game = App.Game;
              CacheFile.SchemaConfig schemaConfig = new CacheFile.SchemaConfig();
              schemaConfig.Schema_Name = this.Schema.name;
              schemaConfig.Schema_Tag = this.Schema.identifier;
              EngineVersion engine = this.FControl.Engine;
              Config.UpdateFile(cacheFile2, name, str2, lastWriteTime, game, schemaConfig, engine);
              this.logger.LogWarning(this.Asset.Filename + " paths have been updated", Array.Empty<object>());
            }
          }
          else
          {
            string name = this.Asset.Name;
            string str3 = str1;
            DateTime lastWriteTime = new FileInfo(str1).LastWriteTime;
            string game = App.Game;
            CacheFile.SchemaConfig schemaConfig = new CacheFile.SchemaConfig();
            schemaConfig.Schema_Name = this.Schema.name;
            schemaConfig.Schema_Tag = this.Schema.identifier;
            EngineVersion engine = this.FControl.Engine;
            Config.AddFile(name, str3, lastWriteTime, game, schemaConfig, engine);
            this.logger.Log(this.Asset.Filename + " has been added to your watch list", Array.Empty<object>());
          }
          CacheFile cacheFile3 = Config.Get<CacheFile>(this.Asset.Name, (CacheFile) null);
          if (File.Exists(cacheFile3.JSON_Path))
          {
            this.watcher = new FileSystemSafeWatcher(Path.GetDirectoryName(cacheFile3.JSON_Path));
            try
            {
              this.watcher.Filter = cacheFile3.Name + ".json";
              this.watcher.Changed += new FileSystemEventHandler(this.OnChanged);
              this.watcher.EnableRaisingEvents = true;
              this.IsWatching = true;
            }
            catch (Exception ex)
            {
              this.logger.LogError("Error: " + ex.Message, Array.Empty<object>());
            }
          }
        }
      }
      finally
      {
        this.logger.Log("Configured and exported JSON to {0}", new object[1]
        {
          (object) str1
        });
        if (this.IsWatching)
          this.logger.Log("Now watching <{0}>", new object[1]
          {
            (object) str1
          });
      }
    }

    private void OnEnterQueue()
    {
      if (!this.IsWatching)
        return;
      CacheFile watchFile = Config.Get<CacheFile>(this.Asset.Name, (CacheFile) null);
      if (watchFile != null)
      {
        if (File.Exists(watchFile.JSON_Path))
        {
          if (BackupManager.Backup(this.Asset.Name, Config.Get<int>("MaxBackups", 2)))
          {
            this.logger.Log("Created backup for {0}", new object[1]
            {
              (object) this.Asset.DisplayName
            });
            App.SerializeQueue.Add(this.Asset, this.Schema, this.FControl.Engine, watchFile.JSON_Path, watchFile.JSFB_Path, (MetaSerializerCallback) (task =>
            {
              if (Config.Get<bool>("WindowsNotifications", true))
                App.NotifyManager.Show(this.Asset.NameWithExt + " serialized", (NotificationType) 5, "", new TimeSpan?(TimeSpan.FromSeconds((double) App.NotificationLifeTime)), (NotificationTextTrimType) 0, 1U, true, (TextContentSettings) null, true, (object) null);
              this.logger.Log("Import {0} => {1} success!", new object[2]
              {
                (object) (this.Asset.NameWithoutExt + ".json"),
                (object) this.Asset.DisplayName
              });
              Config.UpdateFile(watchFile, watchFile.JSFB_Path, watchFile.JSON_Path, new FileInfo(watchFile.JSON_Path).LastWriteTime, App.Game, watchFile.Schema, this.FControl.Engine);
              this.FControl.UpdateControlSource();
            }), (MetaSerializerFailedCallback) (task =>
            {
              this.logger.LogError("Serialization failed for <" + this.Asset.NameWithoutExt + ">", Array.Empty<object>());
              int num = (int) MetaMessageBox.Show("There was an error when trying to serialize " + this.Asset.NameWithoutExt, "Meta File Manager");
            }));
          }
          else
            this.logger.LogError("There was a problem trying to backup {0}", new object[1]
            {
              (object) this.Asset.Name
            });
        }
        else
        {
          int num1 = (int) MetaMessageBox.Show("File not found <" + watchFile.JSON_Path + ">", "Meta File Manager");
        }
      }
    }

    public virtual void Import()
    {
      if (this.IsWatching)
      {
        CacheFile cacheFile = Config.Get<CacheFile>(this.Asset.Name, (CacheFile) null);
        if (cacheFile != null)
        {
          if (File.Exists(cacheFile.JSON_Path))
          {
            if (File.Exists(this.Asset.Name))
            {
              if (BackupManager.Backup(this.Asset.Name, Config.Get<int>("MaxBackups", 2)))
              {
                this.logger.Log("Created backup for {0}", new object[1]
                {
                  (object) this.Asset.DisplayName
                });
                string path = Path.GetTempPath() + Guid.NewGuid().ToString() + ".fbs";
                File.WriteAllBytes(path, this.Resource);
                DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(9, 2);
                interpolatedStringHandler.AppendLiteral(" -b \"");
                interpolatedStringHandler.AppendFormatted(path);
                interpolatedStringHandler.AppendLiteral("\" \"");
                interpolatedStringHandler.AppendFormatted(cacheFile.JSON_Path);
                interpolatedStringHandler.AppendLiteral("\"");
                string stringAndClear = interpolatedStringHandler.ToStringAndClear();
                Process.Start(new ProcessStartInfo(Path.Combine(App.ThirdPartyPath, "flatc.exe"), stringAndClear)
                {
                  CreateNoWindow = true,
                  WorkingDirectory = App.ThirdPartyPath
                }).WaitForExit();
                File.Delete(path);
                string destFileName = Path.GetDirectoryName(cacheFile.JSFB_Path) + "\\" + this.Asset.CName + ".jsfb";
                string str = App.ThirdPartyPath + "\\" + this.Asset.CName + ".jsfb";
                if (File.Exists(str))
                {
                  File.Move(str, destFileName, true);
                  if (Config.Get<bool>("WindowsNotifications", true))
                    App.NotifyManager.Show(this.Asset.DisplayName + " serialized", (NotificationType) 5, "", new TimeSpan?(TimeSpan.FromSeconds((double) App.NotificationLifeTime)), (NotificationTextTrimType) 0, 1U, true, (TextContentSettings) null, true, (object) null);
                  this.logger.Log("Import {0} => {1} success!", new object[2]
                  {
                    (object) (this.Asset.CName + ".json"),
                    (object) this.Asset.DisplayName
                  });
                  Config.UpdateFile(cacheFile, cacheFile.JSFB_Path, cacheFile.JSON_Path, new FileInfo(cacheFile.JSON_Path).LastWriteTime, App.Game, cacheFile.Schema, cacheFile.Engine);
                }
                else
                {
                  int num = (int) MetaMessageBox.Show("There was an error when trying to serialize " + this.Asset.CName, "Meta File Manager");
                }
              }
              else
                this.logger.LogError("There was a problem trying to backup {0}", new object[1]
                {
                  (object) this.Asset.Name
                });
            }
            else
            {
              int num1 = (int) MetaMessageBox.Show("There was an error when trying to open " + this.Asset.Filename, "Meta File Manager");
            }
          }
          else
          {
            int num2 = (int) MetaMessageBox.Show("There was an error when trying to open " + cacheFile.JSON_Path, "Meta File Manager");
          }
        }
      }
      else
      {
        OpenFileDialog openFileDialog = new OpenFileDialog();
        openFileDialog.Filter = "(All supported formats)|*.json";
        openFileDialog.Title = "Open JSON";
        openFileDialog.Multiselect = true;
        OpenFileDialog ofd = openFileDialog;
        bool? nullable = ofd.ShowDialog();
        bool flag = true;
        if (nullable.GetValueOrDefault() == flag & nullable.HasValue)
          MetaTaskWindow.Show("Importing JSON", "", (MetaTaskCallback) (task =>
          {
            if (File.Exists(this.Asset.Name))
            {
              if (!BackupManager.Backup(this.Asset.Name, Config.Get<int>("MaxBackups", 2)))
                return;
              this.logger.Log("Created backup for {0}", new object[1]
              {
                (object) this.Asset.DisplayName
              });
              string path = Path.GetTempPath() + Guid.NewGuid().ToString() + ".fbs";
              File.WriteAllBytes(path, this.Resource);
              DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(9, 2);
              interpolatedStringHandler.AppendLiteral(" -b \"");
              interpolatedStringHandler.AppendFormatted(path);
              interpolatedStringHandler.AppendLiteral("\" \"");
              interpolatedStringHandler.AppendFormatted(ofd.FileName);
              interpolatedStringHandler.AppendLiteral("\"");
              string stringAndClear = interpolatedStringHandler.ToStringAndClear();
              Process.Start(new ProcessStartInfo(Path.Combine(App.ThirdPartyPath, "flatc.exe"), stringAndClear)
              {
                CreateNoWindow = true,
                WorkingDirectory = App.ThirdPartyPath
              }).WaitForExit();
              File.Delete(path);
              string destFileName = Path.GetDirectoryName(ofd.FileName) + "\\" + this.Asset.CName + ".jsfb";
              string str = App.ThirdPartyPath + "\\" + this.Asset.CName + ".jsfb";
              if (File.Exists(str))
              {
                File.Move(str, destFileName, true);
                if (Config.Get<bool>("WindowsNotifications", true))
                  App.NotifyManager.Show(this.Asset.DisplayName + " serialized", (NotificationType) 5, "", new TimeSpan?(TimeSpan.FromSeconds((double) App.NotificationLifeTime)), (NotificationTextTrimType) 0, 1U, true, (TextContentSettings) null, true, (object) null);
                this.logger.Log("Import {0} => {1} success!", new object[2]
                {
                  (object) (this.Asset.CName + ".json"),
                  (object) this.Asset.DisplayName
                });
              }
              else
              {
                int num = (int) MetaMessageBox.Show("There was an error trying to import JSON, check for valid file", "Meta File Manager");
              }
            }
            else
            {
              int num3 = (int) MetaMessageBox.Show("There was an error when trying to open " + this.Asset.Filename, "Meta File Manager");
            }
          }));
      }
      this.FControl.UpdateControlSource();
    }

    public virtual List<ToolbarItem> RegisterToolbarItems() => new List<ToolbarItem>();

    public virtual List<ContextMenuItem> RegisterContextMenuItems() => new List<ContextMenuItem>();

    public void Shutdown()
    {
      if (this.watcher == null)
        return;
      this.IsWatching = false;
      this.watcher.EnableRaisingEvents = false;
      this.watcher.Dispose();
      this.logger.Log("Stopped watching {0}", new object[1]
      {
        (object) this.Asset.CName
      });
    }

    public void Dispose()
    {
      this.Dispose(true);
      GC.SuppressFinalize((object) this);
    }

    protected virtual void Dispose(bool disposing)
    {
      try
      {
        if (!disposing || this.watcher == null)
          return;
        this.watcher.Dispose();
        this.watcher = (FileSystemSafeWatcher) null;
      }
      finally
      {
        this.IsWatching = false;
      }
    }
  }
}
