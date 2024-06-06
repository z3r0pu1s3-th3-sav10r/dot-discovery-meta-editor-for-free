using Meta.Core;
using Meta.Core.Interfaces;
using Meta.Structures.Flatbuffers.WWE2K23;
using Meta.WWE2K23;
using MetaEditor;
using Newtonsoft.Json;
using PropertyTools.DataAnnotations;
using PropertyTools.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Windows;

#nullable enable
namespace Meta.Editor.Controls.CreationSuite
{
  [TemplatePart(Name = "PART_GeneralInfoPropertyGrid", Type = typeof (PropertyGrid))]
  [TemplatePart(Name = "PART_SecondaryInfoPropertyGrid", Type = typeof (PropertyGrid))]
  public class EditorMapping : CreationEditor
  {
    private const string PART_GeneralInfoPropertyGrid = "PART_GeneralInfoPropertyGrid";
    private const string PART_SecondaryInfoPropertyGrid = "PART_SecondaryInfoPropertyGrid";
    private PropertyGrid BasicInfoPropertyGrid;
    private PropertyGrid SecondaryMappingPropertyGrid;
    private EditorMapping.MappingPrimaryInfo mappingPrimaryInfo;
    private EditorMapping.MappingSecondaryInfo mappingSecondaryInfo;

    public EditorMapping.MappingPrimaryInfo Primaryinfo => this.mappingPrimaryInfo;

    public EditorMapping.MappingSecondaryInfo SecondaryInfo => this.mappingSecondaryInfo;

    public override string Title => "Mapping";

    public override string Icon => "Map";

    public MetaPropertyGridFactory MetaPropertyGridFactory { get; set; }

    public EditorMapping(ILogger inLogger)
      : base(inLogger)
    {
      this.DataContext = (object) this;
      this.MetaPropertyGridFactory = new MetaPropertyGridFactory();
      this.mappingPrimaryInfo = new EditorMapping.MappingPrimaryInfo();
      this.mappingPrimaryInfo.LoadDefaults();
      this.mappingSecondaryInfo = new EditorMapping.MappingSecondaryInfo();
      this.mappingSecondaryInfo.LoadDefaults();
    }

    static EditorMapping()
    {
      FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof (EditorMapping), (PropertyMetadata) new FrameworkPropertyMetadata((object) typeof (EditorMapping)));
    }

    public override void OnApplyTemplate()
    {
      base.OnApplyTemplate();
      this.BasicInfoPropertyGrid = this.GetTemplateChild("PART_GeneralInfoPropertyGrid") as PropertyGrid;
      this.BasicInfoPropertyGrid.ControlFactory = (IPropertyGridControlFactory) this.MetaPropertyGridFactory;
      this.BasicInfoPropertyGrid.SelectedObject = (object) this.mappingPrimaryInfo;
      this.SecondaryMappingPropertyGrid = this.GetTemplateChild("PART_SecondaryInfoPropertyGrid") as PropertyGrid;
      this.SecondaryMappingPropertyGrid.ControlFactory = (IPropertyGridControlFactory) this.MetaPropertyGridFactory;
      this.SecondaryMappingPropertyGrid.SelectedObject = (object) this.mappingSecondaryInfo;
    }

    public ObservableCollection<PropertyInfo> GetRenders()
    {
      return new ObservableCollection<PropertyInfo>(((IEnumerable<PropertyInfo>) this.mappingPrimaryInfo.GetType().GetProperties()).Select<PropertyInfo, PropertyInfo>((Func<PropertyInfo, PropertyInfo>) (pi => Attribute.GetCustomAttribute((MemberInfo) pi, typeof (CategoryAttribute)) is CategoryAttribute customAttribute && customAttribute.Category.Contains("Renders") ? pi : (PropertyInfo) null)).Where<PropertyInfo>((Func<PropertyInfo, bool>) (pi => pi != (PropertyInfo) null)));
    }

    public ObservableCollection<IGrouping<int, PropertyInfo>> GetAttireData()
    {
      return new ObservableCollection<IGrouping<int, PropertyInfo>>(((IEnumerable<PropertyInfo>) this.mappingSecondaryInfo.GetType().GetProperties()).Select<PropertyInfo, PropertyInfo>((Func<PropertyInfo, PropertyInfo>) (pi => Attribute.GetCustomAttribute((MemberInfo) pi, typeof (AttireAttribute)) is AttireAttribute ? pi : (PropertyInfo) null)).Where<PropertyInfo>((Func<PropertyInfo, bool>) (pi => pi != (PropertyInfo) null)).GroupBy<PropertyInfo, int>((Func<PropertyInfo, int>) (pi => (pi.GetCustomAttribute(typeof (AttireAttribute)) as AttireAttribute).id)));
    }

