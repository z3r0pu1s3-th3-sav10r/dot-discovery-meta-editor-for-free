using Meta.Core;
using Meta.Core.Interfaces;
using Meta.Structures.Flatbuffers.WWE2K23;
using MetaEditor;
using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Windows;

#nullable enable
namespace Meta.Editor.Controls.CreationSuite
{
  [CreationControl]
  public class BeltCreationControl : CreationControl
  {
    public EditorBelt editorBelt;

    public BeltCreationControl(ILogger inLogger, MetaTabControl tab)
      : base(inLogger, tab)
    {
      this.logger.Log("[Editor][Belt Creation] Loading...", Array.Empty<object>());
      this.editorBelt = new EditorBelt(inLogger);
      this.Editors.Add((CreationEditor) this.editorBelt);
    }

    public override void OpenAs(Profile profile)
    {
      if (!profile.Type.Equals((object) (ProfileType) 1))
        return;
      WWE2K23_Generated_Belt Profile = JsonConvert.DeserializeObject<WWE2K23_Generated_Belt>(JsonConvert.SerializeObject(profile.Generated), new JsonSerializerSettings()
      {
        MissingMemberHandling = MissingMemberHandling.Ignore
      });
      if (Profile != null)
      {
        if (Profile.BeltDataTable != null)
        {
          this.editorBelt.Load(Profile);
        }
        else
        {
          int num = (int) MetaMessageBox.Show("Info or Motion data missing", "Meta Data Manager");
        }
      }
    }

