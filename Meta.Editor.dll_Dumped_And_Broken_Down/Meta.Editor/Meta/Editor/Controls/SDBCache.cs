using System.Collections.ObjectModel;

#nullable enable
namespace Meta.Editor.Controls
{
  public class SDBCache
  {
    public string File { get; set; }

    public ObservableCollection<SDBAsset> Database { get; set; }
  }
}
