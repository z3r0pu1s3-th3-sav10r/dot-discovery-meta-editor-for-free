using System;

#nullable disable
namespace Meta.Editor.Controls.CreationSuite
{
  [AttributeUsage(AttributeTargets.Property)]
  public class AttireAttribute : Attribute
  {
    public AttireAttribute(int id) => this.id = id;

    public virtual int id { get; private set; }
  }
}