    public void Load(CharacterProfile_WWE2K23 Profile, Profile generated)
    {
      this.mappingPrimaryInfo = new EditorMapping.MappingPrimaryInfo();
      this.mappingPrimaryInfo.LoadDefaults();
      this.mappingSecondaryInfo = new EditorMapping.MappingSecondaryInfo();
      this.mappingSecondaryInfo.LoadDefaults();
      ObservableCollection<IGrouping<int, PropertyInfo>> attireData = this.GetAttireData();
      ObservableCollection<PropertyInfo> renders = this.GetRenders();
      WWE2K23_Generated_Character generatedCharacter = JsonConvert.DeserializeObject<WWE2K23_Generated_Character>(JsonConvert.SerializeObject(generated.Generated), new JsonSerializerSettings()
      {
        MissingMemberHandling = MissingMemberHandling.Ignore
      });
      if (generatedCharacter != null)
      {
        ulong num;
        if (generatedCharacter.CharacterMapping != null)
        {
          for (int i = 0; i < generatedCharacter.CharacterMapping.Count; i++)
          {
            IGrouping<int, PropertyInfo> source = attireData.FirstOrDefault<IGrouping<int, PropertyInfo>>((Func<IGrouping<int, PropertyInfo>, bool>) (g => g.Key.Equals(i)));
            PropertyInfo propertyInfo1 = source.ElementAt<PropertyInfo>(1);
            EditorMapping.MappingSecondaryInfo mappingSecondaryInfo1 = this.mappingSecondaryInfo;
            num = generatedCharacter.CharacterMapping[i].character_path;
            string str1 = num.ToString();
            propertyInfo1.SetValue((object) mappingSecondaryInfo1, (object) str1);
            PropertyInfo propertyInfo2 = source.ElementAt<PropertyInfo>(2);
            EditorMapping.MappingSecondaryInfo mappingSecondaryInfo2 = this.mappingSecondaryInfo;
            num = generatedCharacter.CharacterMapping[i].default_attire_path;
            string str2 = num.ToString();
            propertyInfo2.SetValue((object) mappingSecondaryInfo2, (object) str2);
            PropertyInfo propertyInfo3 = source.ElementAt<PropertyInfo>(3);
            EditorMapping.MappingSecondaryInfo mappingSecondaryInfo3 = this.mappingSecondaryInfo;
            num = generatedCharacter.CharacterMapping[i].default_attire_mdl_path;
            string str3 = num.ToString();
            propertyInfo3.SetValue((object) mappingSecondaryInfo3, (object) str3);
            PropertyInfo propertyInfo4 = source.ElementAt<PropertyInfo>(4);
            EditorMapping.MappingSecondaryInfo mappingSecondaryInfo4 = this.mappingSecondaryInfo;
            num = generatedCharacter.CharacterMapping[i].default_attire_mtls_path;
            string str4 = num.ToString();
            propertyInfo4.SetValue((object) mappingSecondaryInfo4, (object) str4);
            PropertyInfo propertyInfo5 = source.ElementAt<PropertyInfo>(5);
            EditorMapping.MappingSecondaryInfo mappingSecondaryInfo5 = this.mappingSecondaryInfo;
            num = generatedCharacter.CharacterMapping[i].basemodel_mdl_path;
            string str5 = num.ToString();
            propertyInfo5.SetValue((object) mappingSecondaryInfo5, (object) str5);
            PropertyInfo propertyInfo6 = source.ElementAt<PropertyInfo>(6);
            EditorMapping.MappingSecondaryInfo mappingSecondaryInfo6 = this.mappingSecondaryInfo;
            num = generatedCharacter.CharacterMapping[i].basemodel_mtls_path;
            string str6 = num.ToString();
            propertyInfo6.SetValue((object) mappingSecondaryInfo6, (object) str6);
            if (i > 0)
              source.ElementAt<PropertyInfo>(0).SetValue((object) this.mappingSecondaryInfo, (object) Profile.Info.additional_attire_names[i - 1]);
          }
          for (int index = 0; index < ((IEnumerable<Texture>) generatedCharacter.Renders.textures.type_a).Count<Texture>(); ++index)
          {
            PropertyInfo propertyInfo = renders.ElementAt<PropertyInfo>(index);
            EditorMapping.MappingPrimaryInfo mappingPrimaryInfo = this.mappingPrimaryInfo;
            num = generatedCharacter.Renders.textures.type_a[index].path;
            string str = num.ToString();
            propertyInfo.SetValue((object) mappingPrimaryInfo, (object) str);
          }
          this.mappingSecondaryInfo.WrestlerAttireCount = (EditorMapping.Attires) generatedCharacter.CharacterMapping.Count;
        }
        if (generatedCharacter.Movie != null)
        {
          EditorMapping.MappingPrimaryInfo mappingPrimaryInfo1 = this.mappingPrimaryInfo;
          num = generatedCharacter.Movie.apron.bk2;
          string str7 = num.ToString();
          mappingPrimaryInfo1.MovieApronBK2Path = str7;
          EditorMapping.MappingPrimaryInfo mappingPrimaryInfo2 = this.mappingPrimaryInfo;
          num = generatedCharacter.Movie.banner.bk2;
          string str8 = num.ToString();
          mappingPrimaryInfo2.MovieBannerBK2Path = str8;
          EditorMapping.MappingPrimaryInfo mappingPrimaryInfo3 = this.mappingPrimaryInfo;
          num = generatedCharacter.Movie.stage.bk2;
          string str9 = num.ToString();
          mappingPrimaryInfo3.MovieStageBK2Path = str9;
          EditorMapping.MappingPrimaryInfo mappingPrimaryInfo4 = this.mappingPrimaryInfo;
          num = generatedCharacter.Movie.barricade.bk2;
          string str10 = num.ToString();
          mappingPrimaryInfo4.MovieBarricadeBK2Path = str10;
        }
      }
      int index1 = 0;
      for (int i = 0; i < Profile.Info.crowd_signs.Count / 4; i++)
      {
        IGrouping<int, PropertyInfo> source = attireData.FirstOrDefault<IGrouping<int, PropertyInfo>>((Func<IGrouping<int, PropertyInfo>, bool>) (g => g.Key.Equals(i)));
        source.ElementAt<PropertyInfo>(7).SetValue((object) this.mappingSecondaryInfo, (object) this.mappingSecondaryInfo.CrowdSigns.Get<uint>((object) Profile.Info.crowd_signs[index1]));
        source.ElementAt<PropertyInfo>(8).SetValue((object) this.mappingSecondaryInfo, (object) this.mappingSecondaryInfo.CrowdSigns.Get<uint>((object) Profile.Info.crowd_signs[index1 + 1]));
        source.ElementAt<PropertyInfo>(9).SetValue((object) this.mappingSecondaryInfo, (object) this.mappingSecondaryInfo.CrowdSigns.Get<uint>((object) Profile.Info.crowd_signs[index1 + 2]));
        source.ElementAt<PropertyInfo>(10).SetValue((object) this.mappingSecondaryInfo, (object) this.mappingSecondaryInfo.CrowdSigns.Get<uint>((object) Profile.Info.crowd_signs[index1 + 3]));
        index1 += 4;
      }
      this.BasicInfoPropertyGrid.SelectedObject = (object) this.mappingPrimaryInfo;
      this.SecondaryMappingPropertyGrid.SelectedObject = (object) this.mappingSecondaryInfo;
    }

