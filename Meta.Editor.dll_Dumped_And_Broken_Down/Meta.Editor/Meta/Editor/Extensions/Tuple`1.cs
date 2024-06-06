#nullable enable
namespace Meta.Editor.Extensions
{
  public class Tuple<T>
  {
    public Tuple(T first) => this.First = first;

    public T First { get; set; }
  }
}
