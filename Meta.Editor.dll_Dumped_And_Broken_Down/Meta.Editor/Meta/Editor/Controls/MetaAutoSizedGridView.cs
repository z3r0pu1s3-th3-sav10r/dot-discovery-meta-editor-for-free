using System.Collections.ObjectModel;
using System.Windows.Controls;

#nullable enable
namespace Meta.Editor.Controls
{
  public class MetaAutoSizedGridView : GridView
  {
    protected override void PrepareItem(ListViewItem item)
    {
      foreach (GridViewColumn column in (Collection<GridViewColumn>) this.Columns)
      {
        if (double.IsNaN(column.Width))
          column.Width = column.ActualWidth;
        column.Width = double.NaN;
      }
      base.PrepareItem(item);
    }
  }
}