    public override void SaveAs()
    {
      base.SaveAs();
      ((UIElement) this.editorBelt.PrimaryInfoPropertyGrid).UpdateLayout();
      ((FrameworkElement) this.editorBelt.PrimaryInfoPropertyGrid).ApplyTemplate();
      SaveFileDialog saveFileDialog1 = new SaveFileDialog();
      saveFileDialog1.Filter = "(All supported formats)|*.json";
      saveFileDialog1.Title = "Save Profile";
      SaveFileDialog saveFileDialog2 = saveFileDialog1;
      bool? nullable = saveFileDialog2.ShowDialog();
      bool flag = true;
      if (!(nullable.GetValueOrDefault() == flag & nullable.HasValue))
        return;
      Profile profile = new Profile()
      {
        Type = (ProfileType) 1
      };
      WWE2K23_Generated_Belt k23GeneratedBelt = new WWE2K23_Generated_Belt()
      {
        BeltData_AssetMap = new BeltsMapTable(),
        BeltDataTable = new BeltInfo()
      };
      k23GeneratedBelt.BeltDataTable.id = this.editorBelt.beltPrimaryInfo.BeltSlotID;
      k23GeneratedBelt.BeltDataTable.meta = new BeltMetaTable();
      k23GeneratedBelt.BeltDataTable.meta.type = (byte) (long) this.editorBelt.beltPrimaryInfo.BeltType.Id;
      k23GeneratedBelt.BeltDataTable.meta.belt_name_id = this.editorBelt.beltPrimaryInfo.BeltBrandFullName;
      k23GeneratedBelt.BeltDataTable.meta.belt_name_2_id = this.editorBelt.beltPrimaryInfo.BeltFullName;
      k23GeneratedBelt.BeltDataTable.meta.belt_champion_id = this.editorBelt.beltPrimaryInfo.BeltChampionName;
      k23GeneratedBelt.BeltDataTable.meta.belt_name_3_id = 712412311U;
      k23GeneratedBelt.BeltDataTable.meta.call_id = this.editorBelt.beltPrimaryInfo.BeltCallID;
      k23GeneratedBelt.BeltDataTable.meta.is_female = this.editorBelt.beltPrimaryInfo.BeltIsFemale;
      k23GeneratedBelt.BeltDataTable.meta.no_heavyweights = this.editorBelt.beltPrimaryInfo.BeltNoHeavyweights;
      k23GeneratedBelt.BeltDataTable.meta.is_tag_team = this.editorBelt.beltPrimaryInfo.BeltIsTagTeam;
      k23GeneratedBelt.BeltDataTable.meta.default_champion_0 = new ushort[0];
      k23GeneratedBelt.BeltDataTable.meta.default_champion_1 = new ushort[2]
      {
        this.editorBelt.beltPrimaryInfo.BeltDefaultChampion1,
        this.editorBelt.beltPrimaryInfo.BeltDefaultChampion2
      };
      k23GeneratedBelt.BeltDataTable.meta.default_champion_2 = new ushort[2]
      {
        this.editorBelt.beltPrimaryInfo.BeltDefaultChampion1,
        this.editorBelt.beltPrimaryInfo.BeltDefaultChampion2
      };
      k23GeneratedBelt.BeltDataTable.meta.visual = new Visual()
      {
        belt_all = this.editorBelt.beltSecondaryInfo.BeltRenderPath.HashTexture(App.CurrentGame.Folders),
        belt_all_ct = this.editorBelt.beltSecondaryInfo.BeltRenderPath.HashTexture(App.CurrentGame.Folders),
        belt_front = this.editorBelt.beltSecondaryInfo.BeltRenderPath.HashTexture(App.CurrentGame.Folders),
        belt_side = this.editorBelt.beltSecondaryInfo.BeltRenderPath.HashTexture(App.CurrentGame.Folders),
        belt_strap = this.editorBelt.beltSecondaryInfo.BeltRenderPath.HashTexture(App.CurrentGame.Folders)
      };
      k23GeneratedBelt.BeltDataTable.meta.movie_data_1 = new MovieData1()
      {
        string_id_1 = this.editorBelt.beltPrimaryInfo.BeltFullName,
        string_id_2 = this.editorBelt.beltPrimaryInfo.BeltFullName
      };
      if (((byte) (long) this.editorBelt.beltPrimaryInfo.BeltType.Id).Equals((byte) 7))
      {
        k23GeneratedBelt.BeltDataTable.meta.movie_data_1.bk2 = uint.Parse("5" + this.editorBelt.beltPrimaryInfo.BeltMovieBK2ID.ToString().PadLeft(3, '0') + "00");
        k23GeneratedBelt.BeltDataTable.meta.movie_data_1.unk_1 = 489U;
      }
      k23GeneratedBelt.BeltDataTable.meta.movie_data_2 = new MovieData2();
      k23GeneratedBelt.BeltData_AssetMap.id = this.editorBelt.beltPrimaryInfo.BeltSlotID;
      k23GeneratedBelt.BeltData_AssetMap.data = new BeltsDataMap[3];
      for (int index = 0; index < k23GeneratedBelt.BeltData_AssetMap.data.Length; ++index)
      {
        k23GeneratedBelt.BeltData_AssetMap.data[index] = new BeltsDataMap();
        if (index.Equals(0))
        {
          k23GeneratedBelt.BeltData_AssetMap.data[index].mdl_path = this.editorBelt.beltSecondaryInfo.CutsceneMDLPath.Hash(App.CurrentGame.Folders);
          k23GeneratedBelt.BeltData_AssetMap.data[index].belt_textures_path = this.editorBelt.beltSecondaryInfo.CutsceneTexturesPath.Hash(App.CurrentGame.Folders);
        }
        else if (index.Equals(1))
        {
          k23GeneratedBelt.BeltData_AssetMap.data[index].mdl_path = this.editorBelt.beltSecondaryInfo.DefaultBeltMDLPath.Hash(App.CurrentGame.Folders);
          k23GeneratedBelt.BeltData_AssetMap.data[index].belt_textures_path = this.editorBelt.beltSecondaryInfo.DefaultTexturesPath.Hash(App.CurrentGame.Folders);
          k23GeneratedBelt.BeltData_AssetMap.data[index].havok_path = this.editorBelt.beltSecondaryInfo.DefaultHavokFolderPath.Hash(App.CurrentGame.Folders);
          k23GeneratedBelt.BeltData_AssetMap.data[index].propconfig_global_jsfb = this.editorBelt.beltSecondaryInfo.DefaultPropConfigPath.Hash(App.CurrentGame.Folders);
        }
        else if (index.Equals(2))
        {
          k23GeneratedBelt.BeltData_AssetMap.data[index].mdl_path = this.editorBelt.beltSecondaryInfo.LadderMDLPath.Hash(App.CurrentGame.Folders);
          k23GeneratedBelt.BeltData_AssetMap.data[index].belt_textures_path = this.editorBelt.beltSecondaryInfo.LadderTexturesPath.Hash(App.CurrentGame.Folders);
        }
      }
      profile.Generated = (object) k23GeneratedBelt;
      JsonSerializerSettings settings = new JsonSerializerSettings()
      {
        DefaultValueHandling = DefaultValueHandling.Ignore,
        MissingMemberHandling = MissingMemberHandling.Ignore,
        Formatting = Formatting.Indented,
        NullValueHandling = NullValueHandling.Ignore
      };
      File.WriteAllText(saveFileDialog2.FileName, JsonConvert.SerializeObject((object) profile, settings));
    }
  }
}
