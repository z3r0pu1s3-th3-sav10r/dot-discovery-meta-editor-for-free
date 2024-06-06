using Meta.Core.Interfaces;
using Meta.WWE2K23;
using MetaEditor;
using Microsoft.CSharp.RuntimeBinder;
using Newtonsoft.Json;
using PropertyTools.DataAnnotations;
using PropertyTools.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Windows;

#nullable enable
namespace Meta.Editor.Controls.CreationSuite
{
  [TemplatePart(Name = "PART_GeneralInfoPropertyGrid", Type = typeof (PropertyGrid))]
  [TemplatePart(Name = "PART_SecondaryInfoPropertyGrid", Type = typeof (PropertyGrid))]
  public class EditorCharacter : CreationEditor
  {
    protected const string PART_GeneralInfoPropertyGrid = "PART_GeneralInfoPropertyGrid";
    protected const string PART_SecondaryInfoPropertyGrid = "PART_SecondaryInfoPropertyGrid";
    public PropertyGrid BasicInfoPropertyGrid;
    protected PropertyGrid SecondaryInfoPropertyGrid;
    public EditorCharacter.CharacterBasicInfo characterPrimaryInfo;
    protected EditorCharacter.CharacterSecondaryInfo characterSecondaryInfo;

    public override string Title => "Info";

    public override string Icon => "FaceAgent";

    public MetaPropertyGridFactory MetaPropertyGridFactory { get; set; }

    public EditorCharacter.CharacterBasicInfo CharacterInfo
    {
      get => (EditorCharacter.CharacterBasicInfo) this.BasicInfoPropertyGrid.SelectedObject;
    }

    public EditorCharacter.CharacterSecondaryInfo CharacterStats
    {
      get => (EditorCharacter.CharacterSecondaryInfo) this.SecondaryInfoPropertyGrid.SelectedObject;
    }

    public EditorCharacter(ILogger inLogger)
      : base(inLogger)
    {
      this.MetaPropertyGridFactory = new MetaPropertyGridFactory();
      this.characterPrimaryInfo = new EditorCharacter.CharacterBasicInfo();
      this.characterPrimaryInfo.LoadDefaults();
      this.characterSecondaryInfo = new EditorCharacter.CharacterSecondaryInfo();
      this.characterSecondaryInfo.LoadDefaults();
    }

    static EditorCharacter()
    {
      FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof (EditorCharacter), (PropertyMetadata) new FrameworkPropertyMetadata((object) typeof (EditorCharacter)));
    }

    public override void OnApplyTemplate()
    {
      base.OnApplyTemplate();
      this.BasicInfoPropertyGrid = this.GetTemplateChild("PART_GeneralInfoPropertyGrid") as PropertyGrid;
      this.BasicInfoPropertyGrid.ControlFactory = (IPropertyGridControlFactory) this.MetaPropertyGridFactory;
      this.BasicInfoPropertyGrid.SelectedObject = (object) this.characterPrimaryInfo;
      this.SecondaryInfoPropertyGrid = this.GetTemplateChild("PART_SecondaryInfoPropertyGrid") as PropertyGrid;
      this.SecondaryInfoPropertyGrid.ControlFactory = (IPropertyGridControlFactory) this.MetaPropertyGridFactory;
      this.SecondaryInfoPropertyGrid.SelectedObject = (object) this.characterSecondaryInfo;
    }

