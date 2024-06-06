using Meta.Structures.Flatbuffers.WWE2K24;
using System.Collections.ObjectModel;

#nullable enable
namespace Meta.Editor.Controls.CreationSuite
{
  public class WWE2K24_Generated_Character
  {
    public ObservableCollection<Meta.Structures.Flatbuffers.WWE2K24.CharacterMapping> CharacterMapping { get; set; }

    public FaceTextures Renders { get; set; }

    public ObservableCollection<Movie_WWE2K24> Movies { get; set; }
  }
}
