using Meta.Core;
using Meta.Core.Interfaces;
using Meta.Editor.Converters;
using Meta.Structures.Flatbuffers.WWE2K24;
using Meta.WWE2K24;
using MetaEditor;
using Microsoft.CSharp.RuntimeBinder;
using Microsoft.Win32;
using Newtonsoft.Json;
using PropertyTools.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Windows;

#nullable enable
namespace Meta.Editor.Controls.CreationSuite
{
  [CreationControl]
  public class CharacterCreationControl_WWE2K24 : CharacterCreationControl
  {
    public EditorCharacter_WWE2K24 editorCharacter;
    public EditorMapping_WWE2K24 editorMapping;
    public EditorMotion_WWE2K24 editorMotion;

    public CharacterCreationControl_WWE2K24(ILogger inLogger, MetaTabControl tab)
      : base(inLogger, tab)
    {
      this.logger.Log("[Editor][Character Creation] Loading...", Array.Empty<object>());
      this.editorCharacter = new EditorCharacter_WWE2K24(inLogger);
      this.editorMapping = new EditorMapping_WWE2K24(inLogger);
      this.editorMotion = new EditorMotion_WWE2K24(inLogger);
      ObservableCollection<CreationEditor> observableCollection = new ObservableCollection<CreationEditor>();
      observableCollection.Add((CreationEditor) this.editorCharacter);
      observableCollection.Add((CreationEditor) this.editorMapping);
      observableCollection.Add((CreationEditor) this.editorMotion);
      this.Editors = observableCollection;
    }

