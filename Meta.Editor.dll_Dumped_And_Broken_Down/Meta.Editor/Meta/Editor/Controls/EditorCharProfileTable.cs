using Meta.Core;
using Meta.Core.Attributes;
using Meta.Core.Interfaces;
using Meta.Editor.Commands;
using Meta.Editor.Converters;
using Meta.Editor.IO.WWE2K23;
using Meta.Editor.Windows;
using Meta.Structures.Flatbuffers;
using Meta.Structures.Flatbuffers.WWE2K23;
using Meta.WWE2K23;
using MetaEditor;
using Microsoft.CSharp.RuntimeBinder;
using Microsoft.Win32;
using Newtonsoft.Json;
using Ookii.Dialogs.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

#nullable enable
namespace Meta.Editor.Controls
{
  [EditorType("Prof")]
  [GameVersion("WWE 2K23")]
  public class EditorCharProfileTable : Meta.Editor.Controls.Editor
  {
    protected bool GameWasClosed;

    public override string Icon => "Table";

    protected ICollection<long> CharacterProfileOffsets { get; set; }

    protected ICollection<long> CharacterMotionOffsets { get; set; }

    public EditorCharProfileTable(ILogger inLogger, FlatbufferSchema _schema, string filename)
      : base(inLogger, _schema, filename)
    {
    }

    public override void Initialize(object sender)
    {
      base.Initialize(sender);
      if (App.ActiveGame == null)
        return;
      App.ActiveGame.Exited += new EventHandler(this.ActiveGame_Exited);
    }

    private void ActiveGame_Exited(object? sender, EventArgs e)
    {
      this.GameWasClosed = true;
      App.GameRunning = false;
    }

    public override List<ToolbarItem> RegisterToolbarItems()
    {
      List<ToolbarItem> toolbarItemList = base.RegisterToolbarItems();
      toolbarItemList.Add(new ToolbarItem("Prime Memory", "Initialize game memory regions for injection", "Memory", new RelayCommand((Action<object>) (state => this.PrimeMemory_Click((object) this, new RoutedEventArgs())))));
      toolbarItemList.Add(new ToolbarItem("Bulk Import", "Bulk import character profile stats", "PackageUp", new RelayCommand((Action<object>) (state => this.BulkImport_Click((object) this, new RoutedEventArgs())))));
      return toolbarItemList;
    }

    public override List<ContextMenuItem> RegisterContextMenuItems()
    {
      List<ContextMenuItem> contextMenuItemList = base.RegisterContextMenuItems();
      contextMenuItemList.Add(new ContextMenuItem("Import Full Character Profile", "Import a Wrestler's data to the desired slot", "FileImport", new RelayCommand((Action<object>) (state => this.ImportProfile_Click((object) this, new RoutedEventArgs())))));
      contextMenuItemList.Add(new ContextMenuItem("Import Character Only", "Import a Wrestler's profile information only", "FaceManProfile", new RelayCommand((Action<object>) (state => this.ImportCharacter_Click((object) this, new RoutedEventArgs())))));
      contextMenuItemList.Add(new ContextMenuItem("Import Motion Only", "Import a Wrestler's profile motion data only", "ExitRun", new RelayCommand((Action<object>) (state => this.ImportMotion_Click((object) this, new RoutedEventArgs())))));
      contextMenuItemList.Add(new ContextMenuItem("Import Moveset Only", "Import a Wrestler's profile moveset data only", "RunFast", new RelayCommand((Action<object>) (state => this.ImportMoveset_Click((object) this, new RoutedEventArgs())))));
      contextMenuItemList.Add(new ContextMenuItem("Extract All", "Extract all character profiles", "DatabaseExport", new RelayCommand((Action<object>) (state => this.ExportAllMemory_Click((object) this, new RoutedEventArgs())))));
      contextMenuItemList.Add(new ContextMenuItem("Extract Full Character Profile", "Extract the character data from memory", "FileExport", new RelayCommand((Action<object>) (state => this.ExportMemory_Click((object) this, new RoutedEventArgs())))));
      return contextMenuItemList;
    }

    private void RenameNode_Click(object sender, RoutedEventArgs e)
    {
      new InputWindow("Rename").ShowDialog();
    }

