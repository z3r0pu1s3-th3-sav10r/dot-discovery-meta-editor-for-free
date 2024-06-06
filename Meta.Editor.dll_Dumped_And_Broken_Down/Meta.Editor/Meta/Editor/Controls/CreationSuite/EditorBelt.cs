using Meta.Core.Interfaces;
using MetaEditor;
using Newtonsoft.Json;
using PropertyTools.DataAnnotations;
using PropertyTools.Wpf;
using System.Collections.ObjectModel;
using System.Windows;

#nullable enable
namespace Meta.Editor.Controls.CreationSuite
{
  public class EditorBelt : CreationEditor
  {
    private const string PART_PrimaryInfoPropertyGrid = "PART_PrimaryInfoPropertyGrid";
    public PropertyGrid PrimaryInfoPropertyGrid;
    private const string PART_SecondaryInfoPropertyGrid = "PART_SecondaryInfoPropertyGrid";
    public PropertyGrid SecondaryInfoPropertyGrid;
    public EditorBelt.BeltBasicInfo beltPrimaryInfo;
    public EditorBelt.BeltMappingInfo beltSecondaryInfo;

    public override string Title => "Info";

    public override string Icon => "Trophy";

    public MetaPropertyGridFactory MetaPropertyGridFactory { get; set; }

    public EditorBelt.BeltBasicInfo BeltInfo
    {
      get => (EditorBelt.BeltBasicInfo) this.PrimaryInfoPropertyGrid.SelectedObject;
    }

    public EditorBelt.BeltMappingInfo BeltMapping
    {
      get => (EditorBelt.BeltMappingInfo) this.SecondaryInfoPropertyGrid.SelectedObject;
    }

    public EditorBelt(ILogger inLogger)
      : base(inLogger)
    {
      this.MetaPropertyGridFactory = new MetaPropertyGridFactory();
      this.beltPrimaryInfo = new EditorBelt.BeltBasicInfo();
      this.beltPrimaryInfo.LoadDefaults();
      this.beltSecondaryInfo = new EditorBelt.BeltMappingInfo();
      this.beltSecondaryInfo.LoadDefaults();
    }

    static EditorBelt()
    {
      FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof (EditorBelt), (PropertyMetadata) new FrameworkPropertyMetadata((object) typeof (EditorBelt)));
    }

    public override void OnApplyTemplate()
    {
      base.OnApplyTemplate();
      this.PrimaryInfoPropertyGrid = this.GetTemplateChild("PART_PrimaryInfoPropertyGrid") as PropertyGrid;
      this.PrimaryInfoPropertyGrid.ControlFactory = (IPropertyGridControlFactory) this.MetaPropertyGridFactory;
      this.PrimaryInfoPropertyGrid.SelectedObject = (object) this.beltPrimaryInfo;
      this.SecondaryInfoPropertyGrid = this.GetTemplateChild("PART_SecondaryInfoPropertyGrid") as PropertyGrid;
      this.SecondaryInfoPropertyGrid.ControlFactory = (IPropertyGridControlFactory) this.MetaPropertyGridFactory;
      this.SecondaryInfoPropertyGrid.SelectedObject = (object) this.beltSecondaryInfo;
    }