    public override void Shutdown()
    {
      base.Shutdown();
      ((FrameworkElement) this.BasicInfoPropertyGrid).DataContext = (object) null;
      this.BasicInfoPropertyGrid.SelectedObject = (object) null;
      ((FrameworkElement) this.SecondaryMappingPropertyGrid).DataContext = (object) null;
      this.SecondaryMappingPropertyGrid.SelectedObject = (object) null;
    }

    public enum Attires
    {
      One = 1,
      Two = 2,
      Three = 3,
      Four = 4,
      Five = 5,
      Six = 6,
      Seven = 7,
      Eight = 8,
      Nine = 9,
      Ten = 10, // 0x0000000A
    }

    public class MappingPrimaryInfo
    {
      public void LoadDefaults()
      {
      }

      [Category("Renders")]
      [DisplayName("Default")]
      [InputFilePath(".dds")]
      [FilterProperty("DDSFilter")]
      public string DefaultAttireRenderPath { get; set; }

      [Category("Renders")]
      [DisplayName("Attire 2")]
      [InputFilePath(".dds")]
      [FilterProperty("DDSFilter")]
      public string Attire2RenderPath { get; set; }

      [Category("Renders")]
      [DisplayName("Attire 3")]
      [InputFilePath(".dds")]
      [FilterProperty("DDSFilter")]
      public string Attire3RenderPath { get; set; }

      [Category("Renders")]
      [DisplayName("Attire 4")]
      [InputFilePath(".dds")]
      [FilterProperty("DDSFilter")]
      public string Attire4RenderPath { get; set; }

      [Category("Renders")]
      [DisplayName("Attire 5")]
      [InputFilePath(".dds")]
      [FilterProperty("DDSFilter")]
      public string Attire5RenderPath { get; set; }

      [Category("Renders")]
      [DisplayName("Attire 6")]
      [InputFilePath(".dds")]
      [FilterProperty("DDSFilter")]
      public string Attire6RenderPath { get; set; }

      [Category("Renders")]
      [DisplayName("Attire 7")]
      [InputFilePath(".dds")]
      [FilterProperty("DDSFilter")]
      public string Attire7RenderPath { get; set; }

      [Category("Renders")]
      [DisplayName("Attire 8")]
      [InputFilePath(".dds")]
      [FilterProperty("DDSFilter")]
      public string Attire8RenderPath { get; set; }

      [Category("Renders")]
      [DisplayName("Attire 9")]
      [InputFilePath(".dds")]
      [FilterProperty("DDSFilter")]
      public string Attire9RenderPath { get; set; }

      [Category("Renders")]
      [DisplayName("Attire 10")]
      [InputFilePath(".dds")]
      [FilterProperty("DDSFilter")]
      public string Attire10RenderPath { get; set; }

      [Category("Movie")]
      [DisplayName("Banner")]
      [InputFilePath(".bk2")]
      [FilterProperty("BK2Filter")]
      public string MovieBannerBK2Path { get; set; }

      [Category("Movie")]
      [DisplayName("Apron")]
      [InputFilePath(".bk2")]
      [FilterProperty("BK2Filter")]
      public string MovieApronBK2Path { get; set; }

      [Category("Movie")]
      [DisplayName("Stage")]
      [InputFilePath(".bk2")]
      [FilterProperty("BK2Filter")]
      public string MovieStageBK2Path { get; set; }

      [Category("Movie")]
      [DisplayName("Barricade")]
      [InputFilePath(".bk2")]
      [FilterProperty("BK2Filter")]
      public string MovieBarricadeBK2Path { get; set; }

      [Browsable(false)]
      public string BK2Filter => "BK2 files (*.bk2)|*.bk2";

      [Browsable(false)]
      public string DDSFilter => "DDS files (*.dds)|*.dds";
    }

    public class MappingSecondaryInfo
    {
      public MappingSecondaryInfo()
      {
        this.CrowdSigns = JsonConvert.DeserializeObject<ObservableCollection<JObjectCrowdSign>>(JsonConvert.SerializeObject(App.FileData[App.Game][nameof (CrowdSigns)]));
      }

