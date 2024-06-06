using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

#nullable disable
namespace Meta.Editor.Properties
{
  [GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
  [DebuggerNonUserCode]
  [CompilerGenerated]
  internal class Resources
  {
    private static ResourceManager resourceMan;
    private static CultureInfo resourceCulture;

    internal Resources()
    {
    }

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    internal static ResourceManager ResourceManager
    {
      get
      {
        if (Meta.Editor.Properties.Resources.resourceMan == null)
          Meta.Editor.Properties.Resources.resourceMan = new ResourceManager("Meta.Editor.Properties.Resources", typeof (Meta.Editor.Properties.Resources).Assembly);
        return Meta.Editor.Properties.Resources.resourceMan;
      }
    }

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    internal static CultureInfo Culture
    {
      get => Meta.Editor.Properties.Resources.resourceCulture;
      set => Meta.Editor.Properties.Resources.resourceCulture = value;
    }
  }
}