    public virtual void Load(object characterProfile)
    {
      // ISSUE: reference to a compiler-generated field
      if (EditorCharacter.\u003C\u003Eo__23.\u003C\u003Ep__0 == null)
      {
        // ISSUE: reference to a compiler-generated field
        EditorCharacter.\u003C\u003Eo__23.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, CharacterProfile_WWE2K23>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.Convert(CSharpBinderFlags.ConvertExplicit, typeof (CharacterProfile_WWE2K23), typeof (EditorCharacter)));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      CharacterProfile_WWE2K23 Profile = EditorCharacter.\u003C\u003Eo__23.\u003C\u003Ep__0.Target((CallSite) EditorCharacter.\u003C\u003Eo__23.\u003C\u003Ep__0, characterProfile);
      this.characterPrimaryInfo = new EditorCharacter.CharacterBasicInfo();
      this.characterPrimaryInfo.LoadDefaults();
      this.characterSecondaryInfo = new EditorCharacter.CharacterSecondaryInfo();
      this.characterSecondaryInfo.LoadDefaults();
      this.characterPrimaryInfo.WrestlerID = Profile.Info.wrestler_id;
      this.characterPrimaryInfo.WrestlerSlotID = Profile.Info.slot_id;
      this.characterPrimaryInfo.WrestlerCommentaryID = Profile.Info.commentary_id;
      this.characterPrimaryInfo.WrestlerAnnounceID = Profile.Info.announcer_id;
      this.characterPrimaryInfo.WrestlerMusic = Profile.Motion.entrance_music;
      this.characterPrimaryInfo.WrestlerGender = this.characterPrimaryInfo.WrestlerGenders.Get<byte>((object) Profile.Info.gender);
      this.characterPrimaryInfo.WrestlerClass = this.characterPrimaryInfo.WrestlerClasses.Get<byte>((object) Profile.Info.wrestler_type);
      this.characterPrimaryInfo.WrestlerPlayability = this.characterPrimaryInfo.Playables.Get<byte>((object) Profile.Info.playability);
      this.characterPrimaryInfo.WrestlerMenuLocation = this.characterPrimaryInfo.MenuLocations.Get<byte>((object) Profile.Info.menu_location);
      this.characterPrimaryInfo.WrestlerWeightClass = this.characterPrimaryInfo.WrestlerWeightClasses.Get<byte>((object) Profile.Info.weight_class);
      this.characterPrimaryInfo.WrestlerCrowdBalance = this.characterPrimaryInfo.CrowdBalances.Get<byte>((object) Profile.Info.crowd_balance);
      this.characterPrimaryInfo.WrestlerCrowdReaction = this.characterPrimaryInfo.CrowdReactions.Get<byte>((object) Profile.Info.crowd_reaction);
      this.characterPrimaryInfo.WrestlerFullName = Profile.Info.fullname_sdb_id;
      this.characterPrimaryInfo.WrestlerNickName = Profile.Info.nickname_sdb_id;
      this.characterPrimaryInfo.WrestlerSocialMedia = Profile.Info.socialmedia_sdb_id;
      this.characterPrimaryInfo.WrestlerHeight = (float) Profile.Info.height;
      this.characterPrimaryInfo.WrestlerWeight = Profile.Info.weight;
      this.characterPrimaryInfo.WrestlerEntranceMovieApronRingPost = Profile.Motion.movie_apron_ringpost;
      this.characterPrimaryInfo.WrestlerEntranceMovieBanner = Profile.Motion.movie_banner;
      this.characterPrimaryInfo.WrestlerEntranceMovieBarricade = Profile.Motion.movie_barricade;
      this.characterPrimaryInfo.WrestlerEntranceMovieStageRamp = Profile.Motion.movie_stage_ramp;
      this.characterPrimaryInfo.WrestlerEntranceMovieTitantron = Profile.Motion.movie_titantron;
      this.characterPrimaryInfo.WrestlerEntranceMovieUnknown = Profile.Motion.movie_unknown;
      this.characterPrimaryInfo.WrestlerEntranceMotionIntro = this.characterPrimaryInfo.WrestlerEntranceMotions.Get<uint>((object) Profile.Motion.entrance_motion_intro);
      this.characterPrimaryInfo.WrestlerEntranceMotionRing = this.characterPrimaryInfo.WrestlerEntranceMotions.Get<uint>((object) Profile.Motion.entrance_motion_ring);
      this.characterPrimaryInfo.WrestlerEntranceMotionRingIn = this.characterPrimaryInfo.WrestlerEntranceMotions.Get<uint>((object) Profile.Motion.entrance_motion_ring_in);
      this.characterPrimaryInfo.WrestlerEntranceMotionRamp = this.characterPrimaryInfo.WrestlerEntranceMotions.Get<uint>((object) Profile.Motion.entrance_motion_ramp);
      this.characterPrimaryInfo.WrestlerEntranceMotionStage = this.characterPrimaryInfo.WrestlerEntranceMotions.Get<uint>((object) Profile.Motion.entrance_motion_stage);
      this.characterPrimaryInfo.WrestlerEntranceTitleMotion = this.characterPrimaryInfo.WrestlerEntranceMotions.Get<uint>((object) Profile.Motion.entrance_title_motion);
      this.characterPrimaryInfo.WrestlerEntranceMITBMotion = this.characterPrimaryInfo.WrestlerMITBMotions.Get<uint>((object) Profile.Motion.entrance_MITB_motion);
      this.characterPrimaryInfo.WrestlerVictoryMotionFace = this.characterPrimaryInfo.VictoryMotions.Get<uint>((object) Profile.Motion.victory_motion_face);
      this.characterPrimaryInfo.WrestlerVictoryMotionHeel = this.characterPrimaryInfo.VictoryMotions.Get<uint>((object) Profile.Motion.victory_motion_heel);
      this.characterPrimaryInfo.WrestlerVictoryTitleMotionFace = this.characterPrimaryInfo.VictoryMotions.Get<uint>((object) Profile.Motion.victory_title_motion_face);
      this.characterPrimaryInfo.WrestlerVictoryTitleMotionHeel = this.characterPrimaryInfo.VictoryMotions.Get<uint>((object) Profile.Motion.victory_title_motion_heel);
      this.characterPrimaryInfo.WrestlerCountry = this.characterPrimaryInfo.Locations.Where<Location>((Func<Location, bool>) (s => s.callname.Equals((Decimal) Profile.Info.location_callname))).FirstOrDefault<Location>();
      MovieConfig movieConfig = this.characterPrimaryInfo.MovieConfigs.Where<MovieConfig>((Func<MovieConfig, bool>) (s => s.Value.Equals(Profile.Motion.movies_enabled))).FirstOrDefault<MovieConfig>();
      if (movieConfig != null)
      {
        this.characterPrimaryInfo.WrestlerMovieDisplayTitantron = movieConfig.Titantron;
        this.characterPrimaryInfo.WrestlerMovieDisplayApron = movieConfig.Apron;
        this.characterPrimaryInfo.WrestlerMovieDisplayBarricade = movieConfig.Barricade;
        this.characterPrimaryInfo.WrestlerMovieDisplayBanner = movieConfig.Banner;
        this.characterPrimaryInfo.WrestlerMovieDisplayStage = movieConfig.Stage;
        this.characterPrimaryInfo.WrestlerMovieDisplayPost = movieConfig.Post;
      }
      PropertyInfo[] properties = this.characterSecondaryInfo.GetType().GetProperties();
      int index1 = 0;
      for (int index2 = 0; index2 < properties.Length; ++index2)
      {
        if (Attribute.GetCustomAttribute((MemberInfo) properties[index2], typeof (CategoryAttribute)) is CategoryAttribute customAttribute && customAttribute.Category.Equals("Attributes") && properties[index2] != (PropertyInfo) null && index1 < Profile.Info.attributes.Count)
        {
          properties[index2].SetValue((object) this.characterSecondaryInfo, (object) Profile.Info.attributes[index1]);
          ++index1;
        }
      }
      int index3 = 0;
      for (int index4 = 0; index4 < properties.Length; ++index4)
      {
        if (Attribute.GetCustomAttribute((MemberInfo) properties[index4], typeof (CategoryAttribute)) is CategoryAttribute customAttribute && customAttribute.Category.Equals("AI"))
        {
          properties[index4].SetValue((object) this.characterSecondaryInfo, (object) Profile.Info.ai_attributes[index3]);
          ++index3;
        }
      }
      int index5 = 0;
      for (int index6 = 0; index6 < properties.Length; ++index6)
      {
        if (Attribute.GetCustomAttribute((MemberInfo) properties[index6], typeof (CategoryAttribute)) is CategoryAttribute customAttribute && customAttribute.Category.Equals("Personality"))
        {
          properties[index6].SetValue((object) this.characterSecondaryInfo, (object) (sbyte) Profile.Info.personality_traits[index5]);
          ++index5;
        }
      }
      int index7 = 0;
      for (int index8 = 0; index8 < properties.Length; ++index8)
      {
        if (Attribute.GetCustomAttribute((MemberInfo) properties[index8], typeof (CategoryAttribute)) is CategoryAttribute customAttribute && customAttribute.Category.Equals("Hit Point Ratio"))
        {
          properties[index8].SetValue((object) this.characterSecondaryInfo, (object) ((int) Profile.Info.hit_point[index7] * 40));
          ++index7;
        }
      }
      this.BasicInfoPropertyGrid.SelectedObject = (object) this.characterPrimaryInfo;
      this.SecondaryInfoPropertyGrid.SelectedObject = (object) this.characterSecondaryInfo;
    }

