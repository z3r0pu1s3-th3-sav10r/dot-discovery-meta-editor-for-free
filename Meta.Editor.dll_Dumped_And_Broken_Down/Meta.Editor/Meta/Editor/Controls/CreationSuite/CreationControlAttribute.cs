using Meta.Core;
using System;

#nullable enable
namespace Meta.Editor.Controls.CreationSuite
{
  [AttributeUsage(AttributeTargets.All)]
  public class CreationControlAttribute : Attribute
  {
    public CreationControlAttribute(string id, ProfileType profileType)
    {
      this.id = id;
      this.profile = profileType;
    }

    public virtual string id { get; private set; }

    public virtual ProfileType profile { get; private set; }
  }
}