      public void LoadDefaults()
      {
        this.WrestlerCrowdSignAttireDefault1 = this.CrowdSigns[1];
        this.WrestlerCrowdSignAttireDefault2 = (JObject) this.CrowdSigns[2];
        this.WrestlerCrowdSignAttireDefault3 = (JObject) this.CrowdSigns[3];
        this.WrestlerCrowdSignAttireDefault4 = (JObject) this.CrowdSigns[4];
      }

      [Browsable(false)]
      public ObservableCollection<JObjectCrowdSign> CrowdSigns { get; set; }

      [Category("Outfit Config")]
      [DisplayName("Attires")]
      [Description("Total number of available attires.")]
      public EditorMapping.Attires WrestlerAttireCount { get; set; } = EditorMapping.Attires.One;

      [Browsable(false)]
      public bool HasTwoAttires => this.WrestlerAttireCount == EditorMapping.Attires.Two;

      [Category("Default Attire")]
      [Attire(0)]
      [Browsable(false)]
      [DisplayName("Attire Name")]
      public uint DefaultAttireSDBID { get; set; }

      [Category("Default Attire")]
      [DisplayName("Character Folder Path")]
      [Attire(0)]
      [MetaDirectorySelect]
      public string DefaultAttireCharacterPath { get; set; }

      [Category("Default Attire")]
      [DisplayName("Attire Folder Path")]
      [Attire(0)]
      [MetaDirectorySelect]
      public string DefaultAttireCharacterAttirePath { get; set; }

      [Category("Default Attire")]
      [DisplayName("Attire MDL Path")]
      [Attire(0)]
      [InputFilePath(".mdl")]
      [FilterProperty("MDLFilter")]
      public string DefaultAttireMDLPath { get; set; }

      [Category("Default Attire")]
      [DisplayName("Attire MTLS Path")]
      [Attire(0)]
      [InputFilePath(".mtls")]
      [FilterProperty("MTLSFilter")]
      public string DefaultAttireMTLSPath { get; set; }

      [Category("Default Attire")]
      [DisplayName("BaseModel MDL Path")]
      [Attire(0)]
      [InputFilePath(".mdl")]
      [FilterProperty("MDLFilter")]
      public string DefaultAttireBaseModelMDLPath { get; set; }

      [Category("Default Attire")]
      [DisplayName("BaseModel MTLS Path")]
      [Attire(0)]
      [InputFilePath(".mtls")]
      [FilterProperty("MTLSFilter")]
      public string DefaultAttireBaseModelMTLSPath { get; set; }

      [Category("Default Attire")]
      [Attire(0)]
      [DisplayName("Crowd Sign 1")]
      [ItemsSourceProperty("CrowdSigns")]
      [CrowdSign]
      public JObjectCrowdSign WrestlerCrowdSignAttireDefault1 { get; set; }

      [Category("Default Attire")]
      [Attire(0)]
      [DisplayName("Crowd Sign 2")]
      [ItemsSourceProperty("CrowdSigns")]
      [CrowdSign]
      public JObject WrestlerCrowdSignAttireDefault2 { get; set; }

      [Category("Default Attire")]
      [Attire(0)]
      [DisplayName("Crowd Sign 3")]
      [ItemsSourceProperty("CrowdSigns")]
      [CrowdSign]
      public JObject WrestlerCrowdSignAttireDefault3 { get; set; }

      [Category("Default Attire")]
      [Attire(0)]
      [DisplayName("Crowd Sign 4")]
      [ItemsSourceProperty("CrowdSigns")]
      [CrowdSign]
      public JObject WrestlerCrowdSignAttireDefault4 { get; set; }

      [Category("2nd Attire")]
      [Attire(1)]
      [DisplayName("Attire Name")]
      public uint Attire2SDB { get; set; }

      [Category("2nd Attire")]
      [DisplayName("Character Folder Path")]
      [Attire(1)]
      [MetaDirectorySelect]
      public string Attire2CharacterPath { get; set; }

      [Category("2nd Attire")]
      [DisplayName("Attire Folder Path")]
      [Attire(1)]
      [MetaDirectorySelect]
      public string Attire2CharacterAttirePath { get; set; }

      [Category("2nd Attire")]
      [DisplayName("Attire MDL Path")]
      [Attire(1)]
      [InputFilePath(".mdl")]
      [FilterProperty("MDLFilter")]
      public string Attire2MDLPath { get; set; }

      [Category("2nd Attire")]
      [DisplayName("Attire MTLS Path")]
      [Attire(1)]
      [InputFilePath(".mtls")]
      [FilterProperty("MTLSFilter")]
      public string Attire2MTLSPath { get; set; }

      [Category("2nd Attire")]
      [DisplayName("BaseModel MDL Path")]
      [Attire(1)]
      [InputFilePath(".mdl")]
      [FilterProperty("MDLFilter")]
      public string Attire2BaseModelMDLPath { get; set; }

      [Category("2nd Attire")]
      [DisplayName("BaseModel MTLS Path")]
      [Attire(1)]
      [InputFilePath(".mtls")]
      [FilterProperty("MTLSFilter")]
      public string Attire2BaseModelMTLSPath { get; set; }

      [Category("2nd Attire")]
      [DisplayName("Crowd Sign 1")]
      [Attire(1)]
      [ItemsSourceProperty("CrowdSigns")]
      [CrowdSign]
      public JObject WrestlerCrowdSign1Attire2 { get; set; }