    public override void Shutdown()
    {
      base.Shutdown();
      ((FrameworkElement) this.BasicInfoPropertyGrid).DataContext = (object) null;
      this.BasicInfoPropertyGrid.SelectedObject = (object) null;
      ((FrameworkElement) this.SecondaryInfoPropertyGrid).DataContext = (object) null;
      this.SecondaryInfoPropertyGrid.SelectedObject = (object) null;
    }

    public class CharacterBasicInfo : BaseEditor
    {
      public CharacterBasicInfo()
      {
        this.Playables = JsonConvert.DeserializeObject<ObservableCollection<JObject>>(JsonConvert.SerializeObject(App.FileData[App.Game]["Playable"]));
        this.MenuLocations = JsonConvert.DeserializeObject<ObservableCollection<JObject>>(JsonConvert.SerializeObject(App.FileData[App.Game]["MenuFlag"]));
        this.ScreenFilters = JsonConvert.DeserializeObject<ObservableCollection<JObject>>(JsonConvert.SerializeObject(App.FileData[App.Game][nameof (ScreenFilters)]));
        this.WrestlerMITBMotions = JsonConvert.DeserializeObject<ObservableCollection<JObject>>(JsonConvert.SerializeObject(App.FileData[App.Game]["MITBMotions"]));
        this.WrestlerEntranceMotions = JsonConvert.DeserializeObject<ObservableCollection<JObject>>(JsonConvert.SerializeObject(App.FileData[App.Game]["EntranceMotions"]));
        this.VictoryMotions = JsonConvert.DeserializeObject<ObservableCollection<JObject>>(JsonConvert.SerializeObject(App.FileData[App.Game][nameof (VictoryMotions)]));
        this.Locations = JsonConvert.DeserializeObject<ObservableCollection<Location>>(JsonConvert.SerializeObject(App.FileData[App.Game][nameof (Locations)]));
        this.CrowdBalances = JsonConvert.DeserializeObject<ObservableCollection<JObject>>(JsonConvert.SerializeObject(App.FileData[App.Game]["CrowdBalance"]));
        this.CrowdReactions = JsonConvert.DeserializeObject<ObservableCollection<JObject>>(JsonConvert.SerializeObject(App.FileData[App.Game]["CrowdReaction"]));
        this.WrestlerClasses = JsonConvert.DeserializeObject<ObservableCollection<JObject>>(JsonConvert.SerializeObject(App.FileData[App.Game]["CharacterClass"]));
        this.WrestlerGenders = JsonConvert.DeserializeObject<ObservableCollection<JObject>>(JsonConvert.SerializeObject(App.FileData[App.Game]["Genders"]));
        this.WrestlerWeightClasses = JsonConvert.DeserializeObject<ObservableCollection<JObject>>(JsonConvert.SerializeObject(App.FileData[App.Game]["Weight"]));
        this.MovieConfigs = JsonConvert.DeserializeObject<ObservableCollection<MovieConfig>>(JsonConvert.SerializeObject(App.FileData[App.Game]["Movies"]));
        this.Paybacks = JsonConvert.DeserializeObject<ObservableCollection<JObject>>(JsonConvert.SerializeObject(App.FileData[App.Game]["Payback"]));
      }

