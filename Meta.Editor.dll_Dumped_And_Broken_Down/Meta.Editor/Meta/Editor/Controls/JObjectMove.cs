#nullable enable
namespace Meta.Editor.Controls
{
  public class JObjectMove : JObject
  {
    public uint ID { get; private set; }

    public override string ToString() => string.Format("{0}", (object) this.Name);

    public JObjectMove(object Value, string name, uint anim_id)
      : base(Value, name)
    {
      this.ID = anim_id;
    }
  }
}