      [Category("2nd Attire")]
      [DisplayName("Crowd Sign 2")]
      [Attire(1)]
      [ItemsSourceProperty("CrowdSigns")]
      [CrowdSign]
      public JObject WrestlerCrowdSign2Attire2 { get; set; }

      [Category("2nd Attire")]
      [DisplayName("Crowd Sign 3")]
      [Attire(1)]
      [ItemsSourceProperty("CrowdSigns")]
      [CrowdSign]
      public JObject WrestlerCrowdSign3Attire2 { get; set; }

      [Category("2nd Attire")]
      [DisplayName("Crowd Sign 4")]
      [Attire(1)]
      [ItemsSourceProperty("CrowdSigns")]
      [CrowdSign]
      public JObject WrestlerCrowdSign4Attire2 { get; set; }

      [Category("3rd Attire")]
      [DisplayName("Attire Name")]
      [Attire(2)]
      public uint Attire3SDB { get; set; }

      [Category("3rd Attire")]
      [DisplayName("Character Folder Path")]
      [Attire(2)]
      [MetaDirectorySelect]
      public string Attire3CharacterPath { get; set; }

      [Category("3rd Attire")]
      [DisplayName("Attire Folder Path")]
      [Attire(2)]
      [MetaDirectorySelect]
      public string Attire3CharacterAttirePath { get; set; }

      [Category("3rd Attire")]
      [DisplayName("Attire MDL Path")]
      [Attire(2)]
      [InputFilePath(".mdl")]
      [FilterProperty("MDLFilter")]
      public string Attire3MDLPath { get; set; }

      [Category("3rd Attire")]
      [DisplayName("Attire MTLS Path")]
      [Attire(2)]
      [InputFilePath(".mtls")]
      [FilterProperty("MTLSFilter")]
      public string Attire3MTLSPath { get; set; }

      [Category("3rd Attire")]
      [DisplayName("BaseModel MDL Path")]
      [Attire(2)]
      [InputFilePath(".mdl")]
      [FilterProperty("MDLFilter")]
      public string Attire3BaseModelMDLPath { get; set; }

      [Category("3rd Attire")]
      [DisplayName("BaseModel MTLS Path")]
      [Attire(2)]
      [InputFilePath(".mtls")]
      [FilterProperty("MTLSFilter")]
      public string Attire3BaseModelMTLSPath { get; set; }

      [Category("3rd Attire")]
      [DisplayName("Crowd Sign 1")]
      [Attire(2)]
      [ItemsSourceProperty("CrowdSigns")]
      [CrowdSign]
      public JObject WrestlerCrowdSign1Attire3 { get; set; }

      [Category("3rd Attire")]
      [DisplayName("Crowd Sign 2")]
      [Attire(2)]
      [ItemsSourceProperty("CrowdSigns")]
      [CrowdSign]
      public JObject WrestlerCrowdSign2Attire3 { get; set; }

      [Category("3rd Attire")]
      [DisplayName("Crowd Sign 3")]
      [Attire(2)]
      [ItemsSourceProperty("CrowdSigns")]
      [CrowdSign]
      public JObject WrestlerCrowdSign3Attire3 { get; set; }

      [Category("3rd Attire")]
      [DisplayName("Crowd Sign 4")]
      [Attire(2)]
      [ItemsSourceProperty("CrowdSigns")]
      [CrowdSign]
      public JObject WrestlerCrowdSign4Attire3 { get; set; }

      [Category("4th Attire")]
      [DisplayName("Attire Name")]
      [Attire(3)]
      public uint Attire4SDB { get; set; }

      [Category("4th Attire")]
      [DisplayName("Character Folder Path")]
      [Attire(3)]
      [MetaDirectorySelect]
      public string Attire4CharacterPath { get; set; }

      [Category("4th Attire")]
      [DisplayName("Attire Folder Path")]
      [Attire(3)]
      [MetaDirectorySelect]
      public string Attire4CharacterAttirePath { get; set; }

      [Category("4th Attire")]
      [DisplayName("Attire MDL Path")]
      [Attire(3)]
      [InputFilePath(".mdl")]
      [FilterProperty("MDLFilter")]
      public string Attire4MDLPath { get; set; }

      [Category("4th Attire")]
      [DisplayName("Attire MTLS Path")]
      [Attire(3)]
      [InputFilePath(".mtls")]
      [FilterProperty("MTLSFilter")]
      public string Attire4MTLSPath { get; set; }

      [Category("4th Attire")]
      [DisplayName("BaseModel MDL Path")]
      [Attire(3)]
      [InputFilePath(".mdl")]
      [FilterProperty("MDLFilter")]
      public string Attire4BaseModelMDLPath { get; set; }

      [Category("4th Attire")]
      [DisplayName("BaseModel MTLS Path")]
      [Attire(3)]
      [InputFilePath(".mtls")]
      [FilterProperty("MTLSFilter")]
      public string Attire4BaseModelMTLSPath { get; set; }

      [Category("4th Attire")]
      [DisplayName("Crowd Sign 1")]
      [Attire(3)]
      [ItemsSourceProperty("CrowdSigns")]
      [CrowdSign]
      public JObject WrestlerCrowdSign1Attire4 { get; set; }

      [Category("4th Attire")]
      [DisplayName("Crowd Sign 2")]
      [Attire(3)]
      [ItemsSourceProperty("CrowdSigns")]
      [CrowdSign]
      public JObject WrestlerCrowdSign2Attire4 { get; set; }