      public void LoadDefaults()
      {
        this.WrestlerPlayability = this.Playables[0];
        this.WrestlerMenuLocation = this.MenuLocations[0];
        this.WrestlerEntranceFilter = this.ScreenFilters[0];
        this.WrestlerEntranceMotionIntro = this.WrestlerEntranceMotions[0];
        this.WrestlerEntranceMotionRing = this.WrestlerEntranceMotions[0];
        this.WrestlerEntranceMotionRingIn = this.WrestlerEntranceMotions[0];
        this.WrestlerEntranceMotionRamp = this.WrestlerEntranceMotions[0];
        this.WrestlerEntranceMotionStage = this.WrestlerEntranceMotions[0];
        this.WrestlerEntranceTitleMotion = this.WrestlerEntranceMotions[0];
        this.WrestlerEntranceMITBMotion = this.WrestlerMITBMotions[0];
        this.WrestlerVictoryTitleMotionFace = this.VictoryMotions[3];
        this.WrestlerVictoryTitleMotionHeel = this.VictoryMotions[3];
        this.WrestlerCountry = this.Locations[1];
        this.WrestlerGender = this.WrestlerGenders[0];
        this.WrestlerClass = this.WrestlerClasses[1];
        this.WrestlerWeightClass = this.WrestlerWeightClasses[1];
        this.WrestlerCrowdBalance = this.CrowdBalances[0];
        this.WrestlerCrowdReaction = this.CrowdReactions[0];
        this.WrestlerVictoryMotionHeel = this.VictoryMotions[0];
        this.WrestlerVictoryMotionFace = this.VictoryMotions[0];
        this.WrestlerPayBack1 = this.Paybacks[0];
        this.WrestlerPayBack2 = this.Paybacks[0];
      }

      [Category("Basic Info")]
      [DisplayName("Slot ID")]
      public ushort WrestlerSlotID { get; set; } = 100;

      [Category("Basic Info")]
      [DisplayName("Wrestler ID")]
      public ushort WrestlerID { get; set; } = 100;

      [Category("Basic Info")]
      [DisplayName("Playability")]
      [ItemsSourceProperty("Playables")]
      [Important]
      public JObject WrestlerPlayability { get; set; }

      [Category("Basic Info")]
      [DisplayName("Menu")]
      [ItemsSourceProperty("MenuLocations")]
      [Important]
      public JObject WrestlerMenuLocation { get; set; }

      [Category("Basic Info")]
      [DisplayName("Gender")]
      [ItemsSourceProperty("WrestlerGenders")]
      [Important]
      public JObject WrestlerGender { get; set; }

      [Category("Basic Info")]
      [DisplayName("Wrestler Type")]
      [ItemsSourceProperty("WrestlerClasses")]
      [Important]
      public JObject WrestlerClass { get; set; }

      [Category("Basic Info")]
      [DisplayName("Location")]
      [ItemsSourceProperty("CountryJson")]
      [Country]
      public Location WrestlerCountry { get; set; }

      [Category("Basic Info")]
      [DisplayName("Height")]
      [Slidable(1.5, 2.15)]
      [FormatString("0.00 m")]
      public float WrestlerHeight { get; set; } = 1.88f;

      [Category("Basic Info")]
      [DisplayName("Weight")]
      [Slidable(0.0, 1000.0, 1.0, 50.0)]
      [FormatString("0 lbs")]
      public ushort WrestlerWeight { get; set; } = 250;

      [Category("Basic Info")]
      [DisplayName("Weight Class")]
      [ItemsSourceProperty("WrestlerWeightClasses")]
      [Important]
      public JObject WrestlerWeightClass { get; set; }

      [Category("Basic Info")]
      [DisplayName("Crowd Reaction")]
      [ItemsSourceProperty("CrowdReactions")]
      [Important]
      public JObject WrestlerCrowdReaction { get; set; }

      [Category("Basic Info")]
      [DisplayName("Crowd Balance")]
      [ItemsSourceProperty("CrowdBalances")]
      [Important]
      public JObject WrestlerCrowdBalance { get; set; }

      [Category("Basic Info")]
      [DisplayName("Commentary ID")]
      public uint WrestlerCommentaryID { get; set; } = (uint) ushort.MaxValue;

      [Category("Basic Info")]
      [DisplayName("Announcer ID")]
      public uint WrestlerAnnounceID { get; set; } = (uint) ushort.MaxValue;

      [Category("Basic Info")]
      [DisplayName("Theme Music ID")]
      public uint WrestlerMusic { get; set; } = 100;

      [Category("Names")]
      [Description("SDB string ID in decimal.")]
      [DisplayName("Full name")]
      public uint WrestlerFullName { get; set; } = 3571365560;

      [Category("Names")]
      [DisplayName("Nickname")]
      [Description("SDB string ID in decimal.")]
      public uint WrestlerNickName { get; set; } = 229794704;

      [Category("Names")]
      [DisplayName("Social Media")]
      [Description("SDB string ID in decimal.")]
      public uint WrestlerSocialMedia { get; set; } = 712412311;

      [Category("Payback")]
      [DisplayName("1")]
      [ItemsSourceProperty("Paybacks")]
      [Important]
      public JObject WrestlerPayBack1 { get; set; }

