using Meta.Core;
using Meta.Core.Interfaces;
using Microsoft.CSharp.RuntimeBinder;
using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;

#nullable enable
namespace Meta.Editor.Extensions
{
  public class Cache<T>
  {
    protected ILogger logger;
    private readonly string specificObjectName;
    private string UniqueCacheID;

    private MetaCacheFile ActiveCache { get; set; }

    public T CachedObject { get; set; }

    public Cache(ILogger inLogger, string specificObjectName)
    {
      this.logger = inLogger;
      this.specificObjectName = specificObjectName;
      this.UniqueCacheID = Cache<T>.GenerateUniqueHash();
      this.SerializeObjects();
    }

    public void SerializeObjects()
    {
      foreach (FileSystemInfo file in new DirectoryInfo(App.CachePath).GetFiles("*.cache"))
      {
        MetaCacheFile metaCacheFile = JsonConvert.DeserializeObject<MetaCacheFile>(File.ReadAllText(file.FullName));
        if (metaCacheFile.Name == this.specificObjectName)
        {
          // ISSUE: reference to a compiler-generated field
          if (Cache<T>.\u003C\u003Eo__12.\u003C\u003Ep__1 == null)
          {
            // ISSUE: reference to a compiler-generated field
            Cache<T>.\u003C\u003Eo__12.\u003C\u003Ep__1 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof (Cache<T>), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
            {
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
            }));
          }
          // ISSUE: reference to a compiler-generated field
          Func<CallSite, object, bool> target1 = Cache<T>.\u003C\u003Eo__12.\u003C\u003Ep__1.Target;
          // ISSUE: reference to a compiler-generated field
          CallSite<Func<CallSite, object, bool>> p1 = Cache<T>.\u003C\u003Eo__12.\u003C\u003Ep__1;
          // ISSUE: reference to a compiler-generated field
          if (Cache<T>.\u003C\u003Eo__12.\u003C\u003Ep__0 == null)
          {
            // ISSUE: reference to a compiler-generated field
            Cache<T>.\u003C\u003Eo__12.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, object, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.NotEqual, typeof (Cache<T>), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
            {
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.Constant, (string) null)
            }));
          }
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          object obj1 = Cache<T>.\u003C\u003Eo__12.\u003C\u003Ep__0.Target((CallSite) Cache<T>.\u003C\u003Eo__12.\u003C\u003Ep__0, metaCacheFile.Object, (object) null);
          if (target1((CallSite) p1, obj1))
          {
            // ISSUE: reference to a compiler-generated field
            if (Cache<T>.\u003C\u003Eo__12.\u003C\u003Ep__3 == null)
            {
              // ISSUE: reference to a compiler-generated field
              Cache<T>.\u003C\u003Eo__12.\u003C\u003Ep__3 = CallSite<Func<CallSite, Type, object, Type, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "DeserializeObject", (IEnumerable<Type>) null, typeof (Cache<T>), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[3]
              {
                CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.IsStaticType, (string) null),
                CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
                CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
              }));
            }
            // ISSUE: reference to a compiler-generated field
            Func<CallSite, Type, object, Type, object> target2 = Cache<T>.\u003C\u003Eo__12.\u003C\u003Ep__3.Target;
            // ISSUE: reference to a compiler-generated field
            CallSite<Func<CallSite, Type, object, Type, object>> p3 = Cache<T>.\u003C\u003Eo__12.\u003C\u003Ep__3;
            Type type1 = typeof (JsonConvert);
            // ISSUE: reference to a compiler-generated field
            if (Cache<T>.\u003C\u003Eo__12.\u003C\u003Ep__2 == null)
            {
              // ISSUE: reference to a compiler-generated field
              Cache<T>.\u003C\u003Eo__12.\u003C\u003Ep__2 = CallSite<Func<CallSite, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "ToString", (IEnumerable<Type>) null, typeof (Cache<T>), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
              {
                CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
              }));
            }
            // ISSUE: reference to a compiler-generated field
            // ISSUE: reference to a compiler-generated field
            object obj2 = Cache<T>.\u003C\u003Eo__12.\u003C\u003Ep__2.Target((CallSite) Cache<T>.\u003C\u003Eo__12.\u003C\u003Ep__2, metaCacheFile.Object);
            Type type2 = typeof (T);
            object obj3 = target2((CallSite) p3, type1, obj2, type2);
            // ISSUE: reference to a compiler-generated field
            if (Cache<T>.\u003C\u003Eo__12.\u003C\u003Ep__4 == null)
            {
              // ISSUE: reference to a compiler-generated field
              Cache<T>.\u003C\u003Eo__12.\u003C\u003Ep__4 = CallSite<Func<CallSite, object, T>>.Create(Binder.Convert(CSharpBinderFlags.ConvertExplicit, typeof (T), typeof (Cache<T>)));
            }
            // ISSUE: reference to a compiler-generated field
            // ISSUE: reference to a compiler-generated field
            this.CachedObject = Cache<T>.\u003C\u003Eo__12.\u003C\u003Ep__4.Target((CallSite) Cache<T>.\u003C\u003Eo__12.\u003C\u003Ep__4, obj3);
          }
          this.ActiveCache = metaCacheFile;
          return;
        }
      }
      this.logger.LogWarning("Cache for {0} not found. Creating cache..", new object[1]
      {
        (object) Path.GetFileName(this.specificObjectName)
      });
      MetaCacheFile metaCacheFile1 = new MetaCacheFile()
      {
        Name = this.specificObjectName,
        UID = this.UniqueCacheID,
        Object = (object) default (T)
      };
      JsonSerializerSettings settings = new JsonSerializerSettings()
      {
        DefaultValueHandling = DefaultValueHandling.Ignore,
        MissingMemberHandling = MissingMemberHandling.Ignore,
        Formatting = Formatting.Indented,
        NullValueHandling = NullValueHandling.Ignore
      };
      string cachePath = App.CachePath;
      DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(10, 2);
      interpolatedStringHandler.AppendLiteral("[");
      interpolatedStringHandler.AppendFormatted(Path.GetFileName(this.specificObjectName));
      interpolatedStringHandler.AppendLiteral("][");
      interpolatedStringHandler.AppendFormatted(this.UniqueCacheID);
      interpolatedStringHandler.AppendLiteral("].cache");
      string stringAndClear = interpolatedStringHandler.ToStringAndClear();
      File.WriteAllText(Path.Combine(cachePath, stringAndClear), JsonConvert.SerializeObject((object) metaCacheFile1, settings));
      this.logger.Log("Created cache [{0}] file successfully", new object[1]
      {
        (object) this.UniqueCacheID
      });
      this.ActiveCache = metaCacheFile1;
      this.CachedObject = default (T);
    }

    public T Load()
    {
      OpenFileDialog openFileDialog1 = new OpenFileDialog();
      openFileDialog1.Filter = "(All supported formats)|*.cache";
      openFileDialog1.Title = "Open Cache File";
      openFileDialog1.Multiselect = false;
      OpenFileDialog openFileDialog2 = openFileDialog1;
      bool? nullable = openFileDialog2.ShowDialog();
      bool flag = true;
      if (nullable.GetValueOrDefault() == flag & nullable.HasValue)
      {
        MetaCacheFile metaCacheFile = JsonConvert.DeserializeObject<MetaCacheFile>(File.ReadAllText(openFileDialog2.FileName));
        if (metaCacheFile != null)
        {
          // ISSUE: reference to a compiler-generated field
          if (Cache<T>.\u003C\u003Eo__13.\u003C\u003Ep__1 == null)
          {
            // ISSUE: reference to a compiler-generated field
            Cache<T>.\u003C\u003Eo__13.\u003C\u003Ep__1 = CallSite<Func<CallSite, Type, object, Type, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "DeserializeObject", (IEnumerable<Type>) null, typeof (Cache<T>), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[3]
            {
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.IsStaticType, (string) null),
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
            }));
          }
          // ISSUE: reference to a compiler-generated field
          Func<CallSite, Type, object, Type, object> target = Cache<T>.\u003C\u003Eo__13.\u003C\u003Ep__1.Target;
          // ISSUE: reference to a compiler-generated field
          CallSite<Func<CallSite, Type, object, Type, object>> p1 = Cache<T>.\u003C\u003Eo__13.\u003C\u003Ep__1;
          Type type1 = typeof (JsonConvert);
          // ISSUE: reference to a compiler-generated field
          if (Cache<T>.\u003C\u003Eo__13.\u003C\u003Ep__0 == null)
          {
            // ISSUE: reference to a compiler-generated field
            Cache<T>.\u003C\u003Eo__13.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "ToString", (IEnumerable<Type>) null, typeof (Cache<T>), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
            {
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
            }));
          }
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          object obj1 = Cache<T>.\u003C\u003Eo__13.\u003C\u003Ep__0.Target((CallSite) Cache<T>.\u003C\u003Eo__13.\u003C\u003Ep__0, metaCacheFile.Object);
          Type type2 = typeof (T);
          object obj2 = target((CallSite) p1, type1, obj1, type2);
          // ISSUE: reference to a compiler-generated field
          if (Cache<T>.\u003C\u003Eo__13.\u003C\u003Ep__2 == null)
          {
            // ISSUE: reference to a compiler-generated field
            Cache<T>.\u003C\u003Eo__13.\u003C\u003Ep__2 = CallSite<Func<CallSite, object, T>>.Create(Binder.Convert(CSharpBinderFlags.ConvertExplicit, typeof (T), typeof (Cache<T>)));
          }
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          return Cache<T>.\u003C\u003Eo__13.\u003C\u003Ep__2.Target((CallSite) Cache<T>.\u003C\u003Eo__13.\u003C\u003Ep__2, obj2);
        }
      }
      return default (T);
    }

    public void Save()
    {
      if (this.ActiveCache == null)
        return;
      this.ActiveCache.Object = (object) this.CachedObject;
      string contents = JsonConvert.SerializeObject((object) this.ActiveCache, new JsonSerializerSettings()
      {
        DefaultValueHandling = DefaultValueHandling.Ignore,
        MissingMemberHandling = MissingMemberHandling.Ignore,
        Formatting = Formatting.Indented,
        NullValueHandling = NullValueHandling.Ignore
      });
      string cachePath = App.CachePath;
      DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(10, 2);
      interpolatedStringHandler.AppendLiteral("[");
      interpolatedStringHandler.AppendFormatted(Path.GetFileName(this.specificObjectName));
      interpolatedStringHandler.AppendLiteral("][");
      interpolatedStringHandler.AppendFormatted(this.ActiveCache.UID);
      interpolatedStringHandler.AppendLiteral("].cache");
      string stringAndClear = interpolatedStringHandler.ToStringAndClear();
      File.WriteAllText(Path.Combine(cachePath, stringAndClear), contents);
      this.logger.Log("Updated cache [{0}]", new object[1]
      {
        (object) this.UniqueCacheID
      });
    }

    public static string GenerateUniqueHash()
    {
      using (MD5 md5 = MD5.Create())
      {
        byte[] bytes = Encoding.ASCII.GetBytes(DateTime.Now.Ticks.ToString());
        byte[] hash = md5.ComputeHash(bytes);
        StringBuilder stringBuilder = new StringBuilder();
        for (int index = 0; index < hash.Length; ++index)
          stringBuilder.Append(hash[index].ToString("X2"));
        return stringBuilder.ToString();
      }
    }
  }
}
