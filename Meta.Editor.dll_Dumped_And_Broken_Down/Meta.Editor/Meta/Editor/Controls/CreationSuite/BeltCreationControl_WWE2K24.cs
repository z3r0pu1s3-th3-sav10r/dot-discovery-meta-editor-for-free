using Meta.Core;
using Meta.Core.Interfaces;
using Meta.Structures.Flatbuffers.WWE2K23;
using Meta.Structures.Flatbuffers.WWE2K24;
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
  public class BeltCreationControl_WWE2K24 : CreationControl
  {
    public EditorBelt_WWE2K24 editorBelt;

    public BeltCreationControl_WWE2K24(ILogger inLogger, MetaTabControl tab)
      : base(inLogger, tab)
    {
      this.logger.Log("[Editor][Belt Creation] Loading...", Array.Empty<object>());
      this.editorBelt = new EditorBelt_WWE2K24(inLogger);
      this.Editors.Add((CreationEditor) this.editorBelt);
    }

    public override void OpenAs(Profile profile)
    {
      if (!profile.Type.Equals((object) (ProfileType) 1))
        return;
      WWE2K24_Generated_Belt Profile = JsonConvert.DeserializeObject<WWE2K24_Generated_Belt>(JsonConvert.SerializeObject(profile.Generated), new JsonSerializerSettings()
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
      WWE2K24_Generated_Belt k24GeneratedBelt = new WWE2K24_Generated_Belt()
      {
        BeltData_AssetMap = new BeltsMapTable(),
        BeltDataTable = new BeltInfo()
      };
      k24GeneratedBelt.BeltDataTable.belt_id = this.editorBelt.beltPrimaryInfo.BeltSlotID;
      k24GeneratedBelt.BeltDataTable.meta = new BeltMetaTable();
      k24GeneratedBelt.BeltDataTable.meta.type = (byte) 1;
      k24GeneratedBelt.BeltDataTable.meta.belt_name_id = this.editorBelt.beltPrimaryInfo.BeltBrandFullName;
      k24GeneratedBelt.BeltDataTable.meta.belt_name_2_id = this.editorBelt.beltPrimaryInfo.BeltFullName;
      k24GeneratedBelt.BeltDataTable.meta.belt_champion_id = this.editorBelt.beltPrimaryInfo.BeltChampionName;
      k24GeneratedBelt.BeltDataTable.meta.belt_name_3_id = 712412311U;
      k24GeneratedBelt.BeltDataTable.meta.call_id = this.editorBelt.beltPrimaryInfo.BeltCallID;
      k24GeneratedBelt.BeltDataTable.meta.is_female = this.editorBelt.beltPrimaryInfo.BeltIsFemale;
      k24GeneratedBelt.BeltDataTable.meta.no_heavyweights = this.editorBelt.beltPrimaryInfo.BeltNoHeavyweights;
      k24GeneratedBelt.BeltDataTable.meta.is_tag_team = this.editorBelt.beltPrimaryInfo.BeltIsTagTeam;
      k24GeneratedBelt.BeltDataTable.meta.default_champion_0 = new ushort[0];
      k24GeneratedBelt.BeltDataTable.meta.default_champion_1 = new ushort[2]
      {
        this.editorBelt.beltPrimaryInfo.BeltDefaultChampion1,
        this.editorBelt.beltPrimaryInfo.BeltDefaultChampion2
      };
      k24GeneratedBelt.BeltDataTable.meta.default_champion_2 = new ushort[2]
      {
        this.editorBelt.beltPrimaryInfo.BeltDefaultChampion1,
        this.editorBelt.beltPrimaryInfo.BeltDefaultChampion2
      };
      k24GeneratedBelt.BeltDataTable.meta.visual = new Visual()
      {
        belt_all = this.editorBelt.beltSecondaryInfo.BeltRenderPath.HashTexture(App.CurrentGame.Folders),
        belt_all_ct = this.editorBelt.beltSecondaryInfo.BeltRenderPath.HashTexture(App.CurrentGame.Folders),
        belt_front = this.editorBelt.beltSecondaryInfo.BeltRenderPath.HashTexture(App.CurrentGame.Folders),
        belt_side = this.editorBelt.beltSecondaryInfo.BeltRenderPath.HashTexture(App.CurrentGame.Folders),
        belt_strap = this.editorBelt.beltSecondaryInfo.BeltRenderPath.HashTexture(App.CurrentGame.Folders)
      };
      k24GeneratedBelt.BeltDataTable.meta.movie_data_1 = new MovieData1()
      {
        string_id_1 = this.editorBelt.beltPrimaryInfo.BeltFullName,
        string_id_2 = this.editorBelt.beltPrimaryInfo.BeltFullName
      };
      k24GeneratedBelt.BeltDataTable.meta.movie_data_1.bk2 = uint.MaxValue;
      if (((byte) (long) this.editorBelt.beltPrimaryInfo.BeltType.Id).Equals((byte) 2))
        k24GeneratedBelt.BeltDataTable.meta.movie_data_1.bk2 = this.editorBelt.beltPrimaryInfo.BeltMovieBK2ID;
      k24GeneratedBelt.BeltDataTable.meta.movie_data_2 = new MovieData2();
      k24GeneratedBelt.BeltData_AssetMap.id = this.editorBelt.beltPrimaryInfo.BeltSlotID;
      k24GeneratedBelt.BeltData_AssetMap.data = new BeltsDataMap[3];
      for (int index = 0; index < k24GeneratedBelt.BeltData_AssetMap.data.Length; ++index)
      {
        k24GeneratedBelt.BeltData_AssetMap.data[index] = new BeltsDataMap();
        if (index.Equals(0))
        {
          k24GeneratedBelt.BeltData_AssetMap.data[index].mdl_path = this.editorBelt.beltSecondaryInfo.CutsceneMDLPath.Hash(App.CurrentGame.Folders);
          k24GeneratedBelt.BeltData_AssetMap.data[index].belt_textures_path = this.editorBelt.beltSecondaryInfo.CutsceneTexturesPath.Hash(App.CurrentGame.Folders);
        }
        else if (index.Equals(1))
        {
          k24GeneratedBelt.BeltData_AssetMap.data[index].mdl_path = this.editorBelt.beltSecondaryInfo.DefaultBeltMDLPath.Hash(App.CurrentGame.Folders);
          k24GeneratedBelt.BeltData_AssetMap.data[index].belt_textures_path = this.editorBelt.beltSecondaryInfo.DefaultTexturesPath.Hash(App.CurrentGame.Folders);
          k24GeneratedBelt.BeltData_AssetMap.data[index].havok_path = this.editorBelt.beltSecondaryInfo.DefaultHavokFolderPath.Hash(App.CurrentGame.Folders);
          k24GeneratedBelt.BeltData_AssetMap.data[index].propconfig_global_jsfb = this.editorBelt.beltSecondaryInfo.DefaultPropConfigPath.Hash(App.CurrentGame.Folders);
        }
        else if (index.Equals(2))
        {
          k24GeneratedBelt.BeltData_AssetMap.data[index].mdl_path = this.editorBelt.beltSecondaryInfo.LadderMDLPath.Hash(App.CurrentGame.Folders);
          k24GeneratedBelt.BeltData_AssetMap.data[index].belt_textures_path = this.editorBelt.beltSecondaryInfo.LadderTexturesPath.Hash(App.CurrentGame.Folders);
        }
      }
      profile.Generated = (object) k24GeneratedBelt;
      JsonSerializerSettings settings = new JsonSerializerSettings()
      {
        DefaultValueHandling = DefaultValueHandling.Ignore,
        MissingMemberHandling = MissingMemberHandling.Ignore,
        Formatting = Formatting.Indented,
        NullValueHandling = NullValueHandling.Ignore
      };
      try
      {
        File.WriteAllText(saveFileDialog2.FileName, JsonConvert.SerializeObject((object) profile, settings));
        this.logger.Log("Export successful. File saved at: " + saveFileDialog2.FileName, Array.Empty<object>());
      }
      catch (Exception ex)
      {
        this.logger.Log("An error occurred while exportingt: " + ex.Message, Array.Empty<object>());
      }
    }
  }
}
