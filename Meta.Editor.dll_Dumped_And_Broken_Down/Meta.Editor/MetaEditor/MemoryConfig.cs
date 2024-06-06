using FlatSharp.Attributes;
using System.Collections.Generic;

#nullable enable
namespace MetaEditor
{
  [FlatBufferTable]
  public class MemoryConfig
  {
    public long MaximumReach { get; set; }

    public Dictionary<string, int> Regions { get; set; }

    public Dictionary<string, string> AOB { get; set; }

    public Dictionary<string, int> ProfileOffsets { get; set; }

    public Dictionary<string, int> MotionOffsets { get; set; }

    public Dictionary<string, int> MoveOffsets { get; set; }
  }
}