      [Category("Payback")]
      [DisplayName("2")]
      [ItemsSourceProperty("Paybacks")]
      [Important]
      public JObject WrestlerPayBack2 { get; set; }

      [Category("Entrance Motion")]
      [DisplayName("Intro")]
      [ItemsSourceProperty("WrestlerEntranceMotions")]
      [Important]
      public JObject WrestlerEntranceMotionIntro { get; set; }

      [Category("Entrance Motion")]
      [DisplayName("Ring")]
      [ItemsSourceProperty("WrestlerEntranceMotions")]
      [Important]
      public JObject WrestlerEntranceMotionRing { get; set; }

      [Category("Entrance Motion")]
      [DisplayName("Ring-In")]
      [ItemsSourceProperty("WrestlerEntranceMotions")]
      [Important]
      public JObject WrestlerEntranceMotionRingIn { get; set; }

      [Category("Entrance Motion")]
      [DisplayName("Ramp")]
      [ItemsSourceProperty("WrestlerEntranceMotions")]
      [Important]
      public JObject WrestlerEntranceMotionRamp { get; set; }

      [Category("Entrance Motion")]
      [DisplayName("Stage")]
      [ItemsSourceProperty("WrestlerEntranceMotions")]
      [Important]
      public JObject WrestlerEntranceMotionStage { get; set; }

      [Category("Entrance Motion")]
      [DisplayName("Title")]
      [ItemsSourceProperty("WrestlerEntranceMotions")]
      [Important]
      public JObject WrestlerEntranceTitleMotion { get; set; }

      [Category("Entrance Motion")]
      [DisplayName("MITB")]
      [ItemsSourceProperty("WrestlerMITBMotions")]
      [Important]
      public JObject WrestlerEntranceMITBMotion { get; set; }

      [Category("Entrance Motion")]
      [DisplayName("Filter")]
      [ItemsSourceProperty("ScreenFilters")]
      [Important]
      public JObject WrestlerEntranceFilter { get; set; }

      [Category("Victory Motion")]
      [DisplayName("Face")]
      [ItemsSourceProperty("VictoryMotions")]
      [Important]
      public JObject WrestlerVictoryMotionFace { get; set; }

      [Category("Victory Motion")]
      [DisplayName("Heel")]
      [ItemsSourceProperty("VictoryMotions")]
      [Important]
      public JObject WrestlerVictoryMotionHeel { get; set; }

      [Category("Victory Motion")]
      [DisplayName("Title Face")]
      [ItemsSourceProperty("VictoryMotions")]
      [Important]
      public JObject WrestlerVictoryTitleMotionFace { get; set; }

      [Category("Victory Motion")]
      [DisplayName("Title Heel")]
      [ItemsSourceProperty("VictoryMotions")]
      [Important]
      public JObject WrestlerVictoryTitleMotionHeel { get; set; }

      [Category("Movies")]
      [DisplayName("Titantron")]
      public uint WrestlerEntranceMovieTitantron { get; set; } = 10000;

      [Category("Movies")]
      [DisplayName("Banner")]
      public uint WrestlerEntranceMovieBanner { get; set; } = 10000;

      [Category("Movies")]
      [DisplayName("Unknown")]
      public uint WrestlerEntranceMovieUnknown { get; set; } = 10000;

      [Category("Movies")]
      [DisplayName("Stage Ramp")]
      public uint WrestlerEntranceMovieStageRamp { get; set; } = 10000;

      [Category("Movies")]
      [DisplayName("Apron & Ring Post")]
      public uint WrestlerEntranceMovieApronRingPost { get; set; } = 10000;

      [Category("Movies")]
      [DisplayName("Barricade")]
      public uint WrestlerEntranceMovieBarricade { get; set; } = 10000;

      [Category("Movie Display")]
      [DisplayName("Titantron")]
      public bool WrestlerMovieDisplayTitantron { get; set; } = true;

      [Category("Movie Display")]
      [DisplayName("Banner")]
      public bool WrestlerMovieDisplayBanner { get; set; } = true;

      [Category("Movie Display")]
      [DisplayName("Stage")]
      public bool WrestlerMovieDisplayStage { get; set; } = true;

      [Category("Movie Display")]
      [DisplayName("Apron")]
      public bool WrestlerMovieDisplayApron { get; set; } = true;

      [Category("Movie Display")]
      [DisplayName("Post")]
      public bool WrestlerMovieDisplayPost { get; set; } = true;

      [Category("Movie Display")]
      [DisplayName("Barricade")]
      public bool WrestlerMovieDisplayBarricade { get; set; } = true;

      [Browsable(false)]
      public IEnumerable<Location> CountryJson => (IEnumerable<Location>) this.Locations;

      [Browsable(false)]
      public ObservableCollection<MovieConfig> MovieConfigs { get; set; }

      [Browsable(false)]
      public ObservableCollection<JObject> Playables { get; set; }

      [Browsable(false)]
      public ObservableCollection<JObject> MenuLocations { get; set; }

      [Browsable(false)]
      public ObservableCollection<JObject> ScreenFilters { get; set; }

      [Browsable(false)]
      public ObservableCollection<JObject> WrestlerMITBMotions { get; set; }

      [Browsable(false)]
      public ObservableCollection<JObject> WrestlerEntranceMotions { get; set; }

      [Browsable(false)]
      public ObservableCollection<JObject> VictoryMotions { get; set; }

