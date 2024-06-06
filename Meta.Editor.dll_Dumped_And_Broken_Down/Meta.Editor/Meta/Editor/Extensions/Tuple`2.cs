#nullable enable
namespace Meta.Editor.Extensions
{
  public class Tuple<T, T2> : Tuple<T>
  {
    public Tuple(T first, T2 second)
      : base(first)
    {
      this.Second = second;
    }

    public T2 Second { get; set; }
  }
}