    public void Load(WWE2K23_Generated_Belt Profile)
    {
      this.beltPrimaryInfo = new EditorBelt.BeltBasicInfo();
      this.beltPrimaryInfo.LoadDefaults();
      this.beltSecondaryInfo = new EditorBelt.BeltMappingInfo();
      this.beltSecondaryInfo.LoadDefaults();
      this.beltPrimaryInfo.BeltType = this.beltPrimaryInfo.BeltTypes.Get<byte>((object) Profile.BeltDataTable.meta.type);
      this.beltPrimaryInfo.BeltSlotID = Profile.BeltDataTable.id;
      this.beltPrimaryInfo.BeltFullName = Profile.BeltDataTable.meta.belt_name_2_id;
      this.beltPrimaryInfo.BeltChampionName = Profile.BeltDataTable.meta.belt_champion_id;
      this.beltPrimaryInfo.BeltBrandFullName = Profile.BeltDataTable.meta.belt_name_id;
      this.beltPrimaryInfo.BeltDefaultChampion1 = Profile.BeltDataTable.meta.default_champion_1[0];
      this.beltPrimaryInfo.BeltDefaultChampion2 = Profile.BeltDataTable.meta.default_champion_1[1];
      this.beltPrimaryInfo.BeltCallID = Profile.BeltDataTable.meta.call_id;
      this.beltPrimaryInfo.BeltIsTagTeam = Profile.BeltDataTable.meta.is_tag_team;
      this.beltPrimaryInfo.BeltIsFemale = Profile.BeltDataTable.meta.is_female;
      this.beltPrimaryInfo.BeltNoHeavyweights = Profile.BeltDataTable.meta.no_heavyweights;
      uint result;
      if (Profile.BeltDataTable.meta.movie_data_1.bk2 > 0U && uint.TryParse(Profile.BeltDataTable.meta.movie_data_1.bk2.ToString().Substring(1, 3), out result))
        this.beltPrimaryInfo.BeltMovieBK2ID = result;
      this.beltSecondaryInfo.BeltRenderPath = Profile.BeltDataTable.meta.visual.belt_all.ToString();
      ulong num;
      if (Profile.BeltData_AssetMap.data[0] != null)
      {
        EditorBelt.BeltMappingInfo beltSecondaryInfo1 = this.beltSecondaryInfo;
        num = Profile.BeltData_AssetMap.data[0].mdl_path;
        string str1 = num.ToString();
        beltSecondaryInfo1.CutsceneMDLPath = str1;
        EditorBelt.BeltMappingInfo beltSecondaryInfo2 = this.beltSecondaryInfo;
        num = Profile.BeltData_AssetMap.data[0].belt_textures_path;
        string str2 = num.ToString();
        beltSecondaryInfo2.CutsceneTexturesPath = str2;
      }
      if (Profile.BeltData_AssetMap.data[1] != null)
      {
        EditorBelt.BeltMappingInfo beltSecondaryInfo3 = this.beltSecondaryInfo;
        num = Profile.BeltData_AssetMap.data[1].mdl_path;
        string str3 = num.ToString();
        beltSecondaryInfo3.DefaultBeltMDLPath = str3;
        EditorBelt.BeltMappingInfo beltSecondaryInfo4 = this.beltSecondaryInfo;
        num = Profile.BeltData_AssetMap.data[1].havok_path;
        string str4 = num.ToString();
        beltSecondaryInfo4.DefaultHavokFolderPath = str4;
        EditorBelt.BeltMappingInfo beltSecondaryInfo5 = this.beltSecondaryInfo;
        num = Profile.BeltData_AssetMap.data[1].propconfig_global_jsfb;
        string str5 = num.ToString();
        beltSecondaryInfo5.DefaultPropConfigPath = str5;
        EditorBelt.BeltMappingInfo beltSecondaryInfo6 = this.beltSecondaryInfo;
        num = Profile.BeltData_AssetMap.data[1].belt_textures_path;
        string str6 = num.ToString();
        beltSecondaryInfo6.DefaultTexturesPath = str6;
      }
      if (Profile.BeltData_AssetMap.data[2] != null)
      {
        EditorBelt.BeltMappingInfo beltSecondaryInfo7 = this.beltSecondaryInfo;
        num = Profile.BeltData_AssetMap.data[2].mdl_path;
        string str7 = num.ToString();
        beltSecondaryInfo7.LadderMDLPath = str7;
        EditorBelt.BeltMappingInfo beltSecondaryInfo8 = this.beltSecondaryInfo;
        num = Profile.BeltData_AssetMap.data[2].belt_textures_path;
        string str8 = num.ToString();
        beltSecondaryInfo8.LadderTexturesPath = str8;
      }
      this.PrimaryInfoPropertyGrid.SelectedObject = (object) this.beltPrimaryInfo;
      this.SecondaryInfoPropertyGrid.SelectedObject = (object) this.beltSecondaryInfo;
    }

    public override void Shutdown()
    {
      base.Shutdown();
      ((FrameworkElement) this.PrimaryInfoPropertyGrid).DataContext = (object) null;
      this.PrimaryInfoPropertyGrid.SelectedObject = (object) null;
    }

    public class BeltBasicInfo
    {
      public BeltBasicInfo()
      {
        this.BeltTypes = JsonConvert.DeserializeObject<ObservableCollection<JObject>>(JsonConvert.SerializeObject(App.FileData[App.Game][nameof (BeltType)]));
      }

      public void LoadDefaults() => this.BeltType = this.BeltTypes[0];

