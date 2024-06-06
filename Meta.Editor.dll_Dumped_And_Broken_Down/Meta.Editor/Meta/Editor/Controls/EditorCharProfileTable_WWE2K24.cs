using Meta.Core;
using Meta.Core.Attributes;
using Meta.Core.Interfaces;
using Meta.Editor.Converters;
using Meta.Editor.Windows;
using Meta.Structures.Flatbuffers;
using Meta.Structures.Flatbuffers.WWE2K24;
using Meta.WWE2K23;
using MetaEditor;
using Microsoft.CSharp.RuntimeBinder;
using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;

#nullable enable
namespace Meta.Editor.Controls
{
  [EditorType("Prof")]
  [GameVersion("WWE 2K24")]
  public class EditorCharProfileTable_WWE2K24 : EditorCharProfileTable
  {
    public EditorCharProfileTable_WWE2K24(
      ILogger inLogger,
      FlatbufferSchema _schema,
      string filename)
      : base(inLogger, _schema, filename)
    {
    }

    public override MetaFlatbufferItem CreateRootNode()
    {
      CharProfileTableArchive profileTableArchive = this.Asset.Deserialize<CharProfileTableArchive>();
      MetaFlatbufferItem rootNode = new MetaFlatbufferItem()
      {
        Name = "root"
      };
      rootNode.Children = new ObservableCollection<MetaFlatbufferItem>();
      MetaFlatbufferItem metaFlatbufferItem1 = new MetaFlatbufferItem()
      {
        Name = "characters"
      };
      metaFlatbufferItem1.Children = new ObservableCollection<MetaFlatbufferItem>();
      rootNode.Children.Add(metaFlatbufferItem1);
      int num = 0;
      foreach (RosterTable rosterTable in profileTableArchive.table)
      {
        MetaFlatbufferItem metaFlatbufferItem2 = new MetaFlatbufferItem()
        {
          Index = num,
          Name = string.Format("Wrestler ID: {0} | Slot ID: {1}", (object) rosterTable.wrestler_id, (object) rosterTable.slot_id),
          Pointer = (int) rosterTable.slot_id,
          Data = (object) rosterTable,
          Icon = "CircleSmall"
        };
        metaFlatbufferItem1.Children.Add(metaFlatbufferItem2);
        ++num;
      }
      IOrderedEnumerable<MetaFlatbufferItem> collection = metaFlatbufferItem1.Children.OrderBy<MetaFlatbufferItem, int>((Func<MetaFlatbufferItem, int>) (ite => ite.Pointer));
      metaFlatbufferItem1.Children = new ObservableCollection<MetaFlatbufferItem>((IEnumerable<MetaFlatbufferItem>) collection);
      metaFlatbufferItem1.IsExpanded = true;
      rootNode.IsExpanded = true;
      return rootNode;
    }

