using System;

#nullable enable
namespace Meta.Editor.Controls.CreationSuite
{
  [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
  internal sealed class DefaultIndexAttribute : Attribute
  {
    public string DefaultSelectedIndex { get; }

    public DefaultIndexAttribute(string defaultSelectedIndex)
    {
      this.DefaultSelectedIndex = defaultSelectedIndex;
    }
  }
}
