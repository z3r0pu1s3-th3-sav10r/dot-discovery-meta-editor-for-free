#nullable enable
namespace Meta.Editor.Controls
{
  public class JObject
  {
    public object Id { get; private set; }

    public string Name { get; private set; }

    public override string ToString() => string.Format("{0}", (object) this.Name);

    public JObject(object Value, string name)
    {
      this.Id = Value;
      this.Name = name;
    }
  }
}
