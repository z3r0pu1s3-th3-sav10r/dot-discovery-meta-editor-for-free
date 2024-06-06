using Meta.Core;
using Meta.Core.Interfaces;
using Meta.Core.IO;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

#nullable enable
namespace Meta.Structures.Flatbuffers
{
  public sealed class FlatbufferSerializeQueue
  {
    private Queue<FlatbufferSerializeQueue.SerializationRequest> serializationQueue = new Queue<FlatbufferSerializeQueue.SerializationRequest>();
    private FlatbufferSerializeQueue.SerializationRequest currentRequest;
    private MetaSerializerCallback _callback;
    private MetaSerializerFailedCallback _failedCallback;

    private static string Flatc => Path.Combine(App.ThirdPartyPath, "flatc.exe");

    public FlatbufferSerializeQueue.SerializationRequest Active
    {
      get => this.currentRequest;
      set
      {
        if (value == this.currentRequest)
          return;
        this.currentRequest = value;
      }
    }

    public FlatbufferSerializeQueue(ILogger logger)
    {
    }

    public void Add(
      MetaAsset asset,
      FlatbufferSchema schema,
      EngineVersion engine,
      string json,
      string jsfb,
      MetaSerializerCallback callback = null,
      MetaSerializerFailedCallback failedCallback = null)
    {
      this.serializationQueue.Enqueue(new FlatbufferSerializeQueue.SerializationRequest(asset, schema, engine, json, jsfb, callback, failedCallback));
      this.ProcessNextFile();
    }

    private async void ProcessNextFile()
    {
      if (this.serializationQueue.Count <= 0)
        return;
      FlatbufferSerializeQueue.SerializationRequest request = this.serializationQueue.Dequeue();
      if (request != null)
      {
        bool flag = await this.InitializeSerialization(request);
        int num = flag ? 1 : 0;
        this.ProcessNextFile();
      }
      request = (FlatbufferSerializeQueue.SerializationRequest) null;
    }

    private string GetEngine(EngineVersion engine)
    {
      EngineVersion engineVersion = engine;
      return engineVersion == null || engineVersion != 1 ? Path.Combine(App.ThirdPartyPath, "flatc.exe") : Path.Combine(App.ThirdPartyPath, "flatcnu.exe");
    }

    private async Task<bool> InitializeSerialization(
      FlatbufferSerializeQueue.SerializationRequest request)
    {
      bool flag = await Task.Run<bool>((Func<bool>) (() =>
      {
        this.Active = request;
        string tempPath = Path.GetTempPath();
        DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(4, 1);
        interpolatedStringHandler.AppendFormatted<Guid>(Guid.NewGuid());
        interpolatedStringHandler.AppendLiteral(".fbs");
        string stringAndClear1 = interpolatedStringHandler.ToStringAndClear();
        string path = Path.Combine(tempPath, stringAndClear1);
        File.WriteAllBytes(path, request.Schema.schema);
        interpolatedStringHandler = new DefaultInterpolatedStringHandler(8, 2);
        interpolatedStringHandler.AppendLiteral("-b \"");
        interpolatedStringHandler.AppendFormatted(path);
        interpolatedStringHandler.AppendLiteral("\" \"");
        interpolatedStringHandler.AppendFormatted(request.JSON);
        interpolatedStringHandler.AppendLiteral("\"");
        string stringAndClear2 = interpolatedStringHandler.ToStringAndClear();
        try
        {
          Process process = Process.Start(new ProcessStartInfo(this.GetEngine(request.Engine), stringAndClear2)
          {
            CreateNoWindow = true,
            WorkingDirectory = App.CachePath
          });
          process.WaitForExit();
          if (process.ExitCode.Equals(0))
          {
            File.Move(App.CachePath + "\\" + request.Asset.NameWithoutExt + ".jsfb", request.JSFB, true);
            request._callback(this);
            return true;
          }
          request._failedCallback(this);
          return false;
        }
        finally
        {
          File.Delete(path);
          this.Active = (FlatbufferSerializeQueue.SerializationRequest) null;
        }
      }));
      return flag;
    }

    public class SerializationRequest
    {
      public MetaSerializerCallback _callback;
      public MetaSerializerFailedCallback _failedCallback;

      public MetaAsset Asset { get; }

      public FlatbufferSchema Schema { get; }

      public string JSON { get; }

      public string JSFB { get; }

      public EngineVersion Engine { get; }

      public SerializationRequest(
        MetaAsset asset,
        FlatbufferSchema schema,
        EngineVersion engine,
        string jSON,
        string jSFB,
        MetaSerializerCallback callback = null,
        MetaSerializerFailedCallback failedCallback = null)
      {
        this.Asset = asset;
        this.Schema = schema;
        this.Engine = engine;
        this.JSON = jSON;
        this.JSFB = jSFB;
        this._callback = callback;
        this._failedCallback = failedCallback;
      }
    }
  }
}
