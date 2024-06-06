using Meta.Structures.Flatbuffers.WWE2K23;
using System.Collections.ObjectModel;

#nullable enable
namespace Meta.Editor.Controls.CreationSuite
{
  public class WWE2K23_Generated_Character
  {
    public ObservableCollection<Meta.Structures.Flatbuffers.WWE2K23.CharacterMapping> CharacterMapping { get; set; }

    public FaceTextures Renders { get; set; }

    public MoviesTable Movie { get; set; }
  }
}