    public override void OpenAs(Profile profile)
    {
      if (!profile.Type.Equals((object) (ProfileType) 0))
        return;
      JsonSerializerSettings serializerSettings1 = new JsonSerializerSettings();
      serializerSettings1.Converters.Add((JsonConverter) new InfoConverter());
      JsonSerializerSettings serializerSettings2 = serializerSettings1;
      // ISSUE: reference to a compiler-generated field
      if (CharacterCreationControl_WWE2K24.\u003C\u003Eo__4.\u003C\u003Ep__2 == null)
      {
        // ISSUE: reference to a compiler-generated field
        CharacterCreationControl_WWE2K24.\u003C\u003Eo__4.\u003C\u003Ep__2 = CallSite<Func<CallSite, object, CharacterProfile_WWE2K24>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.Convert(CSharpBinderFlags.None, typeof (CharacterProfile_WWE2K24), typeof (CharacterCreationControl_WWE2K24)));
      }
      // ISSUE: reference to a compiler-generated field
      Func<CallSite, object, CharacterProfile_WWE2K24> target1 = CharacterCreationControl_WWE2K24.\u003C\u003Eo__4.\u003C\u003Ep__2.Target;
      // ISSUE: reference to a compiler-generated field
      CallSite<Func<CallSite, object, CharacterProfile_WWE2K24>> p2 = CharacterCreationControl_WWE2K24.\u003C\u003Eo__4.\u003C\u003Ep__2;
      // ISSUE: reference to a compiler-generated field
      if (CharacterCreationControl_WWE2K24.\u003C\u003Eo__4.\u003C\u003Ep__1 == null)
      {
        // ISSUE: reference to a compiler-generated field
        CharacterCreationControl_WWE2K24.\u003C\u003Eo__4.\u003C\u003Ep__1 = CallSite<Func<CallSite, Type, object, JsonSerializerSettings, object>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.InvokeMember(CSharpBinderFlags.None, "DeserializeObject", (IEnumerable<Type>) new Type[1]
        {
          typeof (CharacterProfile_WWE2K24)
        }, typeof (CharacterCreationControl_WWE2K24), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[3]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.IsStaticType, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      Func<CallSite, Type, object, JsonSerializerSettings, object> target2 = CharacterCreationControl_WWE2K24.\u003C\u003Eo__4.\u003C\u003Ep__1.Target;
      // ISSUE: reference to a compiler-generated field
      CallSite<Func<CallSite, Type, object, JsonSerializerSettings, object>> p1 = CharacterCreationControl_WWE2K24.\u003C\u003Eo__4.\u003C\u003Ep__1;
      Type type = typeof (JsonConvert);
      // ISSUE: reference to a compiler-generated field
      if (CharacterCreationControl_WWE2K24.\u003C\u003Eo__4.\u003C\u003Ep__0 == null)
      {
        // ISSUE: reference to a compiler-generated field
        CharacterCreationControl_WWE2K24.\u003C\u003Eo__4.\u003C\u003Ep__0 = CallSite<Func<CallSite, Type, object, JsonSerializerSettings, object>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.InvokeMember(CSharpBinderFlags.None, "SerializeObject", (IEnumerable<Type>) null, typeof (CharacterCreationControl_WWE2K24), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[3]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.IsStaticType, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj1 = CharacterCreationControl_WWE2K24.\u003C\u003Eo__4.\u003C\u003Ep__0.Target((CallSite) CharacterCreationControl_WWE2K24.\u003C\u003Eo__4.\u003C\u003Ep__0, typeof (JsonConvert), profile.Data, serializerSettings2);
      JsonSerializerSettings serializerSettings3 = serializerSettings2;
      object obj2 = target2((CallSite) p1, type, obj1, serializerSettings3);
      CharacterProfile_WWE2K24 characterProfileWwE2K24 = target1((CallSite) p2, obj2);
      if (characterProfileWwE2K24 != null)
      {
        if (characterProfileWwE2K24.Info != null && characterProfileWwE2K24.Motion != null)
        {
          this.editorCharacter.Load((object) characterProfileWwE2K24);
          this.editorMapping.Load(characterProfileWwE2K24, profile);
          this.editorMotion.Load(characterProfileWwE2K24);
          this.logger.Log("[Editor][Character Creation] Loaded profile", Array.Empty<object>());
        }
        else
        {
          int num = (int) MetaMessageBox.Show("Info or Motion data missing", "Meta Data Manager");
        }
      }
    }

    public override void SaveAs()
    {
      ((UIElement) this.editorCharacter.BasicInfoPropertyGrid).UpdateLayout();
      ((FrameworkElement) this.editorCharacter.BasicInfoPropertyGrid).ApplyTemplate();
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
        Type = (ProfileType) 0
      };
      CharacterProfile_WWE2K24 characterProfileWwE2K24 = new CharacterProfile_WWE2K24();
      Info info = new Info();
      info.wrestler_id = this.editorCharacter.CharacterInfo.WrestlerID;
      info.wrestler_id_2 = this.editorCharacter.CharacterInfo.WrestlerID;
      info.slot_id = this.editorCharacter.CharacterInfo.WrestlerSlotID;
      info.fullname_sdb_id = this.editorCharacter.CharacterInfo.WrestlerFullName;
      info.nickname_sdb_id = this.editorCharacter.CharacterInfo.WrestlerNickName;
      info.socialmedia_sdb_id = this.editorCharacter.CharacterInfo.WrestlerSocialMedia;
      info.announcer_id = this.editorCharacter.CharacterInfo.WrestlerAnnounceID;
      info.commentary_id = this.editorCharacter.CharacterInfo.WrestlerCommentaryID;
      info.gender = (byte) (long) this.editorCharacter.CharacterInfo.WrestlerGender.Id;
      info.weight = this.editorCharacter.CharacterInfo.WrestlerWeight;
      info.height = Math.Round((double) this.editorCharacter.CharacterInfo.WrestlerHeight, 2);
      info.location_callname = (uint) this.editorCharacter.CharacterInfo.WrestlerCountry.callname;
      info.weight_class = (byte) (long) this.editorCharacter.CharacterInfo.WrestlerWeightClass.Id;
      info.wrestler_type = (byte) (long) this.editorCharacter.CharacterInfo.WrestlerClass.Id;
      info.crowd_balance = (byte) (long) this.editorCharacter.CharacterInfo.WrestlerCrowdBalance.Id;
      info.crowd_reaction = (byte) (long) this.editorCharacter.CharacterInfo.WrestlerCrowdReaction.Id;
      info.playability = (byte) (long) this.editorCharacter.CharacterInfo.WrestlerPlayability.Id;
      info.menu_location = (byte) (long) this.editorCharacter.CharacterInfo.WrestlerMenuLocation.Id;
      info.payback_01 = (byte) (long) this.editorCharacter.CharacterInfo.WrestlerPayBack1.Id;
      info.payback_02 = (byte) (long) this.editorCharacter.CharacterInfo.WrestlerPayBack2.Id;
      ObservableCollection<byte> source1 = new ObservableCollection<byte>();
      foreach (PropertyInfo property in this.editorCharacter.CharacterStats.GetType().GetProperties())
      {
        if (Attribute.GetCustomAttribute((MemberInfo) property, typeof (CategoryAttribute)) is CategoryAttribute customAttribute && customAttribute.Category.Equals("Attributes"))
          source1.Add((byte) property.GetValue((object) this.editorCharacter.CharacterStats));
      }
      ObservableCollection<byte> source2 = new ObservableCollection<byte>();
      foreach (PropertyInfo property in this.editorCharacter.CharacterStats.GetType().GetProperties())
      {
        if (Attribute.GetCustomAttribute((MemberInfo) property, typeof (CategoryAttribute)) is CategoryAttribute customAttribute && customAttribute.Category.Equals("AI"))
          source2.Add((byte) property.GetValue((object) this.editorCharacter.CharacterStats));
      }
      ObservableCollection<byte> source3 = new ObservableCollection<byte>();
      foreach (PropertyInfo property in this.editorCharacter.CharacterStats.GetType().GetProperties())
      {
        if (Attribute.GetCustomAttribute((MemberInfo) property, typeof (CategoryAttribute)) is CategoryAttribute customAttribute && customAttribute.Category.Equals("Personality"))
          source3.Add((byte) (sbyte) property.GetValue((object) this.editorCharacter.CharacterStats));
      }
      ObservableCollection<byte> source4 = new ObservableCollection<byte>();
      foreach (PropertyInfo property in this.editorCharacter.CharacterStats.GetType().GetProperties())
      {
        if (Attribute.GetCustomAttribute((MemberInfo) property, typeof (CategoryAttribute)) is CategoryAttribute customAttribute && customAttribute.Category.Equals("Hit Point Ratio"))
          source4.Add((byte) ((int) property.GetValue((object) this.editorCharacter.CharacterStats) / 40));
      }
      info.attributes = source1.ToList<byte>();
      info.ai_attributes = source2.ToList<byte>();
      info.personality_traits = source3.ToList<byte>();
      info.hit_point = source4.ToList<byte>();
      Motion motion = new Motion();
      motion.entrance_music = this.editorCharacter.characterPrimaryInfo.Get<EditorCharacter_WWE2K24.CharacterBasicInfo, uint>((Expression<Func<EditorCharacter_WWE2K24.CharacterBasicInfo, uint>>) (e => e.WrestlerMusic));
      motion.victory_motion_face = (uint) (long) this.editorCharacter.CharacterInfo.Get<EditorCharacter_WWE2K24.CharacterBasicInfo, JObject>((Expression<Func<EditorCharacter_WWE2K24.CharacterBasicInfo, JObject>>) (e => e.WrestlerVictoryMotionFace)).Id;
      motion.victory_motion_heel = (uint) (long) this.editorCharacter.CharacterInfo.Get<EditorCharacter_WWE2K24.CharacterBasicInfo, JObject>((Expression<Func<EditorCharacter_WWE2K24.CharacterBasicInfo, JObject>>) (e => e.WrestlerVictoryMotionHeel)).Id;
      motion.victory_title_motion_face = (uint) (long) this.editorCharacter.CharacterInfo.Get<EditorCharacter_WWE2K24.CharacterBasicInfo, JObject>((Expression<Func<EditorCharacter_WWE2K24.CharacterBasicInfo, JObject>>) (e => e.WrestlerVictoryTitleMotionFace)).Id;
      motion.victory_title_motion_heel = (uint) (long) this.editorCharacter.CharacterInfo.Get<EditorCharacter_WWE2K24.CharacterBasicInfo, JObject>((Expression<Func<EditorCharacter_WWE2K24.CharacterBasicInfo, JObject>>) (e => e.WrestlerVictoryTitleMotionHeel)).Id;
      motion.entrance_motion_intro = (uint) (long) this.editorCharacter.CharacterInfo.Get<EditorCharacter_WWE2K24.CharacterBasicInfo, JObject>((Expression<Func<EditorCharacter_WWE2K24.CharacterBasicInfo, JObject>>) (e => e.WrestlerEntranceMotionIntro)).Id;
      motion.entrance_motion_stage = (uint) (long) this.editorCharacter.CharacterInfo.Get<EditorCharacter_WWE2K24.CharacterBasicInfo, JObject>((Expression<Func<EditorCharacter_WWE2K24.CharacterBasicInfo, JObject>>) (e => e.WrestlerEntranceMotionStage)).Id;
      motion.entrance_motion_ramp = (uint) (long) this.editorCharacter.CharacterInfo.Get<EditorCharacter_WWE2K24.CharacterBasicInfo, JObject>((Expression<Func<EditorCharacter_WWE2K24.CharacterBasicInfo, JObject>>) (e => e.WrestlerEntranceMotionRamp)).Id;
      motion.entrance_motion_ring_in = (uint) (long) this.editorCharacter.CharacterInfo.Get<EditorCharacter_WWE2K24.CharacterBasicInfo, JObject>((Expression<Func<EditorCharacter_WWE2K24.CharacterBasicInfo, JObject>>) (e => e.WrestlerEntranceMotionRingIn)).Id;
      motion.entrance_motion_ring = (uint) (long) this.editorCharacter.CharacterInfo.Get<EditorCharacter_WWE2K24.CharacterBasicInfo, JObject>((Expression<Func<EditorCharacter_WWE2K24.CharacterBasicInfo, JObject>>) (e => e.WrestlerEntranceMotionRing)).Id;
      motion.entrance_title_motion = (uint) (long) this.editorCharacter.CharacterInfo.Get<EditorCharacter_WWE2K24.CharacterBasicInfo, JObject>((Expression<Func<EditorCharacter_WWE2K24.CharacterBasicInfo, JObject>>) (e => e.WrestlerEntranceTitleMotion)).Id;
      motion.entrance_MITB_motion = (uint) (long) this.editorCharacter.CharacterInfo.Get<EditorCharacter_WWE2K24.CharacterBasicInfo, JObject>((Expression<Func<EditorCharacter_WWE2K24.CharacterBasicInfo, JObject>>) (e => e.WrestlerEntranceMITBMotion)).Id;
      motion.screen_effect = (byte) (long) this.editorCharacter.CharacterInfo.Get<EditorCharacter_WWE2K24.CharacterBasicInfo, JObject>((Expression<Func<EditorCharacter_WWE2K24.CharacterBasicInfo, JObject>>) (e => e.WrestlerEntranceFilter)).Id;
      motion.light_show = (uint) (long) this.editorCharacter.CharacterInfo.Get<EditorCharacter_WWE2K24.CharacterBasicInfo, JObject>((Expression<Func<EditorCharacter_WWE2K24.CharacterBasicInfo, JObject>>) (e => e.WrestlerEntranceLightShow)).Id;
      motion.movie_titantron = this.editorCharacter.CharacterInfo.WrestlerEntranceMovieTitantron;
      motion.movie_barricade = this.editorCharacter.CharacterInfo.WrestlerEntranceMovieBarricade;
      motion.movie_banner = this.editorCharacter.CharacterInfo.WrestlerEntranceMovieBanner;
      motion.movie_stage_ramp = this.editorCharacter.CharacterInfo.WrestlerEntranceMovieStageRamp;
      motion.movie_apron_ringpost = this.editorCharacter.CharacterInfo.WrestlerEntranceMovieApronRingPost;
      MovieConfig movieConfig = this.editorCharacter.CharacterInfo.MovieConfigs.Where<MovieConfig>((Func<MovieConfig, bool>) (s => s.Apron.Equals(this.editorCharacter.CharacterInfo.WrestlerMovieDisplayApron) && s.Banner.Equals(this.editorCharacter.CharacterInfo.WrestlerMovieDisplayBanner) && s.Barricade.Equals(this.editorCharacter.CharacterInfo.WrestlerMovieDisplayBarricade) && s.Post.Equals(this.editorCharacter.CharacterInfo.WrestlerMovieDisplayPost) && s.Stage.Equals(this.editorCharacter.CharacterInfo.WrestlerMovieDisplayStage) && s.Titantron.Equals(this.editorCharacter.CharacterInfo.WrestlerMovieDisplayTitantron))).FirstOrDefault<MovieConfig>();
      motion.movies_enabled = movieConfig.Value;
      Moveset moveset1 = new Moveset();
      if (this.editorMotion.Primaryinfo.MovesetStandingComboEndersAway1 != null)
      {
        Moveset moveset2 = moveset1;
        Motion_Standing motionStanding1 = new Motion_Standing();
        Motion_Standing motionStanding2 = motionStanding1;
        List<ushort> ushortList1 = new List<ushort>();
        ushortList1.Add((ushort) (long) this.editorMotion.Primaryinfo.Get<EditorMotion_WWE2K24.MotionPrimary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionPrimary, JObject>>) (e => e.MovesetStandingLightAttack1)).Id);
        ushortList1.Add((ushort) (long) this.editorMotion.Primaryinfo.Get<EditorMotion_WWE2K24.MotionPrimary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionPrimary, JObject>>) (e => e.MovesetStandingLightAttack2)).Id);
        ushortList1.Add((ushort) (long) this.editorMotion.Primaryinfo.Get<EditorMotion_WWE2K24.MotionPrimary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionPrimary, JObject>>) (e => e.MovesetStandingLightAttack3)).Id);
        List<ushort> ushortList2 = ushortList1;
        motionStanding2.front_light_attack = ushortList2;
        Motion_Standing motionStanding3 = motionStanding1;
        List<ushort> ushortList3 = new List<ushort>();
        ushortList3.Add((ushort) (long) this.editorMotion.Primaryinfo.Get<EditorMotion_WWE2K24.MotionPrimary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionPrimary, JObject>>) (e => e.MovesetStandingHeavyAttack1)).Id);
        ushortList3.Add((ushort) (long) this.editorMotion.Primaryinfo.Get<EditorMotion_WWE2K24.MotionPrimary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionPrimary, JObject>>) (e => e.MovesetStandingHeavyAttack2)).Id);
        ushortList3.Add((ushort) (long) this.editorMotion.Primaryinfo.Get<EditorMotion_WWE2K24.MotionPrimary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionPrimary, JObject>>) (e => e.MovesetStandingHeavyAttack3)).Id);
        List<ushort> ushortList4 = ushortList3;
        motionStanding3.front_heavy_attack = ushortList4;
        Motion_Standing motionStanding4 = motionStanding1;
        List<ushort> ushortList5 = new List<ushort>();
        ushortList5.Add((ushort) (long) this.editorMotion.Primaryinfo.Get<EditorMotion_WWE2K24.MotionPrimary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionPrimary, JObject>>) (e => e.MovesetStandingLightGrapple1)).Id);
        ushortList5.Add((ushort) (long) this.editorMotion.Primaryinfo.Get<EditorMotion_WWE2K24.MotionPrimary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionPrimary, JObject>>) (e => e.MovesetStandingLightGrapple2)).Id);
        ushortList5.Add((ushort) (long) this.editorMotion.Primaryinfo.Get<EditorMotion_WWE2K24.MotionPrimary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionPrimary, JObject>>) (e => e.MovesetStandingLightGrapple3)).Id);
        ushortList5.Add((ushort) (long) this.editorMotion.Primaryinfo.Get<EditorMotion_WWE2K24.MotionPrimary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionPrimary, JObject>>) (e => e.MovesetStandingLightGrapple4)).Id);
        ushortList5.Add((ushort) (long) this.editorMotion.Primaryinfo.Get<EditorMotion_WWE2K24.MotionPrimary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionPrimary, JObject>>) (e => e.MovesetStandingLightGrapple5)).Id);
        List<ushort> ushortList6 = ushortList5;
        motionStanding4.front_light_grapple = ushortList6;
        Motion_Standing motionStanding5 = motionStanding1;
        List<ushort> ushortList7 = new List<ushort>();
        ushortList7.Add((ushort) (long) this.editorMotion.Primaryinfo.Get<EditorMotion_WWE2K24.MotionPrimary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionPrimary, JObject>>) (e => e.MovesetStandingHeavyGrapple1)).Id);
        ushortList7.Add((ushort) (long) this.editorMotion.Primaryinfo.Get<EditorMotion_WWE2K24.MotionPrimary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionPrimary, JObject>>) (e => e.MovesetStandingHeavyGrapple2)).Id);
        ushortList7.Add((ushort) (long) this.editorMotion.Primaryinfo.Get<EditorMotion_WWE2K24.MotionPrimary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionPrimary, JObject>>) (e => e.MovesetStandingHeavyGrapple3)).Id);
        ushortList7.Add((ushort) (long) this.editorMotion.Primaryinfo.Get<EditorMotion_WWE2K24.MotionPrimary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionPrimary, JObject>>) (e => e.MovesetStandingHeavyGrapple4)).Id);
        ushortList7.Add((ushort) (long) this.editorMotion.Primaryinfo.Get<EditorMotion_WWE2K24.MotionPrimary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionPrimary, JObject>>) (e => e.MovesetStandingHeavyGrapple5)).Id);
        List<ushort> ushortList8 = ushortList7;
        motionStanding5.front_heavy_grapple = ushortList8;
        Motion_Standing motionStanding6 = motionStanding1;
        List<ushort> ushortList9 = new List<ushort>();
        ushortList9.Add((ushort) (long) this.editorMotion.Primaryinfo.Get<EditorMotion_WWE2K24.MotionPrimary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionPrimary, JObject>>) (e => e.MovesetStandingFrontRunningAttack1)).Id);
        ushortList9.Add((ushort) (long) this.editorMotion.Primaryinfo.Get<EditorMotion_WWE2K24.MotionPrimary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionPrimary, JObject>>) (e => e.MovesetStandingFrontRunningAttack2)).Id);
        ushortList9.Add((ushort) (long) this.editorMotion.Primaryinfo.Get<EditorMotion_WWE2K24.MotionPrimary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionPrimary, JObject>>) (e => e.MovesetStandingFrontRunningAttack3)).Id);
        List<ushort> ushortList10 = ushortList9;
        motionStanding6.front_running = ushortList10;
        Motion_Standing motionStanding7 = motionStanding1;
        List<ushort> ushortList11 = new List<ushort>();
        ushortList11.Add((ushort) (long) this.editorMotion.Primaryinfo.Get<EditorMotion_WWE2K24.MotionPrimary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionPrimary, JObject>>) (e => e.MovesetStandingRearHeavyAttack)).Id);
        List<ushort> ushortList12 = ushortList11;
        motionStanding7.rear_heavy_attack = ushortList12;
        Motion_Standing motionStanding8 = motionStanding1;
        List<ushort> ushortList13 = new List<ushort>();
        ushortList13.Add((ushort) (long) this.editorMotion.Primaryinfo.Get<EditorMotion_WWE2K24.MotionPrimary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionPrimary, JObject>>) (e => e.MovesetStandingRearLightGrapple1)).Id);
        ushortList13.Add((ushort) (long) this.editorMotion.Primaryinfo.Get<EditorMotion_WWE2K24.MotionPrimary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionPrimary, JObject>>) (e => e.MovesetStandingRearLightGrapple2)).Id);
        ushortList13.Add((ushort) (long) this.editorMotion.Primaryinfo.Get<EditorMotion_WWE2K24.MotionPrimary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionPrimary, JObject>>) (e => e.MovesetStandingRearLightGrapple3)).Id);
        ushortList13.Add((ushort) (long) this.editorMotion.Primaryinfo.Get<EditorMotion_WWE2K24.MotionPrimary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionPrimary, JObject>>) (e => e.MovesetStandingRearLightGrapple4)).Id);
        ushortList13.Add((ushort) (long) this.editorMotion.Primaryinfo.Get<EditorMotion_WWE2K24.MotionPrimary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionPrimary, JObject>>) (e => e.MovesetStandingRearLightGrapple5)).Id);
        List<ushort> ushortList14 = ushortList13;
        motionStanding8.rear_light_grapple = ushortList14;
        Motion_Standing motionStanding9 = motionStanding1;
        List<ushort> ushortList15 = new List<ushort>();
        ushortList15.Add((ushort) (long) this.editorMotion.Primaryinfo.Get<EditorMotion_WWE2K24.MotionPrimary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionPrimary, JObject>>) (e => e.MovesetStandingRearHeavyGrapple1)).Id);
        ushortList15.Add((ushort) (long) this.editorMotion.Primaryinfo.Get<EditorMotion_WWE2K24.MotionPrimary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionPrimary, JObject>>) (e => e.MovesetStandingRearHeavyGrapple2)).Id);
        ushortList15.Add((ushort) (long) this.editorMotion.Primaryinfo.Get<EditorMotion_WWE2K24.MotionPrimary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionPrimary, JObject>>) (e => e.MovesetStandingRearHeavyGrapple3)).Id);
        ushortList15.Add((ushort) (long) this.editorMotion.Primaryinfo.Get<EditorMotion_WWE2K24.MotionPrimary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionPrimary, JObject>>) (e => e.MovesetStandingRearHeavyGrapple4)).Id);
        ushortList15.Add((ushort) (long) this.editorMotion.Primaryinfo.Get<EditorMotion_WWE2K24.MotionPrimary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionPrimary, JObject>>) (e => e.MovesetStandingRearHeavyGrapple5)).Id);
        List<ushort> ushortList16 = ushortList15;
        motionStanding9.rear_heavy_grapple = ushortList16;
        Motion_Standing motionStanding10 = motionStanding1;
        List<ushort> ushortList17 = new List<ushort>();
        ushortList17.Add((ushort) (long) this.editorMotion.Primaryinfo.Get<EditorMotion_WWE2K24.MotionPrimary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionPrimary, JObject>>) (e => e.MovesetStandingRearRunning1)).Id);
        ushortList17.Add((ushort) (long) this.editorMotion.Primaryinfo.Get<EditorMotion_WWE2K24.MotionPrimary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionPrimary, JObject>>) (e => e.MovesetStandingRearRunning2)).Id);
        ushortList17.Add((ushort) (long) this.editorMotion.Primaryinfo.Get<EditorMotion_WWE2K24.MotionPrimary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionPrimary, JObject>>) (e => e.MovesetStandingRearRunning3)).Id);
        List<ushort> ushortList18 = ushortList17;
        motionStanding10.rear_running = ushortList18;
        Motion_Standing motionStanding11 = motionStanding1;
        List<ushort> ushortList19 = new List<ushort>();
        ushortList19.Add((ushort) (long) this.editorMotion.Primaryinfo.Get<EditorMotion_WWE2K24.MotionPrimary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionPrimary, JObject>>) (e => e.MovesetStandingCarry1)).Id);
        ushortList19.Add((ushort) (long) this.editorMotion.Primaryinfo.Get<EditorMotion_WWE2K24.MotionPrimary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionPrimary, JObject>>) (e => e.MovesetStandingCarry2)).Id);
        ushortList19.Add((ushort) (long) this.editorMotion.Primaryinfo.Get<EditorMotion_WWE2K24.MotionPrimary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionPrimary, JObject>>) (e => e.MovesetStandingCarry3)).Id);
        ushortList19.Add((ushort) (long) this.editorMotion.Primaryinfo.Get<EditorMotion_WWE2K24.MotionPrimary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionPrimary, JObject>>) (e => e.MovesetStandingCarry4)).Id);
        List<ushort> ushortList20 = ushortList19;
        motionStanding11.carry = ushortList20;
        Motion_Standing motionStanding12 = motionStanding1;
        List<ushort> ushortList21 = new List<ushort>();
        ushortList21.Add((ushort) (long) this.editorMotion.Primaryinfo.Get<EditorMotion_WWE2K24.MotionPrimary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionPrimary, JObject>>) (e => e.MovesetStandingFootCatch1)).Id);
        ushortList21.Add((ushort) (long) this.editorMotion.Primaryinfo.Get<EditorMotion_WWE2K24.MotionPrimary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionPrimary, JObject>>) (e => e.MovesetStandingFootCatch2)).Id);
        ushortList21.Add((ushort) (long) this.editorMotion.Primaryinfo.Get<EditorMotion_WWE2K24.MotionPrimary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionPrimary, JObject>>) (e => e.MovesetStandingFootCatch3)).Id);
        ushortList21.Add((ushort) (long) this.editorMotion.Primaryinfo.Get<EditorMotion_WWE2K24.MotionPrimary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionPrimary, JObject>>) (e => e.MovesetStandingFootCatch4)).Id);
        List<ushort> ushortList22 = ushortList21;
        motionStanding12.foot_catch = ushortList22;
        Motion_Standing motionStanding13 = motionStanding1;
        List<ushort> ushortList23 = new List<ushort>();
        ushortList23.Add((ushort) (long) this.editorMotion.Primaryinfo.Get<EditorMotion_WWE2K24.MotionPrimary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionPrimary, JObject>>) (e => e.MovesetStandingLeveragePin1)).Id);
        ushortList23.Add((ushort) (long) this.editorMotion.Primaryinfo.Get<EditorMotion_WWE2K24.MotionPrimary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionPrimary, JObject>>) (e => e.MovesetStandingLeveragePin2)).Id);
        List<ushort> ushortList24 = ushortList23;
        motionStanding13.leverage_pin = ushortList24;
        Motion_Standing motionStanding14 = motionStanding1;
        List<uint> uintList1 = new List<uint>();
        uintList1.Add((uint) (long) this.editorMotion.Primaryinfo.Get<EditorMotion_WWE2K24.MotionPrimary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionPrimary, JObject>>) (e => e.MovesetStandingComboChain3)).Id);
        List<uint> uintList2 = uintList1;
        motionStanding14.combo_chain_away = uintList2;
        Motion_Standing motionStanding15 = motionStanding1;
        List<uint> uintList3 = new List<uint>();
        uintList3.Add((uint) (long) this.editorMotion.Primaryinfo.Get<EditorMotion_WWE2K24.MotionPrimary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionPrimary, JObject>>) (e => e.MovesetStandingComboChain1)).Id);
        List<uint> uintList4 = uintList3;
        motionStanding15.combo_chain_towards = uintList4;
        Motion_Standing motionStanding16 = motionStanding1;
        List<uint> uintList5 = new List<uint>();
        uintList5.Add((uint) (long) this.editorMotion.Primaryinfo.Get<EditorMotion_WWE2K24.MotionPrimary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionPrimary, JObject>>) (e => e.MovesetStandingComboChain2)).Id);
        List<uint> uintList6 = uintList5;
        motionStanding16.combo_chain_neutral = uintList6;
        motionStanding1.combo_enders_away = new List<ushort>();
        motionStanding1.combo_enders_neutral = new List<ushort>();
        motionStanding1.combo_enders_towards = new List<ushort>();
        Motion_Standing motionStanding17 = motionStanding1;
        moveset2.moves_standing = motionStanding17;
        foreach (PropertyInfo property in this.editorMotion.Primaryinfo.GetType().GetProperties())
        {
          if (Attribute.GetCustomAttribute((MemberInfo) property, typeof (CategoryAttribute)) is CategoryAttribute customAttribute && customAttribute.Category.Equals("Standing|Combo Enders - Towards"))
          {
            object obj = property.GetValue((object) this.editorMotion.Primaryinfo);
            if (obj != null)
              moveset1.moves_standing.combo_enders_towards.Add((ushort) (long) ((JObject) obj).Id);
          }
        }
        foreach (PropertyInfo property in this.editorMotion.Primaryinfo.GetType().GetProperties())
        {
          if (Attribute.GetCustomAttribute((MemberInfo) property, typeof (CategoryAttribute)) is CategoryAttribute customAttribute && customAttribute.Category.Equals("Standing|Combo Enders - Neutral"))
          {
            object obj = property.GetValue((object) this.editorMotion.Primaryinfo);
            if (obj != null)
              moveset1.moves_standing.combo_enders_neutral.Add((ushort) (long) ((JObject) obj).Id);
          }
        }
        foreach (PropertyInfo property in this.editorMotion.Primaryinfo.GetType().GetProperties())
        {
          if (Attribute.GetCustomAttribute((MemberInfo) property, typeof (CategoryAttribute)) is CategoryAttribute customAttribute && customAttribute.Category.Equals("Standing|Combo Enders - Away"))
          {
            object obj = property.GetValue((object) this.editorMotion.Primaryinfo);
            if (obj != null)
              moveset1.moves_standing.combo_enders_away.Add((ushort) (long) ((JObject) obj).Id);
          }
        }
        Moveset moveset3 = moveset1;
        Motion_Signatures motionSignatures1 = new Motion_Signatures();
        Motion_Signatures motionSignatures2 = motionSignatures1;
        List<ushort> ushortList25 = new List<ushort>();
        ushortList25.Add((ushort) (long) this.editorMotion.Primaryinfo.Get<EditorMotion_WWE2K24.MotionPrimary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionPrimary, JObject>>) (e => e.MovesetSignaturesInRing1)).Id);
        ushortList25.Add((ushort) (long) this.editorMotion.Primaryinfo.Get<EditorMotion_WWE2K24.MotionPrimary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionPrimary, JObject>>) (e => e.MovesetSignaturesInRing2)).Id);
        List<ushort> ushortList26 = ushortList25;
        motionSignatures2.in_ring = ushortList26;
        Motion_Signatures motionSignatures3 = motionSignatures1;
        List<ushort> ushortList27 = new List<ushort>();
        ushortList27.Add((ushort) (long) this.editorMotion.Primaryinfo.Get<EditorMotion_WWE2K24.MotionPrimary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionPrimary, JObject>>) (e => e.MovesetSignaturesRingside1)).Id);
        ushortList27.Add((ushort) (long) this.editorMotion.Primaryinfo.Get<EditorMotion_WWE2K24.MotionPrimary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionPrimary, JObject>>) (e => e.MovesetSignaturesRingside2)).Id);
        List<ushort> ushortList28 = ushortList27;
        motionSignatures3.ringside = ushortList28;
        Motion_Signatures motionSignatures4 = motionSignatures1;
        moveset3.moves_signatures = motionSignatures4;
        Moveset moveset4 = moveset1;
        Motion_Finishers motionFinishers1 = new Motion_Finishers();
        Motion_Finishers motionFinishers2 = motionFinishers1;
        List<ushort> ushortList29 = new List<ushort>();
        ushortList29.Add((ushort) (long) this.editorMotion.Primaryinfo.Get<EditorMotion_WWE2K24.MotionPrimary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionPrimary, JObject>>) (e => e.MovesetFinisherInRing1)).Id);
        ushortList29.Add((ushort) (long) this.editorMotion.Primaryinfo.Get<EditorMotion_WWE2K24.MotionPrimary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionPrimary, JObject>>) (e => e.MovesetFinisherInRing2)).Id);
        List<ushort> ushortList30 = ushortList29;
        motionFinishers2.in_ring = ushortList30;
        Motion_Finishers motionFinishers3 = motionFinishers1;
        List<ushort> ushortList31 = new List<ushort>();
        ushortList31.Add((ushort) (long) this.editorMotion.Primaryinfo.Get<EditorMotion_WWE2K24.MotionPrimary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionPrimary, JObject>>) (e => e.MovesetFinisherRingside1)).Id);
        ushortList31.Add((ushort) (long) this.editorMotion.Primaryinfo.Get<EditorMotion_WWE2K24.MotionPrimary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionPrimary, JObject>>) (e => e.MovesetFinisherRingside2)).Id);
        ushortList31.Add((ushort) (long) this.editorMotion.Primaryinfo.Get<EditorMotion_WWE2K24.MotionPrimary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionPrimary, JObject>>) (e => e.MovesetFinisherRingside3)).Id);
        List<ushort> ushortList32 = ushortList31;
        motionFinishers3.ringside = ushortList32;
        Motion_Finishers motionFinishers4 = motionFinishers1;
        List<ushort> ushortList33 = new List<ushort>();
        ushortList33.Add((ushort) (long) this.editorMotion.Primaryinfo.Get<EditorMotion_WWE2K24.MotionPrimary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionPrimary, JObject>>) (e => e.MovesetFinisher1V2)).Id);
        ushortList33.Add((ushort) (long) this.editorMotion.Primaryinfo.Get<EditorMotion_WWE2K24.MotionPrimary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionPrimary, JObject>>) (e => e.MovesetFinisherCatching)).Id);
        ushortList33.Add((ushort) (long) this.editorMotion.SecondaryInfo.Get<EditorMotion_WWE2K24.MotionSecondary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionSecondary, JObject>>) (e => e.MovesetMatchTypeHellInACell1)).Id);
        ushortList33.Add((ushort) (long) this.editorMotion.Primaryinfo.Get<EditorMotion_WWE2K24.MotionPrimary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionPrimary, JObject>>) (e => e.MovesetFinisherHellInACell)).Id);
        ushortList33.Add((ushort) (long) this.editorMotion.Primaryinfo.Get<EditorMotion_WWE2K24.MotionPrimary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionPrimary, JObject>>) (e => e.MovesetFinisherAnnouncerTable)).Id);
        ushortList33.Add((ushort) (long) this.editorMotion.Primaryinfo.Get<EditorMotion_WWE2K24.MotionPrimary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionPrimary, JObject>>) (e => e.MovesetFinisherLedge)).Id);
        List<ushort> ushortList34 = ushortList33;
        motionFinishers4.other = ushortList34;
        Motion_Finishers motionFinishers5 = motionFinishers1;
        List<ushort> ushortList35 = new List<ushort>();
        ushortList35.Add((ushort) (long) this.editorMotion.Primaryinfo.Get<EditorMotion_WWE2K24.MotionPrimary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionPrimary, JObject>>) (e => e.MovesetFinisherTable1)).Id);
        ushortList35.Add((ushort) (long) this.editorMotion.Primaryinfo.Get<EditorMotion_WWE2K24.MotionPrimary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionPrimary, JObject>>) (e => e.MovesetFinisherTable2)).Id);
        List<ushort> ushortList36 = ushortList35;
        motionFinishers5.table = ushortList36;
        Motion_Finishers motionFinishers6 = motionFinishers1;
        List<ushort> ushortList37 = new List<ushort>();
        ushortList37.Add((ushort) (long) this.editorMotion.SecondaryInfo.Get<EditorMotion_WWE2K24.MotionSecondary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionSecondary, JObject>>) (e => e.MovesetMatchTypeMixedTagNormalTagFinishers1)).Id);
        ushortList37.Add((ushort) (long) this.editorMotion.SecondaryInfo.Get<EditorMotion_WWE2K24.MotionSecondary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionSecondary, JObject>>) (e => e.MovesetMatchTypeMixedTagNormalTagFinishers2)).Id);
        List<ushort> ushortList38 = ushortList37;
        motionFinishers6.tag_team_mixed_tag = ushortList38;
        Motion_Finishers motionFinishers7 = motionFinishers1;
        List<ushort> ushortList39 = new List<ushort>();
        ushortList39.Add((ushort) (long) this.editorMotion.Primaryinfo.Get<EditorMotion_WWE2K24.MotionPrimary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionPrimary, JObject>>) (e => e.MovesetFinisherRumble1)).Id);
        ushortList39.Add((ushort) (long) this.editorMotion.Primaryinfo.Get<EditorMotion_WWE2K24.MotionPrimary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionPrimary, JObject>>) (e => e.MovesetFinisherRumble2)).Id);
        ushortList39.Add((ushort) (long) this.editorMotion.Primaryinfo.Get<EditorMotion_WWE2K24.MotionPrimary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionPrimary, JObject>>) (e => e.MovesetFinisherRumble3)).Id);
        ushortList39.Add((ushort) (long) this.editorMotion.Primaryinfo.Get<EditorMotion_WWE2K24.MotionPrimary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionPrimary, JObject>>) (e => e.MovesetFinisherRumble4)).Id);
        List<ushort> ushortList40 = ushortList39;
        motionFinishers7.rumble = ushortList40;
        Motion_Finishers motionFinishers8 = motionFinishers1;
        moveset4.moves_finishers = motionFinishers8;
        Moveset moveset5 = moveset1;
        Motion_Ground motionGround1 = new Motion_Ground();
        Motion_Ground motionGround2 = motionGround1;
        List<ushort> ushortList41 = new List<ushort>();
        ushortList41.Add((ushort) (long) this.editorMotion.Primaryinfo.Get<EditorMotion_WWE2K24.MotionPrimary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionPrimary, JObject>>) (e => e.MovesetGroundFaceuUpUppper1)).Id);
        ushortList41.Add((ushort) (long) this.editorMotion.Primaryinfo.Get<EditorMotion_WWE2K24.MotionPrimary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionPrimary, JObject>>) (e => e.MovesetGroundFaceuUpUppper2)).Id);
        ushortList41.Add((ushort) (long) this.editorMotion.Primaryinfo.Get<EditorMotion_WWE2K24.MotionPrimary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionPrimary, JObject>>) (e => e.MovesetGroundFaceuUpUppper3)).Id);
        List<ushort> ushortList42 = ushortList41;
        motionGround2.face_up_upper = ushortList42;
        Motion_Ground motionGround3 = motionGround1;
        List<ushort> ushortList43 = new List<ushort>();
        ushortList43.Add((ushort) (long) this.editorMotion.Primaryinfo.Get<EditorMotion_WWE2K24.MotionPrimary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionPrimary, JObject>>) (e => e.MovesetGroundFaceuUpSide1)).Id);
        ushortList43.Add((ushort) (long) this.editorMotion.Primaryinfo.Get<EditorMotion_WWE2K24.MotionPrimary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionPrimary, JObject>>) (e => e.MovesetGroundFaceuUpSide2)).Id);
        ushortList43.Add((ushort) (long) this.editorMotion.Primaryinfo.Get<EditorMotion_WWE2K24.MotionPrimary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionPrimary, JObject>>) (e => e.MovesetGroundFaceuUpSide3)).Id);
        List<ushort> ushortList44 = ushortList43;
        motionGround3.face_up_side = ushortList44;
        Motion_Ground motionGround4 = motionGround1;
        List<ushort> ushortList45 = new List<ushort>();
        ushortList45.Add((ushort) (long) this.editorMotion.Primaryinfo.Get<EditorMotion_WWE2K24.MotionPrimary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionPrimary, JObject>>) (e => e.MovesetGroundFaceuUpLower1)).Id);
        ushortList45.Add((ushort) (long) this.editorMotion.Primaryinfo.Get<EditorMotion_WWE2K24.MotionPrimary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionPrimary, JObject>>) (e => e.MovesetGroundFaceuUpLower2)).Id);
        ushortList45.Add((ushort) (long) this.editorMotion.Primaryinfo.Get<EditorMotion_WWE2K24.MotionPrimary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionPrimary, JObject>>) (e => e.MovesetGroundFaceuUpLower3)).Id);
        List<ushort> ushortList46 = ushortList45;
        motionGround4.face_up_lower = ushortList46;
        Motion_Ground motionGround5 = motionGround1;
        List<ushort> ushortList47 = new List<ushort>();
        ushortList47.Add((ushort) (long) this.editorMotion.Primaryinfo.Get<EditorMotion_WWE2K24.MotionPrimary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionPrimary, JObject>>) (e => e.MovesetGroundFaceuUpRunning)).Id);
        List<ushort> ushortList48 = ushortList47;
        motionGround5.face_up_running = ushortList48;
        Motion_Ground motionGround6 = motionGround1;
        List<ushort> ushortList49 = new List<ushort>();
        ushortList49.Add((ushort) (long) this.editorMotion.Primaryinfo.Get<EditorMotion_WWE2K24.MotionPrimary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionPrimary, JObject>>) (e => e.MovesetGroundFaceDownUppper1)).Id);
        ushortList49.Add((ushort) (long) this.editorMotion.Primaryinfo.Get<EditorMotion_WWE2K24.MotionPrimary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionPrimary, JObject>>) (e => e.MovesetGroundFaceDownUppper2)).Id);
        ushortList49.Add((ushort) (long) this.editorMotion.Primaryinfo.Get<EditorMotion_WWE2K24.MotionPrimary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionPrimary, JObject>>) (e => e.MovesetGroundFaceDownUppper3)).Id);
        List<ushort> ushortList50 = ushortList49;
        motionGround6.face_down_upper = ushortList50;
        Motion_Ground motionGround7 = motionGround1;
        List<ushort> ushortList51 = new List<ushort>();
        ushortList51.Add((ushort) (long) this.editorMotion.Primaryinfo.Get<EditorMotion_WWE2K24.MotionPrimary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionPrimary, JObject>>) (e => e.MovesetGroundFaceDownSide1)).Id);
        ushortList51.Add((ushort) (long) this.editorMotion.Primaryinfo.Get<EditorMotion_WWE2K24.MotionPrimary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionPrimary, JObject>>) (e => e.MovesetGroundFaceDownSide2)).Id);
        ushortList51.Add((ushort) (long) this.editorMotion.Primaryinfo.Get<EditorMotion_WWE2K24.MotionPrimary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionPrimary, JObject>>) (e => e.MovesetGroundFaceDownSide3)).Id);
        List<ushort> ushortList52 = ushortList51;
        motionGround7.face_down_side = ushortList52;
        Motion_Ground motionGround8 = motionGround1;
        List<ushort> ushortList53 = new List<ushort>();
        ushortList53.Add((ushort) (long) this.editorMotion.Primaryinfo.Get<EditorMotion_WWE2K24.MotionPrimary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionPrimary, JObject>>) (e => e.MovesetGroundFaceDownLower1)).Id);
        ushortList53.Add((ushort) (long) this.editorMotion.Primaryinfo.Get<EditorMotion_WWE2K24.MotionPrimary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionPrimary, JObject>>) (e => e.MovesetGroundFaceDownLower2)).Id);
        ushortList53.Add((ushort) (long) this.editorMotion.Primaryinfo.Get<EditorMotion_WWE2K24.MotionPrimary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionPrimary, JObject>>) (e => e.MovesetGroundFaceDownLower3)).Id);
        List<ushort> ushortList54 = ushortList53;
        motionGround8.face_down_lower = ushortList54;
        Motion_Ground motionGround9 = motionGround1;
        List<ushort> ushortList55 = new List<ushort>();
        ushortList55.Add((ushort) (long) this.editorMotion.Primaryinfo.Get<EditorMotion_WWE2K24.MotionPrimary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionPrimary, JObject>>) (e => e.MovesetGroundKneelingFront1)).Id);
        ushortList55.Add((ushort) (long) this.editorMotion.Primaryinfo.Get<EditorMotion_WWE2K24.MotionPrimary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionPrimary, JObject>>) (e => e.MovesetGroundKneelingFront2)).Id);
        ushortList55.Add((ushort) (long) this.editorMotion.Primaryinfo.Get<EditorMotion_WWE2K24.MotionPrimary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionPrimary, JObject>>) (e => e.MovesetGroundKneelingFront3)).Id);
        ushortList55.Add((ushort) (long) this.editorMotion.Primaryinfo.Get<EditorMotion_WWE2K24.MotionPrimary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionPrimary, JObject>>) (e => e.MovesetGroundKneelingFront4)).Id);
        ushortList55.Add((ushort) (long) this.editorMotion.Primaryinfo.Get<EditorMotion_WWE2K24.MotionPrimary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionPrimary, JObject>>) (e => e.MovesetGroundKneelingFront5)).Id);
        List<ushort> ushortList56 = ushortList55;
        motionGround9.kneeling_front = ushortList56;
        Motion_Ground motionGround10 = motionGround1;
        List<ushort> ushortList57 = new List<ushort>();
        ushortList57.Add((ushort) (long) this.editorMotion.Primaryinfo.Get<EditorMotion_WWE2K24.MotionPrimary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionPrimary, JObject>>) (e => e.MovesetGroundKneelingRear1)).Id);
        ushortList57.Add((ushort) (long) this.editorMotion.Primaryinfo.Get<EditorMotion_WWE2K24.MotionPrimary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionPrimary, JObject>>) (e => e.MovesetGroundKneelingRear2)).Id);
        List<ushort> ushortList58 = ushortList57;
        motionGround10.kneeling_rear = ushortList58;
        Motion_Ground motionGround11 = motionGround1;
        List<ushort> ushortList59 = new List<ushort>();
        ushortList59.Add((ushort) (long) this.editorMotion.Primaryinfo.Get<EditorMotion_WWE2K24.MotionPrimary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionPrimary, JObject>>) (e => e.MovesetGroundSeatedFront1)).Id);
        ushortList59.Add((ushort) (long) this.editorMotion.Primaryinfo.Get<EditorMotion_WWE2K24.MotionPrimary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionPrimary, JObject>>) (e => e.MovesetGroundSeatedFront2)).Id);
        ushortList59.Add((ushort) (long) this.editorMotion.Primaryinfo.Get<EditorMotion_WWE2K24.MotionPrimary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionPrimary, JObject>>) (e => e.MovesetGroundSeatedFront3)).Id);
        List<ushort> ushortList60 = ushortList59;
        motionGround11.seated_front = ushortList60;
        Motion_Ground motionGround12 = motionGround1;
        List<ushort> ushortList61 = new List<ushort>();
        ushortList61.Add((ushort) (long) this.editorMotion.Primaryinfo.Get<EditorMotion_WWE2K24.MotionPrimary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionPrimary, JObject>>) (e => e.MovesetGroundSeatedRear1)).Id);
        ushortList61.Add((ushort) (long) this.editorMotion.Primaryinfo.Get<EditorMotion_WWE2K24.MotionPrimary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionPrimary, JObject>>) (e => e.MovesetGroundSeatedRear2)).Id);
        List<ushort> ushortList62 = ushortList61;
        motionGround12.seated_rear = ushortList62;
        Motion_Ground motionGround13 = motionGround1;
        moveset5.moves_ground = motionGround13;
        Moveset moveset6 = moveset1;
        Motion_IrishWhip motionIrishWhip1 = new Motion_IrishWhip();
        Motion_IrishWhip motionIrishWhip2 = motionIrishWhip1;
        List<ushort> ushortList63 = new List<ushort>();
        ushortList63.Add((ushort) (long) this.editorMotion.Primaryinfo.Get<EditorMotion_WWE2K24.MotionPrimary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionPrimary, JObject>>) (e => e.MovesetIrishWhipReboundAction1)).Id);
        ushortList63.Add((ushort) (long) this.editorMotion.Primaryinfo.Get<EditorMotion_WWE2K24.MotionPrimary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionPrimary, JObject>>) (e => e.MovesetIrishWhipReboundAction2)).Id);
        List<ushort> ushortList64 = ushortList63;
        motionIrishWhip2.rebound_action = ushortList64;
        Motion_IrishWhip motionIrishWhip3 = motionIrishWhip1;
        List<ushort> ushortList65 = new List<ushort>();
        ushortList65.Add((ushort) (long) this.editorMotion.Primaryinfo.Get<EditorMotion_WWE2K24.MotionPrimary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionPrimary, JObject>>) (e => e.MovesetIrishWhipReboundAttack1)).Id);
        ushortList65.Add((ushort) (long) this.editorMotion.Primaryinfo.Get<EditorMotion_WWE2K24.MotionPrimary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionPrimary, JObject>>) (e => e.MovesetIrishWhipReboundAttack2)).Id);
        ushortList65.Add((ushort) (long) this.editorMotion.Primaryinfo.Get<EditorMotion_WWE2K24.MotionPrimary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionPrimary, JObject>>) (e => e.MovesetIrishWhipReboundAttack3)).Id);
        List<ushort> ushortList66 = ushortList65;
        motionIrishWhip3.rebound_attack = ushortList66;
        Motion_IrishWhip motionIrishWhip4 = motionIrishWhip1;
        List<ushort> ushortList67 = new List<ushort>();
        ushortList67.Add((ushort) (long) this.editorMotion.Primaryinfo.Get<EditorMotion_WWE2K24.MotionPrimary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionPrimary, JObject>>) (e => e.MovesetIrishWhipPullBackAttack1)).Id);
        ushortList67.Add((ushort) (long) this.editorMotion.Primaryinfo.Get<EditorMotion_WWE2K24.MotionPrimary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionPrimary, JObject>>) (e => e.MovesetIrishWhipPullBackAttack2)).Id);
        List<ushort> ushortList68 = ushortList67;
        motionIrishWhip4.pullback_attack = ushortList68;
        Motion_IrishWhip motionIrishWhip5 = motionIrishWhip1;
        moveset6.moves_irish_whip = motionIrishWhip5;
        Moveset moveset7 = moveset1;
        Motion_Corner motionCorner1 = new Motion_Corner();
        Motion_Corner motionCorner2 = motionCorner1;
        List<ushort> ushortList69 = new List<ushort>();
        ushortList69.Add((ushort) (long) this.editorMotion.Primaryinfo.Get<EditorMotion_WWE2K24.MotionPrimary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionPrimary, JObject>>) (e => e.MovesetCornerLeaningFront1)).Id);
        ushortList69.Add((ushort) (long) this.editorMotion.Primaryinfo.Get<EditorMotion_WWE2K24.MotionPrimary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionPrimary, JObject>>) (e => e.MovesetCornerLeaningFront2)).Id);
        ushortList69.Add((ushort) (long) this.editorMotion.Primaryinfo.Get<EditorMotion_WWE2K24.MotionPrimary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionPrimary, JObject>>) (e => e.MovesetCornerLeaningFront3)).Id);
        ushortList69.Add((ushort) (long) this.editorMotion.Primaryinfo.Get<EditorMotion_WWE2K24.MotionPrimary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionPrimary, JObject>>) (e => e.MovesetCornerLeaningFront4)).Id);
        ushortList69.Add((ushort) (long) this.editorMotion.Primaryinfo.Get<EditorMotion_WWE2K24.MotionPrimary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionPrimary, JObject>>) (e => e.MovesetCornerLeaningFront5)).Id);
        ushortList69.Add((ushort) (long) this.editorMotion.Primaryinfo.Get<EditorMotion_WWE2K24.MotionPrimary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionPrimary, JObject>>) (e => e.MovesetCornerLeaningFront6)).Id);
        List<ushort> ushortList70 = ushortList69;
        motionCorner2.leaning_front = ushortList70;
        Motion_Corner motionCorner3 = motionCorner1;
        List<ushort> ushortList71 = new List<ushort>();
        ushortList71.Add((ushort) (long) this.editorMotion.Primaryinfo.Get<EditorMotion_WWE2K24.MotionPrimary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionPrimary, JObject>>) (e => e.MovesetCornerLeaningRear1)).Id);
        ushortList71.Add((ushort) (long) this.editorMotion.Primaryinfo.Get<EditorMotion_WWE2K24.MotionPrimary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionPrimary, JObject>>) (e => e.MovesetCornerLeaningRear2)).Id);
        ushortList71.Add((ushort) (long) this.editorMotion.Primaryinfo.Get<EditorMotion_WWE2K24.MotionPrimary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionPrimary, JObject>>) (e => e.MovesetCornerLeaningRear3)).Id);
        ushortList71.Add((ushort) (long) this.editorMotion.Primaryinfo.Get<EditorMotion_WWE2K24.MotionPrimary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionPrimary, JObject>>) (e => e.MovesetCornerLeaningRear4)).Id);
        ushortList71.Add((ushort) (long) this.editorMotion.Primaryinfo.Get<EditorMotion_WWE2K24.MotionPrimary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionPrimary, JObject>>) (e => e.MovesetCornerLeaningRear5)).Id);
        ushortList71.Add((ushort) (long) this.editorMotion.Primaryinfo.Get<EditorMotion_WWE2K24.MotionPrimary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionPrimary, JObject>>) (e => e.MovesetCornerLeaningRear6)).Id);
        List<ushort> ushortList72 = ushortList71;
        motionCorner3.leaning_rear = ushortList72;
        Motion_Corner motionCorner4 = motionCorner1;
        List<ushort> ushortList73 = new List<ushort>();
        ushortList73.Add((ushort) (long) this.editorMotion.Primaryinfo.Get<EditorMotion_WWE2K24.MotionPrimary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionPrimary, JObject>>) (e => e.MovesetCornerTopRopeStunnedFront1)).Id);
        ushortList73.Add((ushort) (long) this.editorMotion.Primaryinfo.Get<EditorMotion_WWE2K24.MotionPrimary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionPrimary, JObject>>) (e => e.MovesetCornerTopRopeStunnedFront2)).Id);
        List<ushort> ushortList74 = ushortList73;
        motionCorner4.top_rope_stunned_front = ushortList74;
        Motion_Corner motionCorner5 = motionCorner1;
        List<ushort> ushortList75 = new List<ushort>();
        ushortList75.Add((ushort) (long) this.editorMotion.Primaryinfo.Get<EditorMotion_WWE2K24.MotionPrimary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionPrimary, JObject>>) (e => e.MovesetCornerTopRopeStunnedRear1)).Id);
        ushortList75.Add((ushort) (long) this.editorMotion.Primaryinfo.Get<EditorMotion_WWE2K24.MotionPrimary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionPrimary, JObject>>) (e => e.MovesetCornerTopRopeStunnedRear2)).Id);
        List<ushort> ushortList76 = ushortList75;
        motionCorner5.top_rope_stunned_rear = ushortList76;
        Motion_Corner motionCorner6 = motionCorner1;
        List<ushort> ushortList77 = new List<ushort>();
        ushortList77.Add((ushort) (long) this.editorMotion.Primaryinfo.Get<EditorMotion_WWE2K24.MotionPrimary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionPrimary, JObject>>) (e => e.MovesetCornerSeated1)).Id);
        ushortList77.Add((ushort) (long) this.editorMotion.Primaryinfo.Get<EditorMotion_WWE2K24.MotionPrimary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionPrimary, JObject>>) (e => e.MovesetCornerSeated2)).Id);
        ushortList77.Add((ushort) (long) this.editorMotion.Primaryinfo.Get<EditorMotion_WWE2K24.MotionPrimary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionPrimary, JObject>>) (e => e.MovesetCornerSeated3)).Id);
        List<ushort> ushortList78 = ushortList77;
        motionCorner6.seated = ushortList78;
        Motion_Corner motionCorner7 = motionCorner1;
        List<ushort> ushortList79 = new List<ushort>();
        ushortList79.Add((ushort) (long) this.editorMotion.Primaryinfo.Get<EditorMotion_WWE2K24.MotionPrimary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionPrimary, JObject>>) (e => e.MovesetCornerTreeOfWoe1)).Id);
        ushortList79.Add((ushort) (long) this.editorMotion.Primaryinfo.Get<EditorMotion_WWE2K24.MotionPrimary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionPrimary, JObject>>) (e => e.MovesetCornerTreeOfWoe2)).Id);
        List<ushort> ushortList80 = ushortList79;
        motionCorner7.tree_of_woe = ushortList80;
        Motion_Corner motionCorner8 = motionCorner1;
        moveset7.moves_corner = motionCorner8;
        Moveset moveset8 = moveset1;
        Motion_Rope motionRope1 = new Motion_Rope();
        Motion_Rope motionRope2 = motionRope1;
        List<ushort> ushortList81 = new List<ushort>();
        ushortList81.Add((ushort) (long) this.editorMotion.Primaryinfo.Get<EditorMotion_WWE2K24.MotionPrimary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionPrimary, JObject>>) (e => e.MovesetRopeLeaning1)).Id);
        ushortList81.Add((ushort) (long) this.editorMotion.Primaryinfo.Get<EditorMotion_WWE2K24.MotionPrimary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionPrimary, JObject>>) (e => e.MovesetRopeLeaning2)).Id);
        ushortList81.Add((ushort) (long) this.editorMotion.Primaryinfo.Get<EditorMotion_WWE2K24.MotionPrimary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionPrimary, JObject>>) (e => e.MovesetRopeLeaning3)).Id);
        ushortList81.Add((ushort) (long) this.editorMotion.Primaryinfo.Get<EditorMotion_WWE2K24.MotionPrimary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionPrimary, JObject>>) (e => e.MovesetRopeLeaning4)).Id);
        ushortList81.Add((ushort) (long) this.editorMotion.Primaryinfo.Get<EditorMotion_WWE2K24.MotionPrimary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionPrimary, JObject>>) (e => e.MovesetRopeLeaning5)).Id);
        ushortList81.Add((ushort) (long) this.editorMotion.Primaryinfo.Get<EditorMotion_WWE2K24.MotionPrimary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionPrimary, JObject>>) (e => e.MovesetRopeLeaning6)).Id);
        List<ushort> ushortList82 = ushortList81;
        motionRope2.leaning = ushortList82;
        Motion_Rope motionRope3 = motionRope1;
        List<ushort> ushortList83 = new List<ushort>();
        ushortList83.Add((ushort) (long) this.editorMotion.Primaryinfo.Get<EditorMotion_WWE2K24.MotionPrimary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionPrimary, JObject>>) (e => e.MovesetRopeMiddleRope1)).Id);
        List<ushort> ushortList84 = ushortList83;
        motionRope3.middle_rope = ushortList84;
        Motion_Rope motionRope4 = motionRope1;
        moveset8.moves_rope = motionRope4;
        Moveset moveset9 = moveset1;
        Motion_Apron motionApron1 = new Motion_Apron();
        Motion_Apron motionApron2 = motionApron1;
        List<ushort> ushortList85 = new List<ushort>();
        ushortList85.Add((ushort) (long) this.editorMotion.Primaryinfo.Get<EditorMotion_WWE2K24.MotionPrimary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionPrimary, JObject>>) (e => e.MovesetApronFromRingFront1)).Id);
        ushortList85.Add((ushort) (long) this.editorMotion.Primaryinfo.Get<EditorMotion_WWE2K24.MotionPrimary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionPrimary, JObject>>) (e => e.MovesetApronFromRingFront2)).Id);
        ushortList85.Add((ushort) (long) this.editorMotion.Primaryinfo.Get<EditorMotion_WWE2K24.MotionPrimary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionPrimary, JObject>>) (e => e.MovesetApronFromRingFront3)).Id);
        List<ushort> ushortList86 = ushortList85;
        motionApron2.from_ring_front = ushortList86;
        Motion_Apron motionApron3 = motionApron1;
        List<ushort> ushortList87 = new List<ushort>();
        ushortList87.Add((ushort) (long) this.editorMotion.Primaryinfo.Get<EditorMotion_WWE2K24.MotionPrimary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionPrimary, JObject>>) (e => e.MovesetApronFromRingRear1)).Id);
        List<ushort> ushortList88 = ushortList87;
        motionApron3.from_ring_rear = ushortList88;
        Motion_Apron motionApron4 = motionApron1;
        List<ushort> ushortList89 = new List<ushort>();
        ushortList89.Add((ushort) (long) this.editorMotion.Primaryinfo.Get<EditorMotion_WWE2K24.MotionPrimary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionPrimary, JObject>>) (e => e.MovesetApronFromApronToRing1)).Id);
        ushortList89.Add((ushort) (long) this.editorMotion.Primaryinfo.Get<EditorMotion_WWE2K24.MotionPrimary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionPrimary, JObject>>) (e => e.MovesetApronFromApronToRing2)).Id);
        List<ushort> ushortList90 = ushortList89;
        motionApron4.from_apron_to_ring = ushortList90;
        Motion_Apron motionApron5 = motionApron1;
        List<ushort> ushortList91 = new List<ushort>();
        ushortList91.Add((ushort) (long) this.editorMotion.Primaryinfo.Get<EditorMotion_WWE2K24.MotionPrimary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionPrimary, JObject>>) (e => e.MovesetApronFromApronToRingSide1)).Id);
        ushortList91.Add((ushort) (long) this.editorMotion.Primaryinfo.Get<EditorMotion_WWE2K24.MotionPrimary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionPrimary, JObject>>) (e => e.MovesetApronFromApronToRingSide2)).Id);
        List<ushort> ushortList92 = ushortList91;
        motionApron5.from_apron_to_ringside = ushortList92;
        Motion_Apron motionApron6 = motionApron1;
        moveset9.moves_apron = motionApron6;
        Moveset moveset10 = moveset1;
        Motion_Diving motionDiving1 = new Motion_Diving();
        Motion_Diving motionDiving2 = motionDiving1;
        List<ushort> ushortList93 = new List<ushort>();
        ushortList93.Add((ushort) (long) this.editorMotion.Primaryinfo.Get<EditorMotion_WWE2K24.MotionPrimary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionPrimary, JObject>>) (e => e.MovesetDivingMiddleRope1)).Id);
        List<ushort> ushortList94 = ushortList93;
        motionDiving2.middle_rope_light_dive = ushortList94;
        Motion_Diving motionDiving3 = motionDiving1;
        List<ushort> ushortList95 = new List<ushort>();
        ushortList95.Add((ushort) (long) this.editorMotion.Primaryinfo.Get<EditorMotion_WWE2K24.MotionPrimary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionPrimary, JObject>>) (e => e.MovesetDivingMiddleRope2)).Id);
        List<ushort> ushortList96 = ushortList95;
        motionDiving3.middle_rope_light_dive_to_supine = ushortList96;
        Motion_Diving motionDiving4 = motionDiving1;
        List<ushort> ushortList97 = new List<ushort>();
        ushortList97.Add((ushort) (long) this.editorMotion.Primaryinfo.Get<EditorMotion_WWE2K24.MotionPrimary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionPrimary, JObject>>) (e => e.MovesetDivingTopRope1)).Id);
        ushortList97.Add((ushort) (long) this.editorMotion.Primaryinfo.Get<EditorMotion_WWE2K24.MotionPrimary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionPrimary, JObject>>) (e => e.MovesetDivingTopRope2)).Id);
        List<ushort> ushortList98 = ushortList97;
        motionDiving4.diving_top_rope_attack = ushortList98;
        Motion_Diving motionDiving5 = motionDiving1;
        List<ushort> ushortList99 = new List<ushort>();
        ushortList99.Add((ushort) (long) this.editorMotion.Primaryinfo.Get<EditorMotion_WWE2K24.MotionPrimary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionPrimary, JObject>>) (e => e.MovesetDivingTopRope3)).Id);
        ushortList99.Add((ushort) (long) this.editorMotion.Primaryinfo.Get<EditorMotion_WWE2K24.MotionPrimary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionPrimary, JObject>>) (e => e.MovesetDivingTopRope4)).Id);
        List<ushort> ushortList100 = ushortList99;
        motionDiving5.diving_top_rope_to_supine = ushortList100;
        Motion_Diving motionDiving6 = motionDiving1;
        List<ushort> ushortList101 = new List<ushort>();
        ushortList101.Add((ushort) (long) this.editorMotion.Primaryinfo.Get<EditorMotion_WWE2K24.MotionPrimary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionPrimary, JObject>>) (e => e.MovesetDivingLedge1)).Id);
        ushortList101.Add((ushort) (long) this.editorMotion.Primaryinfo.Get<EditorMotion_WWE2K24.MotionPrimary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionPrimary, JObject>>) (e => e.MovesetDivingLedge2)).Id);
        List<ushort> ushortList102 = ushortList101;
        motionDiving6.ledge = ushortList102;
        Motion_Diving motionDiving7 = motionDiving1;
        List<ushort> ushortList103 = new List<ushort>();
        ushortList103.Add((ushort) (long) this.editorMotion.Primaryinfo.Get<EditorMotion_WWE2K24.MotionPrimary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionPrimary, JObject>>) (e => e.MovesetDivingEquipmentBox1)).Id);
        ushortList103.Add((ushort) (long) this.editorMotion.Primaryinfo.Get<EditorMotion_WWE2K24.MotionPrimary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionPrimary, JObject>>) (e => e.MovesetDivingEquipmentBox2)).Id);
        List<ushort> ushortList104 = ushortList103;
        motionDiving7.equipment_box = ushortList104;
        Motion_Diving motionDiving8 = motionDiving1;
        moveset10.moves_diving = motionDiving8;
        Moveset moveset11 = moveset1;
        Motion_Springboard motionSpringboard1 = new Motion_Springboard();
        Motion_Springboard motionSpringboard2 = motionSpringboard1;
        List<ushort> ushortList105 = new List<ushort>();
        ushortList105.Add((ushort) (long) this.editorMotion.Primaryinfo.Get<EditorMotion_WWE2K24.MotionPrimary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionPrimary, JObject>>) (e => e.MovesetSpringboardToRingStandingFront1)).Id);
        ushortList105.Add((ushort) (long) this.editorMotion.Primaryinfo.Get<EditorMotion_WWE2K24.MotionPrimary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionPrimary, JObject>>) (e => e.MovesetSpringboardToRingStandingFront2)).Id);
        ushortList105.Add((ushort) (long) this.editorMotion.Primaryinfo.Get<EditorMotion_WWE2K24.MotionPrimary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionPrimary, JObject>>) (e => e.MovesetSpringboardToRingStandingFront3)).Id);
        ushortList105.Add((ushort) (long) this.editorMotion.Primaryinfo.Get<EditorMotion_WWE2K24.MotionPrimary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionPrimary, JObject>>) (e => e.MovesetSpringboardToRingStandingFront4)).Id);
        List<ushort> ushortList106 = ushortList105;
        motionSpringboard2.to_ring_standing_front = ushortList106;
        Motion_Springboard motionSpringboard3 = motionSpringboard1;
        List<ushort> ushortList107 = new List<ushort>();
        ushortList107.Add((ushort) (long) this.editorMotion.Primaryinfo.Get<EditorMotion_WWE2K24.MotionPrimary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionPrimary, JObject>>) (e => e.MovesetSpringboardToRingFaceUp1)).Id);
        ushortList107.Add((ushort) (long) this.editorMotion.Primaryinfo.Get<EditorMotion_WWE2K24.MotionPrimary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionPrimary, JObject>>) (e => e.MovesetSpringboardToRingFaceUp2)).Id);
        ushortList107.Add((ushort) (long) this.editorMotion.Primaryinfo.Get<EditorMotion_WWE2K24.MotionPrimary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionPrimary, JObject>>) (e => e.MovesetSpringboardToRingFaceUp3)).Id);
        ushortList107.Add((ushort) (long) this.editorMotion.Primaryinfo.Get<EditorMotion_WWE2K24.MotionPrimary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionPrimary, JObject>>) (e => e.MovesetSpringboardToRingFaceUp4)).Id);
        List<ushort> ushortList108 = ushortList107;
        motionSpringboard3.to_ring_supine = ushortList108;
        Motion_Springboard motionSpringboard4 = motionSpringboard1;
        List<ushort> ushortList109 = new List<ushort>();
        ushortList109.Add((ushort) (long) this.editorMotion.Primaryinfo.Get<EditorMotion_WWE2K24.MotionPrimary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionPrimary, JObject>>) (e => e.MovesetSpringboardToRingsideStandingFront1)).Id);
        ushortList109.Add((ushort) (long) this.editorMotion.Primaryinfo.Get<EditorMotion_WWE2K24.MotionPrimary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionPrimary, JObject>>) (e => e.MovesetSpringboardToRingsideStandingFront2)).Id);
        ushortList109.Add((ushort) (long) this.editorMotion.Primaryinfo.Get<EditorMotion_WWE2K24.MotionPrimary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionPrimary, JObject>>) (e => e.MovesetSpringboardToRingsideStandingFront3)).Id);
        List<ushort> ushortList110 = ushortList109;
        motionSpringboard4.to_ringside_standing_front = ushortList110;
        Motion_Springboard motionSpringboard5 = motionSpringboard1;
        List<ushort> ushortList111 = new List<ushort>();
        ushortList111.Add((ushort) (long) this.editorMotion.Primaryinfo.Get<EditorMotion_WWE2K24.MotionPrimary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionPrimary, JObject>>) (e => e.MovesetSpringboardToRingsideFaceUp1)).Id);
        ushortList111.Add((ushort) (long) this.editorMotion.Primaryinfo.Get<EditorMotion_WWE2K24.MotionPrimary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionPrimary, JObject>>) (e => e.MovesetSpringboardToRingsideFaceUp2)).Id);
        ushortList111.Add((ushort) (long) this.editorMotion.Primaryinfo.Get<EditorMotion_WWE2K24.MotionPrimary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionPrimary, JObject>>) (e => e.MovesetSpringboardToRingsideFaceUp3)).Id);
        List<ushort> ushortList112 = ushortList111;
        motionSpringboard5.to_ringside_supine = ushortList112;
        Motion_Springboard motionSpringboard6 = motionSpringboard1;
        moveset11.moves_springboard = motionSpringboard6;
        Moveset moveset12 = moveset1;
        Motion_Holds motionHolds1 = new Motion_Holds();
        Motion_Holds motionHolds2 = motionHolds1;
        List<ushort> ushortList113 = new List<ushort>();
        ushortList113.Add((ushort) (long) this.editorMotion.SecondaryInfo.Get<EditorMotion_WWE2K24.MotionSecondary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionSecondary, JObject>>) (e => e.MovesetHoldsSubmission1)).Id);
        ushortList113.Add((ushort) (long) this.editorMotion.SecondaryInfo.Get<EditorMotion_WWE2K24.MotionSecondary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionSecondary, JObject>>) (e => e.MovesetHoldsSubmission3)).Id);
        ushortList113.Add((ushort) (long) this.editorMotion.SecondaryInfo.Get<EditorMotion_WWE2K24.MotionSecondary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionSecondary, JObject>>) (e => e.MovesetHoldsSubmission4)).Id);
        ushortList113.Add((ushort) (long) this.editorMotion.SecondaryInfo.Get<EditorMotion_WWE2K24.MotionSecondary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionSecondary, JObject>>) (e => e.MovesetHoldsSubmission5)).Id);
        List<ushort> ushortList114 = ushortList113;
        motionHolds2.submission = ushortList114;
        Motion_Holds motionHolds3 = motionHolds1;
        moveset12.moves_holds = motionHolds3;
        Moveset moveset13 = moveset1;
        Motion_Other_Attacks motionOtherAttacks1 = new Motion_Other_Attacks();
        Motion_Other_Attacks motionOtherAttacks2 = motionOtherAttacks1;
        List<ushort> ushortList115 = new List<ushort>();
        ushortList115.Add((ushort) (long) this.editorMotion.SecondaryInfo.Get<EditorMotion_WWE2K24.MotionSecondary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionSecondary, JObject>>) (e => e.MovesetOtherAttacksBarricade1)).Id);
        ushortList115.Add((ushort) (long) this.editorMotion.SecondaryInfo.Get<EditorMotion_WWE2K24.MotionSecondary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionSecondary, JObject>>) (e => e.MovesetOtherAttacksBarricade2)).Id);
        List<ushort> ushortList116 = ushortList115;
        motionOtherAttacks2.barricade = ushortList116;
        Motion_Other_Attacks motionOtherAttacks3 = motionOtherAttacks1;
        List<ushort> ushortList117 = new List<ushort>();
        ushortList117.Add((ushort) (long) this.editorMotion.SecondaryInfo.Get<EditorMotion_WWE2K24.MotionSecondary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionSecondary, JObject>>) (e => e.MovesetOtherAttacksComeback)).Id);
        List<ushort> ushortList118 = ushortList117;
        motionOtherAttacks3.comeback = ushortList118;
        Motion_Other_Attacks motionOtherAttacks4 = motionOtherAttacks1;
        moveset13.moves_other_attacks = motionOtherAttacks4;
        Moveset moveset14 = moveset1;
        Motion_Movement motionMovement1 = new Motion_Movement();
        Motion_Movement motionMovement2 = motionMovement1;
        List<ushort> ushortList119 = new List<ushort>();
        ushortList119.Add((ushort) (long) this.editorMotion.SecondaryInfo.Get<EditorMotion_WWE2K24.MotionSecondary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionSecondary, JObject>>) (e => e.MovesetMovementEnterRing1)).Id);
        ushortList119.Add((ushort) (long) this.editorMotion.SecondaryInfo.Get<EditorMotion_WWE2K24.MotionSecondary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionSecondary, JObject>>) (e => e.MovesetMovementEnterRing2)).Id);
        List<ushort> ushortList120 = ushortList119;
        motionMovement2.enter_ring = ushortList120;
        Motion_Movement motionMovement3 = motionMovement1;
        List<ushort> ushortList121 = new List<ushort>();
        ushortList121.Add((ushort) (long) this.editorMotion.SecondaryInfo.Get<EditorMotion_WWE2K24.MotionSecondary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionSecondary, JObject>>) (e => e.MovesetMovementExitRing1)).Id);
        ushortList121.Add((ushort) (long) this.editorMotion.SecondaryInfo.Get<EditorMotion_WWE2K24.MotionSecondary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionSecondary, JObject>>) (e => e.MovesetMovementExitRing2)).Id);
        List<ushort> ushortList122 = ushortList121;
        motionMovement3.exit_ring = ushortList122;
        Motion_Movement motionMovement4 = motionMovement1;
        List<byte> byteList1 = new List<byte>();
        byteList1.Add((byte) (long) this.editorMotion.SecondaryInfo.Get<EditorMotion_WWE2K24.MotionSecondary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionSecondary, JObject>>) (e => e.MovesetMovementClimbTopRope1)).Id);
        byteList1.Add((byte) (long) this.editorMotion.SecondaryInfo.Get<EditorMotion_WWE2K24.MotionSecondary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionSecondary, JObject>>) (e => e.MovesetMovementClimbTopRope2)).Id);
        List<byte> byteList2 = byteList1;
        motionMovement4.climb_top_rope = byteList2;
        Motion_Movement motionMovement5 = motionMovement1;
        List<ushort> ushortList123 = new List<ushort>();
        ushortList123.Add((ushort) (long) this.editorMotion.SecondaryInfo.Get<EditorMotion_WWE2K24.MotionSecondary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionSecondary, JObject>>) (e => e.MovesetMovementRecovery)).Id);
        List<ushort> ushortList124 = ushortList123;
        motionMovement5.recovery = ushortList124;
        Motion_Movement motionMovement6 = motionMovement1;
        moveset14.moves_movement = motionMovement6;
        Moveset moveset15 = moveset1;
        Motion_Match_Type motionMatchType1 = new Motion_Match_Type();
        Motion_Match_Type motionMatchType2 = motionMatchType1;
        List<ushort> ushortList125 = new List<ushort>();
        ushortList125.Add((ushort) (long) this.editorMotion.SecondaryInfo.Get<EditorMotion_WWE2K24.MotionSecondary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionSecondary, JObject>>) (e => e.MovesetMatchTypeTableTableAttack)).Id);
        ushortList125.Add((ushort) (long) this.editorMotion.SecondaryInfo.Get<EditorMotion_WWE2K24.MotionSecondary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionSecondary, JObject>>) (e => e.MovesetMatchTypeTableInCornerAttack)).Id);
        ushortList125.Add((ushort) (long) this.editorMotion.SecondaryInfo.Get<EditorMotion_WWE2K24.MotionSecondary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionSecondary, JObject>>) (e => e.MovesetMatchTypeTableCornerAttack)).Id);
        ushortList125.Add((ushort) (long) this.editorMotion.SecondaryInfo.Get<EditorMotion_WWE2K24.MotionSecondary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionSecondary, JObject>>) (e => e.MovesetMatchTypeTableAttackOpponentOnRopes)).Id);
        ushortList125.Add((ushort) (long) this.editorMotion.SecondaryInfo.Get<EditorMotion_WWE2K24.MotionSecondary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionSecondary, JObject>>) (e => e.MovesetMatchTypeTableAttackOpponentOnApron)).Id);
        List<ushort> ushortList126 = ushortList125;
        motionMatchType2.table = ushortList126;
        Motion_Match_Type motionMatchType3 = motionMatchType1;
        List<ushort> ushortList127 = new List<ushort>();
        ushortList127.Add((ushort) (long) this.editorMotion.SecondaryInfo.Get<EditorMotion_WWE2K24.MotionSecondary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionSecondary, JObject>>) (e => e.MovesetMatchTypeLadderLightAttack)).Id);
        ushortList127.Add((ushort) (long) this.editorMotion.SecondaryInfo.Get<EditorMotion_WWE2K24.MotionSecondary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionSecondary, JObject>>) (e => e.MovesetMatchTypeLadderHeavyAttack)).Id);
        ushortList127.Add((ushort) (long) this.editorMotion.SecondaryInfo.Get<EditorMotion_WWE2K24.MotionSecondary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionSecondary, JObject>>) (e => e.MovesetMatchTypeLadderGrapple)).Id);
        ushortList127.Add((ushort) (long) this.editorMotion.Primaryinfo.Get<EditorMotion_WWE2K24.MotionPrimary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionPrimary, JObject>>) (e => e.MovesetFinisherLadder1)).Id);
        ushortList127.Add((ushort) (long) this.editorMotion.Primaryinfo.Get<EditorMotion_WWE2K24.MotionPrimary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionPrimary, JObject>>) (e => e.MovesetFinisherLadder2)).Id);
        List<ushort> ushortList128 = ushortList127;
        motionMatchType3.ladder = ushortList128;
        Motion_Match_Type motionMatchType4 = motionMatchType1;
        List<ushort> ushortList129 = new List<ushort>();
        ushortList129.Add((ushort) (long) this.editorMotion.SecondaryInfo.Get<EditorMotion_WWE2K24.MotionSecondary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionSecondary, JObject>>) (e => e.MovesetMatchTypeTagTeamNormalTagAttacks1)).Id);
        ushortList129.Add((ushort) (long) this.editorMotion.SecondaryInfo.Get<EditorMotion_WWE2K24.MotionSecondary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionSecondary, JObject>>) (e => e.MovesetMatchTypeTagTeamNormalTagAttacks2)).Id);
        ushortList129.Add((ushort) (long) this.editorMotion.SecondaryInfo.Get<EditorMotion_WWE2K24.MotionSecondary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionSecondary, JObject>>) (e => e.MovesetMatchTypeTagTeamNormalTagAttacks3)).Id);
        ushortList129.Add((ushort) (long) this.editorMotion.SecondaryInfo.Get<EditorMotion_WWE2K24.MotionSecondary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionSecondary, JObject>>) (e => e.MovesetMatchTypeTagTeamNormalTagAttacks4)).Id);
        List<ushort> ushortList130 = ushortList129;
        motionMatchType4.tag_team_normal_tag_attacks = ushortList130;
        Motion_Match_Type motionMatchType5 = motionMatchType1;
        List<ushort> ushortList131 = new List<ushort>();
        ushortList131.Add((ushort) (long) this.editorMotion.SecondaryInfo.Get<EditorMotion_WWE2K24.MotionSecondary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionSecondary, JObject>>) (e => e.MovesetMatchTypeMixedTagNormalTagAttacks1)).Id);
        ushortList131.Add((ushort) (long) this.editorMotion.SecondaryInfo.Get<EditorMotion_WWE2K24.MotionSecondary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionSecondary, JObject>>) (e => e.MovesetMatchTypeMixedTagNormalTagAttacks2)).Id);
        ushortList131.Add((ushort) (long) this.editorMotion.SecondaryInfo.Get<EditorMotion_WWE2K24.MotionSecondary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionSecondary, JObject>>) (e => e.MovesetMatchTypeMixedTagNormalTagAttacks3)).Id);
        ushortList131.Add((ushort) (long) this.editorMotion.SecondaryInfo.Get<EditorMotion_WWE2K24.MotionSecondary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionSecondary, JObject>>) (e => e.MovesetMatchTypeMixedTagNormalTagAttacks4)).Id);
        List<ushort> ushortList132 = ushortList131;
        motionMatchType5.tag_team_mixed_tag_attacks = ushortList132;
        Motion_Match_Type motionMatchType6 = motionMatchType1;
        List<ushort> ushortList133 = new List<ushort>();
        ushortList133.Add((ushort) (long) this.editorMotion.SecondaryInfo.Get<EditorMotion_WWE2K24.MotionSecondary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionSecondary, JObject>>) (e => e.MovesetMatchTypeTagteamDoubleTeam1)).Id);
        ushortList133.Add((ushort) (long) this.editorMotion.SecondaryInfo.Get<EditorMotion_WWE2K24.MotionSecondary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionSecondary, JObject>>) (e => e.MovesetMatchTypeTagteamDoubleTeam2)).Id);
        ushortList133.Add((ushort) (long) this.editorMotion.SecondaryInfo.Get<EditorMotion_WWE2K24.MotionSecondary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionSecondary, JObject>>) (e => e.MovesetMatchTypeTagteamDoubleTeam3)).Id);
        ushortList133.Add((ushort) (long) this.editorMotion.SecondaryInfo.Get<EditorMotion_WWE2K24.MotionSecondary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionSecondary, JObject>>) (e => e.MovesetMatchTypeTagteamDoubleTeam4)).Id);
        List<ushort> ushortList134 = ushortList133;
        motionMatchType6.tag_team_double_team = ushortList134;
        Motion_Match_Type motionMatchType7 = motionMatchType1;
        moveset15.moves_match_type = motionMatchType7;
        moveset1.moves_taunts = new Motion_Taunts();
        moveset1.moves_taunts.to_crowd_standing = this.Input((object) this.editorMotion.SecondaryInfo, "Taunt|To Crowd - Standing");
        moveset1.moves_taunts.to_crowd_corner = this.Input((object) this.editorMotion.SecondaryInfo, "Taunt|To Crowd - Corner");
        moveset1.moves_taunts.to_crowd_top_rope = this.Input((object) this.editorMotion.SecondaryInfo, "Taunt|To Crowd - Top Rope Facing Ring");
        moveset1.moves_taunts.to_crowd_middle_rope = this.Input((object) this.editorMotion.SecondaryInfo, "Taunt|To Crowd - Middle Rope");
        moveset1.moves_taunts.to_crowd_apron_facing_ring = this.Input((object) this.editorMotion.SecondaryInfo, "Taunt|To Crowd - Apron Facing Ring");
        moveset1.moves_taunts.to_crowd_apron_facing_ringside = this.Input((object) this.editorMotion.SecondaryInfo, "Taunt|To Crowd - Apron Facing Ringside");
        moveset1.moves_taunts.to_opponent_standing_to_standing = this.Input((object) this.editorMotion.SecondaryInfo, "Taunt|To Opponent - Standing");
        moveset1.moves_taunts.to_opponent_standing_to_ground = this.Input((object) this.editorMotion.SecondaryInfo, "Taunt|To Opponent - Ground");
        moveset1.moves_taunts.to_opponent_corner = this.Input((object) this.editorMotion.SecondaryInfo, "Taunt|To Opponent - Corner");
        moveset1.moves_taunts.to_opponent_top_rope = this.Input((object) this.editorMotion.SecondaryInfo, "Taunt|To Opponent - Top Rope Facing Ring");
        moveset1.moves_taunts.to_opponent_middle_rope = this.Input((object) this.editorMotion.SecondaryInfo, "Taunt|To Opponent - Middle Rope");
        moveset1.moves_taunts.to_opponent_apron_facing_ring = this.Input((object) this.editorMotion.SecondaryInfo, "Taunt|To Opponent - Apron Facing Ring");
        moveset1.moves_taunts.to_opponent_apron_facing_ringside = this.Input((object) this.editorMotion.SecondaryInfo, "Taunt|To Opponent - Apron Facing Ringside");
        moveset1.moves_taunts.wake_up = this.Input((object) this.editorMotion.SecondaryInfo, "Taunt|Wake Up");
        Moveset moveset16 = moveset1;
        Motion_PreMatch motionPreMatch1 = new Motion_PreMatch();
        Motion_PreMatch motionPreMatch2 = motionPreMatch1;
        List<ushort> ushortList135 = new List<ushort>();
        ushortList135.Add((ushort) (long) this.editorMotion.SecondaryInfo.Get<EditorMotion_WWE2K24.MotionSecondary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionSecondary, JObject>>) (e => e.MovesetPreMatchWarmup1)).Id);
        ushortList135.Add((ushort) (long) this.editorMotion.SecondaryInfo.Get<EditorMotion_WWE2K24.MotionSecondary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionSecondary, JObject>>) (e => e.MovesetPreMatchWarmup2)).Id);
        ushortList135.Add((ushort) (long) this.editorMotion.SecondaryInfo.Get<EditorMotion_WWE2K24.MotionSecondary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionSecondary, JObject>>) (e => e.MovesetPreMatchWarmup3)).Id);
        ushortList135.Add((ushort) (long) this.editorMotion.SecondaryInfo.Get<EditorMotion_WWE2K24.MotionSecondary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionSecondary, JObject>>) (e => e.MovesetPreMatchWarmup4)).Id);
        ushortList135.Add((ushort) (long) this.editorMotion.SecondaryInfo.Get<EditorMotion_WWE2K24.MotionSecondary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionSecondary, JObject>>) (e => e.MovesetPreMatchWarmup5)).Id);
        List<ushort> ushortList136 = ushortList135;
        motionPreMatch2.warm_up = ushortList136;
        Motion_PreMatch motionPreMatch3 = motionPreMatch1;
        List<ushort> ushortList137 = new List<ushort>();
        ushortList137.Add((ushort) (long) this.editorMotion.SecondaryInfo.Get<EditorMotion_WWE2K24.MotionSecondary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionSecondary, JObject>>) (e => e.MovesetPreMatchTitleMatchChampion)).Id);
        List<ushort> ushortList138 = ushortList137;
        motionPreMatch3.title_match_champion = ushortList138;
        Motion_PreMatch motionPreMatch4 = motionPreMatch1;
        List<ushort> ushortList139 = new List<ushort>();
        ushortList139.Add((ushort) (long) this.editorMotion.SecondaryInfo.Get<EditorMotion_WWE2K24.MotionSecondary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionSecondary, JObject>>) (e => e.MovesetPreMatchTitleMatchChallenger1)).Id);
        ushortList139.Add((ushort) (long) this.editorMotion.SecondaryInfo.Get<EditorMotion_WWE2K24.MotionSecondary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionSecondary, JObject>>) (e => e.MovesetPreMatchTitleMatchChallenger2)).Id);
        List<ushort> ushortList140 = ushortList139;
        motionPreMatch4.title_match_challenger = ushortList140;
        Motion_PreMatch motionPreMatch5 = motionPreMatch1;
        moveset16.moves_pre_match = motionPreMatch5;
        Moveset moveset17 = moveset1;
        Motion_Weight_Detection motionWeightDetection1 = new Motion_Weight_Detection();
        Motion_Weight_Detection motionWeightDetection2 = motionWeightDetection1;
        List<ushort> ushortList141 = new List<ushort>();
        ushortList141.Add((ushort) (long) this.editorMotion.SecondaryInfo.Get<EditorMotion_WWE2K24.MotionSecondary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionSecondary, JObject>>) (e => e.MovesetWeightDetectionStanding1)).Id);
        ushortList141.Add((ushort) (long) this.editorMotion.SecondaryInfo.Get<EditorMotion_WWE2K24.MotionSecondary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionSecondary, JObject>>) (e => e.MovesetWeightDetectionStanding2)).Id);
        ushortList141.Add((ushort) (long) this.editorMotion.SecondaryInfo.Get<EditorMotion_WWE2K24.MotionSecondary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionSecondary, JObject>>) (e => e.MovesetWeightDetectionRunning1)).Id);
        ushortList141.Add((ushort) (long) this.editorMotion.SecondaryInfo.Get<EditorMotion_WWE2K24.MotionSecondary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionSecondary, JObject>>) (e => e.MovesetWeightDetectionRunning2)).Id);
        ushortList141.Add((ushort) (long) this.editorMotion.SecondaryInfo.Get<EditorMotion_WWE2K24.MotionSecondary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionSecondary, JObject>>) (e => e.MovesetWeightDetectionFrontGrapple1)).Id);
        ushortList141.Add((ushort) (long) this.editorMotion.SecondaryInfo.Get<EditorMotion_WWE2K24.MotionSecondary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionSecondary, JObject>>) (e => e.MovesetWeightDetectionFrontGrapple2)).Id);
        ushortList141.Add((ushort) (long) this.editorMotion.SecondaryInfo.Get<EditorMotion_WWE2K24.MotionSecondary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionSecondary, JObject>>) (e => e.MovesetWeightDetectionRearGrapple1)).Id);
        ushortList141.Add((ushort) (long) this.editorMotion.SecondaryInfo.Get<EditorMotion_WWE2K24.MotionSecondary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionSecondary, JObject>>) (e => e.MovesetWeightDetectionRearGrapple2)).Id);
        ushortList141.Add((ushort) (long) this.editorMotion.SecondaryInfo.Get<EditorMotion_WWE2K24.MotionSecondary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionSecondary, JObject>>) (e => e.MovesetWeightDetectionSupineGrapple1)).Id);
        ushortList141.Add((ushort) (long) this.editorMotion.SecondaryInfo.Get<EditorMotion_WWE2K24.MotionSecondary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionSecondary, JObject>>) (e => e.MovesetWeightDetectionSupineGrapple2)).Id);
        ushortList141.Add((ushort) (long) this.editorMotion.SecondaryInfo.Get<EditorMotion_WWE2K24.MotionSecondary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionSecondary, JObject>>) (e => e.MovesetWeightDetectionSupineGrapple3)).Id);
        ushortList141.Add((ushort) (long) this.editorMotion.SecondaryInfo.Get<EditorMotion_WWE2K24.MotionSecondary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionSecondary, JObject>>) (e => e.MovesetWeightDetectionProneGrapple1)).Id);
        ushortList141.Add((ushort) (long) this.editorMotion.SecondaryInfo.Get<EditorMotion_WWE2K24.MotionSecondary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionSecondary, JObject>>) (e => e.MovesetWeightDetectionProneGrapple2)).Id);
        ushortList141.Add((ushort) (long) this.editorMotion.SecondaryInfo.Get<EditorMotion_WWE2K24.MotionSecondary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionSecondary, JObject>>) (e => e.MovesetWeightDetectionProneGrapple3)).Id);
        ushortList141.Add((ushort) (long) this.editorMotion.SecondaryInfo.Get<EditorMotion_WWE2K24.MotionSecondary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionSecondary, JObject>>) (e => e.MovesetWeightDetectionKneeling1)).Id);
        ushortList141.Add((ushort) (long) this.editorMotion.SecondaryInfo.Get<EditorMotion_WWE2K24.MotionSecondary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionSecondary, JObject>>) (e => e.MovesetWeightDetectionKneeling2)).Id);
        ushortList141.Add((ushort) (long) this.editorMotion.SecondaryInfo.Get<EditorMotion_WWE2K24.MotionSecondary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionSecondary, JObject>>) (e => e.MovesetWeightDetectionSeated1)).Id);
        ushortList141.Add((ushort) (long) this.editorMotion.SecondaryInfo.Get<EditorMotion_WWE2K24.MotionSecondary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionSecondary, JObject>>) (e => e.MovesetWeightDetectionSeated2)).Id);
        ushortList141.Add((ushort) (long) this.editorMotion.SecondaryInfo.Get<EditorMotion_WWE2K24.MotionSecondary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionSecondary, JObject>>) (e => e.MovesetWeightDetectionCorner1)).Id);
        ushortList141.Add((ushort) (long) this.editorMotion.SecondaryInfo.Get<EditorMotion_WWE2K24.MotionSecondary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionSecondary, JObject>>) (e => e.MovesetWeightDetectionCorner2)).Id);
        ushortList141.Add((ushort) (long) this.editorMotion.SecondaryInfo.Get<EditorMotion_WWE2K24.MotionSecondary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionSecondary, JObject>>) (e => e.MovesetWeightDetectionTopRope1)).Id);
        ushortList141.Add((ushort) (long) this.editorMotion.SecondaryInfo.Get<EditorMotion_WWE2K24.MotionSecondary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionSecondary, JObject>>) (e => e.MovesetWeightDetectionTopRope2)).Id);
        ushortList141.Add((ushort) (long) this.editorMotion.SecondaryInfo.Get<EditorMotion_WWE2K24.MotionSecondary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionSecondary, JObject>>) (e => e.MovesetWeightDetectionRopeStunned)).Id);
        ushortList141.Add((ushort) (long) this.editorMotion.SecondaryInfo.Get<EditorMotion_WWE2K24.MotionSecondary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionSecondary, JObject>>) (e => e.MovesetWeightDetectionReboundAction)).Id);
        ushortList141.Add((ushort) (long) this.editorMotion.SecondaryInfo.Get<EditorMotion_WWE2K24.MotionSecondary, JObject>((Expression<Func<EditorMotion_WWE2K24.MotionSecondary, JObject>>) (e => e.MovesetWeightDetectionPullbackAttack)).Id);
        List<ushort> ushortList142 = ushortList141;
        motionWeightDetection2.moveset = ushortList142;
        Motion_Weight_Detection motionWeightDetection3 = motionWeightDetection1;
        moveset17.moves_weight_detection = motionWeightDetection3;
      }
      else
        moveset1 = (Moveset) null;
      ObservableCollection<IGrouping<int, PropertyInfo>> attireData = this.editorMapping.GetAttireData();
      ObservableCollection<PropertyInfo> renders = this.editorMapping.GetRenders();
      WWE2K24_Generated_Character generatedCharacter1 = new WWE2K24_Generated_Character();
      generatedCharacter1.CharacterMapping = new ObservableCollection<CharacterMapping>();
      generatedCharacter1.Renders = new FaceTextures()
      {
        renders = new ObservableCollection<Texture>()
      };
      info.additional_attire_names = new List<uint>();
      info.crowd_signs = new List<uint>();
      generatedCharacter1.Renders.id = this.editorCharacter.CharacterInfo.WrestlerID;
      for (int i = 0; (EditorMapping_WWE2K24.Attires) i < this.editorMapping.SecondaryInfo.WrestlerAttireCount; i++)
      {
        IGrouping<int, PropertyInfo> source5 = attireData.FirstOrDefault<IGrouping<int, PropertyInfo>>((Func<IGrouping<int, PropertyInfo>, bool>) (g => g.Key.Equals(i)));
        CharacterMapping characterMapping = new CharacterMapping()
        {
          id = this.editorCharacter.CharacterInfo.WrestlerID,
          attire_num = (byte) i,
          character_path = ((string) source5.ElementAt<PropertyInfo>(1).GetValue((object) this.editorMapping.SecondaryInfo)).Hash(App.CurrentGame.Folders),
          attire_path = ((string) source5.ElementAt<PropertyInfo>(2).GetValue((object) this.editorMapping.SecondaryInfo)).Hash(App.CurrentGame.Folders),
          attire_mdl_path = ((string) source5.ElementAt<PropertyInfo>(3).GetValue((object) this.editorMapping.SecondaryInfo)).Hash(App.CurrentGame.Folders),
          attire_mtls_path = ((string) source5.ElementAt<PropertyInfo>(4).GetValue((object) this.editorMapping.SecondaryInfo)).Hash(App.CurrentGame.Folders),
          basemodel_mdl_path = ((string) source5.ElementAt<PropertyInfo>(5).GetValue((object) this.editorMapping.SecondaryInfo)).Hash(App.CurrentGame.Folders),
          basemodel_mtls_path = ((string) source5.ElementAt<PropertyInfo>(6).GetValue((object) this.editorMapping.SecondaryInfo)).Hash(App.CurrentGame.Folders)
        };
        generatedCharacter1.Renders.renders.Add(new Texture()
        {
          path = ((string) renders.ElementAt<PropertyInfo>(i).GetValue((object) this.editorMapping.Primaryinfo)).HashTexture(App.CurrentGame.Folders)
        });
        if (i > 0)
        {
          characterMapping.attire_num = (byte) i;
          info.additional_attire_names.Add((uint) source5.ElementAt<PropertyInfo>(0).GetValue((object) this.editorMapping.SecondaryInfo));
        }
        generatedCharacter1.CharacterMapping.Add(characterMapping);
      }
      WWE2K24_Generated_Character generatedCharacter2 = generatedCharacter1;
      ObservableCollection<Movie_WWE2K24> observableCollection = new ObservableCollection<Movie_WWE2K24>();
      observableCollection.Add(new Movie_WWE2K24()
      {
        id = this.editorMapping.Primaryinfo.WrestlerEntranceMovieTitantronID,
        sdb_id = this.editorMapping.Primaryinfo.WrestlerEntranceMovieTitantronSDB,
        type = Movie_WWE2K24.Tron_Type.Titantron.ToString(),
        bk2_path = this.editorMapping.Primaryinfo.WrestlerEntranceMovieTitantronBK2.Hash(App.CurrentGame.Folders),
        thumbnail_dds_path = this.editorMapping.Primaryinfo.WrestlerEntranceMovieTitantronThumbnail.HashTexture(App.CurrentGame.Folders)
      });
      Movie_WWE2K24 movieWwE2K24_1 = new Movie_WWE2K24();
      movieWwE2K24_1.id = this.editorMapping.Primaryinfo.WrestlerEntranceMovieBannerID;
      movieWwE2K24_1.sdb_id = this.editorMapping.Primaryinfo.WrestlerEntranceMovieBannerSDB;
      Movie_WWE2K24.Tron_Type tronType = Movie_WWE2K24.Tron_Type.Banner;
      movieWwE2K24_1.type = tronType.ToString();
      movieWwE2K24_1.bk2_path = this.editorMapping.Primaryinfo.WrestlerEntranceMovieBannerBK2.Hash(App.CurrentGame.Folders);
      observableCollection.Add(movieWwE2K24_1);
      Movie_WWE2K24 movieWwE2K24_2 = new Movie_WWE2K24();
      movieWwE2K24_2.id = this.editorMapping.Primaryinfo.WrestlerEntranceMovieStageID;
      movieWwE2K24_2.sdb_id = this.editorMapping.Primaryinfo.WrestlerEntranceMovieStageSDB;
      tronType = Movie_WWE2K24.Tron_Type.Stage;
      movieWwE2K24_2.type = tronType.ToString();
      movieWwE2K24_2.bk2_path = this.editorMapping.Primaryinfo.WrestlerEntranceMovieStageBK2.Hash(App.CurrentGame.Folders);
      observableCollection.Add(movieWwE2K24_2);
      Movie_WWE2K24 movieWwE2K24_3 = new Movie_WWE2K24();
      movieWwE2K24_3.id = this.editorMapping.Primaryinfo.WrestlerEntranceMovieApronID;
      movieWwE2K24_3.sdb_id = this.editorMapping.Primaryinfo.WrestlerEntranceMovieApronSDB;
      tronType = Movie_WWE2K24.Tron_Type.Apron;
      movieWwE2K24_3.type = tronType.ToString();
      movieWwE2K24_3.bk2_path = this.editorMapping.Primaryinfo.WrestlerEntranceMovieApronBK2.Hash(App.CurrentGame.Folders);
      observableCollection.Add(movieWwE2K24_3);
      Movie_WWE2K24 movieWwE2K24_4 = new Movie_WWE2K24();
      movieWwE2K24_4.id = this.editorMapping.Primaryinfo.WrestlerEntranceMovieBarricadeID;
      movieWwE2K24_4.sdb_id = this.editorMapping.Primaryinfo.WrestlerEntranceMovieBarricadeSDB;
      tronType = Movie_WWE2K24.Tron_Type.Barricade;
      movieWwE2K24_4.type = tronType.ToString();
      movieWwE2K24_4.bk2_path = this.editorMapping.Primaryinfo.WrestlerEntranceMovieBarricadeBK2.Hash(App.CurrentGame.Folders);
      observableCollection.Add(movieWwE2K24_4);
      generatedCharacter2.Movies = observableCollection;
      characterProfileWwE2K24.Info = info;
      characterProfileWwE2K24.Motion = motion;
      characterProfileWwE2K24.Moveset = moveset1;
      profile.Data = (object) characterProfileWwE2K24;
      profile.Generated = (object) generatedCharacter1;
      JsonSerializerSettings settings = new JsonSerializerSettings()
      {
        MissingMemberHandling = MissingMemberHandling.Ignore,
        Formatting = Formatting.Indented,
        NullValueHandling = NullValueHandling.Ignore
      };
      File.WriteAllText(saveFileDialog2.FileName, JsonConvert.SerializeObject((object) profile, settings));
    }
  }
}
