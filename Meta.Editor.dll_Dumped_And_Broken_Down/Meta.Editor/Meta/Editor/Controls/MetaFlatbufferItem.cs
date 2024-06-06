using System.Collections.ObjectModel;

#nullable enable
namespace Meta.Editor.Controls
{
  public class MetaFlatbufferItem
  {
    public bool IsVisible { get; set; }

    public int Index { get; set; }

    public int Pointer { get; set; }

    public bool IsExpanded { get; set; }

    public string Name { get; set; }

    public object Data { get; set; }

    public string Icon { get; set; } = "Folder";

    public string IconExpand { get; set; } = "FolderOpen";

    public MetaFlatbufferItem.ItemType IType { get; set; }

    public ObservableCollection<MetaFlatbufferItem> Children { get; set; }

    public enum ItemType
    {
      Folder,
      Root,
      Data,
    }
  }
}