    protected override void PrimeMemory_Click(object sender, RoutedEventArgs e)
    {
      if (App.GameRunning)
      {
        MetaTaskWindow.Show("Priming Memory", "This may take a minute - do not exit this window", (MetaTaskCallback) (async task =>
        {
          this.CharacterProfileOffsets = (ICollection<long>) null;
          IEnumerable<long> ProfileRegionSearchTable = App.MemoryManager.AoBScanAsync(App.CurrentGame.Memory.AOB["Profile"], App.CurrentGame.Exe, App.CurrentGame.Memory.MaximumReach);
          int TotalRegions = ProfileRegionSearchTable.Count<long>();
          if (TotalRegions > 0)
          {
            List<long> ProfileCleanTable = ProfileRegionSearchTable.ToList<long>();
            for (int i = 0; i < ProfileCleanTable.Count; ++i)
            {
              ProfileCleanTable[i] -= (long) (App.CurrentGame.Memory.Regions["ProfileSize"] * 100);
              this.logger.Log("Found {0} [Character] location", new object[1]
              {
                (object) ProfileCleanTable[i]
              });
            }
            this.CharacterProfileOffsets = (ICollection<long>) ProfileCleanTable;
            this.logger.Log("Found {0} total [Character] memory locations", new object[1]
            {
              (object) TotalRegions
            });
            ProfileCleanTable = (List<long>) null;
          }
          long BaseAddress = 0;
          IEnumerable<long> MotionRegionSearchTable = App.MemoryManager.AoBScanAsync(App.CurrentGame.Memory.AOB["UniverseMotion"], App.CurrentGame.Exe, App.CurrentGame.Memory.MaximumReach, ref BaseAddress);
          TotalRegions = MotionRegionSearchTable.Count<long>();
          this.CharacterMotionOffsets = (ICollection<long>) new List<long>();
          if (TotalRegions > 0)
          {
            List<long> MotionCleanTable = MotionRegionSearchTable.ToList<long>();
            for (int i = 0; i < MotionCleanTable.Count; ++i)
            {
              long MotionAddy = MotionCleanTable[i] + (long) App.CurrentGame.Memory.Regions["MotionUniverseSize"];
              if (!App.MemoryManager.ReadMByte(App.CurrentGame.Exe, 1L, MotionAddy, (byte) 1))
              {
                this.CharacterMotionOffsets.Add(MotionAddy - 1L - (long) (App.CurrentGame.Memory.Regions["MotionSize"] * 100));
                this.logger.Log("Found {0} [Motion] location", new object[1]
                {
                  (object) (MotionAddy - 1L - (long) (App.CurrentGame.Memory.Regions["MotionSize"] * 100))
                });
              }
            }
            MotionCleanTable = (List<long>) null;
          }
          this.CharacterMotionOffsets.Add(BaseAddress + (long) App.CurrentGame.Memory.Regions["MotionStatic"] - (long) (App.CurrentGame.Memory.Regions["MotionSize"] * 100));
          this.logger.Log("Found {0} total [Motion] memory locations (including static)", new object[1]
          {
            (object) this.CharacterMotionOffsets.Count
          });
          ProfileRegionSearchTable = (IEnumerable<long>) null;
          MotionRegionSearchTable = (IEnumerable<long>) null;
        }));
      }
      else
      {
        int num = (int) MetaMessageBox.Show("Game was not found, attempting resync (check log)", "Meta Memory Manager");
        if (App.InitiateWatchGame())
          this.GameWasClosed = false;
      }
    }

