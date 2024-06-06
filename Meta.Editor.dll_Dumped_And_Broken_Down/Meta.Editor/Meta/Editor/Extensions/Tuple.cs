#nullable enable
namespace Meta.Editor.Extensions
{
  public static class Tuple
  {
    public static Tuple<T1> New<T1>(T1 t1) => new Tuple<T1>(t1);

    public static Tuple<T1, T2> New<T1, T2>(T1 t1, T2 t2) => new Tuple<T1, T2>(t1, t2);
  }
}