      [Category("Basic Info")]
      [DisplayName("Belt Type")]
      [ItemsSourceProperty("BeltTypes")]
      [Important]
      public JObject BeltType { get; set; }

      [Category("Basic Info")]
      [DisplayName("Slot ID")]
      public uint BeltSlotID { get; set; } = 100;

      [Category("Basic Info")]
      [DisplayName("Default Champion 1")]
      public ushort BeltDefaultChampion1 { get; set; } = ushort.MaxValue;

      [Category("Basic Info")]
      [DisplayName("Default Champion 2")]
      public ushort BeltDefaultChampion2 { get; set; } = ushort.MaxValue;

      [Category("Basic Info")]
      [DisplayName("Call ID")]
      public uint BeltCallID { get; set; } = 31;

      [Category("Basic Info")]
      [DisplayName("Tag Team")]
      public bool BeltIsTagTeam { get; set; } = false;

      [Category("Basic Info")]
      [DisplayName("Female")]
      public bool BeltIsFemale { get; set; } = false;

      [Category("Basic Info")]
      [DisplayName("No Heavyweights")]
      public bool BeltNoHeavyweights { get; set; } = false;

      [Category("Names")]
      [DisplayName("Brand Full Name")]
      [Description("The full name of the belt plus the brand name e.g WWE WOMEN'S TAG TEAM CHAMPIONSHIP")]
      public uint BeltBrandFullName { get; set; } = 1562083740;

      [Category("Names")]
      [DisplayName("Full Name")]
      [Description("The full name of the belt e.g WOMEN'S TAG TEAM CHAMPIONSHIP")]
      public uint BeltFullName { get; set; } = 1562083740;

      [Category("Names")]
      [DisplayName("Champion Name")]
      [Description("The champion name of the belt e.g WORLD HEAVYWEIGHT CHAMPION")]
      public uint BeltChampionName { get; set; } = 2672352231;

      [Category("Movies")]
      [DisplayName("Match Intro BK2 ID")]
      public uint BeltMovieBK2ID { get; set; } = 164;

      [Browsable(false)]
      public ObservableCollection<JObject> BeltTypes { get; set; }
    }

    public class BeltMappingInfo
    {
      public void LoadDefaults()
      {
      }

      [Category("Render")]
      [DisplayName("Default")]
      [InputFilePath(".dds")]
      [FilterProperty("DDSFilter")]
      public string BeltRenderPath { get; set; }

      [Category("Cutscene Belt")]
      [DisplayName("MDL Path")]
      [InputFilePath(".mdl")]
      [FilterProperty("MDLFilter")]
      public string CutsceneMDLPath { get; set; }

      [Category("Cutscene Belt")]
      [DisplayName("Textures Path")]
      [MetaDirectorySelect]
      public string CutsceneTexturesPath { get; set; }

      [Category("Default Belt")]
      [DisplayName("MDL Path")]
      [InputFilePath(".mdl")]
      [FilterProperty("MDLFilter")]
      public string DefaultBeltMDLPath { get; set; }

      [Category("Default Belt")]
      [DisplayName("Prop Config JSFB Path")]
      [InputFilePath(".jsfb")]
      [FilterProperty("JSFBFilter")]
      public string DefaultPropConfigPath { get; set; } = "2381046570996296543";

      [Category("Default Belt")]
      [DisplayName("Havok Folder Path")]
      [MetaDirectorySelect]
      public string DefaultHavokFolderPath { get; set; }

      [Category("Default Belt")]
      [DisplayName("Textures Path")]
      [MetaDirectorySelect]
      public string DefaultTexturesPath { get; set; }

      [Category("Ladder Belt")]
      [DisplayName("MDL Path")]
      [InputFilePath(".mdl")]
      [FilterProperty("MDLFilter")]
      public string LadderMDLPath { get; set; }

      [Category("Ladder Belt")]
      [DisplayName("Textures Path")]
      [MetaDirectorySelect]
      public string LadderTexturesPath { get; set; }

      [Browsable(false)]
      public string BK2Filter => "BK2 files (*.bk2)|*.bk2";

      [Browsable(false)]
      public string DDSFilter => "DDS files (*.dds)|*.dds";

      [Browsable(false)]
      public string MDLFilter => "MDL files (*.mdl)|*.mdl";

      [Browsable(false)]
      public string JSFBFilter => "JSFB files (*.jsfb)|*.jsfb";
    }
  }
}
