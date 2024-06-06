using Meta.Core.IO;
using Meta.Editor.Converters;
using Meta.WWE2K23;
using MetaEditor;
using Microsoft.CSharp.RuntimeBinder;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;

#nullable enable
namespace Meta.Editor.IO.WWE2K23
{
  public class ProfileRender : NativeReader
  {
    private Info activeProfile;

    public Info Profile => this.activeProfile;

    public ProfileRender(Stream inStream, MetaGame game)
      : base(inStream)
    {
      this.Parse(game);
    }

    private void Parse(MetaGame game)
    {
      this.activeProfile = new Info();
      Info activeProfile1 = this.activeProfile;
      // ISSUE: reference to a compiler-generated field
      if (ProfileRender.\u003C\u003Eo__4.\u003C\u003Ep__0 == null)
      {
        // ISSUE: reference to a compiler-generated field
        ProfileRender.\u003C\u003Eo__4.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, ushort>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (ushort), typeof (ProfileRender)));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      int num1 = (int) ProfileRender.\u003C\u003Eo__4.\u003C\u003Ep__0.Target((CallSite) ProfileRender.\u003C\u003Eo__4.\u003C\u003Ep__0, ProfileExtensions.ReadMemory<ushort>((NativeReader) this, game.Memory.ProfileOffsets, "Wrestler_ID"));
      activeProfile1.wrestler_id = (ushort) num1;
      Info activeProfile2 = this.activeProfile;
      // ISSUE: reference to a compiler-generated field
      if (ProfileRender.\u003C\u003Eo__4.\u003C\u003Ep__1 == null)
      {
        // ISSUE: reference to a compiler-generated field
        ProfileRender.\u003C\u003Eo__4.\u003C\u003Ep__1 = CallSite<Func<CallSite, object, ushort>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (ushort), typeof (ProfileRender)));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      int num2 = (int) ProfileRender.\u003C\u003Eo__4.\u003C\u003Ep__1.Target((CallSite) ProfileRender.\u003C\u003Eo__4.\u003C\u003Ep__1, ProfileExtensions.ReadMemory<ushort>((NativeReader) this, game.Memory.ProfileOffsets, "Slot_ID"));
      activeProfile2.slot_id = (ushort) num2;
      Info activeProfile3 = this.activeProfile;
      // ISSUE: reference to a compiler-generated field
      if (ProfileRender.\u003C\u003Eo__4.\u003C\u003Ep__2 == null)
      {
        // ISSUE: reference to a compiler-generated field
        ProfileRender.\u003C\u003Eo__4.\u003C\u003Ep__2 = CallSite<Func<CallSite, object, ushort>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (ushort), typeof (ProfileRender)));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      int num3 = (int) ProfileRender.\u003C\u003Eo__4.\u003C\u003Ep__2.Target((CallSite) ProfileRender.\u003C\u003Eo__4.\u003C\u003Ep__2, ProfileExtensions.ReadMemory<ushort>((NativeReader) this, game.Memory.ProfileOffsets, "Wrestler_ID_2"));
      activeProfile3.wrestler_id_2 = (ushort) num3;
      Info activeProfile4 = this.activeProfile;
      // ISSUE: reference to a compiler-generated field
      if (ProfileRender.\u003C\u003Eo__4.\u003C\u003Ep__3 == null)
      {
        // ISSUE: reference to a compiler-generated field
        ProfileRender.\u003C\u003Eo__4.\u003C\u003Ep__3 = CallSite<Func<CallSite, object, uint>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (uint), typeof (ProfileRender)));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      int num4 = (int) ProfileRender.\u003C\u003Eo__4.\u003C\u003Ep__3.Target((CallSite) ProfileRender.\u003C\u003Eo__4.\u003C\u003Ep__3, ProfileExtensions.ReadMemory<uint>((NativeReader) this, game.Memory.ProfileOffsets, "Full_Name"));
      activeProfile4.fullname_sdb_id = (uint) num4;
      Info activeProfile5 = this.activeProfile;
      // ISSUE: reference to a compiler-generated field
      if (ProfileRender.\u003C\u003Eo__4.\u003C\u003Ep__4 == null)
      {
        // ISSUE: reference to a compiler-generated field
        ProfileRender.\u003C\u003Eo__4.\u003C\u003Ep__4 = CallSite<Func<CallSite, object, uint>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (uint), typeof (ProfileRender)));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      int num5 = (int) ProfileRender.\u003C\u003Eo__4.\u003C\u003Ep__4.Target((CallSite) ProfileRender.\u003C\u003Eo__4.\u003C\u003Ep__4, ProfileExtensions.ReadMemory<uint>((NativeReader) this, game.Memory.ProfileOffsets, "Nickname"));
      activeProfile5.nickname_sdb_id = (uint) num5;
      Info activeProfile6 = this.activeProfile;
      // ISSUE: reference to a compiler-generated field
      if (ProfileRender.\u003C\u003Eo__4.\u003C\u003Ep__5 == null)
      {
        // ISSUE: reference to a compiler-generated field
        ProfileRender.\u003C\u003Eo__4.\u003C\u003Ep__5 = CallSite<Func<CallSite, object, uint>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (uint), typeof (ProfileRender)));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      int num6 = (int) ProfileRender.\u003C\u003Eo__4.\u003C\u003Ep__5.Target((CallSite) ProfileRender.\u003C\u003Eo__4.\u003C\u003Ep__5, ProfileExtensions.ReadMemory<uint>((NativeReader) this, game.Memory.ProfileOffsets, "Social_media"));
      activeProfile6.socialmedia_sdb_id = (uint) num6;
      Info activeProfile7 = this.activeProfile;
      // ISSUE: reference to a compiler-generated field
      if (ProfileRender.\u003C\u003Eo__4.\u003C\u003Ep__6 == null)
      {
        // ISSUE: reference to a compiler-generated field
        ProfileRender.\u003C\u003Eo__4.\u003C\u003Ep__6 = CallSite<Func<CallSite, object, byte>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (byte), typeof (ProfileRender)));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      int num7 = (int) ProfileRender.\u003C\u003Eo__4.\u003C\u003Ep__6.Target((CallSite) ProfileRender.\u003C\u003Eo__4.\u003C\u003Ep__6, ProfileExtensions.ReadMemory<byte>((NativeReader) this, game.Memory.ProfileOffsets, "Unlock_Flag"));
      activeProfile7.playability = (byte) num7;
      Info activeProfile8 = this.activeProfile;
      // ISSUE: reference to a compiler-generated field
      if (ProfileRender.\u003C\u003Eo__4.\u003C\u003Ep__7 == null)
      {
        // ISSUE: reference to a compiler-generated field
        ProfileRender.\u003C\u003Eo__4.\u003C\u003Ep__7 = CallSite<Func<CallSite, object, byte>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (byte), typeof (ProfileRender)));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      int num8 = (int) ProfileRender.\u003C\u003Eo__4.\u003C\u003Ep__7.Target((CallSite) ProfileRender.\u003C\u003Eo__4.\u003C\u003Ep__7, ProfileExtensions.ReadMemory<byte>((NativeReader) this, game.Memory.ProfileOffsets, "Menu_Flag"));
      activeProfile8.menu_location = (byte) num8;
      this.activeProfile.additional_attire_names = new List<uint>();
      Info activeProfile9 = this.activeProfile;
      // ISSUE: reference to a compiler-generated field
      if (ProfileRender.\u003C\u003Eo__4.\u003C\u003Ep__8 == null)
      {
        // ISSUE: reference to a compiler-generated field
        ProfileRender.\u003C\u003Eo__4.\u003C\u003Ep__8 = CallSite<Func<CallSite, object, byte>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (byte), typeof (ProfileRender)));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      int num9 = (int) ProfileRender.\u003C\u003Eo__4.\u003C\u003Ep__8.Target((CallSite) ProfileRender.\u003C\u003Eo__4.\u003C\u003Ep__8, ProfileExtensions.ReadMemory<byte>((NativeReader) this, game.Memory.ProfileOffsets, "Gender"));
      activeProfile9.gender = (byte) num9;
      Info activeProfile10 = this.activeProfile;
      // ISSUE: reference to a compiler-generated field
      if (ProfileRender.\u003C\u003Eo__4.\u003C\u003Ep__9 == null)
      {
        // ISSUE: reference to a compiler-generated field
        ProfileRender.\u003C\u003Eo__4.\u003C\u003Ep__9 = CallSite<Func<CallSite, object, ushort>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (ushort), typeof (ProfileRender)));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      int num10 = (int) ProfileRender.\u003C\u003Eo__4.\u003C\u003Ep__9.Target((CallSite) ProfileRender.\u003C\u003Eo__4.\u003C\u003Ep__9, ProfileExtensions.ReadMemory<ushort>((NativeReader) this, game.Memory.ProfileOffsets, "Weight"));
      activeProfile10.weight = (ushort) num10;
      Info activeProfile11 = this.activeProfile;
      // ISSUE: reference to a compiler-generated field
      if (ProfileRender.\u003C\u003Eo__4.\u003C\u003Ep__10 == null)
      {
        // ISSUE: reference to a compiler-generated field
        ProfileRender.\u003C\u003Eo__4.\u003C\u003Ep__10 = CallSite<Func<CallSite, object, byte>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (byte), typeof (ProfileRender)));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      int num11 = (int) ProfileRender.\u003C\u003Eo__4.\u003C\u003Ep__10.Target((CallSite) ProfileRender.\u003C\u003Eo__4.\u003C\u003Ep__10, ProfileExtensions.ReadMemory<byte>((NativeReader) this, game.Memory.ProfileOffsets, "Weight_Class"));
      activeProfile11.weight_class = (byte) num11;
      Info activeProfile12 = this.activeProfile;
      // ISSUE: reference to a compiler-generated field
      if (ProfileRender.\u003C\u003Eo__4.\u003C\u003Ep__11 == null)
      {
        // ISSUE: reference to a compiler-generated field
        ProfileRender.\u003C\u003Eo__4.\u003C\u003Ep__11 = CallSite<Func<CallSite, object, byte>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (byte), typeof (ProfileRender)));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      int num12 = (int) ProfileRender.\u003C\u003Eo__4.\u003C\u003Ep__11.Target((CallSite) ProfileRender.\u003C\u003Eo__4.\u003C\u003Ep__11, ProfileExtensions.ReadMemory<byte>((NativeReader) this, game.Memory.ProfileOffsets, "Crowd_Balance"));
      activeProfile12.crowd_balance = (byte) num12;
      Info activeProfile13 = this.activeProfile;
      // ISSUE: reference to a compiler-generated field
      if (ProfileRender.\u003C\u003Eo__4.\u003C\u003Ep__12 == null)
      {
        // ISSUE: reference to a compiler-generated field
        ProfileRender.\u003C\u003Eo__4.\u003C\u003Ep__12 = CallSite<Func<CallSite, object, byte>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (byte), typeof (ProfileRender)));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      int num13 = (int) ProfileRender.\u003C\u003Eo__4.\u003C\u003Ep__12.Target((CallSite) ProfileRender.\u003C\u003Eo__4.\u003C\u003Ep__12, ProfileExtensions.ReadMemory<byte>((NativeReader) this, game.Memory.ProfileOffsets, "Crowd_Reaction"));
      activeProfile13.crowd_reaction = (byte) num13;
      Info activeProfile14 = this.activeProfile;
      // ISSUE: reference to a compiler-generated field
      if (ProfileRender.\u003C\u003Eo__4.\u003C\u003Ep__13 == null)
      {
        // ISSUE: reference to a compiler-generated field
        ProfileRender.\u003C\u003Eo__4.\u003C\u003Ep__13 = CallSite<Func<CallSite, object, List<uint>>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (List<uint>), typeof (ProfileRender)));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      List<uint> uintList = ProfileRender.\u003C\u003Eo__4.\u003C\u003Ep__13.Target((CallSite) ProfileRender.\u003C\u003Eo__4.\u003C\u003Ep__13, ProfileExtensions.ReadMemoryArray<List<uint>>((NativeReader) this, game.Memory.ProfileOffsets, "Crowd_Signs", 40));
      activeProfile14.crowd_signs = uintList;
      Info activeProfile15 = this.activeProfile;
      // ISSUE: reference to a compiler-generated field
      if (ProfileRender.\u003C\u003Eo__4.\u003C\u003Ep__14 == null)
      {
        // ISSUE: reference to a compiler-generated field
        ProfileRender.\u003C\u003Eo__4.\u003C\u003Ep__14 = CallSite<Func<CallSite, object, List<byte>>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (List<byte>), typeof (ProfileRender)));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      List<byte> byteList1 = ProfileRender.\u003C\u003Eo__4.\u003C\u003Ep__14.Target((CallSite) ProfileRender.\u003C\u003Eo__4.\u003C\u003Ep__14, ProfileExtensions.ReadMemoryArray<List<byte>>((NativeReader) this, game.Memory.ProfileOffsets, "Ai_Attributes", 27));
      activeProfile15.ai_attributes = byteList1;
      Info activeProfile16 = this.activeProfile;
      // ISSUE: reference to a compiler-generated field
      if (ProfileRender.\u003C\u003Eo__4.\u003C\u003Ep__15 == null)
      {
        // ISSUE: reference to a compiler-generated field
        ProfileRender.\u003C\u003Eo__4.\u003C\u003Ep__15 = CallSite<Func<CallSite, object, List<byte>>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (List<byte>), typeof (ProfileRender)));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      List<byte> byteList2 = ProfileRender.\u003C\u003Eo__4.\u003C\u003Ep__15.Target((CallSite) ProfileRender.\u003C\u003Eo__4.\u003C\u003Ep__15, ProfileExtensions.ReadMemoryArray<List<byte>>((NativeReader) this, game.Memory.ProfileOffsets, "Attributes", 24));
      activeProfile16.attributes = byteList2;
      Info activeProfile17 = this.activeProfile;
      // ISSUE: reference to a compiler-generated field
      if (ProfileRender.\u003C\u003Eo__4.\u003C\u003Ep__16 == null)
      {
        // ISSUE: reference to a compiler-generated field
        ProfileRender.\u003C\u003Eo__4.\u003C\u003Ep__16 = CallSite<Func<CallSite, object, List<byte>>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (List<byte>), typeof (ProfileRender)));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      List<byte> byteList3 = ProfileRender.\u003C\u003Eo__4.\u003C\u003Ep__16.Target((CallSite) ProfileRender.\u003C\u003Eo__4.\u003C\u003Ep__16, ProfileExtensions.ReadMemoryArray<List<byte>>((NativeReader) this, game.Memory.ProfileOffsets, "Hit_Point_Ratio", 4));
      activeProfile17.hit_point = byteList3;
      Info activeProfile18 = this.activeProfile;
      // ISSUE: reference to a compiler-generated field
      if (ProfileRender.\u003C\u003Eo__4.\u003C\u003Ep__17 == null)
      {
        // ISSUE: reference to a compiler-generated field
        ProfileRender.\u003C\u003Eo__4.\u003C\u003Ep__17 = CallSite<Func<CallSite, object, List<byte>>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (List<byte>), typeof (ProfileRender)));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      List<byte> byteList4 = ProfileRender.\u003C\u003Eo__4.\u003C\u003Ep__17.Target((CallSite) ProfileRender.\u003C\u003Eo__4.\u003C\u003Ep__17, ProfileExtensions.ReadMemoryArray<List<byte>>((NativeReader) this, game.Memory.ProfileOffsets, "Hit_Point_Ratio", 6));
      activeProfile18.personality_traits = byteList4;
      Info activeProfile19 = this.activeProfile;
      // ISSUE: reference to a compiler-generated field
      if (ProfileRender.\u003C\u003Eo__4.\u003C\u003Ep__18 == null)
      {
        // ISSUE: reference to a compiler-generated field
        ProfileRender.\u003C\u003Eo__4.\u003C\u003Ep__18 = CallSite<Func<CallSite, object, uint>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (uint), typeof (ProfileRender)));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      int num14 = (int) ProfileRender.\u003C\u003Eo__4.\u003C\u003Ep__18.Target((CallSite) ProfileRender.\u003C\u003Eo__4.\u003C\u003Ep__18, ProfileExtensions.ReadMemory<uint>((NativeReader) this, game.Memory.ProfileOffsets, "Commentary_ID"));
      activeProfile19.commentary_id = (uint) num14;
      Info activeProfile20 = this.activeProfile;
      // ISSUE: reference to a compiler-generated field
      if (ProfileRender.\u003C\u003Eo__4.\u003C\u003Ep__19 == null)
      {
        // ISSUE: reference to a compiler-generated field
        ProfileRender.\u003C\u003Eo__4.\u003C\u003Ep__19 = CallSite<Func<CallSite, object, uint>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (uint), typeof (ProfileRender)));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      int num15 = (int) ProfileRender.\u003C\u003Eo__4.\u003C\u003Ep__19.Target((CallSite) ProfileRender.\u003C\u003Eo__4.\u003C\u003Ep__19, ProfileExtensions.ReadMemory<uint>((NativeReader) this, game.Memory.ProfileOffsets, "Ring_Announcer_ID"));
      activeProfile20.announcer_id = (uint) num15;
      Info activeProfile21 = this.activeProfile;
      // ISSUE: reference to a compiler-generated field
      if (ProfileRender.\u003C\u003Eo__4.\u003C\u003Ep__20 == null)
      {
        // ISSUE: reference to a compiler-generated field
        ProfileRender.\u003C\u003Eo__4.\u003C\u003Ep__20 = CallSite<Func<CallSite, object, uint>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (uint), typeof (ProfileRender)));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      int num16 = (int) ProfileRender.\u003C\u003Eo__4.\u003C\u003Ep__20.Target((CallSite) ProfileRender.\u003C\u003Eo__4.\u003C\u003Ep__20, ProfileExtensions.ReadMemory<uint>((NativeReader) this, game.Memory.ProfileOffsets, "Hometown"));
      activeProfile21.location_callname = (uint) num16;
      Info activeProfile22 = this.activeProfile;
      // ISSUE: reference to a compiler-generated field
      if (ProfileRender.\u003C\u003Eo__4.\u003C\u003Ep__21 == null)
      {
        // ISSUE: reference to a compiler-generated field
        ProfileRender.\u003C\u003Eo__4.\u003C\u003Ep__21 = CallSite<Func<CallSite, object, byte>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (byte), typeof (ProfileRender)));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      int num17 = (int) ProfileRender.\u003C\u003Eo__4.\u003C\u003Ep__21.Target((CallSite) ProfileRender.\u003C\u003Eo__4.\u003C\u003Ep__21, ProfileExtensions.ReadMemory<byte>((NativeReader) this, game.Memory.ProfileOffsets, "Payback_1_Flag"));
      activeProfile22.payback_01 = (byte) num17;
      Info activeProfile23 = this.activeProfile;
      // ISSUE: reference to a compiler-generated field
      if (ProfileRender.\u003C\u003Eo__4.\u003C\u003Ep__22 == null)
      {
        // ISSUE: reference to a compiler-generated field
        ProfileRender.\u003C\u003Eo__4.\u003C\u003Ep__22 = CallSite<Func<CallSite, object, byte>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (byte), typeof (ProfileRender)));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      int num18 = (int) ProfileRender.\u003C\u003Eo__4.\u003C\u003Ep__22.Target((CallSite) ProfileRender.\u003C\u003Eo__4.\u003C\u003Ep__22, ProfileExtensions.ReadMemory<byte>((NativeReader) this, game.Memory.ProfileOffsets, "Payback_2_Flag"));
      activeProfile23.payback_02 = (byte) num18;
      Info activeProfile24 = this.activeProfile;
      // ISSUE: reference to a compiler-generated field
      if (ProfileRender.\u003C\u003Eo__4.\u003C\u003Ep__24 == null)
      {
        // ISSUE: reference to a compiler-generated field
        ProfileRender.\u003C\u003Eo__4.\u003C\u003Ep__24 = CallSite<Func<CallSite, object, double>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (double), typeof (ProfileRender)));
      }
      // ISSUE: reference to a compiler-generated field
      Func<CallSite, object, double> target = ProfileRender.\u003C\u003Eo__4.\u003C\u003Ep__24.Target;
      // ISSUE: reference to a compiler-generated field
      CallSite<Func<CallSite, object, double>> p24 = ProfileRender.\u003C\u003Eo__4.\u003C\u003Ep__24;
      // ISSUE: reference to a compiler-generated field
      if (ProfileRender.\u003C\u003Eo__4.\u003C\u003Ep__23 == null)
      {
        // ISSUE: reference to a compiler-generated field
        ProfileRender.\u003C\u003Eo__4.\u003C\u003Ep__23 = CallSite<Func<CallSite, Type, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "ConvertValueToHeight", (IEnumerable<Type>) null, typeof (ProfileRender), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.IsStaticType, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj = ProfileRender.\u003C\u003Eo__4.\u003C\u003Ep__23.Target((CallSite) ProfileRender.\u003C\u003Eo__4.\u003C\u003Ep__23, typeof (HeightConverter), ProfileExtensions.ReadMemory<ushort>((NativeReader) this, game.Memory.ProfileOffsets, "Height"));
      double num19 = target((CallSite) p24, obj);
      activeProfile24.height = num19;
    }
  }
}