      [Browsable(false)]
      public ObservableCollection<JObject> Paybacks { get; set; }

      [Browsable(false)]
      public ObservableCollection<Location> Locations { get; set; }

      [Browsable(false)]
      public ObservableCollection<JObject> CrowdBalances { get; set; }

      [Browsable(false)]
      public ObservableCollection<JObject> CrowdReactions { get; set; }

      [Browsable(false)]
      public ObservableCollection<JObject> WrestlerClasses { get; set; }

      [Browsable(false)]
      public ObservableCollection<JObject> WrestlerGenders { get; set; }

      [Browsable(false)]
      public ObservableCollection<JObject> WrestlerWeightClasses { get; set; }
    }

    public class CharacterSecondaryInfo : BaseEditor
    {
      public void LoadDefaults()
      {
      }

      [Category("Hit Point Ratio")]
      [DisplayName("Head")]
      [Slidable(0.0, 2200.0, 40.0, 80.0, true, 40.0)]
      [FormatString("0")]
      public int WrestlerHitPointHead { get; set; } = 1120;

      [Category("Hit Point Ratio")]
      [DisplayName("Body")]
      [Slidable(0.0, 2200.0, 40.0, 80.0, true, 40.0)]
      [FormatString("0")]
      public int WrestlerHitPointBody { get; set; } = 1000;

      [Category("Hit Point Ratio")]
      [DisplayName("Arms")]
      [Slidable(0.0, 2200.0, 40.0, 80.0, true, 40.0)]
      [FormatString("0")]
      public int WrestlerHitPointArms { get; set; } = 880;

      [Category("Hit Point Ratio")]
      [DisplayName("Legs")]
      [Slidable(0.0, 2200.0, 40.0, 80.0, true, 40.0)]
      [FormatString("0")]
      public int WrestlerHitPointLegs { get; set; } = 1000;

      [Category("Personality")]
      [DisplayName("Egotistical | Prideful")]
      [Slidable(-100.0, 100.0, 1.0, 10.0)]
      [FormatString("0")]
      public sbyte WrestlerEgotisticalPrideful { get; set; }

      [Category("Personality")]
      [DisplayName("Disrespectful | Respectful")]
      [Slidable(-100.0, 100.0, 1.0, 10.0)]
      [FormatString("0")]
      public sbyte WrestlerDisrespectfulRespectful { get; set; }

      [Category("Personality")]
      [DisplayName("Desperate | Preservant")]
      [Slidable(-100.0, 100.0, 1.0, 10.0)]
      [FormatString("0")]
      public sbyte WrestlerDesperatePreservant { get; set; }

      [Category("Personality")]
      [DisplayName("Treacherous | Loyal")]
      [Slidable(-100.0, 100.0, 1.0, 10.0)]
      [FormatString("0")]
      public sbyte WrestlerTreacherousLoyal { get; set; }

      [Category("Personality")]
      [DisplayName("Cowardly | Bold")]
      [Slidable(-100.0, 100.0, 1.0, 10.0)]
      [FormatString("0")]
      public sbyte WrestlerCowardlyBold { get; set; }

      [Category("Personality")]
      [DisplayName("Aggressive | Disciplined")]
      [Slidable(-100.0, 100.0, 1.0, 10.0)]
      [FormatString("0")]
      public sbyte WrestlerAggressiveDisciplined { get; set; }

      [Category("Attributes")]
      [DisplayName("Arm Power")]
      [Slidable(0.0, 255.0, 1.0, 20.0)]
      [FormatString("0")]
      public byte WrestlerAttributeArmPower { get; set; } = 50;

      [Category("Attributes")]
      [DisplayName("Leg Power")]
      [Slidable(0.0, 255.0, 1.0, 20.0)]
      [FormatString("0")]
      public byte WrestlerAttributeLegPower { get; set; } = 50;

      [Category("Attributes")]
      [DisplayName("Grapple Offense")]
      [Slidable(0.0, 255.0, 1.0, 20.0)]
      [FormatString("0")]
      public byte WrestlerAttributeGrappleOffense { get; set; } = 50;

      [Category("Attributes")]
      [DisplayName("Running Offense")]
      [Slidable(0.0, 255.0, 1.0, 20.0)]
      [FormatString("0")]
      public byte WrestlerAttributeRunningOffense { get; set; } = 50;

      [Category("Attributes")]
      [DisplayName("Aerial Offense")]
      [Slidable(0.0, 255.0, 1.0, 20.0)]
      [FormatString("0")]
      public byte WrestlerAttributeAerialOffense { get; set; } = 50;

      [Category("Attributes")]
      [DisplayName("Aerial Range")]
      [Slidable(0.0, 255.0, 1.0, 20.0)]
      [FormatString("0")]
      public byte WrestlerAttributeAeriaRange { get; set; } = 50;

      [Category("Attributes")]
      [DisplayName("Power Submission Offense")]
      [Slidable(0.0, 255.0, 1.0, 20.0)]
      [FormatString("0")]
      public byte WrestlerAttributePowerSubmissionOffense { get; set; } = 50;

      [Category("Attributes")]
      [DisplayName("Technical Submission Offense")]
      [Slidable(0.0, 255.0, 1.0, 20.0)]
      [FormatString("0")]
      public byte WrestlerAttributeTechnicalSubmissionOffense { get; set; } = 50;

