using PropertyTools.Wpf;
using System.ComponentModel;

#nullable enable
namespace Meta.Editor.Controls
{
  public class MetaPropertyGridOperator : PropertyGridOperator
  {
    protected virtual PropertyItem CreateCore(
      PropertyDescriptor pd,
      PropertyDescriptorCollection properties)
    {
      return base.CreateCore(pd, properties);
    }
  }
}