    private void ExportAllMemory_Click(object sender, RoutedEventArgs e)
    {
      if (!this.GameWasClosed)
      {
        if (App.GameRunning)
        {
          if (this.CharacterProfileOffsets != null && this.CharacterProfileOffsets.Count > 0)
          {
            VistaFolderBrowserDialog dialog = new VistaFolderBrowserDialog();
            dialog.Description = "Please select a folder.";
            dialog.UseDescriptionForTitle = true;
            bool? nullable = dialog.ShowDialog();
            if (!(1 == (nullable.GetValueOrDefault() ? 1 : 0) & nullable.HasValue))
              return;
            MetaTaskWindow.Show("Exporting characters from memory", "This may take a minute", (MetaTaskCallback) (task =>
            {
              TreeView tree = ((FlatbufferControl) this.Parent).Tree;
              this.logger.Log(((MetaFlatbufferItem) tree.Items[0]).Children.Count.ToString(), Array.Empty<object>());
              foreach (MetaFlatbufferItem child in (Collection<MetaFlatbufferItem>) ((MetaFlatbufferItem) tree.Items[0]).Children[0].Children)
              {
                long num1 = this.CharacterProfileOffsets.FirstOrDefault<long>() + (long) (App.CurrentGame.Memory.Regions["ProfileSize"] * child.Pointer);
                using (ProfileRender profileRender = new ProfileRender((Stream) new MemoryStream(App.MemoryManager.ReadMemory(App.CurrentGame.Exe, (long) App.CurrentGame.Memory.Regions["ProfileSize"], num1)), App.CurrentGame))
                {
                  long num2 = this.CharacterMotionOffsets.FirstOrDefault<long>() + (long) (App.CurrentGame.Memory.Regions["MotionSize"] * child.Pointer);
                  byte[] buffer = App.MemoryManager.ReadMemory(App.CurrentGame.Exe, (long) App.CurrentGame.Memory.Regions["MotionSize"], num2);
                  using (MotionRender motionRender = new MotionRender((Stream) new MemoryStream(buffer), App.CurrentGame))
                  {
                    using (MovesetReader movesetReader = new MovesetReader((Stream) new MemoryStream(buffer), App.CurrentGame))
                    {
                      Profile profile = new Profile()
                      {
                        Type = (ProfileType) 0
                      };
                      profile.Data = (object) new CharacterProfile_WWE2K23()
                      {
                        Info = profileRender.Profile,
                        Motion = motionRender.Motion,
                        Moveset = movesetReader.Moveset
                      };
                      JsonSerializerSettings settings = new JsonSerializerSettings()
                      {
                        DefaultValueHandling = DefaultValueHandling.Ignore,
                        MissingMemberHandling = MissingMemberHandling.Ignore,
                        Formatting = Formatting.Indented,
                        NullValueHandling = NullValueHandling.Ignore
                      };
                      string selectedPath = dialog.SelectedPath;
                      // ISSUE: reference to a compiler-generated field
                      if (EditorCharProfileTable.\u003C\u003Eo__18.\u003C\u003Ep__0 == null)
                      {
                        // ISSUE: reference to a compiler-generated field
                        EditorCharProfileTable.\u003C\u003Eo__18.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "wrestler_id", typeof (EditorCharProfileTable), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
                        {
                          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
                        }));
                      }
                      // ISSUE: reference to a compiler-generated field
                      // ISSUE: reference to a compiler-generated field
                      object obj = EditorCharProfileTable.\u003C\u003Eo__18.\u003C\u003Ep__0.Target((CallSite) EditorCharProfileTable.\u003C\u003Eo__18.\u003C\u003Ep__0, child.Data);
                      File.WriteAllText(string.Format("{0}/wrestler_id_{1}.json", (object) selectedPath, obj), JsonConvert.SerializeObject((object) profile, settings));
                      motionRender.Dispose();
                      movesetReader.Dispose();
                    }
                  }
                  profileRender.Dispose();
                }
              }
            }));
            this.logger.Log("Finished exporting", Array.Empty<object>());
          }
          else
          {
            int num3 = (int) MetaMessageBox.Show("Memory is not primed", "Meta Memory Manager");
          }
        }
        else
        {
          int num4 = (int) MetaMessageBox.Show("Game was not found, attempting resync (check log)", "Meta Memory Manager");
          if (App.InitiateWatchGame())
            this.GameWasClosed = false;
        }
      }
      else
      {
        int num5 = (int) MetaMessageBox.Show("Game was recently closed, you must prime memory again.", "Meta Memory Manager");
        if (!App.GameRunning && App.InitiateWatchGame())
          this.GameWasClosed = false;
      }
    }

    private void ExportMemory_Click(object sender, RoutedEventArgs e)
    {
      if (!this.GameWasClosed)
      {
        if (App.GameRunning)
        {
          if (this.CharacterProfileOffsets != null && this.CharacterProfileOffsets.Count > 0)
          {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "(All supported formats)|*.json";
            saveFileDialog.Title = "Save Profile";
            SaveFileDialog sfd = saveFileDialog;
            bool? nullable = sfd.ShowDialog();
            bool flag = true;
            if (!(nullable.GetValueOrDefault() == flag & nullable.HasValue))
              return;
            MetaTaskWindow.Show("Exporting character from memory", "This may take a minute", (MetaTaskCallback) (task => ((DispatcherObject) this.FControl).Dispatcher.Invoke((Action) (() =>
            {
              TreeView tree = ((FlatbufferControl) this.Parent).Tree;
              long num1 = this.CharacterProfileOffsets.LastOrDefault<long>() + (long) (App.CurrentGame.Memory.Regions["ProfileSize"] * ((MetaFlatbufferItem) tree.SelectedItem).Pointer);
              using (ProfileRender profileRender = new ProfileRender((Stream) new MemoryStream(App.MemoryManager.ReadMemory(App.CurrentGame.Exe, (long) App.CurrentGame.Memory.Regions["ProfileSize"], num1)), App.CurrentGame))
              {
                long num2 = this.CharacterMotionOffsets.LastOrDefault<long>() + (long) (App.CurrentGame.Memory.Regions["MotionSize"] * ((MetaFlatbufferItem) tree.SelectedItem).Pointer);
                byte[] buffer = App.MemoryManager.ReadMemory(App.CurrentGame.Exe, (long) App.CurrentGame.Memory.Regions["MotionSize"], num2);
                using (MotionRender motionRender = new MotionRender((Stream) new MemoryStream(buffer), App.CurrentGame))
                {
                  using (MovesetReader movesetReader = new MovesetReader((Stream) new MemoryStream(buffer), App.CurrentGame))
                  {
                    Profile profile = new Profile()
                    {
                      Type = (ProfileType) 0
                    };
                    profile.Data = (object) new CharacterProfile_WWE2K23()
                    {
                      Info = profileRender.Profile,
                      Motion = motionRender.Motion,
                      Moveset = movesetReader.Moveset
                    };
                    JsonSerializerSettings settings = new JsonSerializerSettings()
                    {
                      Formatting = Formatting.Indented,
                      NullValueHandling = NullValueHandling.Ignore
                    };
                    File.WriteAllText(sfd.FileName, JsonConvert.SerializeObject((object) profile, settings));
                    motionRender.Dispose();
                    movesetReader.Dispose();
                  }
                }
                profileRender.Dispose();
              }
            }))));
          }
          else
          {
            int num3 = (int) MetaMessageBox.Show("Memory is not primed", "Meta Memory Manager");
          }
        }
        else
        {
          int num4 = (int) MetaMessageBox.Show("Game was not found, attempting resync (check log)", "Meta Memory Manager");
          if (App.InitiateWatchGame())
            this.GameWasClosed = false;
        }
      }
      else
      {
        int num5 = (int) MetaMessageBox.Show("Game was recently closed, you must prime memory again.", "Meta Memory Manager");
        if (!App.GameRunning && App.InitiateWatchGame())
          this.GameWasClosed = false;
      }
    }

    protected virtual bool ImportMemory(EditorCharProfileTable.ImportMethod method)
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
                if (EditorCharProfileTable.\u003C\u003Eo__20.\u003C\u003Ep__2 == null)
                {
                  // ISSUE: reference to a compiler-generated field
                  EditorCharProfileTable.\u003C\u003Eo__20.\u003C\u003Ep__2 = CallSite<Func<CallSite, object, CharacterProfile_WWE2K23>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (CharacterProfile_WWE2K23), typeof (EditorCharProfileTable)));
                }
                // ISSUE: reference to a compiler-generated field
                Func<CallSite, object, CharacterProfile_WWE2K23> target1 = EditorCharProfileTable.\u003C\u003Eo__20.\u003C\u003Ep__2.Target;
                // ISSUE: reference to a compiler-generated field
                CallSite<Func<CallSite, object, CharacterProfile_WWE2K23>> p2 = EditorCharProfileTable.\u003C\u003Eo__20.\u003C\u003Ep__2;
                // ISSUE: reference to a compiler-generated field
                if (EditorCharProfileTable.\u003C\u003Eo__20.\u003C\u003Ep__1 == null)
                {
                  // ISSUE: reference to a compiler-generated field
                  EditorCharProfileTable.\u003C\u003Eo__20.\u003C\u003Ep__1 = CallSite<Func<CallSite, Type, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "DeserializeObject", (IEnumerable<Type>) new Type[1]
                  {
                    typeof (CharacterProfile_WWE2K23)
                  }, typeof (EditorCharProfileTable), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
                  {
                    CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.IsStaticType, (string) null),
                    CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
                  }));
                }
                // ISSUE: reference to a compiler-generated field
                Func<CallSite, Type, object, object> target2 = EditorCharProfileTable.\u003C\u003Eo__20.\u003C\u003Ep__1.Target;
                // ISSUE: reference to a compiler-generated field
                CallSite<Func<CallSite, Type, object, object>> p1 = EditorCharProfileTable.\u003C\u003Eo__20.\u003C\u003Ep__1;
                Type type = typeof (JsonConvert);
                // ISSUE: reference to a compiler-generated field
                if (EditorCharProfileTable.\u003C\u003Eo__20.\u003C\u003Ep__0 == null)
                {
                  // ISSUE: reference to a compiler-generated field
                  EditorCharProfileTable.\u003C\u003Eo__20.\u003C\u003Ep__0 = CallSite<Func<CallSite, Type, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "SerializeObject", (IEnumerable<Type>) null, typeof (EditorCharProfileTable), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
                  {
                    CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.IsStaticType, (string) null),
                    CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
                  }));
                }
                // ISSUE: reference to a compiler-generated field
                // ISSUE: reference to a compiler-generated field
                object obj1 = EditorCharProfileTable.\u003C\u003Eo__20.\u003C\u003Ep__0.Target((CallSite) EditorCharProfileTable.\u003C\u003Eo__20.\u003C\u003Ep__0, typeof (JsonConvert), profile.Data);
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
                        App.MemoryManager.CWrite<byte>(App.CurrentGame.Memory.ProfileOffsets, "Gender", (object) MetaData.Info.gender);
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
                  if (MetaData.Moveset != null && (method == EditorCharProfileTable.ImportMethod.Full || method == EditorCharProfileTable.ImportMethod.Moveset))
                  {
                    foreach (long characterMotionOffset in (IEnumerable<long>) this.CharacterMotionOffsets)
                    {
                      long ActualAddress = characterMotionOffset + (long) (App.CurrentGame.Memory.Regions["MotionSize"] * ((MetaFlatbufferItem) tree.SelectedItem).Pointer);
                      DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(39, 1);
                      interpolatedStringHandler.AppendLiteral("Importing [Moveset] to memory region (");
                      interpolatedStringHandler.AppendFormatted<long>(ActualAddress);
                      interpolatedStringHandler.AppendLiteral(")");
                      MetaTaskWindow.Show(interpolatedStringHandler.ToStringAndClear(), "Hold tight.", (MetaTaskCallback) (task =>
                      {
                        string str;
                        App.MemoryManager.Queue(App.CurrentGame.Exe, ActualAddress, ref str);
                        App.MemoryManager.Write(new byte[2]
                        {
                          MetaData.Info.payback_01,
                          MetaData.Info.payback_02
                        }, App.CurrentGame.Memory.MoveOffsets["Moves_Payback"]);
                        App.MemoryManager.WriteUShortArray(MetaData.Moveset.moves_standing.front_light_attack.ToArray(), App.CurrentGame.Memory.MoveOffsets["Moves_Standing_Front_Light_Attack"]);
                        App.MemoryManager.WriteUShortArray(MetaData.Moveset.moves_standing.front_heavy_attack.ToArray(), App.CurrentGame.Memory.MoveOffsets["Moves_Standing_Front_Heavy_Attack"]);
                        App.MemoryManager.WriteUShortArray(MetaData.Moveset.moves_standing.front_running.ToArray(), App.CurrentGame.Memory.MoveOffsets["Moves_Standing_Front_Running"]);
                        App.MemoryManager.WriteUShortArray(MetaData.Moveset.moves_standing.rear_heavy_attack.ToArray(), App.CurrentGame.Memory.MoveOffsets["Moves_Standing_Rear_Heavy_Attack"]);
                        App.MemoryManager.WriteUShortArray(MetaData.Moveset.moves_standing.front_light_grapple.ToArray(), App.CurrentGame.Memory.MoveOffsets["Moves_Standing_Front_Light_Grapple"]);
                        App.MemoryManager.WriteUShortArray(MetaData.Moveset.moves_standing.front_heavy_grapple.ToArray(), App.CurrentGame.Memory.MoveOffsets["Moves_Standing_Front_Heavy_Grapple"]);
                        App.MemoryManager.WriteUShortArray(MetaData.Moveset.moves_standing.rear_light_grapple.ToArray(), App.CurrentGame.Memory.MoveOffsets["Moves_Standing_Rear_Light_Grapple"]);
                        App.MemoryManager.WriteUShortArray(MetaData.Moveset.moves_standing.rear_heavy_grapple.ToArray(), App.CurrentGame.Memory.MoveOffsets["Moves_Standing_Rear_Heavy_Grapple"]);
                        App.MemoryManager.WriteUShortArray(MetaData.Moveset.moves_standing.carry.ToArray(), App.CurrentGame.Memory.MoveOffsets["Moves_Standing_Carry"]);
                        App.MemoryManager.WriteUShortArray(MetaData.Moveset.moves_standing.leverage_pin.ToArray(), App.CurrentGame.Memory.MoveOffsets["Moves_Standing_Leverage_Pin"]);
                        App.MemoryManager.WriteUInt(MetaData.Moveset.moves_standing.combo_chain_neutral[0], App.CurrentGame.Memory.MoveOffsets["Moves_Combo_Chain_Neutral"]);
                        App.MemoryManager.WriteUInt(MetaData.Moveset.moves_standing.combo_chain_away[0], App.CurrentGame.Memory.MoveOffsets["Moves_Combo_Chain_Away"]);
                        App.MemoryManager.WriteUInt(MetaData.Moveset.moves_standing.combo_chain_towards[0], App.CurrentGame.Memory.MoveOffsets["Moves_Combo_Chain_Towards"]);
                        App.MemoryManager.WriteUShortArray(MetaData.Moveset.moves_standing.combo_enders_away.ToArray(), App.CurrentGame.Memory.MoveOffsets["Moves_Combo_Enders_Away"]);
                        App.MemoryManager.WriteUShortArray(MetaData.Moveset.moves_standing.combo_enders_neutral.ToArray(), App.CurrentGame.Memory.MoveOffsets["Moves_Combo_Enders_Neutral"]);
                        App.MemoryManager.WriteUShortArray(MetaData.Moveset.moves_standing.combo_enders_towards.ToArray(), App.CurrentGame.Memory.MoveOffsets["Moves_Combo_Enders_Towards"]);
                        App.MemoryManager.WriteUShort(MetaData.Moveset.moves_standing.foot_catch[0], App.CurrentGame.Memory.MoveOffsets["Moves_Standing_FootCatch_Light_Attack"]);
                        App.MemoryManager.WriteUShort(MetaData.Moveset.moves_standing.foot_catch[1], App.CurrentGame.Memory.MoveOffsets["Moves_Standing_FootCatch_Heavy_Attack"]);
                        App.MemoryManager.WriteUShort(MetaData.Moveset.moves_standing.foot_catch[2], App.CurrentGame.Memory.MoveOffsets["Moves_Standing_FootCatch_Submission"]);
                        App.MemoryManager.WriteUShort(MetaData.Moveset.moves_standing.foot_catch[3], App.CurrentGame.Memory.MoveOffsets["Moves_Standing_FootCatch_Reversal"]);
                        App.MemoryManager.WriteUShortArray(MetaData.Moveset.moves_signatures.in_ring.ToArray(), App.CurrentGame.Memory.MoveOffsets["Moves_Signatures_InRing"]);
                        App.MemoryManager.WriteUShortArray(MetaData.Moveset.moves_signatures.ringside.ToArray(), App.CurrentGame.Memory.MoveOffsets["Moves_Signatures_Ringside"]);
                        App.MemoryManager.WriteUShortArray(MetaData.Moveset.moves_finishers.in_ring.ToArray(), App.CurrentGame.Memory.MoveOffsets["Moves_Finishers_InRing"]);
                        App.MemoryManager.WriteUShortArray(MetaData.Moveset.moves_finishers.ringside.ToArray(), App.CurrentGame.Memory.MoveOffsets["Moves_Finishers_Ringside"]);
                        App.MemoryManager.WriteUShort(MetaData.Moveset.moves_finishers.other[0], App.CurrentGame.Memory.MoveOffsets["Moves_Finisher_1v2"]);
                        App.MemoryManager.WriteUShort(MetaData.Moveset.moves_finishers.other[1], App.CurrentGame.Memory.MoveOffsets["Moves_Finisher_Catching"]);
                        App.MemoryManager.WriteUShort(MetaData.Moveset.moves_finishers.other[2], App.CurrentGame.Memory.MoveOffsets["Moves_Finishers_HIAC_Ledge_Throw"]);
                        App.MemoryManager.WriteUShort(MetaData.Moveset.moves_finishers.other[3], App.CurrentGame.Memory.MoveOffsets["Moves_Finisher_HIAC"]);
                        App.MemoryManager.WriteUShort(MetaData.Moveset.moves_finishers.other[4], App.CurrentGame.Memory.MoveOffsets["Moves_Finisher_Announcer_Table"]);
                        App.MemoryManager.WriteUShortArray(MetaData.Moveset.moves_finishers.table.ToArray(), App.CurrentGame.Memory.MoveOffsets["Moves_Finishers_Table"]);
                        App.MemoryManager.WriteUShortArray(MetaData.Moveset.moves_finishers.rumble.ToArray(), App.CurrentGame.Memory.MoveOffsets["Moves_Finishers_Rumble"]);
                        App.MemoryManager.WriteUShortArray(MetaData.Moveset.moves_finishers.tag_team_mixed_tag.ToArray(), App.CurrentGame.Memory.MoveOffsets["Moves_Finishers_Mixed_Tag"]);
                        App.MemoryManager.WriteUShortArray(MetaData.Moveset.moves_ground.kneeling_front.ToArray(), App.CurrentGame.Memory.MoveOffsets["Moves_Ground_Kneeling_Front"]);
                        App.MemoryManager.WriteUShortArray(MetaData.Moveset.moves_ground.kneeling_rear.ToArray(), App.CurrentGame.Memory.MoveOffsets["Moves_Ground_Kneeling_Rear"]);
                        App.MemoryManager.WriteUShortArray(MetaData.Moveset.moves_ground.seated_front.ToArray(), App.CurrentGame.Memory.MoveOffsets["Moves_Ground_Seated_Front"]);
                        App.MemoryManager.WriteUShortArray(MetaData.Moveset.moves_ground.seated_rear.ToArray(), App.CurrentGame.Memory.MoveOffsets["Moves_Ground_Seated_Rear"]);
                        App.MemoryManager.WriteUShortArray(MetaData.Moveset.moves_ground.face_up_upper.ToArray(), App.CurrentGame.Memory.MoveOffsets["Moves_Ground_FaceUp_Upper"]);
                        App.MemoryManager.WriteUShortArray(MetaData.Moveset.moves_ground.face_up_side.ToArray(), App.CurrentGame.Memory.MoveOffsets["Moves_Ground_FaceUp_Side"]);
                        App.MemoryManager.WriteUShortArray(MetaData.Moveset.moves_ground.face_up_lower.ToArray(), App.CurrentGame.Memory.MoveOffsets["Moves_Ground_FaceUp_Lower"]);
                        App.MemoryManager.WriteUShortArray(MetaData.Moveset.moves_ground.face_down_upper.ToArray(), App.CurrentGame.Memory.MoveOffsets["Moves_Ground_FaceDown_Upper"]);
                        App.MemoryManager.WriteUShortArray(MetaData.Moveset.moves_ground.face_down_side.ToArray(), App.CurrentGame.Memory.MoveOffsets["Moves_Ground_FaceDown_Side"]);
                        App.MemoryManager.WriteUShortArray(MetaData.Moveset.moves_ground.face_down_lower.ToArray(), App.CurrentGame.Memory.MoveOffsets["Moves_Ground_FaceDown_Lower"]);
                        App.MemoryManager.WriteUShortArray(MetaData.Moveset.moves_ground.face_up_running.ToArray(), App.CurrentGame.Memory.MoveOffsets["Moves_Ground_FaceUp_Running"]);
                        App.MemoryManager.WriteUShortArray(MetaData.Moveset.moves_irish_whip.rebound_attack.ToArray(), App.CurrentGame.Memory.MoveOffsets["Moves_IrishWhip_ReboundAttack"]);
                        App.MemoryManager.WriteUShortArray(MetaData.Moveset.moves_irish_whip.rebound_action.ToArray(), App.CurrentGame.Memory.MoveOffsets["Moves_IrishWhip_ReboundAction"]);
                        App.MemoryManager.WriteUShortArray(MetaData.Moveset.moves_irish_whip.pullback_attack.ToArray(), App.CurrentGame.Memory.MoveOffsets["Moves_IrishWhip_PullBackAttack"]);
                        App.MemoryManager.WriteUShortArray(MetaData.Moveset.moves_corner.leaning_front.ToArray(), App.CurrentGame.Memory.MoveOffsets["Moves_Corner_Leaning_Front"]);
                        App.MemoryManager.WriteUShortArray(MetaData.Moveset.moves_corner.leaning_rear.ToArray(), App.CurrentGame.Memory.MoveOffsets["Moves_Corner_Leaning_Rear"]);
                        App.MemoryManager.WriteUShortArray(MetaData.Moveset.moves_corner.seated.ToArray(), App.CurrentGame.Memory.MoveOffsets["Moves_Corner_Seated"]);
                        App.MemoryManager.WriteUShortArray(MetaData.Moveset.moves_corner.top_rope_stunned_front.ToArray(), App.CurrentGame.Memory.MoveOffsets["Moves_Corner_Top_Rope_Stunned_Front"]);
                        App.MemoryManager.WriteUShortArray(MetaData.Moveset.moves_corner.top_rope_stunned_rear.ToArray(), App.CurrentGame.Memory.MoveOffsets["Moves_Corner_Top_Rope_Stunned_Rear"]);
                        App.MemoryManager.WriteUShortArray(MetaData.Moveset.moves_corner.tree_of_woe.ToArray(), App.CurrentGame.Memory.MoveOffsets["Moves_Corner_Tree_Of_Woe"]);
                        App.MemoryManager.WriteUShortArray(MetaData.Moveset.moves_rope.leaning.ToArray(), App.CurrentGame.Memory.MoveOffsets["Moves_Rope_Leaning"]);
                        App.MemoryManager.WriteUShortArray(MetaData.Moveset.moves_rope.middle_rope.ToArray(), App.CurrentGame.Memory.MoveOffsets["Moves_Rope_MiddleRope"]);
                        App.MemoryManager.WriteUShortArray(MetaData.Moveset.moves_apron.from_ring_front.ToArray(), App.CurrentGame.Memory.MoveOffsets["Moves_Apron_From_Ring_Front"]);
                        App.MemoryManager.WriteUShortArray(MetaData.Moveset.moves_apron.from_ring_rear.ToArray(), App.CurrentGame.Memory.MoveOffsets["Moves_Apron_From_Ring_Rear"]);
                        App.MemoryManager.WriteUShortArray(MetaData.Moveset.moves_apron.from_apron_to_ring.ToArray(), App.CurrentGame.Memory.MoveOffsets["Moves_Apron_From_Apron_To_Ring"]);
                        App.MemoryManager.WriteUShortArray(MetaData.Moveset.moves_apron.from_apron_to_ringside.ToArray(), App.CurrentGame.Memory.MoveOffsets["Moves_Apron_From_Apron_To_RingSide"]);
                        App.MemoryManager.WriteUShortArray(MetaData.Moveset.moves_diving.middle_rope_light_dive.ToArray(), App.CurrentGame.Memory.MoveOffsets["Moves_Diving_Middle_Rope_LightDive"]);
                        App.MemoryManager.WriteUShortArray(MetaData.Moveset.moves_diving.middle_rope_light_dive_to_supine.ToArray(), App.CurrentGame.Memory.MoveOffsets["Moves_Diving_Middle_Rope_LightDive_To_Supine"]);
                        App.MemoryManager.WriteUShortArray(MetaData.Moveset.moves_diving.diving_top_rope_attack.ToArray(), App.CurrentGame.Memory.MoveOffsets["Moves_Diving_Top_Rope_Attack"]);
                        App.MemoryManager.WriteUShortArray(MetaData.Moveset.moves_diving.diving_top_rope_to_supine.ToArray(), App.CurrentGame.Memory.MoveOffsets["Moves_Diving_Top_Rope_To_Supine"]);
                        App.MemoryManager.WriteUShortArray(MetaData.Moveset.moves_diving.equipment_box.ToArray(), App.CurrentGame.Memory.MoveOffsets["Moves_Diving_Equipment_Box"]);
                        App.MemoryManager.WriteUShortArray(MetaData.Moveset.moves_diving.ledge.ToArray(), App.CurrentGame.Memory.MoveOffsets["Moves_Diving_Ledge"]);
                        App.MemoryManager.WriteUShortArray(MetaData.Moveset.moves_springboard.to_ring_standing_front.ToArray(), App.CurrentGame.Memory.MoveOffsets["Moves_Springboard_To_Ring_Standing"]);
                        App.MemoryManager.WriteUShortArray(MetaData.Moveset.moves_springboard.to_ring_supine.ToArray(), App.CurrentGame.Memory.MoveOffsets["Moves_Springboard_In_Ring_Supine"]);
                        App.MemoryManager.WriteUShortArray(MetaData.Moveset.moves_springboard.to_ringside_standing_front.ToArray(), App.CurrentGame.Memory.MoveOffsets["Moves_Springboard_To_Ringside_Standing"]);
                        App.MemoryManager.WriteUShortArray(MetaData.Moveset.moves_springboard.to_ringside_supine.ToArray(), App.CurrentGame.Memory.MoveOffsets["Moves_Springboard_To_Ringside_Supine"]);
                        App.MemoryManager.WriteUShortArray(MetaData.Moveset.moves_holds.submission.ToArray(), App.CurrentGame.Memory.MoveOffsets["Moves_Holds_Submission"]);
                        App.MemoryManager.WriteUShortArray(MetaData.Moveset.moves_other_attacks.comeback.ToArray(), App.CurrentGame.Memory.MoveOffsets["Moves_Other_Attacks_Comeback"]);
                        App.MemoryManager.WriteUShort(MetaData.Moveset.moves_other_attacks.barricade[0], App.CurrentGame.Memory.MoveOffsets["Moves_Match_Type_Barricade_Heavy_Attack"]);
                        App.MemoryManager.WriteUShort(MetaData.Moveset.moves_other_attacks.barricade[1], App.CurrentGame.Memory.MoveOffsets["Moves_Match_Type_Barricade_Grab"]);
                        App.MemoryManager.WriteUShortArray(MetaData.Moveset.moves_movement.recovery.ToArray(), App.CurrentGame.Memory.MoveOffsets["Moves_Movement_Instant_Recovery"]);
                        App.MemoryManager.WriteUShort(MetaData.Moveset.moves_movement.enter_ring[0], App.CurrentGame.Memory.MoveOffsets["Moves_Movement_Enter_Ring_FromRingside"]);
                        App.MemoryManager.WriteUShort(MetaData.Moveset.moves_movement.enter_ring[1], App.CurrentGame.Memory.MoveOffsets["Moves_Movement_Exit_Ring_ToRingside"]);
                        App.MemoryManager.WriteUShort(MetaData.Moveset.moves_movement.exit_ring[0], App.CurrentGame.Memory.MoveOffsets["Moves_Movement_Exit_Ring_FromApron"]);
                        App.MemoryManager.WriteUShort(MetaData.Moveset.moves_movement.exit_ring[1], App.CurrentGame.Memory.MoveOffsets["Moves_Movement_Exit_Ring_ToApron"]);
                        App.MemoryManager.Write(MetaData.Moveset.moves_movement.climb_top_rope.ToArray(), App.CurrentGame.Memory.MoveOffsets["Moves_Movement_Top_Rope_Climb"]);
                        App.MemoryManager.WriteUShortArray(MetaData.Moveset.moves_match_type.tag_team_double_team.ToArray(), App.CurrentGame.Memory.MoveOffsets["Moves_Match_Type_TagTeam_DoubleTeam"]);
                        App.MemoryManager.WriteUShortArray(MetaData.Moveset.moves_match_type.tag_team_normal_tag_attacks.ToArray(), App.CurrentGame.Memory.MoveOffsets["Moves_Match_Type_TagTeam_Normal_Tag_Attacks"]);
                        App.MemoryManager.WriteUShortArray(MetaData.Moveset.moves_match_type.tag_team_mixed_tag_attacks.ToArray(), App.CurrentGame.Memory.MoveOffsets["Moves_Match_Type_TagTeam_Mixed_Tag_Attacks"]);
                        App.MemoryManager.WriteUShortArray(MetaData.Moveset.moves_match_type.ladder.ToArray(), App.CurrentGame.Memory.MoveOffsets["Moves_Match_Type_Ladder"]);
                        App.MemoryManager.WriteUShort(MetaData.Moveset.moves_match_type.table[0], App.CurrentGame.Memory.MoveOffsets["Moves_Match_Type_Table_Grab"]);
                        App.MemoryManager.WriteUShort(MetaData.Moveset.moves_match_type.table[1], App.CurrentGame.Memory.MoveOffsets["Moves_Match_Type_Table_Corner_Grab"]);
                        App.MemoryManager.WriteUShort(MetaData.Moveset.moves_match_type.table[2], App.CurrentGame.Memory.MoveOffsets["Moves_Match_Type_Table_TopRope_Grab"]);
                        App.MemoryManager.WriteUShort(MetaData.Moveset.moves_match_type.table[3], App.CurrentGame.Memory.MoveOffsets["Moves_Match_Type_Table_Rope_Stunned"]);
                        App.MemoryManager.WriteUShort(MetaData.Moveset.moves_match_type.table[4], App.CurrentGame.Memory.MoveOffsets["Moves_Match_Type_Table_Apron"]);
                        App.MemoryManager.WriteUShortArray(MetaData.Moveset.moves_taunts.to_crowd_standing.ToArray(), App.CurrentGame.Memory.MoveOffsets["Moves_Taunts_Crowd_Standing"]);
                        App.MemoryManager.WriteUShortArray(MetaData.Moveset.moves_taunts.to_crowd_corner.ToArray(), App.CurrentGame.Memory.MoveOffsets["Moves_Taunts_Crowd_Corner"]);
                        App.MemoryManager.WriteUShortArray(MetaData.Moveset.moves_taunts.to_crowd_top_rope.ToArray(), App.CurrentGame.Memory.MoveOffsets["Moves_Taunts_Crowd_Top_Rope"]);
                        App.MemoryManager.WriteUShortArray(MetaData.Moveset.moves_taunts.to_crowd_middle_rope.ToArray(), App.CurrentGame.Memory.MoveOffsets["Moves_Taunts_Crowd_Middle_Rope"]);
                        App.MemoryManager.WriteUShortArray(MetaData.Moveset.moves_taunts.to_crowd_apron_facing_ring.ToArray(), App.CurrentGame.Memory.MoveOffsets["Moves_Taunts_Crowd_Apron"]);
                        App.MemoryManager.WriteUShortArray(MetaData.Moveset.moves_taunts.to_crowd_apron_facing_ringside.ToArray(), App.CurrentGame.Memory.MoveOffsets["Moves_Taunts_Crowd_Apron_To_Ringside"]);
                        App.MemoryManager.WriteUShortArray(MetaData.Moveset.moves_taunts.to_opponent_standing_to_standing.ToArray(), App.CurrentGame.Memory.MoveOffsets["Moves_Taunts_Opponent_Standing"]);
                        App.MemoryManager.WriteUShortArray(MetaData.Moveset.moves_taunts.to_opponent_standing_to_ground.ToArray(), App.CurrentGame.Memory.MoveOffsets["Moves_Taunts_Opponent_Grounded"]);
                        App.MemoryManager.WriteUShortArray(MetaData.Moveset.moves_taunts.to_opponent_corner.ToArray(), App.CurrentGame.Memory.MoveOffsets["Moves_Taunts_Opponent_Corner"]);
                        App.MemoryManager.WriteUShortArray(MetaData.Moveset.moves_taunts.to_opponent_top_rope.ToArray(), App.CurrentGame.Memory.MoveOffsets["Moves_Taunts_Opponent_Top_Rope"]);
                        App.MemoryManager.WriteUShortArray(MetaData.Moveset.moves_taunts.to_opponent_middle_rope.ToArray(), App.CurrentGame.Memory.MoveOffsets["Moves_Taunts_Opponent_Middle_Rope"]);
                        App.MemoryManager.WriteUShortArray(MetaData.Moveset.moves_taunts.to_opponent_apron_facing_ring.ToArray(), App.CurrentGame.Memory.MoveOffsets["Moves_Taunts_Opponent_Apron"]);
                        App.MemoryManager.WriteUShortArray(MetaData.Moveset.moves_taunts.to_opponent_apron_facing_ringside.ToArray(), App.CurrentGame.Memory.MoveOffsets["Moves_Taunts_Opponent_Apron_To_Ringside"]);
                        App.MemoryManager.WriteUShortArray(MetaData.Moveset.moves_taunts.wake_up.ToArray(), App.CurrentGame.Memory.MoveOffsets["Moves_Taunts_Opponent_Wake_Up"]);
                        App.MemoryManager.WriteUShortArray(MetaData.Moveset.moves_pre_match.warm_up.ToArray(), App.CurrentGame.Memory.MoveOffsets["Moves_PreMatch_Warmups"]);
                        App.MemoryManager.WriteUShortArray(MetaData.Moveset.moves_pre_match.title_match_champion.ToArray(), App.CurrentGame.Memory.MoveOffsets["Moves_PreMatch_TitleMatch_Champion"]);
                        App.MemoryManager.WriteUShortArray(MetaData.Moveset.moves_pre_match.title_match_challenger.ToArray(), App.CurrentGame.Memory.MoveOffsets["Moves_PreMatch_TitleMatch_Challenger"]);
                        App.MemoryManager.WriteUShortArray(MetaData.Moveset.moves_weight_detection.moveset.ToArray(), App.CurrentGame.Memory.MoveOffsets["Moves_Weight_Detection"]);
                        App.MemoryManager.Release();
                      }));
                      this.logger.Log("Imported [Moveset Data] to region: {0}", new object[1]
                      {
                        (object) ActualAddress
                      });
                    }
                  }
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

    private void ImportMotion_Click(object sender, RoutedEventArgs e)
    {
      if (!this.ImportMemory(EditorCharProfileTable.ImportMethod.Motion))
        return;
      this.logger.Log("Finished importing", Array.Empty<object>());
    }

    private void ImportMoveset_Click(object sender, RoutedEventArgs e)
    {
      if (!this.ImportMemory(EditorCharProfileTable.ImportMethod.Moveset))
        return;
      this.logger.Log("Finished importing", Array.Empty<object>());
    }

    private void ImportCharacter_Click(object sender, RoutedEventArgs e)
    {
      if (!this.ImportMemory(EditorCharProfileTable.ImportMethod.Character))
        return;
      this.logger.Log("Finished importing", Array.Empty<object>());
    }

    private void ImportProfile_Click(object sender, RoutedEventArgs e)
    {
      if (!this.ImportMemory(EditorCharProfileTable.ImportMethod.Full))
        return;
      this.logger.Log("Finished importing", Array.Empty<object>());
    }

    protected virtual void BulkImport_Click(object sender, RoutedEventArgs e)
    {
      if (!this.GameWasClosed)
      {
        if (App.GameRunning)
        {
          if (this.CharacterProfileOffsets != null && this.CharacterProfileOffsets.Count > 0)
          {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "(All supported formats)|*.json";
            openFileDialog1.Title = "Open Bulk Profile";
            openFileDialog1.Multiselect = false;
            OpenFileDialog openFileDialog2 = openFileDialog1;
            bool? nullable = openFileDialog2.ShowDialog();
            bool flag = true;
            if (!(nullable.GetValueOrDefault() == flag & nullable.HasValue))
              return;
            TreeView tree = ((FlatbufferControl) this.Parent).Tree;
            List<BulkCharacterProfile> bulkProfiles = JsonConvert.DeserializeObject<List<BulkCharacterProfile>>(File.ReadAllText(openFileDialog2.FileName));
            MetaTaskWindow.Show("Importing Profiles", "Hold tight.", (MetaTaskCallback) (task =>
            {
              foreach (BulkCharacterProfile characterProfile in bulkProfiles)
              {
                string str;
                foreach (long characterProfileOffset in (IEnumerable<long>) this.CharacterProfileOffsets)
                {
                  long num = characterProfileOffset + (long) (App.CurrentGame.Memory.Regions["ProfileSize"] * (int) characterProfile.slot);
                  App.MemoryManager.Queue(App.CurrentGame.Exe, num, ref str);
                  App.MemoryManager.Write(BitConverter.GetBytes((ushort) 0), App.CurrentGame.Memory.ProfileOffsets["Category"]);
                  App.MemoryManager.Write(BitConverter.GetBytes(characterProfile.weight), App.CurrentGame.Memory.ProfileOffsets["Weight"]);
                  App.MemoryManager.WriteByte(characterProfile.weight_class, App.CurrentGame.Memory.ProfileOffsets["Weight_Class"]);
                  App.MemoryManager.WriteByte(characterProfile.wrestler_type, App.CurrentGame.Memory.ProfileOffsets["Wrestler_Type"]);
                  App.MemoryManager.Write(characterProfile.ai_attributes.ToArray(), App.CurrentGame.Memory.ProfileOffsets["Ai_Attributes"]);
                  App.MemoryManager.Write(characterProfile.attributes.ToArray(), App.CurrentGame.Memory.ProfileOffsets["Attributes"]);
                  App.MemoryManager.WriteByte(characterProfile.crowd_balance, App.CurrentGame.Memory.ProfileOffsets["Crowd_Balance"]);
                  App.MemoryManager.WriteByte(characterProfile.crowd_reaction, App.CurrentGame.Memory.ProfileOffsets["Crowd_Reaction"]);
                  byte[] numArray = new byte[characterProfile.hit_point.Count];
                  for (int index = 0; index < numArray.Length; ++index)
                    numArray[index] = (byte) (characterProfile.hit_point[index] / 40);
                  App.MemoryManager.Write(numArray, App.CurrentGame.Memory.ProfileOffsets["Hit_Point_Ratio"]);
                  App.MemoryManager.Write(characterProfile.personality_traits.ToArray(), App.CurrentGame.Memory.ProfileOffsets["Personality_Traits"]);
                  App.MemoryManager.WriteByte(characterProfile.moves_payback[0], App.CurrentGame.Memory.ProfileOffsets["Payback_1_Flag"]);
                  App.MemoryManager.WriteByte(characterProfile.moves_payback[1], App.CurrentGame.Memory.ProfileOffsets["Payback_2_Flag"]);
                  ushort minValue = (ushort) HeightConverter.CalculateValueRange(characterProfile.height).minValue;
                  App.MemoryManager.Write(BitConverter.GetBytes(minValue), App.CurrentGame.Memory.ProfileOffsets["Height"]);
                  App.MemoryManager.Release();
                }
                foreach (long characterMotionOffset in (IEnumerable<long>) this.CharacterMotionOffsets)
                {
                  long num = characterMotionOffset + (long) (App.CurrentGame.Memory.Regions["MotionSize"] * (int) characterProfile.slot);
                  App.MemoryManager.Queue(App.CurrentGame.Exe, num, ref str);
                  App.MemoryManager.Write(characterProfile.moves_payback.ToArray(), App.CurrentGame.Memory.MoveOffsets["Moves_Payback"]);
                  App.MemoryManager.Release();
                }
                this.logger.Log("Imported [Character Data][{0}]", new object[1]
                {
                  (object) characterProfile.slot.ToString()
                });
              }
            }));
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
    }

    protected virtual void PrimeMemory_Click(object sender, RoutedEventArgs e)
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
            ProfileCleanTable.RemoveAt(ProfileCleanTable.Count - 1);
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
          Icon = "TextBoxOutline"
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

    public enum ImportMethod
    {
      Full,
      Motion,
      Moveset,
      Character,
    }
  }
}
