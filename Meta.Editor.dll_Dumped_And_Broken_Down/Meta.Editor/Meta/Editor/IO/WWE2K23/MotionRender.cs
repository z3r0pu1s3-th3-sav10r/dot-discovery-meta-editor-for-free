using Meta.Core.IO;
using Meta.WWE2K23;
using MetaEditor;
using System.IO;

#nullable enable
namespace Meta.Editor.IO.WWE2K23
{
  public class MotionRender : NativeReader
  {
    private Motion activeMotion;

    public Motion Motion => this.activeMotion;

    public MotionRender(Stream inStream, MetaGame game)
      : base(inStream)
    {
      this.Parse(game);
    }

    private void Parse(MetaGame game)
    {
      this.activeMotion = new Motion();
      this.Position = (long) game.Memory.MotionOffsets["Movie_Display"];
      this.activeMotion.movies_enabled = this.ReadByte();
      this.Position = (long) game.Memory.MotionOffsets["Entrance_Music"];
      this.activeMotion.entrance_music = this.ReadUInt((Endian) 0);
      this.Position = (long) game.Memory.MotionOffsets["Titantron_Movie"];
      this.activeMotion.movie_titantron = this.ReadUInt((Endian) 0);
      this.Position = (long) game.Memory.MotionOffsets["Unknown_Movie"];
      this.activeMotion.movie_unknown = this.ReadUInt((Endian) 0);
      this.Position = (long) game.Memory.MotionOffsets["Banner_Movie"];
      this.activeMotion.movie_banner = this.ReadUInt((Endian) 0);
      this.Position = (long) game.Memory.MotionOffsets["Stage_Ramp_Movie"];
      this.activeMotion.movie_stage_ramp = this.ReadUInt((Endian) 0);
      this.Position = (long) game.Memory.MotionOffsets["Arena_Effect"];
      this.activeMotion.screen_effect = this.ReadByte();
      this.Position = (long) game.Memory.MotionOffsets["Light_Show"];
      this.activeMotion.light_show = this.ReadUInt((Endian) 0);
      this.Position = (long) game.Memory.MotionOffsets["Apron_Ring_Post_Movie"];
      this.activeMotion.movie_apron_ringpost = this.ReadUInt((Endian) 0);
      this.Position = (long) game.Memory.MotionOffsets["Barricade_Movie"];
      this.activeMotion.movie_barricade = this.ReadUInt((Endian) 0);
      this.Position = (long) game.Memory.MotionOffsets["Victory_Motion_Face"];
      this.activeMotion.victory_motion_face = this.ReadUInt((Endian) 0);
      this.Position = (long) game.Memory.MotionOffsets["Victory_Motion_Heel"];
      this.activeMotion.victory_motion_heel = this.ReadUInt((Endian) 0);
      this.Position = (long) game.Memory.MotionOffsets["Victory_Title_Motion_Face"];
      this.activeMotion.victory_title_motion_face = this.ReadUInt((Endian) 0);
      this.Position = (long) game.Memory.MotionOffsets["Victory_Title_Motion_Heel"];
      this.activeMotion.victory_title_motion_heel = this.ReadUInt((Endian) 0);
      this.Position = (long) game.Memory.MotionOffsets["Title_Motion"];
      this.activeMotion.entrance_title_motion = this.ReadUInt((Endian) 0);
      this.Position = (long) game.Memory.MotionOffsets["MITB_Motion"];
      this.activeMotion.entrance_MITB_motion = this.ReadUInt((Endian) 0);
      this.Position = (long) game.Memory.MotionOffsets["Motion_Intro"];
      this.activeMotion.entrance_motion_intro = this.ReadUInt((Endian) 0);
      this.Position = (long) game.Memory.MotionOffsets["Motion_Stage"];
      this.activeMotion.entrance_motion_stage = this.ReadUInt((Endian) 0);
      this.Position = (long) game.Memory.MotionOffsets["Motion_Ramp"];
      this.activeMotion.entrance_motion_ramp = this.ReadUInt((Endian) 0);
      this.Position = (long) game.Memory.MotionOffsets["Motion_Ring_In"];
      this.activeMotion.entrance_motion_ring_in = this.ReadUInt((Endian) 0);
      this.Position = (long) game.Memory.MotionOffsets["Motion_Ring"];
      this.activeMotion.entrance_motion_ring = this.ReadUInt((Endian) 0);
    }
  }
}