    protected override bool ImportMemory(EditorCharProfileTable.ImportMethod method)
    {
      if (!this.GameWasClosed)
      {
        if (App.GameRunning)
        {
          if (this.CharacterProfileOffsets != null && this.CharacterProfileOffsets.Count > 0)
          {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "(All supported formats)|*.json";
            openFileDialog1.Title = "Open Profile";
            openFileDialog1.Multiselect = false;
            OpenFileDialog openFileDialog2 = openFileDialog1;
            bool? nullable = openFileDialog2.ShowDialog();
            bool flag = true;
            if (nullable.GetValueOrDefault() == flag & nullable.HasValue)
            {
              Profile profile = JsonConvert.DeserializeObject<Profile>(File.ReadAllText(openFileDialog2.FileName));
              if (profile.Type.Equals((object) (ProfileType) 0))
              {
                TreeView tree = ((FlatbufferControl) this.Parent).Tree;
                // ISSUE: reference to a compiler-generated field
                if (EditorCharProfileTable_WWE2K24.\u003C\u003Eo__3.\u003C\u003Ep__2 == null)
                {
                  // ISSUE: reference to a compiler-generated field
                  EditorCharProfileTable_WWE2K24.\u003C\u003Eo__3.\u003C\u003Ep__2 = CallSite<Func<CallSite, object, CharacterProfile_WWE2K23>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (CharacterProfile_WWE2K23), typeof (EditorCharProfileTable_WWE2K24)));
                }
                // ISSUE: reference to a compiler-generated field
                Func<CallSite, object, CharacterProfile_WWE2K23> target1 = EditorCharProfileTable_WWE2K24.\u003C\u003Eo__3.\u003C\u003Ep__2.Target;
                // ISSUE: reference to a compiler-generated field
                CallSite<Func<CallSite, object, CharacterProfile_WWE2K23>> p2 = EditorCharProfileTable_WWE2K24.\u003C\u003Eo__3.\u003C\u003Ep__2;
                // ISSUE: reference to a compiler-generated field
                if (EditorCharProfileTable_WWE2K24.\u003C\u003Eo__3.\u003C\u003Ep__1 == null)
                {
                  // ISSUE: reference to a compiler-generated field
                  EditorCharProfileTable_WWE2K24.\u003C\u003Eo__3.\u003C\u003Ep__1 = CallSite<Func<CallSite, Type, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "DeserializeObject", (IEnumerable<Type>) new Type[1]
                  {
                    typeof (CharacterProfile_WWE2K23)
                  }, typeof (EditorCharProfileTable_WWE2K24), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
                  {
                    CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.IsStaticType, (string) null),
                    CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
                  }));
                }
                // ISSUE: reference to a compiler-generated field
                Func<CallSite, Type, object, object> target2 = EditorCharProfileTable_WWE2K24.\u003C\u003Eo__3.\u003C\u003Ep__1.Target;
                // ISSUE: reference to a compiler-generated field
                CallSite<Func<CallSite, Type, object, object>> p1 = EditorCharProfileTable_WWE2K24.\u003C\u003Eo__3.\u003C\u003Ep__1;
                Type type = typeof (JsonConvert);
                // ISSUE: reference to a compiler-generated field
                if (EditorCharProfileTable_WWE2K24.\u003C\u003Eo__3.\u003C\u003Ep__0 == null)
                {
                  // ISSUE: reference to a compiler-generated field
                  EditorCharProfileTable_WWE2K24.\u003C\u003Eo__3.\u003C\u003Ep__0 = CallSite<Func<CallSite, Type, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "SerializeObject", (IEnumerable<Type>) null, typeof (EditorCharProfileTable_WWE2K24), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
                  {
                    CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.IsStaticType, (string) null),
                    CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
                  }));
                }
                // ISSUE: reference to a compiler-generated field
                // ISSUE: reference to a compiler-generated field
                object obj1 = EditorCharProfileTable_WWE2K24.\u003C\u003Eo__3.\u003C\u003Ep__0.Target((CallSite) EditorCharProfileTable_WWE2K24.\u003C\u003Eo__3.\u003C\u003Ep__0, typeof (JsonConvert), profile.Data);
                object obj2 = target2((CallSite) p1, type, obj1);
                CharacterProfile_WWE2K23 MetaData = target1((CallSite) p2, obj2);
                if (MetaData != null)
                {
                  if (MetaData.Info != null && (method == EditorCharProfileTable.ImportMethod.Full || method == EditorCharProfileTable.ImportMethod.Character))
                  {
                    foreach (long characterProfileOffset in (IEnumerable<long>) this.CharacterProfileOffsets)
                    {
                      long ActualAddress = characterProfileOffset + (long) (App.CurrentGame.Memory.Regions["ProfileSize"] * ((MetaFlatbufferItem) tree.SelectedItem).Pointer);
                      DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(41, 1);
                      interpolatedStringHandler.AppendLiteral("Importing [Character] to memory region (");
                      interpolatedStringHandler.AppendFormatted<long>(ActualAddress);
                      interpolatedStringHandler.AppendLiteral(")");
                      MetaTaskWindow.Show(interpolatedStringHandler.ToStringAndClear(), "Hold tight.", (MetaTaskCallback) (task =>
                      {
                        string str;
                        App.MemoryManager.Queue(App.CurrentGame.Exe, ActualAddress, ref str);
                        App.MemoryManager.CWrite<ushort>(App.CurrentGame.Memory.ProfileOffsets, "Category", (object) (ushort) 0);
                        App.MemoryManager.CWrite<ushort>(App.CurrentGame.Memory.ProfileOffsets, "Wrestler_ID", (object) MetaData.Info.wrestler_id);
                        App.MemoryManager.CWrite<ushort>(App.CurrentGame.Memory.ProfileOffsets, "Slot_ID", (object) MetaData.Info.slot_id);
                        App.MemoryManager.CWrite<ushort>(App.CurrentGame.Memory.ProfileOffsets, "Wrestler_ID_2", (object) MetaData.Info.wrestler_id_2);
                        App.MemoryManager.CWrite<uint>(App.CurrentGame.Memory.ProfileOffsets, "Full_Name", (object) MetaData.Info.fullname_sdb_id);
                        App.MemoryManager.CWrite<uint>(App.CurrentGame.Memory.ProfileOffsets, "Full_Name_2", (object) MetaData.Info.fullname_sdb_id);
                        App.MemoryManager.CWrite<uint>(App.CurrentGame.Memory.ProfileOffsets, "Full_Name_3", (object) MetaData.Info.fullname_sdb_id);
                        App.MemoryManager.CWrite<uint>(App.CurrentGame.Memory.ProfileOffsets, "Nickname", (object) MetaData.Info.nickname_sdb_id);
                        App.MemoryManager.CWrite<uint>(App.CurrentGame.Memory.ProfileOffsets, "Full_Name_4", (object) MetaData.Info.fullname_sdb_id);
                        App.MemoryManager.CWrite<uint>(App.CurrentGame.Memory.ProfileOffsets, "Social_media", (object) MetaData.Info.socialmedia_sdb_id);
                        App.MemoryManager.CWrite<ushort>(App.CurrentGame.Memory.ProfileOffsets, "Gender", (object) MetaData.Info.gender);
                        App.MemoryManager.CWrite<ushort>(App.CurrentGame.Memory.ProfileOffsets, "Weight", (object) MetaData.Info.weight);
                        App.MemoryManager.CWrite<byte>(App.CurrentGame.Memory.ProfileOffsets, "Weight_Class", (object) MetaData.Info.weight_class);
                        App.MemoryManager.CWrite<byte>(App.CurrentGame.Memory.ProfileOffsets, "Wrestler_Type", (object) MetaData.Info.wrestler_type);
                        App.MemoryManager.CWrite<byte>(App.CurrentGame.Memory.ProfileOffsets, "Crowd_Balance", (object) MetaData.Info.crowd_balance);
                        App.MemoryManager.CWrite<byte>(App.CurrentGame.Memory.ProfileOffsets, "Crowd_Reaction", (object) MetaData.Info.crowd_reaction);
                        App.MemoryManager.CWrite<uint>(App.CurrentGame.Memory.ProfileOffsets, "Victory_Name", (object) MetaData.Info.fullname_sdb_id);
                        App.MemoryManager.CWrite<uint>(App.CurrentGame.Memory.ProfileOffsets, "Commentary_ID", (object) MetaData.Info.commentary_id);
                        App.MemoryManager.CWrite<uint>(App.CurrentGame.Memory.ProfileOffsets, "Ring_Announcer_ID", (object) MetaData.Info.announcer_id);
                        App.MemoryManager.CWrite<uint>(App.CurrentGame.Memory.ProfileOffsets, "Hometown", (object) MetaData.Info.location_callname);
                        App.MemoryManager.CWrite<byte>(App.CurrentGame.Memory.ProfileOffsets, "Payback_1_Flag", (object) MetaData.Info.payback_01);
                        App.MemoryManager.CWrite<byte>(App.CurrentGame.Memory.ProfileOffsets, "Payback_2_Flag", (object) MetaData.Info.payback_02);
                        App.MemoryManager.CWrite<byte>(App.CurrentGame.Memory.ProfileOffsets, "Unlock_Flag", (object) MetaData.Info.playability);
                        App.MemoryManager.CWrite<byte>(App.CurrentGame.Memory.ProfileOffsets, "Menu_Flag", (object) MetaData.Info.menu_location);
                        App.MemoryManager.CWrite<uint[]>(App.CurrentGame.Memory.ProfileOffsets, "Crowd_Signs", (object) MetaData.Info.crowd_signs.ToByteArray());
                        App.MemoryManager.CWrite<byte[]>(App.CurrentGame.Memory.ProfileOffsets, "Ai_Attributes", (object) MetaData.Info.ai_attributes.ToArray());
                        App.MemoryManager.CWrite<byte[]>(App.CurrentGame.Memory.ProfileOffsets, "Attributes", (object) MetaData.Info.attributes.ToArray());
                        App.MemoryManager.CWrite<byte[]>(App.CurrentGame.Memory.ProfileOffsets, "Hit_Point_Ratio", (object) MetaData.Info.hit_point.ToArray());
                        App.MemoryManager.CWrite<byte[]>(App.CurrentGame.Memory.ProfileOffsets, "Personality_Traits", (object) MetaData.Info.personality_traits.ToArray());
                        ushort minValue = (ushort) HeightConverter.CalculateValueRange(MetaData.Info.height).minValue;
                        App.MemoryManager.CWrite<ushort>(App.CurrentGame.Memory.ProfileOffsets, "Height", (object) minValue);
                        App.MemoryManager.Write(new byte[2]
                        {
                          MetaData.Info.payback_01,
                          MetaData.Info.payback_02
                        }, App.CurrentGame.Memory.MoveOffsets["Moves_Payback"]);
                        App.MemoryManager.Release();
                      }));
                      this.logger.Log("Imported [Character Data] to region: {0}", new object[1]
                      {
                        (object) ActualAddress
                      });
                    }
                  }
                  if (MetaData.Motion != null && (method == EditorCharProfileTable.ImportMethod.Full || method == EditorCharProfileTable.ImportMethod.Motion))
                  {
                    foreach (long characterMotionOffset in (IEnumerable<long>) this.CharacterMotionOffsets)
                    {
                      long ActualAddress = characterMotionOffset + (long) (App.CurrentGame.Memory.Regions["MotionSize"] * ((MetaFlatbufferItem) tree.SelectedItem).Pointer);
                      DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(38, 1);
                      interpolatedStringHandler.AppendLiteral("Importing [Motion] to memory region (");
                      interpolatedStringHandler.AppendFormatted<long>(ActualAddress);
                      interpolatedStringHandler.AppendLiteral(")");
                      MetaTaskWindow.Show(interpolatedStringHandler.ToStringAndClear(), "Hold tight.", (MetaTaskCallback) (task =>
                      {
                        string str;
                        App.MemoryManager.Queue(App.CurrentGame.Exe, ActualAddress, ref str);
                        App.MemoryManager.Write(BitConverter.GetBytes(MetaData.Info.wrestler_id), App.CurrentGame.Memory.MotionOffsets["Wrestler_ID"]);
                        App.MemoryManager.Write(BitConverter.GetBytes(MetaData.Motion.entrance_music), App.CurrentGame.Memory.MotionOffsets["Entrance_Music"]);
                        App.MemoryManager.Write(BitConverter.GetBytes(MetaData.Motion.entrance_music), App.CurrentGame.Memory.MotionOffsets["Victory_Entrance_Music"]);
                        App.MemoryManager.Write(new byte[4], App.CurrentGame.Memory.MotionOffsets["Template_Flag"]);
                        App.MemoryManager.Write(new byte[4], App.CurrentGame.Memory.MotionOffsets["Template_ID"]);
                        App.MemoryManager.Write(BitConverter.GetBytes(MetaData.Motion.victory_motion_face), App.CurrentGame.Memory.MotionOffsets["Victory_Motion_Face"]);
                        App.MemoryManager.Write(BitConverter.GetBytes(MetaData.Motion.victory_motion_heel), App.CurrentGame.Memory.MotionOffsets["Victory_Motion_Heel"]);
                        App.MemoryManager.Write(BitConverter.GetBytes(MetaData.Motion.victory_title_motion_face), App.CurrentGame.Memory.MotionOffsets["Victory_Title_Motion_Face"]);
                        App.MemoryManager.Write(BitConverter.GetBytes(MetaData.Motion.victory_title_motion_heel), App.CurrentGame.Memory.MotionOffsets["Victory_Title_Motion_Heel"]);
                        App.MemoryManager.Write(BitConverter.GetBytes(MetaData.Motion.entrance_title_motion), App.CurrentGame.Memory.MotionOffsets["Title_Motion"]);
                        App.MemoryManager.Write(BitConverter.GetBytes(MetaData.Motion.entrance_MITB_motion), App.CurrentGame.Memory.MotionOffsets["MITB_Motion"]);
                        App.MemoryManager.Write(new byte[4], App.CurrentGame.Memory.MotionOffsets["Victory_Template_Flag"]);
                        App.MemoryManager.Write(new byte[4], App.CurrentGame.Memory.MotionOffsets["Victory_Template_ID"]);
                        App.MemoryManager.Write(new byte[4]
                        {
                          byte.MaxValue,
                          byte.MaxValue,
                          byte.MaxValue,
                          byte.MaxValue
                        }, App.CurrentGame.Memory.MotionOffsets["Template"]);
                        App.MemoryManager.Write(BitConverter.GetBytes((short) MetaData.Motion.screen_effect), App.CurrentGame.Memory.MotionOffsets["Arena_Effect"]);
                        App.MemoryManager.Write(BitConverter.GetBytes(MetaData.Motion.light_show), App.CurrentGame.Memory.MotionOffsets["Light_Show"]);
                        App.MemoryManager.Write(BitConverter.GetBytes(MetaData.Motion.entrance_motion_intro), App.CurrentGame.Memory.MotionOffsets["Motion_Intro"]);
                        App.MemoryManager.Write(BitConverter.GetBytes(MetaData.Motion.entrance_motion_stage), App.CurrentGame.Memory.MotionOffsets["Motion_Stage"]);
                        App.MemoryManager.Write(BitConverter.GetBytes(MetaData.Motion.entrance_motion_ramp), App.CurrentGame.Memory.MotionOffsets["Motion_Ramp"]);
                        App.MemoryManager.Write(BitConverter.GetBytes(MetaData.Motion.entrance_motion_ring_in), App.CurrentGame.Memory.MotionOffsets["Motion_Ring_In"]);
                        App.MemoryManager.Write(BitConverter.GetBytes(MetaData.Motion.entrance_motion_ring), App.CurrentGame.Memory.MotionOffsets["Motion_Ring"]);
                        App.MemoryManager.Write(BitConverter.GetBytes((short) MetaData.Motion.movies_enabled), App.CurrentGame.Memory.MotionOffsets["Movie_Display"]);
                        App.MemoryManager.Write(BitConverter.GetBytes(MetaData.Motion.movie_titantron), App.CurrentGame.Memory.MotionOffsets["Titantron_Movie"]);
                        App.MemoryManager.Write(BitConverter.GetBytes(MetaData.Motion.movie_stage_ramp), App.CurrentGame.Memory.MotionOffsets["Stage_Ramp_Movie"]);
                        App.MemoryManager.Write(BitConverter.GetBytes(MetaData.Motion.movie_barricade), App.CurrentGame.Memory.MotionOffsets["Barricade_Movie"]);
                        App.MemoryManager.Write(BitConverter.GetBytes(MetaData.Motion.movie_apron_ringpost), App.CurrentGame.Memory.MotionOffsets["Apron_Ring_Post_Movie"]);
                        App.MemoryManager.Write(BitConverter.GetBytes(MetaData.Motion.movie_unknown), App.CurrentGame.Memory.MotionOffsets["Unknown_Movie"]);
                        App.MemoryManager.Write(BitConverter.GetBytes(MetaData.Motion.movie_banner), App.CurrentGame.Memory.MotionOffsets["Banner_Movie"]);
                        App.MemoryManager.Write(BitConverter.GetBytes(MetaData.Motion.movie_titantron), App.CurrentGame.Memory.MotionOffsets["Victory_Titantron_Movie"]);
                        App.MemoryManager.Write(BitConverter.GetBytes(MetaData.Motion.movie_stage_ramp), App.CurrentGame.Memory.MotionOffsets["Victory_Stage_Ramp_Movie"]);
                        App.MemoryManager.Write(BitConverter.GetBytes(MetaData.Motion.movie_apron_ringpost), App.CurrentGame.Memory.MotionOffsets["Victory_Apron_Ring_Post_Movie"]);
                        App.MemoryManager.Write(BitConverter.GetBytes(MetaData.Motion.movie_unknown), App.CurrentGame.Memory.MotionOffsets["Victory_Unknown_Movie"]);
                        App.MemoryManager.Write(BitConverter.GetBytes(MetaData.Motion.movie_banner), App.CurrentGame.Memory.MotionOffsets["Victory_Banner_Movie"]);
                        App.MemoryManager.Write(new byte[2]
                        {
                          MetaData.Info.payback_01,
                          MetaData.Info.payback_02
                        }, App.CurrentGame.Memory.MoveOffsets["Moves_Payback"]);
                        App.MemoryManager.Release();
                      }));
                      this.logger.Log("Imported [Motion Data] to region: {0}", new object[1]
                      {
                        (object) ActualAddress
                      });
                    }
                  }
                  if (MetaData.Moveset == null || method != EditorCharProfileTable.ImportMethod.Full && method != EditorCharProfileTable.ImportMethod.Moveset)
                    ;
                  return true;
                }
              }
              else
              {
                int num = (int) MetaMessageBox.Show("Invalid profile.", "Meta Memory Manager");
              }
            }
          }
          else
          {
            int num1 = (int) MetaMessageBox.Show("Memory is not primed", "Meta Memory Manager");
          }
        }
        else
        {
          int num2 = (int) MetaMessageBox.Show("Game was not found, attempting resync", "Meta Memory Manager");
          if (App.InitiateWatchGame())
            this.GameWasClosed = false;
        }
      }
      else
      {
        int num3 = (int) MetaMessageBox.Show("Game was recently closed, you must prime memory again.", "Meta Memory Manager");
        if (!App.GameRunning && App.InitiateWatchGame())
          this.GameWasClosed = false;
      }
      return false;
    }
  }
}