      [Category("Attributes")]
      [DisplayName("Strike Reversal")]
      [Slidable(0.0, 255.0, 1.0, 20.0)]
      [FormatString("0")]
      public byte WrestlerAttributeStrikeReversal { get; set; } = 50;

      [Category("Attributes")]
      [DisplayName("Grapple Reversal")]
      [Slidable(0.0, 255.0, 1.0, 20.0)]
      [FormatString("0")]
      public byte WrestlerAttributeGrappleReversal { get; set; } = 50;

      [Category("Attributes")]
      [DisplayName("Aerial Reversal")]
      [Slidable(0.0, 255.0, 1.0, 20.0)]
      [FormatString("0")]
      public byte WrestlerAttributeAerialReversal { get; set; } = 50;

      [Category("Attributes")]
      [DisplayName("Body Durability")]
      [Slidable(0.0, 255.0, 1.0, 20.0)]
      [FormatString("0")]
      public byte WrestlerAttributeBodyDurability { get; set; } = 50;

      [Category("Attributes")]
      [DisplayName("Arm Durability")]
      [Slidable(0.0, 255.0, 1.0, 20.0)]
      [FormatString("0")]
      public byte WrestlerAttributeArmDurability { get; set; } = 50;

      [Category("Attributes")]
      [DisplayName("Leg Durability")]
      [Slidable(0.0, 255.0, 1.0, 20.0)]
      [FormatString("0")]
      public byte WrestlerAttributeLegDurability { get; set; } = 50;

      [Category("Attributes")]
      [DisplayName("Power Submission Defense")]
      [Slidable(0.0, 255.0, 1.0, 20.0)]
      [FormatString("0")]
      public byte WrestlerAttributePowerSubmissionDefense { get; set; } = 50;

      [Category("Attributes")]
      [DisplayName("Technical Submission Defense")]
      [Slidable(0.0, 255.0, 1.0, 20.0)]
      [FormatString("0")]
      public byte WrestlerAttributeTechnicalSubmissionDefense { get; set; } = 50;

      [Category("Attributes")]
      [DisplayName("Pin Escape")]
      [Slidable(0.0, 255.0, 1.0, 20.0)]
      [FormatString("0")]
      public byte WrestlerAttributePinEscape { get; set; } = 50;

      [Category("Attributes")]
      [DisplayName("Strength")]
      [Slidable(0.0, 255.0, 1.0, 20.0)]
      [FormatString("0")]
      public byte WrestlerAttributeStrength { get; set; } = 50;

      [Category("Attributes")]
      [DisplayName("Stamina")]
      [Slidable(0.0, 255.0, 1.0, 20.0)]
      [FormatString("0")]
      public byte WrestlerAttributeStamina { get; set; } = 50;

      [Category("Attributes")]
      [DisplayName("Agility")]
      [Slidable(0.0, 255.0, 1.0, 20.0)]
      [FormatString("0")]
      public byte WrestlerAttributeAgility { get; set; } = 50;

      [Category("Attributes")]
      [DisplayName("Movement Speed")]
      [Slidable(0.0, 255.0, 1.0, 20.0)]
      [FormatString("0")]
      public byte WrestlerAttributeMovementSpeed { get; set; } = 50;

      [Category("Attributes")]
      [DisplayName("Recovery")]
      [Slidable(0.0, 255.0, 1.0, 20.0)]
      [FormatString("0")]
      public byte WrestlerAttributeRecovery { get; set; } = 50;

      [Category("Attributes")]
      [DisplayName("Special")]
      [Slidable(0.0, 255.0, 1.0, 20.0)]
      [FormatString("0")]
      public byte WrestlerAttributeSpecial { get; set; } = 50;

      [Category("Attributes")]
      [DisplayName("Finisher")]
      [Slidable(0.0, 255.0, 1.0, 20.0)]
      [FormatString("0")]
      public byte WrestlerAttributeFinisher { get; set; } = 50;

      [Category("AI")]
      [DisplayName("Combo Tendency")]
      [Slidable(0.0, 255.0, 1.0, 20.0)]
      [FormatString("0")]
      public byte WrestlerAIComboTendency { get; set; } = 63;

      [Category("AI")]
      [DisplayName("Combo Selection Towards")]
      [Slidable(0.0, 255.0, 1.0, 20.0)]
      [FormatString("0")]
      public byte WrestlerAIComboSelectionTowards { get; set; } = 63;

      [Category("AI")]
      [DisplayName("Combo Selection Neutral")]
      [Slidable(0.0, 255.0, 1.0, 20.0)]
      [FormatString("0")]
      public byte WrestlerAIComboSelectionNeutral { get; set; } = 63;

      [Category("AI")]
      [DisplayName("Combo Selection Away")]
      [Slidable(0.0, 255.0, 1.0, 20.0)]
      [FormatString("0")]
      public byte WrestlerAIComboSelectionAway { get; set; } = 63;

      [Category("AI")]
      [DisplayName("Submissions Tendency")]
      [Slidable(0.0, 255.0, 1.0, 20.0)]
      [FormatString("0")]
      public byte WrestlerAISubmissionsTendency { get; set; } = 82;

      [Category("AI")]
      [DisplayName("Light Strike Tendency")]
      [Slidable(0.0, 255.0, 1.0, 20.0)]
      [FormatString("0")]
      public byte WrestlerAILightStrikeTendency { get; set; } = 63;