      [Category("4th Attire")]
      [DisplayName("Crowd Sign 3")]
      [Attire(3)]
      [ItemsSourceProperty("CrowdSigns")]
      [CrowdSign]
      public JObject WrestlerCrowdSign3Attire4 { get; set; }

      [Category("4th Attire")]
      [DisplayName("Crowd Sign 4")]
      [Attire(3)]
      [ItemsSourceProperty("CrowdSigns")]
      [CrowdSign]
      public JObject WrestlerCrowdSign4Attire4 { get; set; }

      [Category("5th Attire")]
      [DisplayName("Attire Name")]
      [Attire(4)]
      public uint Attire5SDB { get; set; }

      [Category("5th Attire")]
      [DisplayName("Character Folder Path")]
      [Attire(4)]
      [MetaDirectorySelect]
      public string Attire5CharacterPath { get; set; }

      [Category("5th Attire")]
      [DisplayName("Attire Folder Path")]
      [Attire(4)]
      [MetaDirectorySelect]
      public string Attire5CharacterAttirePath { get; set; }

      [Category("5th Attire")]
      [DisplayName("Attire MDL Path")]
      [Attire(4)]
      [InputFilePath(".mdl")]
      [FilterProperty("MDLFilter")]
      public string Attire5MDLPath { get; set; }

      [Category("5th Attire")]
      [DisplayName("Attire MTLS Path")]
      [Attire(4)]
      [InputFilePath(".mtls")]
      [FilterProperty("MTLSFilter")]
      public string Attire5MTLSPath { get; set; }

      [Category("5th Attire")]
      [DisplayName("BaseModel MDL Path")]
      [Attire(4)]
      [InputFilePath(".mdl")]
      [FilterProperty("MDLFilter")]
      public string Attire5BaseModelMDLPath { get; set; }

      [Category("5th Attire")]
      [DisplayName("BaseModel MTLS Path")]
      [Attire(4)]
      [InputFilePath(".mtls")]
      [FilterProperty("MTLSFilter")]
      public string Attire5BaseModelMTLSPath { get; set; }

      [Category("5th Attire")]
      [DisplayName("Crowd Sign 1")]
      [Attire(4)]
      [ItemsSourceProperty("CrowdSigns")]
      [CrowdSign]
      public JObject WrestlerCrowdSign1Attire5 { get; set; }

      [Category("5th Attire")]
      [DisplayName("Crowd Sign 2")]
      [Attire(4)]
      [ItemsSourceProperty("CrowdSigns")]
      [CrowdSign]
      public JObject WrestlerCrowdSign2Attire5 { get; set; }

      [Category("5th Attire")]
      [DisplayName("Crowd Sign 3")]
      [Attire(4)]
      [ItemsSourceProperty("CrowdSigns")]
      [CrowdSign]
      public JObject WrestlerCrowdSign3Attire5 { get; set; }

      [Category("5th Attire")]
      [DisplayName("Crowd Sign 4")]
      [Attire(4)]
      [ItemsSourceProperty("CrowdSigns")]
      [CrowdSign]
      public JObject WrestlerCrowdSign4Attire5 { get; set; }

      [Category("6th Attire")]
      [Attire(5)]
      [DisplayName("Attire Name")]
      public uint Attire6SDB { get; set; }

      [Category("6th Attire")]
      [DisplayName("Character Folder Path")]
      [Attire(5)]
      [MetaDirectorySelect]
      public string Attire6CharacterPath { get; set; }

      [Category("6th Attire")]
      [DisplayName("Attire Folder Path")]
      [Attire(5)]
      [MetaDirectorySelect]
      public string Attire6CharacterAttirePath { get; set; }

      [Category("6th Attire")]
      [DisplayName("Attire MDL Path")]
      [Attire(5)]
      [InputFilePath(".mdl")]
      [FilterProperty("MDLFilter")]
      public string Attire6MDLPath { get; set; }

      [Category("6th Attire")]
      [DisplayName("Attire MTLS Path")]
      [Attire(5)]
      [InputFilePath(".mtls")]
      [FilterProperty("MTLSFilter")]
      public string Attire6MTLSPath { get; set; }

      [Category("6th Attire")]
      [DisplayName("BaseModel MDL Path")]
      [Attire(5)]
      [InputFilePath(".mdl")]
      [FilterProperty("MDLFilter")]
      public string Attire6BaseModelMDLPath { get; set; }

      [Category("6th Attire")]
      [DisplayName("BaseModel MTLS Path")]
      [Attire(5)]
      [InputFilePath(".mtls")]
      [FilterProperty("MTLSFilter")]
      public string Attire6BaseModelMTLSPath { get; set; }

      [Category("6th Attire")]
      [DisplayName("Crowd Sign 1")]
      [Attire(5)]
      [ItemsSourceProperty("CrowdSigns")]
      [CrowdSign]
      public JObject WrestlerCrowdSign1Attire6 { get; set; }

      [Category("6th Attire")]
      [DisplayName("Crowd Sign 2")]
      [Attire(5)]
      [ItemsSourceProperty("CrowdSigns")]
      [CrowdSign]
      public JObject WrestlerCrowdSign2Attire6 { get; set; }

      [Category("6th Attire")]
      [DisplayName("Crowd Sign 3")]
      [Attire(5)]
      [ItemsSourceProperty("CrowdSigns")]
      [CrowdSign]
      public JObject WrestlerCrowdSign3Attire6 { get; set; }

