#nullable enable
namespace Meta.Editor.Controls
{
  public sealed class JObjectCrowdSign : JObject
  {
    public JObjectCrowdSign(object Value, string name)
      : base(Value, name)
    {
    }

    public override string ToString() => string.Format("{0} {1}", this.Id, (object) this.Name);
  }
}