      [Category("AI")]
      [DisplayName("Heavy Strike Tendency")]
      [Slidable(0.0, 255.0, 1.0, 20.0)]
      [FormatString("0")]
      public byte WrestlerAIHeavyStrikeTendency { get; set; } = 43;

      [Category("AI")]
      [DisplayName("Light Grapple Tendency")]
      [Slidable(0.0, 255.0, 1.0, 20.0)]
      [FormatString("0")]
      public byte WrestlerAILightGrappleTendency { get; set; } = 66;

      [Category("AI")]
      [DisplayName("Heavy Grapple Tendency")]
      [Slidable(0.0, 255.0, 1.0, 20.0)]
      [FormatString("0")]
      public byte WrestlerAIHeavyGrappleTendency { get; set; } = 66;

      [Category("AI")]
      [DisplayName("Ground Strike Tendency")]
      [Slidable(0.0, 255.0, 1.0, 20.0)]
      [FormatString("0")]
      public byte WrestlerAIGroundStrikeTendency { get; set; } = 66;

      [Category("AI")]
      [DisplayName("Ground Grapple Tendency")]
      [Slidable(0.0, 255.0, 1.0, 20.0)]
      [FormatString("0")]
      public byte WrestlerAIGroundGrappleTendency { get; set; } = 66;

      [Category("AI")]
      [DisplayName("Environmental Strike Tendency")]
      [Slidable(0.0, 255.0, 1.0, 20.0)]
      [FormatString("0")]
      public byte WrestlerAIEnvironmentalStrikeTendency { get; set; } = 64;

      [Category("AI")]
      [DisplayName("Environmental Grapple Tendency")]
      [Slidable(0.0, 255.0, 1.0, 20.0)]
      [FormatString("0")]
      public byte WrestlerAIEnvironmentalGrappleTendency { get; set; } = 64;

      [Category("AI")]
      [DisplayName("Dive Tendency")]
      [Slidable(0.0, 255.0, 1.0, 20.0)]
      [FormatString("0")]
      public byte WrestlerAIDiveTendency { get; set; } = 62;

      [Category("AI")]
      [DisplayName("Daredevil Dive Tendency")]
      [Slidable(0.0, 255.0, 1.0, 20.0)]
      [FormatString("0")]
      public byte WrestlerAIDaredevilDiveTendency { get; set; } = 42;

      [Category("AI")]
      [DisplayName("In Ring Springboard Tendency")]
      [Slidable(0.0, 255.0, 1.0, 20.0)]
      [FormatString("0")]
      public byte WrestlerAIInRingSpringboardTendency { get; set; } = 42;

      [Category("AI")]
      [DisplayName("Ringside Springboard Tendency")]
      [Slidable(0.0, 255.0, 1.0, 20.0)]
      [FormatString("0")]
      public byte WrestlerAIRingsideSpringboardTendency { get; set; } = 42;

      [Category("AI")]
      [DisplayName("Limb Targeting Tendency")]
      [Slidable(0.0, 255.0, 1.0, 20.0)]
      [FormatString("0")]
      public byte WrestlerAILimbTargetingTendency { get; set; } = 82;

      [Category("AI")]
      [DisplayName("Running Attack Tendency")]
      [Slidable(0.0, 255.0, 1.0, 20.0)]
      [FormatString("0")]
      public byte WrestlerAIRunningAttackTendency { get; set; } = 47;

      [Category("AI")]
      [DisplayName("Blocking Tendency")]
      [Slidable(0.0, 255.0, 1.0, 20.0)]
      [FormatString("0")]
      public byte WrestlerAIBlockingTendency { get; set; } = 74;

      [Category("AI")]
      [DisplayName("Dodging Tendency")]
      [Slidable(0.0, 255.0, 1.0, 20.0)]
      [FormatString("0")]
      public byte WrestlerAIDodgingTendency { get; set; } = 47;

      [Category("AI")]
      [DisplayName("Weapon Usage Tendency")]
      [Slidable(0.0, 255.0, 1.0, 20.0)]
      [FormatString("0")]
      public byte WrestlerAIWeaponUsageTendency { get; set; } = 42;

      [Category("AI")]
      [DisplayName("Table Usage Tendency")]
      [Slidable(0.0, 255.0, 1.0, 20.0)]
      [FormatString("0")]
      public byte WrestlerAITableUsageTendency { get; set; } = 42;

      [Category("AI")]
      [DisplayName("Possum Attack and Pin Tendency")]
      [Slidable(0.0, 255.0, 1.0, 20.0)]
      [FormatString("0")]
      public byte WrestlerAIPossumAttackandPinTendency { get; set; } = 78;

      [Category("AI")]
      [DisplayName("Instant Recovery Tendency")]
      [Slidable(0.0, 255.0, 1.0, 20.0)]
      [FormatString("0")]
      public byte WrestlerAIInstantRecoveryTendency { get; set; } = 42;

      [Category("AI")]
      [DisplayName("Ring Escape Tendency")]
      [Slidable(0.0, 255.0, 1.0, 20.0)]
      [FormatString("0")]
      public byte WrestlerAIRingEscapeTendency { get; set; } = 78;

      [Category("AI")]
      [DisplayName("Pin Combo Tendency")]
      [Slidable(0.0, 255.0, 1.0, 20.0)]
      [FormatString("0")]
      public byte WrestlerAIPinComboTendency { get; set; } = 87;
    }
  }
}