      [Category("6th Attire")]
      [DisplayName("Crowd Sign 4")]
      [Attire(5)]
      [ItemsSourceProperty("CrowdSigns")]
      [CrowdSign]
      public JObject WrestlerCrowdSign4Attire6 { get; set; }

      [Category("7th Attire")]
      [DisplayName("Attire Name")]
      [Attire(6)]
      public uint Attire7SDB { get; set; }

      [Category("7th Attire")]
      [DisplayName("Character Folder Path")]
      [Attire(6)]
      [MetaDirectorySelect]
      public string Attire7CharacterPath { get; set; }

      [Category("7th Attire")]
      [DisplayName("Attire Folder Path")]
      [Attire(6)]
      [MetaDirectorySelect]
      public string Attire7CharacterAttirePath { get; set; }

      [Category("7th Attire")]
      [DisplayName("Attire MDL Path")]
      [Attire(6)]
      [InputFilePath(".mdl")]
      [FilterProperty("MDLFilter")]
      public string Attire7MDLPath { get; set; }

      [Category("7th Attire")]
      [DisplayName("Attire MTLS Path")]
      [Attire(6)]
      [InputFilePath(".mtls")]
      [FilterProperty("MTLSFilter")]
      public string Attire7MTLSPath { get; set; }

      [Category("7th Attire")]
      [DisplayName("BaseModel MDL Path")]
      [Attire(6)]
      [InputFilePath(".mdl")]
      [FilterProperty("MDLFilter")]
      public string Attire7BaseModelMDLPath { get; set; }

      [Category("7th Attire")]
      [DisplayName("BaseModel MTLS Path")]
      [Attire(6)]
      [InputFilePath(".mtls")]
      [FilterProperty("MTLSFilter")]
      public string Attire7BaseModelMTLSPath { get; set; }

      [Category("7th Attire")]
      [DisplayName("Crowd Sign 1")]
      [Attire(6)]
      [ItemsSourceProperty("CrowdSigns")]
      [CrowdSign]
      public JObject WrestlerCrowdSign1Attire7 { get; set; }

      [Category("7th Attire")]
      [DisplayName("Crowd Sign 2")]
      [Attire(6)]
      [ItemsSourceProperty("CrowdSigns")]
      [CrowdSign]
      public JObject WrestlerCrowdSign2Attire7 { get; set; }

      [Category("7th Attire")]
      [DisplayName("Crowd Sign 3")]
      [Attire(6)]
      [ItemsSourceProperty("CrowdSigns")]
      [CrowdSign]
      public JObject WrestlerCrowdSign3Attire7 { get; set; }

      [Category("7th Attire")]
      [DisplayName("Crowd Sign 4")]
      [Attire(6)]
      [ItemsSourceProperty("CrowdSigns")]
      [CrowdSign]
      public JObject WrestlerCrowdSign4Attire7 { get; set; }

      [Category("8th Attire")]
      [DisplayName("Attire Name")]
      [Attire(7)]
      public uint Attire8SDB { get; set; }

      [Category("8th Attire")]
      [DisplayName("Character Folder Path")]
      [Attire(7)]
      [MetaDirectorySelect]
      public string Attire8CharacterPath { get; set; }

      [Category("8th Attire")]
      [DisplayName("Attire Folder Path")]
      [Attire(7)]
      [MetaDirectorySelect]
      public string Attire8CharacterAttirePath { get; set; }

      [Category("8th Attire")]
      [DisplayName("Attire MDL Path")]
      [Attire(7)]
      [InputFilePath(".mdl")]
      [FilterProperty("MDLFilter")]
      public string Attire8MDLPath { get; set; }

      [Category("8th Attire")]
      [DisplayName("Attire MTLS Path")]
      [Attire(7)]
      [InputFilePath(".mtls")]
      [FilterProperty("MTLSFilter")]
      public string Attire8MTLSPath { get; set; }

      [Category("8th Attire")]
      [DisplayName("BaseModel MDL Path")]
      [Attire(7)]
      [InputFilePath(".mdl")]
      [FilterProperty("MDLFilter")]
      public string Attire8BaseModelMDLPath { get; set; }

      [Category("8th Attire")]
      [DisplayName("BaseModel MTLS Path")]
      [Attire(7)]
      [InputFilePath(".mtls")]
      [FilterProperty("MTLSFilter")]
      public string Attire8BaseModelMTLSPath { get; set; }

      [Category("8th Attire")]
      [DisplayName("Crowd Sign 1")]
      [Attire(7)]
      [ItemsSourceProperty("CrowdSigns")]
      [CrowdSign]
      public JObject WrestlerCrowdSign1Attire8 { get; set; }

      [Category("8th Attire")]
      [DisplayName("Crowd Sign 2")]
      [Attire(7)]
      [ItemsSourceProperty("CrowdSigns")]
      [CrowdSign]
      public JObject WrestlerCrowdSign2Attire8 { get; set; }

      [Category("8th Attire")]
      [DisplayName("Crowd Sign 3")]
      [Attire(7)]
      [ItemsSourceProperty("CrowdSigns")]
      [CrowdSign]
      public JObject WrestlerCrowdSign3Attire8 { get; set; }

      [Category("8th Attire")]
      [DisplayName("Crowd Sign 4")]
      [Attire(7)]
      [ItemsSourceProperty("CrowdSigns")]
      [CrowdSign]
      public JObject WrestlerCrowdSign4Attire8 { get; set; }

