using System;

#nullable enable
namespace Meta.Editor.Plugin.Attributes
{
  [AttributeUsage(AttributeTargets.Assembly, AllowMultiple = false)]
  public class PluginAuthorAttribute : Attribute
  {
    public string Author { get; private set; }

    public PluginAuthorAttribute(string author) => this.Author = author;
  }
}
