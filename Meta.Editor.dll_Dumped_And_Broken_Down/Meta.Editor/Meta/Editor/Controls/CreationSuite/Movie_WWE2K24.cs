#nullable enable
namespace Meta.Editor.Controls.CreationSuite
{
  public class Movie_WWE2K24
  {
    public uint id { get; set; }

    public string type { get; set; }

    public uint sdb_id { get; set; }

    public ulong bk2_path { get; set; }

    public ulong thumbnail_dds_path { get; set; }

    public enum Tron_Type
    {
      Unknown,
      Titantron,
      Banner,
      Stage,
      Apron,
      Barricade,
      Transition,
    }
  }
}