      [Category("9th Attire")]
      [DisplayName("Attire Name")]
      [Attire(8)]
      public uint Attire9SDB { get; set; }

      [Category("9th Attire")]
      [DisplayName("Character Folder Path")]
      [Attire(8)]
      [MetaDirectorySelect]
      public string Attire9CharacterPath { get; set; }

      [Category("9th Attire")]
      [DisplayName("Attire Folder Path")]
      [Attire(8)]
      [MetaDirectorySelect]
      public string Attire9CharacterAttirePath { get; set; }

      [Category("9th Attire")]
      [DisplayName("Attire MDL Path")]
      [Attire(8)]
      [InputFilePath(".mdl")]
      [FilterProperty("MDLFilter")]
      public string Attire9MDLPath { get; set; }

      [Category("9th Attire")]
      [DisplayName("Attire MTLS Path")]
      [Attire(8)]
      [InputFilePath(".mtls")]
      [FilterProperty("MTLSFilter")]
      public string Attire9MTLSPath { get; set; }

      [Category("9th Attire")]
      [DisplayName("BaseModel MDL Path")]
      [Attire(8)]
      [InputFilePath(".mdl")]
      [FilterProperty("MDLFilter")]
      public string Attire9BaseModelMDLPath { get; set; }

      [Category("9th Attire")]
      [DisplayName("BaseModel MTLS Path")]
      [Attire(8)]
      [InputFilePath(".mtls")]
      [FilterProperty("MTLSFilter")]
      public string Attire9BaseModelMTLSPath { get; set; }

      [Category("9th Attire")]
      [DisplayName("Crowd Sign 1")]
      [Attire(8)]
      [ItemsSourceProperty("CrowdSigns")]
      [CrowdSign]
      public JObject WrestlerCrowdSign1Attire9 { get; set; }

      [Category("9th Attire")]
      [DisplayName("Crowd Sign 2")]
      [Attire(8)]
      [ItemsSourceProperty("CrowdSigns")]
      [CrowdSign]
      public JObject WrestlerCrowdSign2Attire9 { get; set; }

      [Category("9th Attire")]
      [DisplayName("Crowd Sign 3")]
      [Attire(8)]
      [ItemsSourceProperty("CrowdSigns")]
      [CrowdSign]
      public JObject WrestlerCrowdSign3Attire9 { get; set; }

      [Category("9th Attire")]
      [DisplayName("Crowd Sign 4")]
      [Attire(8)]
      [ItemsSourceProperty("CrowdSigns")]
      [CrowdSign]
      public JObject WrestlerCrowdSign4Attire9 { get; set; }

      [Category("10th Attire")]
      [DisplayName("Attire Name")]
      [Attire(9)]
      public uint Attire10SDB { get; set; }

      [Category("10th Attire")]
      [DisplayName("Character Folder Path")]
      [Attire(9)]
      [MetaDirectorySelect]
      public string Attire10CharacterPath { get; set; }

      [Category("10th Attire")]
      [DisplayName("Attire Folder Path")]
      [Attire(9)]
      [MetaDirectorySelect]
      public string Attire10CharacterAttirePath { get; set; }

      [Category("10th Attire")]
      [DisplayName("Attire MDL Path")]
      [Attire(9)]
      [InputFilePath(".mdl")]
      [FilterProperty("MDLFilter")]
      public string Attire10MDLPath { get; set; }

      [Category("10th Attire")]
      [DisplayName("Attire MTLS Path")]
      [Attire(9)]
      [InputFilePath(".mtls")]
      [FilterProperty("MTLSFilter")]
      public string Attire10MTLSPath { get; set; }

      [Category("10th Attire")]
      [DisplayName("BaseModel MDL Path")]
      [Attire(9)]
      [InputFilePath(".mdl")]
      [FilterProperty("MDLFilter")]
      public string Attire10BaseModelMDLPath { get; set; }

      [Category("10th Attire")]
      [DisplayName("BaseModel MTLS Path")]
      [Attire(9)]
      [InputFilePath(".mtls")]
      [FilterProperty("MTLSFilter")]
      public string Attire10BaseModelMTLSPath { get; set; }

      [Category("10th Attire")]
      [DisplayName("Crowd Sign 1")]
      [Attire(9)]
      [ItemsSourceProperty("CrowdSigns")]
      [CrowdSign]
      public JObject WrestlerCrowdSign1Attire10 { get; set; }

      [Category("10th Attire")]
      [DisplayName("Crowd Sign 2")]
      [Attire(9)]
      [ItemsSourceProperty("CrowdSigns")]
      [CrowdSign]
      public JObject WrestlerCrowdSign2Attire10 { get; set; }

      [Category("10th Attire")]
      [DisplayName("Crowd Sign 3")]
      [Attire(9)]
      [ItemsSourceProperty("CrowdSigns")]
      [CrowdSign]
      public JObject WrestlerCrowdSign3Attire10 { get; set; }

      [Category("10th Attire")]
      [DisplayName("Crowd Sign 4")]
      [Attire(9)]
      [ItemsSourceProperty("CrowdSigns")]
      [CrowdSign]
      public JObject WrestlerCrowdSign4Attire10 { get; set; }

      [Browsable(false)]
      public string MDLFilter => "MDL files (*.mdl)|*.mdl";

      [Browsable(false)]
      public string MTLSFilter => "MTLS files (*.mtls)|*.mtls";
    }
  }
}
