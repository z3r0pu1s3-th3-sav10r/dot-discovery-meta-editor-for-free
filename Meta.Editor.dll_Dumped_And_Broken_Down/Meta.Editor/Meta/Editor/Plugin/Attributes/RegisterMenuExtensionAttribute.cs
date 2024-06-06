using System;

#nullable enable
namespace Meta.Editor.Plugin.Attributes
{
  [AttributeUsage(AttributeTargets.Assembly, AllowMultiple = true, Inherited = false)]
  public class RegisterMenuExtensionAttribute : Attribute
  {
    public Type MenuExtensionType { get; private set; }

    public RegisterMenuExtensionAttribute(Type type) => this.MenuExtensionType = type;
  }
}
