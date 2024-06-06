#nullable disable
namespace Meta.Editor.Extensions
{
  public abstract class OptionsExtension
  {
    public virtual void Load()
    {
    }

    public virtual bool Validate() => true;

    public virtual void Save()
    {
    }
  }
}
