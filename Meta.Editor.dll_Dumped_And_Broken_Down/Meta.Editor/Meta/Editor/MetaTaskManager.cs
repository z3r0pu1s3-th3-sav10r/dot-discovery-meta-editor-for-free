using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;

#nullable enable
namespace Meta.Editor
{
  public class MetaTaskManager : IDisposable
  {
    private readonly BlockingCollection<Task> _taskQ = new BlockingCollection<Task>();

    public MetaTaskManager(int workerCount)
    {
      for (int index = 0; index < workerCount; ++index)
        Task.Factory.StartNew(new Action(this.Consume), TaskCreationOptions.LongRunning);
    }

    public Task Enqueue(Action action, CancellationToken cancelToken = default (CancellationToken))
    {
      Task task = new Task(action, cancelToken);
      this._taskQ.Add(task);
      return task;
    }

    public Task<TResult> Enqueue<TResult>(Func<TResult> func, CancellationToken cancelToken = default (CancellationToken))
    {
      Task<TResult> task = new Task<TResult>(func, cancelToken);
      this._taskQ.Add((Task) task);
      return task;
    }

    private void Consume()
    {
      foreach (Task consuming in this._taskQ.GetConsumingEnumerable())
      {
        try
        {
          if (!consuming.IsCanceled)
            consuming.RunSynchronously();
        }
        catch (InvalidOperationException ex)
        {
        }
      }
    }

    public void Dispose() => this._taskQ.CompleteAdding();
  }
}
