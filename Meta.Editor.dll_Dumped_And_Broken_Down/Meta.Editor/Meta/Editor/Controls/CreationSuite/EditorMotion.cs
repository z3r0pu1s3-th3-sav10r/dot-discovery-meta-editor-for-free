using Meta.Core.Interfaces;
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
  [TemplatePart(Name = "PART_PrimaryPropertyGrid", Type = typeof (PropertyGrid))]
  [TemplatePart(Name = "PART_SecondaryInfoPropertyGrid", Type = typeof (PropertyGrid))]
  public class EditorMotion : CreationEditor
  {
    private const string PART_PrimaryPropertyGrid = "PART_PrimaryPropertyGrid";
    private const string PART_SecondaryInfoPropertyGrid = "PART_SecondaryInfoPropertyGrid";
    private PropertyGrid BasicInfoPropertyGrid;
    private PropertyGrid SecondaryMappingPropertyGrid;
    private EditorMotion.MotionPrimary motionPrimaryInfo;
    private EditorMotion.MotionSecondary motionSecondaryInfo;

    public MetaPropertyGridFactory MetaPropertyGridFactory { get; set; }

    public EditorMotion.MotionPrimary Primaryinfo => this.motionPrimaryInfo;

    public EditorMotion.MotionSecondary SecondaryInfo => this.motionSecondaryInfo;

    public override string Title => "Moveset";

    public override string Icon => "MotionSensor";

    public EditorMotion(ILogger inLogger)
      : base(inLogger)
    {
      this.DataContext = (object) this;
      this.MetaPropertyGridFactory = new MetaPropertyGridFactory();
      this.motionPrimaryInfo = new EditorMotion.MotionPrimary();
      this.motionSecondaryInfo = new EditorMotion.MotionSecondary();
    }

    static EditorMotion()
    {
      FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof (EditorMotion), (PropertyMetadata) new FrameworkPropertyMetadata((object) typeof (EditorMotion)));
    }

    public override void OnApplyTemplate()
    {
      base.OnApplyTemplate();
      this.MetaPropertyGridFactory = new MetaPropertyGridFactory();
      this.BasicInfoPropertyGrid = this.GetTemplateChild("PART_PrimaryPropertyGrid") as PropertyGrid;
      this.BasicInfoPropertyGrid.ControlFactory = (IPropertyGridControlFactory) this.MetaPropertyGridFactory;
      this.BasicInfoPropertyGrid.SelectedObject = (object) this.motionPrimaryInfo;
      this.SecondaryMappingPropertyGrid = this.GetTemplateChild("PART_SecondaryInfoPropertyGrid") as PropertyGrid;
      this.SecondaryMappingPropertyGrid.ControlFactory = (IPropertyGridControlFactory) this.MetaPropertyGridFactory;
      this.SecondaryMappingPropertyGrid.SelectedObject = (object) this.motionSecondaryInfo;
    }

    public override void Shutdown()
    {
      base.Shutdown();
      ((FrameworkElement) this.BasicInfoPropertyGrid).DataContext = (object) null;
      this.BasicInfoPropertyGrid.SelectedObject = (object) null;
      ((FrameworkElement) this.SecondaryMappingPropertyGrid).DataContext = (object) null;
      this.SecondaryMappingPropertyGrid.SelectedObject = (object) null;
    }

    public void Load(CharacterProfile_WWE2K23 Profile)
    {
      if (Profile.Moveset == null)
        return;
      this.motionPrimaryInfo = new EditorMotion.MotionPrimary();
      this.motionSecondaryInfo = new EditorMotion.MotionSecondary();
      this.motionPrimaryInfo.GetType().GetProperties();
      this.motionPrimaryInfo.MovesetStandingLightAttack1 = this.motionPrimaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_standing.front_light_attack[0]);
      this.motionPrimaryInfo.MovesetStandingLightAttack2 = this.motionPrimaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_standing.front_light_attack[1]);
      this.motionPrimaryInfo.MovesetStandingLightAttack3 = this.motionPrimaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_standing.front_light_attack[2]);
      this.motionPrimaryInfo.MovesetStandingHeavyAttack1 = this.motionPrimaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_standing.front_heavy_attack[0]);
      this.motionPrimaryInfo.MovesetStandingHeavyAttack2 = this.motionPrimaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_standing.front_heavy_attack[1]);
      this.motionPrimaryInfo.MovesetStandingHeavyAttack3 = this.motionPrimaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_standing.front_heavy_attack[2]);
      this.motionPrimaryInfo.MovesetStandingLightGrapple1 = this.motionPrimaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_standing.front_light_grapple[0]);
      this.motionPrimaryInfo.MovesetStandingLightGrapple2 = this.motionPrimaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_standing.front_light_grapple[1]);
      this.motionPrimaryInfo.MovesetStandingLightGrapple3 = this.motionPrimaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_standing.front_light_grapple[2]);
      this.motionPrimaryInfo.MovesetStandingLightGrapple4 = this.motionPrimaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_standing.front_light_grapple[3]);
      this.motionPrimaryInfo.MovesetStandingLightGrapple5 = this.motionPrimaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_standing.front_light_grapple[4]);
      this.motionPrimaryInfo.MovesetStandingHeavyGrapple1 = this.motionPrimaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_standing.front_heavy_grapple[0]);
      this.motionPrimaryInfo.MovesetStandingHeavyGrapple2 = this.motionPrimaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_standing.front_heavy_grapple[1]);
      this.motionPrimaryInfo.MovesetStandingHeavyGrapple3 = this.motionPrimaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_standing.front_heavy_grapple[2]);
      this.motionPrimaryInfo.MovesetStandingHeavyGrapple4 = this.motionPrimaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_standing.front_heavy_grapple[3]);
      this.motionPrimaryInfo.MovesetStandingHeavyGrapple5 = this.motionPrimaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_standing.front_heavy_grapple[4]);
      this.motionPrimaryInfo.MovesetStandingFrontRunningAttack1 = this.motionPrimaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_standing.front_running[0]);
      this.motionPrimaryInfo.MovesetStandingFrontRunningAttack2 = this.motionPrimaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_standing.front_running[1]);
      this.motionPrimaryInfo.MovesetStandingFrontRunningAttack3 = this.motionPrimaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_standing.front_running[2]);
      this.motionPrimaryInfo.MovesetStandingRearHeavyAttack = this.motionPrimaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_standing.rear_heavy_attack[0]);
      this.motionPrimaryInfo.MovesetStandingRearLightGrapple1 = this.motionPrimaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_standing.rear_light_grapple[0]);
      this.motionPrimaryInfo.MovesetStandingRearLightGrapple2 = this.motionPrimaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_standing.rear_light_grapple[1]);
      this.motionPrimaryInfo.MovesetStandingRearLightGrapple3 = this.motionPrimaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_standing.rear_light_grapple[2]);
      this.motionPrimaryInfo.MovesetStandingRearLightGrapple4 = this.motionPrimaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_standing.rear_light_grapple[3]);
      this.motionPrimaryInfo.MovesetStandingRearLightGrapple5 = this.motionPrimaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_standing.rear_light_grapple[4]);
      this.motionPrimaryInfo.MovesetStandingRearHeavyGrapple1 = this.motionPrimaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_standing.rear_heavy_grapple[0]);
      this.motionPrimaryInfo.MovesetStandingRearHeavyGrapple2 = this.motionPrimaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_standing.rear_heavy_grapple[1]);
      this.motionPrimaryInfo.MovesetStandingRearHeavyGrapple3 = this.motionPrimaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_standing.rear_heavy_grapple[2]);
      this.motionPrimaryInfo.MovesetStandingRearHeavyGrapple4 = this.motionPrimaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_standing.rear_heavy_grapple[3]);
      this.motionPrimaryInfo.MovesetStandingRearHeavyGrapple5 = this.motionPrimaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_standing.rear_heavy_grapple[4]);
      this.motionPrimaryInfo.MovesetStandingRearRunning1 = this.motionPrimaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_standing.rear_running[0]);
      this.motionPrimaryInfo.MovesetStandingRearRunning2 = this.motionPrimaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_standing.rear_running[1]);
      this.motionPrimaryInfo.MovesetStandingRearRunning3 = this.motionPrimaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_standing.rear_running[2]);
      this.motionPrimaryInfo.MovesetStandingCarry1 = this.motionPrimaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_standing.carry[0]);
      this.motionPrimaryInfo.MovesetStandingCarry2 = this.motionPrimaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_standing.carry[1]);
      this.motionPrimaryInfo.MovesetStandingCarry3 = this.motionPrimaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_standing.carry[2]);
      this.motionPrimaryInfo.MovesetStandingCarry4 = this.motionPrimaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_standing.carry[3]);
      this.motionPrimaryInfo.MovesetStandingFootCatch1 = this.motionPrimaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_standing.foot_catch[0]);
      this.motionPrimaryInfo.MovesetStandingFootCatch2 = this.motionPrimaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_standing.foot_catch[1]);
      this.motionPrimaryInfo.MovesetStandingFootCatch3 = this.motionPrimaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_standing.foot_catch[2]);
      this.motionPrimaryInfo.MovesetStandingFootCatch4 = this.motionPrimaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_standing.foot_catch[3]);
      this.motionPrimaryInfo.MovesetStandingLeveragePin1 = this.motionPrimaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_standing.leverage_pin[0]);
      this.motionPrimaryInfo.MovesetStandingLeveragePin2 = this.motionPrimaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_standing.leverage_pin[1]);
      this.motionPrimaryInfo.MovesetSignaturesInRing1 = this.motionPrimaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_signatures.in_ring[0]);
      this.motionPrimaryInfo.MovesetSignaturesInRing2 = this.motionPrimaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_signatures.in_ring[1]);
      this.motionPrimaryInfo.MovesetSignaturesRingside1 = this.motionPrimaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_signatures.ringside[0]);
      this.motionPrimaryInfo.MovesetSignaturesRingside2 = this.motionPrimaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_signatures.ringside[1]);
      this.motionPrimaryInfo.MovesetFinisherInRing1 = this.motionPrimaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_finishers.in_ring[0]);
      this.motionPrimaryInfo.MovesetFinisherInRing2 = this.motionPrimaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_finishers.in_ring[1]);
      this.motionPrimaryInfo.MovesetFinisherRingside1 = this.motionPrimaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_finishers.ringside[0]);
      this.motionPrimaryInfo.MovesetFinisherRingside2 = this.motionPrimaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_finishers.ringside[1]);
      this.motionPrimaryInfo.MovesetFinisherRingside3 = this.motionPrimaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_finishers.ringside[2]);
      this.motionPrimaryInfo.MovesetFinisherTable1 = this.motionPrimaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_finishers.table[0]);
      this.motionPrimaryInfo.MovesetFinisherTable2 = this.motionPrimaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_finishers.table[1]);
      this.motionPrimaryInfo.MovesetFinisherRumble1 = this.motionPrimaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_finishers.rumble[0]);
      this.motionPrimaryInfo.MovesetFinisherRumble2 = this.motionPrimaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_finishers.rumble[1]);
      this.motionPrimaryInfo.MovesetFinisherRumble3 = this.motionPrimaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_finishers.rumble[2]);
      this.motionPrimaryInfo.MovesetFinisherRumble4 = this.motionPrimaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_finishers.rumble[3]);
      this.motionPrimaryInfo.MovesetFinisherLadder1 = this.motionPrimaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_match_type.ladder[3]);
      this.motionPrimaryInfo.MovesetFinisherLadder2 = this.motionPrimaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_match_type.ladder[4]);
      this.motionPrimaryInfo.MovesetFinisher1V2 = this.motionPrimaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_finishers.other[0]);
      this.motionPrimaryInfo.MovesetFinisherCatching = this.motionPrimaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_finishers.other[1]);
      this.motionPrimaryInfo.MovesetFinisherLedge = this.motionPrimaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_finishers.other[5]);
      this.motionPrimaryInfo.MovesetFinisherHellInACell = this.motionPrimaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_finishers.other[3]);
      this.motionPrimaryInfo.MovesetFinisherAnnouncerTable = this.motionPrimaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_finishers.other[4]);
      this.motionPrimaryInfo.SetValue("Finisher|Rumble", Profile.Moveset.moves_finishers.rumble);
      this.motionPrimaryInfo.MovesetStandingComboChain1 = this.motionPrimaryInfo.Combos.Get<uint>((object) Profile.Moveset.moves_standing.combo_chain_towards[0]);
      this.motionPrimaryInfo.MovesetStandingComboChain2 = this.motionPrimaryInfo.Combos.Get<uint>((object) Profile.Moveset.moves_standing.combo_chain_neutral[0]);
      this.motionPrimaryInfo.MovesetStandingComboChain3 = this.motionPrimaryInfo.Combos.Get<uint>((object) Profile.Moveset.moves_standing.combo_chain_away[0]);
      this.motionPrimaryInfo.SetValue("Standing|Combo Enders - Towards", Profile.Moveset.moves_standing.combo_enders_towards);
      this.motionPrimaryInfo.SetValue("Standing|Combo Enders - Neutral", Profile.Moveset.moves_standing.combo_enders_neutral);
      this.motionPrimaryInfo.SetValue("Standing|Combo Enders - Away", Profile.Moveset.moves_standing.combo_enders_away);
      this.motionPrimaryInfo.MovesetGroundFaceuUpUppper1 = this.motionPrimaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_ground.face_up_upper[0]);
      this.motionPrimaryInfo.MovesetGroundFaceuUpUppper2 = this.motionPrimaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_ground.face_up_upper[1]);
      this.motionPrimaryInfo.MovesetGroundFaceuUpUppper3 = this.motionPrimaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_ground.face_up_upper[2]);
      this.motionPrimaryInfo.MovesetGroundFaceuUpSide1 = this.motionPrimaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_ground.face_up_side[0]);
      this.motionPrimaryInfo.MovesetGroundFaceuUpSide2 = this.motionPrimaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_ground.face_up_side[1]);
      this.motionPrimaryInfo.MovesetGroundFaceuUpSide3 = this.motionPrimaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_ground.face_up_side[2]);
      this.motionPrimaryInfo.MovesetGroundFaceuUpLower1 = this.motionPrimaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_ground.face_up_lower[0]);
      this.motionPrimaryInfo.MovesetGroundFaceuUpLower2 = this.motionPrimaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_ground.face_up_lower[1]);
      this.motionPrimaryInfo.MovesetGroundFaceuUpLower3 = this.motionPrimaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_ground.face_up_lower[2]);
      this.motionPrimaryInfo.MovesetGroundFaceuUpRunning = this.motionPrimaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_ground.face_up_running[0]);
      this.motionPrimaryInfo.MovesetGroundFaceDownUppper1 = this.motionPrimaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_ground.face_down_upper[0]);
      this.motionPrimaryInfo.MovesetGroundFaceDownUppper2 = this.motionPrimaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_ground.face_down_upper[1]);
      this.motionPrimaryInfo.MovesetGroundFaceDownUppper3 = this.motionPrimaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_ground.face_down_upper[2]);
      this.motionPrimaryInfo.MovesetGroundFaceDownSide1 = this.motionPrimaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_ground.face_down_side[0]);
      this.motionPrimaryInfo.MovesetGroundFaceDownSide2 = this.motionPrimaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_ground.face_down_side[1]);
      this.motionPrimaryInfo.MovesetGroundFaceDownSide3 = this.motionPrimaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_ground.face_down_side[2]);
      this.motionPrimaryInfo.MovesetGroundFaceDownLower1 = this.motionPrimaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_ground.face_down_lower[0]);
      this.motionPrimaryInfo.MovesetGroundFaceDownLower2 = this.motionPrimaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_ground.face_down_lower[1]);
      this.motionPrimaryInfo.MovesetGroundFaceDownLower3 = this.motionPrimaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_ground.face_down_lower[2]);
      this.motionPrimaryInfo.MovesetGroundKneelingFront1 = this.motionPrimaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_ground.kneeling_front[0]);
      this.motionPrimaryInfo.MovesetGroundKneelingFront2 = this.motionPrimaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_ground.kneeling_front[1]);
      this.motionPrimaryInfo.MovesetGroundKneelingFront3 = this.motionPrimaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_ground.kneeling_front[2]);
      this.motionPrimaryInfo.MovesetGroundKneelingFront4 = this.motionPrimaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_ground.kneeling_front[3]);
      this.motionPrimaryInfo.MovesetGroundKneelingFront5 = this.motionPrimaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_ground.kneeling_front[4]);
      this.motionPrimaryInfo.MovesetGroundKneelingRear1 = this.motionPrimaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_ground.kneeling_rear[0]);
      this.motionPrimaryInfo.MovesetGroundKneelingRear2 = this.motionPrimaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_ground.kneeling_rear[1]);
      this.motionPrimaryInfo.MovesetGroundSeatedFront1 = this.motionPrimaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_ground.seated_front[0]);
      this.motionPrimaryInfo.MovesetGroundSeatedFront2 = this.motionPrimaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_ground.seated_front[1]);
      this.motionPrimaryInfo.MovesetGroundSeatedFront3 = this.motionPrimaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_ground.seated_front[2]);
      this.motionPrimaryInfo.MovesetGroundSeatedRear1 = this.motionPrimaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_ground.seated_rear[0]);
      this.motionPrimaryInfo.MovesetGroundSeatedRear2 = this.motionPrimaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_ground.seated_rear[1]);
      this.motionPrimaryInfo.MovesetIrishWhipReboundAction1 = this.motionPrimaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_irish_whip.rebound_action[0]);
      this.motionPrimaryInfo.MovesetIrishWhipReboundAction2 = this.motionPrimaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_irish_whip.rebound_action[1]);
      this.motionPrimaryInfo.MovesetIrishWhipReboundAttack1 = this.motionPrimaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_irish_whip.rebound_attack[0]);
      this.motionPrimaryInfo.MovesetIrishWhipReboundAttack2 = this.motionPrimaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_irish_whip.rebound_attack[1]);
      this.motionPrimaryInfo.MovesetIrishWhipReboundAttack3 = this.motionPrimaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_irish_whip.rebound_attack[2]);
      this.motionPrimaryInfo.MovesetIrishWhipPullBackAttack1 = this.motionPrimaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_irish_whip.pullback_attack[0]);
      this.motionPrimaryInfo.MovesetIrishWhipPullBackAttack2 = this.motionPrimaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_irish_whip.pullback_attack[1]);
      this.motionPrimaryInfo.MovesetCornerLeaningFront1 = this.motionPrimaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_corner.leaning_front[0]);
      this.motionPrimaryInfo.MovesetCornerLeaningFront2 = this.motionPrimaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_corner.leaning_front[1]);
      this.motionPrimaryInfo.MovesetCornerLeaningFront3 = this.motionPrimaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_corner.leaning_front[2]);
      this.motionPrimaryInfo.MovesetCornerLeaningFront4 = this.motionPrimaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_corner.leaning_front[3]);
      this.motionPrimaryInfo.MovesetCornerLeaningFront5 = this.motionPrimaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_corner.leaning_front[4]);
      this.motionPrimaryInfo.MovesetCornerLeaningFront6 = this.motionPrimaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_corner.leaning_front[5]);
      this.motionPrimaryInfo.MovesetCornerLeaningRear1 = this.motionPrimaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_corner.leaning_rear[0]);
      this.motionPrimaryInfo.MovesetCornerLeaningRear2 = this.motionPrimaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_corner.leaning_rear[1]);
      this.motionPrimaryInfo.MovesetCornerLeaningRear3 = this.motionPrimaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_corner.leaning_rear[2]);
      this.motionPrimaryInfo.MovesetCornerLeaningRear4 = this.motionPrimaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_corner.leaning_rear[3]);
      this.motionPrimaryInfo.MovesetCornerLeaningRear5 = this.motionPrimaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_corner.leaning_rear[4]);
      this.motionPrimaryInfo.MovesetCornerLeaningRear6 = this.motionPrimaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_corner.leaning_rear[5]);
      this.motionPrimaryInfo.MovesetCornerTopRopeStunnedFront1 = this.motionPrimaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_corner.top_rope_stunned_front[0]);
      this.motionPrimaryInfo.MovesetCornerTopRopeStunnedFront2 = this.motionPrimaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_corner.top_rope_stunned_front[1]);
      this.motionPrimaryInfo.MovesetCornerTopRopeStunnedRear1 = this.motionPrimaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_corner.top_rope_stunned_rear[0]);
      this.motionPrimaryInfo.MovesetCornerTopRopeStunnedRear2 = this.motionPrimaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_corner.top_rope_stunned_rear[1]);
      this.motionPrimaryInfo.MovesetCornerSeated1 = this.motionPrimaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_corner.seated[0]);
      this.motionPrimaryInfo.MovesetCornerSeated2 = this.motionPrimaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_corner.seated[1]);
      this.motionPrimaryInfo.MovesetCornerSeated3 = this.motionPrimaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_corner.seated[2]);
      this.motionPrimaryInfo.MovesetCornerTreeOfWoe1 = this.motionPrimaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_corner.tree_of_woe[0]);
      this.motionPrimaryInfo.MovesetCornerTreeOfWoe2 = this.motionPrimaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_corner.tree_of_woe[1]);
      this.motionPrimaryInfo.MovesetRopeLeaning1 = this.motionPrimaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_rope.leaning[0]);
      this.motionPrimaryInfo.MovesetRopeLeaning2 = this.motionPrimaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_rope.leaning[1]);
      this.motionPrimaryInfo.MovesetRopeLeaning3 = this.motionPrimaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_rope.leaning[2]);
      this.motionPrimaryInfo.MovesetRopeLeaning4 = this.motionPrimaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_rope.leaning[3]);
      this.motionPrimaryInfo.MovesetRopeLeaning5 = this.motionPrimaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_rope.leaning[4]);
      this.motionPrimaryInfo.MovesetRopeLeaning6 = this.motionPrimaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_rope.leaning[5]);
      this.motionPrimaryInfo.MovesetRopeMiddleRope1 = this.motionPrimaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_rope.middle_rope[0]);
      this.motionPrimaryInfo.MovesetApronFromRingFront1 = this.motionPrimaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_apron.from_ring_front[0]);
      this.motionPrimaryInfo.MovesetApronFromRingFront2 = this.motionPrimaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_apron.from_ring_front[1]);
      this.motionPrimaryInfo.MovesetApronFromRingFront3 = this.motionPrimaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_apron.from_ring_front[2]);
      this.motionPrimaryInfo.MovesetApronFromRingRear1 = this.motionPrimaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_apron.from_ring_rear[0]);
      this.motionPrimaryInfo.MovesetApronFromApronToRing1 = this.motionPrimaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_apron.from_apron_to_ring[0]);
      this.motionPrimaryInfo.MovesetApronFromApronToRing2 = this.motionPrimaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_apron.from_apron_to_ring[1]);
      this.motionPrimaryInfo.MovesetApronFromApronToRingSide1 = this.motionPrimaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_apron.from_apron_to_ringside[0]);
      this.motionPrimaryInfo.MovesetApronFromApronToRingSide2 = this.motionPrimaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_apron.from_apron_to_ringside[1]);
      this.motionPrimaryInfo.MovesetDivingMiddleRope1 = this.motionPrimaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_diving.middle_rope_light_dive[0]);
      this.motionPrimaryInfo.MovesetDivingMiddleRope2 = this.motionPrimaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_diving.middle_rope_light_dive_to_supine[0]);
      this.motionPrimaryInfo.MovesetDivingTopRope1 = this.motionPrimaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_diving.diving_top_rope_attack[0]);
      this.motionPrimaryInfo.MovesetDivingTopRope2 = this.motionPrimaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_diving.diving_top_rope_attack[1]);
      this.motionPrimaryInfo.MovesetDivingTopRope3 = this.motionPrimaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_diving.diving_top_rope_to_supine[0]);
      this.motionPrimaryInfo.MovesetDivingTopRope4 = this.motionPrimaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_diving.diving_top_rope_to_supine[1]);
      this.motionPrimaryInfo.MovesetDivingLedge1 = this.motionPrimaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_diving.ledge[0]);
      this.motionPrimaryInfo.MovesetDivingLedge2 = this.motionPrimaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_diving.ledge[1]);
      this.motionPrimaryInfo.MovesetDivingEquipmentBox1 = this.motionPrimaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_diving.equipment_box[0]);
      this.motionPrimaryInfo.MovesetDivingEquipmentBox2 = this.motionPrimaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_diving.equipment_box[1]);
      this.motionPrimaryInfo.MovesetSpringboardToRingStandingFront1 = this.motionPrimaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_springboard.to_ring_standing_front[0]);
      this.motionPrimaryInfo.MovesetSpringboardToRingStandingFront2 = this.motionPrimaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_springboard.to_ring_standing_front[1]);
      this.motionPrimaryInfo.MovesetSpringboardToRingStandingFront3 = this.motionPrimaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_springboard.to_ring_standing_front[2]);
      this.motionPrimaryInfo.MovesetSpringboardToRingStandingFront4 = this.motionPrimaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_springboard.to_ring_standing_front[3]);
      this.motionPrimaryInfo.MovesetSpringboardToRingFaceUp1 = this.motionPrimaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_springboard.to_ring_supine[0]);
      this.motionPrimaryInfo.MovesetSpringboardToRingFaceUp2 = this.motionPrimaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_springboard.to_ring_supine[1]);
      this.motionPrimaryInfo.MovesetSpringboardToRingFaceUp3 = this.motionPrimaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_springboard.to_ring_supine[2]);
      this.motionPrimaryInfo.MovesetSpringboardToRingFaceUp4 = this.motionPrimaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_springboard.to_ring_supine[3]);
      this.motionPrimaryInfo.MovesetSpringboardToRingsideStandingFront1 = this.motionPrimaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_springboard.to_ringside_standing_front[0]);
      this.motionPrimaryInfo.MovesetSpringboardToRingsideStandingFront2 = this.motionPrimaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_springboard.to_ringside_standing_front[1]);
      this.motionPrimaryInfo.MovesetSpringboardToRingsideStandingFront3 = this.motionPrimaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_springboard.to_ringside_standing_front[2]);
      this.motionPrimaryInfo.MovesetSpringboardToRingsideFaceUp1 = this.motionPrimaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_springboard.to_ringside_supine[0]);
      this.motionPrimaryInfo.MovesetSpringboardToRingsideFaceUp2 = this.motionPrimaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_springboard.to_ringside_supine[1]);
      this.motionPrimaryInfo.MovesetSpringboardToRingsideFaceUp3 = this.motionPrimaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_springboard.to_ringside_supine[2]);
      this.motionSecondaryInfo.MovesetHoldsSubmission1 = this.motionSecondaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_holds.submission[0]);
      this.motionSecondaryInfo.MovesetHoldsSubmission2 = this.motionSecondaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_standing.foot_catch[2]);
      this.motionSecondaryInfo.MovesetHoldsSubmission3 = this.motionSecondaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_holds.submission[1]);
      this.motionSecondaryInfo.MovesetHoldsSubmission4 = this.motionSecondaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_holds.submission[2]);
      this.motionSecondaryInfo.MovesetHoldsSubmission5 = this.motionSecondaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_holds.submission[3]);
      this.motionSecondaryInfo.MovesetOtherAttacksBarricade1 = this.motionSecondaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_other_attacks.barricade[0]);
      this.motionSecondaryInfo.MovesetOtherAttacksBarricade2 = this.motionSecondaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_other_attacks.barricade[1]);
      this.motionSecondaryInfo.MovesetOtherAttacksComeback = this.motionSecondaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_other_attacks.comeback[0]);
      this.motionSecondaryInfo.MovesetMovementEnterRing1 = this.motionSecondaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_movement.enter_ring[0]);
      this.motionSecondaryInfo.MovesetMovementEnterRing2 = this.motionSecondaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_movement.enter_ring[1]);
      this.motionSecondaryInfo.MovesetMovementExitRing1 = this.motionSecondaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_movement.exit_ring[0]);
      this.motionSecondaryInfo.MovesetMovementExitRing2 = this.motionSecondaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_movement.exit_ring[1]);
      this.motionSecondaryInfo.MovesetMovementRecovery = this.motionSecondaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_movement.recovery[0]);
      this.motionSecondaryInfo.MovesetMovementClimbTopRope1 = this.motionSecondaryInfo.WrestlerMovesClimbFront.Get<uint>((object) (uint) Profile.Moveset.moves_movement.climb_top_rope[0]);
      this.motionSecondaryInfo.MovesetMovementClimbTopRope2 = this.motionSecondaryInfo.WrestlerMovesClimbRear.Get<uint>((object) (uint) Profile.Moveset.moves_movement.climb_top_rope[1]);
      this.motionSecondaryInfo.MovesetMatchTypeTableTableAttack = this.motionSecondaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_match_type.table[0]);
      this.motionSecondaryInfo.MovesetMatchTypeTableInCornerAttack = this.motionSecondaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_match_type.table[1]);
      this.motionSecondaryInfo.MovesetMatchTypeTableCornerAttack = this.motionSecondaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_match_type.table[2]);
      this.motionSecondaryInfo.MovesetMatchTypeTableAttackOpponentOnRopes = this.motionSecondaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_match_type.table[3]);
      this.motionSecondaryInfo.MovesetMatchTypeTableAttackOpponentOnApron = this.motionSecondaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_match_type.table[4]);
      this.motionSecondaryInfo.MovesetMatchTypeLadderLightAttack = this.motionSecondaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_match_type.ladder[0]);
      this.motionSecondaryInfo.MovesetMatchTypeLadderHeavyAttack = this.motionSecondaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_match_type.ladder[1]);
      this.motionSecondaryInfo.MovesetMatchTypeLadderGrapple = this.motionSecondaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_match_type.ladder[2]);
      this.motionSecondaryInfo.MovesetMatchTypeTagTeamNormalTagAttacks1 = this.motionSecondaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_match_type.tag_team_normal_tag_attacks[0]);
      this.motionSecondaryInfo.MovesetMatchTypeTagTeamNormalTagAttacks2 = this.motionSecondaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_match_type.tag_team_normal_tag_attacks[1]);
      this.motionSecondaryInfo.MovesetMatchTypeTagTeamNormalTagAttacks3 = this.motionSecondaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_match_type.tag_team_normal_tag_attacks[2]);
      this.motionSecondaryInfo.MovesetMatchTypeTagTeamNormalTagAttacks4 = this.motionSecondaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_match_type.tag_team_normal_tag_attacks[3]);
      this.motionSecondaryInfo.MovesetMatchTypeMixedTagNormalTagAttacks1 = this.motionSecondaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_match_type.tag_team_mixed_tag_attacks[0]);
      this.motionSecondaryInfo.MovesetMatchTypeMixedTagNormalTagAttacks2 = this.motionSecondaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_match_type.tag_team_mixed_tag_attacks[1]);
      this.motionSecondaryInfo.MovesetMatchTypeMixedTagNormalTagAttacks3 = this.motionSecondaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_match_type.tag_team_mixed_tag_attacks[2]);
      this.motionSecondaryInfo.MovesetMatchTypeMixedTagNormalTagAttacks4 = this.motionSecondaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_match_type.tag_team_mixed_tag_attacks[3]);
      this.motionSecondaryInfo.MovesetMatchTypeMixedTagNormalTagFinishers1 = this.motionSecondaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_finishers.tag_team_mixed_tag[0]);
      this.motionSecondaryInfo.MovesetMatchTypeMixedTagNormalTagFinishers2 = this.motionSecondaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_finishers.tag_team_mixed_tag[1]);
      this.motionSecondaryInfo.MovesetMatchTypeTagteamDoubleTeam1 = this.motionSecondaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_match_type.tag_team_double_team[0]);
      this.motionSecondaryInfo.MovesetMatchTypeTagteamDoubleTeam2 = this.motionSecondaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_match_type.tag_team_double_team[1]);
      this.motionSecondaryInfo.MovesetMatchTypeTagteamDoubleTeam3 = this.motionSecondaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_match_type.tag_team_double_team[2]);
      this.motionSecondaryInfo.MovesetMatchTypeTagteamDoubleTeam4 = this.motionSecondaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_match_type.tag_team_double_team[3]);
      this.motionSecondaryInfo.MovesetMatchTypeHellInACell1 = this.motionSecondaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_finishers.other[2]);
      this.motionSecondaryInfo.MovesetTauntToCrowdStanding1 = this.motionSecondaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_taunts.to_crowd_standing[0]);
      this.motionSecondaryInfo.MovesetTauntToCrowdStanding2 = this.motionSecondaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_taunts.to_crowd_standing[1]);
      this.motionSecondaryInfo.MovesetTauntToCrowdStanding3 = this.motionSecondaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_taunts.to_crowd_standing[2]);
      this.motionSecondaryInfo.MovesetTauntToCrowdStanding4 = this.motionSecondaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_taunts.to_crowd_standing[3]);
      this.motionSecondaryInfo.MovesetTauntToCrowdStanding5 = this.motionSecondaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_taunts.to_crowd_standing[4]);
      this.motionSecondaryInfo.MovesetTauntToCrowdCorner1 = this.motionSecondaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_taunts.to_crowd_corner[0]);
      this.motionSecondaryInfo.MovesetTauntToCrowdCorner2 = this.motionSecondaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_taunts.to_crowd_corner[1]);
      this.motionSecondaryInfo.MovesetTauntToCrowdCorner3 = this.motionSecondaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_taunts.to_crowd_corner[2]);
      this.motionSecondaryInfo.MovesetTauntToCrowdTopRopeFacingRing1 = this.motionSecondaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_taunts.to_crowd_top_rope[0]);
      this.motionSecondaryInfo.MovesetTauntToCrowdTopRopeFacingRing2 = this.motionSecondaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_taunts.to_crowd_top_rope[1]);
      this.motionSecondaryInfo.MovesetTauntToCrowdTopRopeFacingRing3 = this.motionSecondaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_taunts.to_crowd_top_rope[2]);
      this.motionSecondaryInfo.MovesetTauntToCrowdMiddleRope1 = this.motionSecondaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_taunts.to_crowd_middle_rope[0]);
      this.motionSecondaryInfo.MovesetTauntToCrowdMiddleRope2 = this.motionSecondaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_taunts.to_crowd_middle_rope[1]);
      this.motionSecondaryInfo.MovesetTauntToCrowdMiddleRope3 = this.motionSecondaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_taunts.to_crowd_middle_rope[2]);
      this.motionSecondaryInfo.MovesetTauntToCrowdApronFacingRing1 = this.motionSecondaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_taunts.to_crowd_apron_facing_ring[0]);
      this.motionSecondaryInfo.MovesetTauntToCrowdApronFacingRing2 = this.motionSecondaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_taunts.to_crowd_apron_facing_ring[1]);
      this.motionSecondaryInfo.MovesetTauntToCrowdApronFacingRing3 = this.motionSecondaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_taunts.to_crowd_apron_facing_ring[2]);
      this.motionSecondaryInfo.MovesetTauntToCrowdApronFacingRingside1 = this.motionSecondaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_taunts.to_crowd_apron_facing_ringside[0]);
      this.motionSecondaryInfo.MovesetTauntToCrowdApronFacingRingside2 = this.motionSecondaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_taunts.to_crowd_apron_facing_ringside[1]);
      this.motionSecondaryInfo.MovesetTauntToCrowdApronFacingRingside3 = this.motionSecondaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_taunts.to_crowd_apron_facing_ringside[2]);
      this.motionSecondaryInfo.MovesetTauntToOpponentStanding1 = this.motionSecondaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_taunts.to_opponent_standing_to_standing[0]);
      this.motionSecondaryInfo.MovesetTauntToOpponentStanding2 = this.motionSecondaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_taunts.to_opponent_standing_to_standing[1]);
      this.motionSecondaryInfo.MovesetTauntToOpponentStanding3 = this.motionSecondaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_taunts.to_opponent_standing_to_standing[2]);
      this.motionSecondaryInfo.MovesetTauntToOpponentStanding4 = this.motionSecondaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_taunts.to_opponent_standing_to_standing[3]);
      this.motionSecondaryInfo.MovesetTauntToOpponentStanding5 = this.motionSecondaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_taunts.to_opponent_standing_to_standing[4]);
      this.motionSecondaryInfo.MovesetTauntToOpponentStandingToGround1 = this.motionSecondaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_taunts.to_opponent_standing_to_ground[0]);
      this.motionSecondaryInfo.MovesetTauntToOpponentStandingToGround2 = this.motionSecondaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_taunts.to_opponent_standing_to_ground[1]);
      this.motionSecondaryInfo.MovesetTauntToOpponentStandingToGround3 = this.motionSecondaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_taunts.to_opponent_standing_to_ground[2]);
      this.motionSecondaryInfo.MovesetTauntToOpponentStandingToGround4 = this.motionSecondaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_taunts.to_opponent_standing_to_ground[3]);
      this.motionSecondaryInfo.MovesetTauntToOpponentStandingToGround5 = this.motionSecondaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_taunts.to_opponent_standing_to_ground[4]);
      this.motionSecondaryInfo.MovesetTauntToOpponentCorner1 = this.motionSecondaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_taunts.to_opponent_corner[0]);
      this.motionSecondaryInfo.MovesetTauntToOpponentCorner2 = this.motionSecondaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_taunts.to_opponent_corner[1]);
      this.motionSecondaryInfo.MovesetTauntToOpponentCorner3 = this.motionSecondaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_taunts.to_opponent_corner[2]);
      this.motionSecondaryInfo.MovesetTauntToOpponentTopRopeFacingRing1 = this.motionSecondaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_taunts.to_opponent_top_rope[0]);
      this.motionSecondaryInfo.MovesetTauntToOpponentTopRopeFacingRing2 = this.motionSecondaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_taunts.to_opponent_top_rope[1]);
      this.motionSecondaryInfo.MovesetTauntToOpponentTopRopeFacingRing3 = this.motionSecondaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_taunts.to_opponent_top_rope[2]);
      this.motionSecondaryInfo.MovesetTauntToOpponentMiddleRope1 = this.motionSecondaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_taunts.to_opponent_middle_rope[0]);
      this.motionSecondaryInfo.MovesetTauntToOpponentMiddleRope2 = this.motionSecondaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_taunts.to_opponent_middle_rope[1]);
      this.motionSecondaryInfo.MovesetTauntToOpponentMiddleRope3 = this.motionSecondaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_taunts.to_opponent_middle_rope[2]);
      this.motionSecondaryInfo.MovesetTauntToOpponentApronFacingRing1 = this.motionSecondaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_taunts.to_opponent_apron_facing_ring[0]);
      this.motionSecondaryInfo.MovesetTauntToOpponentApronFacingRing2 = this.motionSecondaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_taunts.to_opponent_apron_facing_ring[1]);
      this.motionSecondaryInfo.MovesetTauntToOpponentApronFacingRing3 = this.motionSecondaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_taunts.to_opponent_apron_facing_ring[2]);
      this.motionSecondaryInfo.MovesetTauntToOpponentApronFacingRingside1 = this.motionSecondaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_taunts.to_opponent_apron_facing_ringside[0]);
      this.motionSecondaryInfo.MovesetTauntToOpponentApronFacingRingside2 = this.motionSecondaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_taunts.to_opponent_apron_facing_ringside[1]);
      this.motionSecondaryInfo.MovesetTauntToOpponentApronFacingRingside3 = this.motionSecondaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_taunts.to_opponent_apron_facing_ringside[2]);
      this.motionSecondaryInfo.MovesetTauntWakeUp1 = this.motionSecondaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_taunts.wake_up[0]);
      this.motionSecondaryInfo.MovesetTauntWakeUp2 = this.motionSecondaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_taunts.wake_up[1]);
      this.motionSecondaryInfo.MovesetTauntWakeUp3 = this.motionSecondaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_taunts.wake_up[2]);
      this.motionSecondaryInfo.MovesetTauntWakeUp4 = this.motionSecondaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_taunts.wake_up[3]);
      this.motionSecondaryInfo.MovesetTauntWakeUp5 = this.motionSecondaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_taunts.wake_up[4]);
      this.motionSecondaryInfo.MovesetTauntWakeUp6 = this.motionSecondaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_taunts.wake_up[5]);
      this.motionSecondaryInfo.MovesetTauntWakeUp7 = this.motionSecondaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_taunts.wake_up[6]);
      this.motionSecondaryInfo.MovesetPreMatchWarmup1 = this.motionSecondaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_pre_match.warm_up[0]);
      this.motionSecondaryInfo.MovesetPreMatchWarmup2 = this.motionSecondaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_pre_match.warm_up[1]);
      this.motionSecondaryInfo.MovesetPreMatchWarmup3 = this.motionSecondaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_pre_match.warm_up[2]);
      this.motionSecondaryInfo.MovesetPreMatchWarmup4 = this.motionSecondaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_pre_match.warm_up[3]);
      this.motionSecondaryInfo.MovesetPreMatchWarmup5 = this.motionSecondaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_pre_match.warm_up[4]);
      this.motionSecondaryInfo.MovesetPreMatchTitleMatchChampion = this.motionSecondaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_pre_match.title_match_champion[0]);
      this.motionSecondaryInfo.MovesetPreMatchTitleMatchChallenger1 = this.motionSecondaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_pre_match.title_match_challenger[0]);
      this.motionSecondaryInfo.MovesetPreMatchTitleMatchChallenger2 = this.motionSecondaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_pre_match.title_match_challenger[1]);
      this.motionSecondaryInfo.MovesetWeightDetectionStanding1 = this.motionSecondaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_weight_detection.moveset[0]);
      this.motionSecondaryInfo.MovesetWeightDetectionStanding2 = this.motionSecondaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_weight_detection.moveset[1]);
      this.motionSecondaryInfo.MovesetWeightDetectionRunning1 = this.motionSecondaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_weight_detection.moveset[2]);
      this.motionSecondaryInfo.MovesetWeightDetectionRunning2 = this.motionSecondaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_weight_detection.moveset[3]);
      this.motionSecondaryInfo.MovesetWeightDetectionFrontGrapple1 = this.motionSecondaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_weight_detection.moveset[4]);
      this.motionSecondaryInfo.MovesetWeightDetectionFrontGrapple2 = this.motionSecondaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_weight_detection.moveset[5]);
      this.motionSecondaryInfo.MovesetWeightDetectionRearGrapple1 = this.motionSecondaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_weight_detection.moveset[6]);
      this.motionSecondaryInfo.MovesetWeightDetectionRearGrapple2 = this.motionSecondaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_weight_detection.moveset[7]);
      this.motionSecondaryInfo.MovesetWeightDetectionSupineGrapple1 = this.motionSecondaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_weight_detection.moveset[8]);
      this.motionSecondaryInfo.MovesetWeightDetectionSupineGrapple2 = this.motionSecondaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_weight_detection.moveset[9]);
      this.motionSecondaryInfo.MovesetWeightDetectionSupineGrapple3 = this.motionSecondaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_weight_detection.moveset[10]);
      this.motionSecondaryInfo.MovesetWeightDetectionProneGrapple1 = this.motionSecondaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_weight_detection.moveset[11]);
      this.motionSecondaryInfo.MovesetWeightDetectionProneGrapple2 = this.motionSecondaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_weight_detection.moveset[12]);
      this.motionSecondaryInfo.MovesetWeightDetectionProneGrapple3 = this.motionSecondaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_weight_detection.moveset[13]);
      this.motionSecondaryInfo.MovesetWeightDetectionKneeling1 = this.motionSecondaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_weight_detection.moveset[14]);
      this.motionSecondaryInfo.MovesetWeightDetectionKneeling2 = this.motionSecondaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_weight_detection.moveset[15]);
      this.motionSecondaryInfo.MovesetWeightDetectionSeated1 = this.motionSecondaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_weight_detection.moveset[16]);
      this.motionSecondaryInfo.MovesetWeightDetectionSeated2 = this.motionSecondaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_weight_detection.moveset[17]);
      this.motionSecondaryInfo.MovesetWeightDetectionCorner1 = this.motionSecondaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_weight_detection.moveset[18]);
      this.motionSecondaryInfo.MovesetWeightDetectionCorner2 = this.motionSecondaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_weight_detection.moveset[19]);
      this.motionSecondaryInfo.MovesetWeightDetectionTopRope1 = this.motionSecondaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_weight_detection.moveset[20]);
      this.motionSecondaryInfo.MovesetWeightDetectionTopRope2 = this.motionSecondaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_weight_detection.moveset[21]);
      this.motionSecondaryInfo.MovesetWeightDetectionRopeStunned = this.motionSecondaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_weight_detection.moveset[22]);
      this.motionSecondaryInfo.MovesetWeightDetectionReboundAction = this.motionSecondaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_weight_detection.moveset[23]);
      this.motionSecondaryInfo.MovesetWeightDetectionPullbackAttack = this.motionSecondaryInfo.WrestlerMoves.Get<uint>((object) (uint) Profile.Moveset.moves_weight_detection.moveset[24]);
      this.BasicInfoPropertyGrid.SelectedObject = (object) this.motionPrimaryInfo;
      this.SecondaryMappingPropertyGrid.SelectedObject = (object) this.motionSecondaryInfo;
    }

    public class MotionPrimary : BaseEditor
    {
      private ObservableCollection<JObject> wrestlerMoves;
      private ObservableCollection<JObject> wrestlerCombos;

      public MotionPrimary()
      {
        this.wrestlerMoves = JsonConvert.DeserializeObject<ObservableCollection<JObject>>(JsonConvert.SerializeObject(App.FileData[App.Game]["Moves"]));
        this.wrestlerCombos = JsonConvert.DeserializeObject<ObservableCollection<JObject>>(JsonConvert.SerializeObject(App.FileData[App.Game][nameof (Combos)]));
        this.wrestlerMoves = new ObservableCollection<JObject>((IEnumerable<JObject>) this.wrestlerMoves.OrderBy<JObject, string>((Func<JObject, string>) (w => w.Name)));
      }

      public void SetValue(string category, List<ushort> values)
      {
        PropertyInfo[] properties = this.GetType().GetProperties();
        int index1 = 0;
        for (int index2 = 0; index2 < properties.Length; ++index2)
        {
          if (Attribute.GetCustomAttribute((MemberInfo) properties[index2], typeof (CategoryAttribute)) is CategoryAttribute customAttribute && customAttribute.Category.Equals(category))
          {
            properties[index2].SetValue((object) this, (object) this.wrestlerMoves.Get<uint>((object) (uint) values[index1]));
            ++index1;
          }
        }
      }

      [Category("Standing|Front Light Attack")]
      [DisplayName("1")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetStandingLightAttack1 { get; set; }

      [Category("Standing|Front Light Attack")]
      [DisplayName("2")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetStandingLightAttack2 { get; set; }

      [Category("Standing|Front Light Attack")]
      [DisplayName("3")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetStandingLightAttack3 { get; set; }

      [Category("Standing|Combo Chain")]
      [DisplayName("Towards")]
      [ItemsSourceProperty("Combos")]
      [Important]
      public JObject MovesetStandingComboChain1 { get; set; }

      [Category("Standing|Combo Chain")]
      [DisplayName("Neutral")]
      [ItemsSourceProperty("Combos")]
      [Important]
      public JObject MovesetStandingComboChain2 { get; set; }

      [Category("Standing|Combo Chain")]
      [DisplayName("Away")]
      [ItemsSourceProperty("Combos")]
      [Important]
      public JObject MovesetStandingComboChain3 { get; set; }

      [Category("Standing|Combo Enders - Towards")]
      [DisplayName("1")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetStandingComboEndersTowards1 { get; set; }

      [Category("Standing|Combo Enders - Towards")]
      [DisplayName("2")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetStandingComboEndersTowards2 { get; set; }

      [Category("Standing|Combo Enders - Towards")]
      [DisplayName("3")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetStandingComboEndersTowards3 { get; set; }

      [Category("Standing|Combo Enders - Towards")]
      [DisplayName("4")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetStandingComboEndersTowards4 { get; set; }

      [Category("Standing|Combo Enders - Towards")]
      [DisplayName("5")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetStandingComboEndersTowards5 { get; set; }

      [Category("Standing|Combo Enders - Towards")]
      [DisplayName("6")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetStandingComboEndersTowards6 { get; set; }

      [Category("Standing|Combo Enders - Towards")]
      [DisplayName("7")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetStandingComboEndersTowards7 { get; set; }

      [Category("Standing|Combo Enders - Towards")]
      [DisplayName("8")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetStandingComboEndersTowards8 { get; set; }

      [Category("Standing|Combo Enders - Towards")]
      [DisplayName("9")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetStandingComboEndersTowards9 { get; set; }

      [Category("Standing|Combo Enders - Towards")]
      [DisplayName("10")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetStandingComboEndersTowards10 { get; set; }

      [Category("Standing|Combo Enders - Towards")]
      [DisplayName("11")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetStandingComboEndersTowards11 { get; set; }

      [Category("Standing|Combo Enders - Towards")]
      [DisplayName("12")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetStandingComboEndersTowards12 { get; set; }

      [Category("Standing|Combo Enders - Towards")]
      [DisplayName("13")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetStandingComboEndersTowards13 { get; set; }

      [Category("Standing|Combo Enders - Neutral")]
      [DisplayName("1")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetStandingComboEndersNeutral1 { get; set; }

      [Category("Standing|Combo Enders - Neutral")]
      [DisplayName("2")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetStandingComboEndersNeutral2 { get; set; }

      [Category("Standing|Combo Enders - Neutral")]
      [DisplayName("3")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetStandingComboEndersNeutral3 { get; set; }

      [Category("Standing|Combo Enders - Neutral")]
      [DisplayName("4")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetStandingComboEndersNeutral4 { get; set; }

      [Category("Standing|Combo Enders - Neutral")]
      [DisplayName("5")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetStandingComboEndersNeutral5 { get; set; }

      [Category("Standing|Combo Enders - Neutral")]
      [DisplayName("6")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetStandingComboEndersNeutral6 { get; set; }

      [Category("Standing|Combo Enders - Neutral")]
      [DisplayName("7")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetStandingComboEndersNeutral7 { get; set; }

      [Category("Standing|Combo Enders - Neutral")]
      [DisplayName("8")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetStandingComboEndersNeutral8 { get; set; }

      [Category("Standing|Combo Enders - Neutral")]
      [DisplayName("9")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetStandingComboEndersNeutral9 { get; set; }

      [Category("Standing|Combo Enders - Neutral")]
      [DisplayName("10")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetStandingComboEndersNeutral10 { get; set; }

      [Category("Standing|Combo Enders - Neutral")]
      [DisplayName("11")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetStandingComboEndersNeutral11 { get; set; }

      [Category("Standing|Combo Enders - Neutral")]
      [DisplayName("12")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetStandingComboEndersNeutral12 { get; set; }

      [Category("Standing|Combo Enders - Neutral")]
      [DisplayName("13")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetStandingComboEndersNeutral13 { get; set; }

      [Category("Standing|Combo Enders - Away")]
      [DisplayName("1")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetStandingComboEndersAway1 { get; set; }

      [Category("Standing|Combo Enders - Away")]
      [DisplayName("2")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetStandingComboEndersAway2 { get; set; }

      [Category("Standing|Combo Enders - Away")]
      [DisplayName("3")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetStandingComboEndersAway3 { get; set; }

      [Category("Standing|Combo Enders - Away")]
      [DisplayName("4")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetStandingComboEndersAway4 { get; set; }

      [Category("Standing|Combo Enders - Away")]
      [DisplayName("5")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetStandingComboEndersAway5 { get; set; }

      [Category("Standing|Combo Enders - Away")]
      [DisplayName("6")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetStandingComboEndersAway6 { get; set; }

      [Category("Standing|Combo Enders - Away")]
      [DisplayName("7")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetStandingComboEndersAway7 { get; set; }

      [Category("Standing|Combo Enders - Away")]
      [DisplayName("8")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetStandingComboEndersAway8 { get; set; }

      [Category("Standing|Combo Enders - Away")]
      [DisplayName("9")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetStandingComboEndersAway9 { get; set; }

      [Category("Standing|Combo Enders - Away")]
      [DisplayName("10")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetStandingComboEndersAway10 { get; set; }

      [Category("Standing|Combo Enders - Away")]
      [DisplayName("11")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetStandingComboEndersAway11 { get; set; }

      [Category("Standing|Combo Enders - Away")]
      [DisplayName("12")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetStandingComboEndersAway12 { get; set; }

      [Category("Standing|Combo Enders - Away")]
      [DisplayName("13")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetStandingComboEndersAway13 { get; set; }

      [Category("Standing|Front Heavy Attack")]
      [DisplayName("1")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetStandingHeavyAttack1 { get; set; }

      [Category("Standing|Front Heavy Attack")]
      [DisplayName("2")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetStandingHeavyAttack2 { get; set; }

      [Category("Standing|Front Heavy Attack")]
      [DisplayName("3")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetStandingHeavyAttack3 { get; set; }

      [Category("Standing|Light Grapple")]
      [DisplayName("1")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetStandingLightGrapple1 { get; set; }

      [Category("Standing|Light Grapple")]
      [DisplayName("2")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetStandingLightGrapple2 { get; set; }

      [Category("Standing|Light Grapple")]
      [DisplayName("3")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetStandingLightGrapple3 { get; set; }

      [Category("Standing|Light Grapple")]
      [DisplayName("4")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetStandingLightGrapple4 { get; set; }

      [Category("Standing|Light Grapple")]
      [DisplayName("5")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetStandingLightGrapple5 { get; set; }

      [Category("Standing|Heavy Grapple")]
      [DisplayName("1")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetStandingHeavyGrapple1 { get; set; }

      [Category("Standing|Heavy Grapple")]
      [DisplayName("2")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetStandingHeavyGrapple2 { get; set; }

      [Category("Standing|Heavy Grapple")]
      [DisplayName("3")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetStandingHeavyGrapple3 { get; set; }

      [Category("Standing|Heavy Grapple")]
      [DisplayName("4")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetStandingHeavyGrapple4 { get; set; }

      [Category("Standing|Heavy Grapple")]
      [DisplayName("5")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetStandingHeavyGrapple5 { get; set; }

      [Category("Standing|Front Running Attack")]
      [DisplayName("1")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetStandingFrontRunningAttack1 { get; set; }

      [Category("Standing|Front Running Attack")]
      [DisplayName("2")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetStandingFrontRunningAttack2 { get; set; }

      [Category("Standing|Front Running Attack")]
      [DisplayName("3")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetStandingFrontRunningAttack3 { get; set; }

      [Category("Standing|Rear Heavy Attack")]
      [DisplayName("1")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetStandingRearHeavyAttack { get; set; }

      [Category("Standing|Rear Light Grapple")]
      [DisplayName("1")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetStandingRearLightGrapple1 { get; set; }

      [Category("Standing|Rear Light Grapple")]
      [DisplayName("2")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetStandingRearLightGrapple2 { get; set; }

      [Category("Standing|Rear Light Grapple")]
      [DisplayName("3")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetStandingRearLightGrapple3 { get; set; }

      [Category("Standing|Rear Light Grapple")]
      [DisplayName("4")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetStandingRearLightGrapple4 { get; set; }

      [Category("Standing|Rear Light Grapple")]
      [DisplayName("5")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetStandingRearLightGrapple5 { get; set; }

      [Category("Standing|Rear Heavy Grapple")]
      [DisplayName("1")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetStandingRearHeavyGrapple1 { get; set; }

      [Category("Standing|Rear Heavy Grapple")]
      [DisplayName("2")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetStandingRearHeavyGrapple2 { get; set; }

      [Category("Standing|Rear Heavy Grapple")]
      [DisplayName("3")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetStandingRearHeavyGrapple3 { get; set; }

      [Category("Standing|Rear Heavy Grapple")]
      [DisplayName("4")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetStandingRearHeavyGrapple4 { get; set; }

      [Category("Standing|Rear Heavy Grapple")]
      [DisplayName("5")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetStandingRearHeavyGrapple5 { get; set; }

      [Category("Standing|Rear Running")]
      [DisplayName("1")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetStandingRearRunning1 { get; set; }

      [Category("Standing|Rear Running")]
      [DisplayName("2")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetStandingRearRunning2 { get; set; }

      [Category("Standing|Rear Running")]
      [DisplayName("3")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetStandingRearRunning3 { get; set; }

      [Category("Standing|Carry")]
      [DisplayName("1")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetStandingCarry1 { get; set; }

      [Category("Standing|Carry")]
      [DisplayName("2")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetStandingCarry2 { get; set; }

      [Category("Standing|Carry")]
      [DisplayName("3")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetStandingCarry3 { get; set; }

      [Category("Standing|Carry")]
      [DisplayName("4")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetStandingCarry4 { get; set; }

      [Category("Standing|Foot Catch")]
      [DisplayName("1")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetStandingFootCatch1 { get; set; }

      [Category("Standing|Foot Catch")]
      [DisplayName("2")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetStandingFootCatch2 { get; set; }

      [Category("Standing|Foot Catch")]
      [DisplayName("3")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetStandingFootCatch3 { get; set; }

      [Category("Standing|Foot Catch")]
      [DisplayName("4")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetStandingFootCatch4 { get; set; }

      [Category("Standing|Leverage Pin")]
      [DisplayName("1")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetStandingLeveragePin1 { get; set; }

      [Category("Standing|Leverage Pin")]
      [DisplayName("2")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetStandingLeveragePin2 { get; set; }

      [Category("Ground|Face Up - Upper")]
      [DisplayName("1")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetGroundFaceuUpUppper1 { get; set; }

      [Category("Ground|Face Up - Upper")]
      [DisplayName("2")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetGroundFaceuUpUppper2 { get; set; }

      [Category("Ground|Face Up - Upper")]
      [DisplayName("3")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetGroundFaceuUpUppper3 { get; set; }

      [Category("Ground|Face Up - Side")]
      [DisplayName("1")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetGroundFaceuUpSide1 { get; set; }

      [Category("Ground|Face Up - Side")]
      [DisplayName("2")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetGroundFaceuUpSide2 { get; set; }

      [Category("Ground|Face Up - Side")]
      [DisplayName("3")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetGroundFaceuUpSide3 { get; set; }

      [Category("Ground|Face Up - Lower")]
      [DisplayName("1")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetGroundFaceuUpLower1 { get; set; }

      [Category("Ground|Face Up - Lower")]
      [DisplayName("2")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetGroundFaceuUpLower2 { get; set; }

      [Category("Ground|Face Up - Lower")]
      [DisplayName("3")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetGroundFaceuUpLower3 { get; set; }

      [Category("Ground|Face Up - Running")]
      [DisplayName("1")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetGroundFaceuUpRunning { get; set; }

      [Category("Ground|Face Down - Upper")]
      [DisplayName("1")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetGroundFaceDownUppper1 { get; set; }

      [Category("Ground|Face Down - Upper")]
      [DisplayName("2")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetGroundFaceDownUppper2 { get; set; }

      [Category("Ground|Face Down - Upper")]
      [DisplayName("3")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetGroundFaceDownUppper3 { get; set; }

      [Category("Ground|Face Down - Side")]
      [DisplayName("1")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetGroundFaceDownSide1 { get; set; }

      [Category("Ground|Face Down - Side")]
      [DisplayName("2")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetGroundFaceDownSide2 { get; set; }

      [Category("Ground|Face Down - Side")]
      [DisplayName("3")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetGroundFaceDownSide3 { get; set; }

      [Category("Ground|Face Down - Lower")]
      [DisplayName("1")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetGroundFaceDownLower1 { get; set; }

      [Category("Ground|Face Down - Lower")]
      [DisplayName("2")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetGroundFaceDownLower2 { get; set; }

      [Category("Ground|Face Down - Lower")]
      [DisplayName("3")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetGroundFaceDownLower3 { get; set; }

      [Category("Ground|Kneeling - Front")]
      [DisplayName("1")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetGroundKneelingFront1 { get; set; }

      [Category("Ground|Kneeling - Front")]
      [DisplayName("2")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetGroundKneelingFront2 { get; set; }

      [Category("Ground|Kneeling - Front")]
      [DisplayName("3")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetGroundKneelingFront3 { get; set; }

      [Category("Ground|Kneeling - Front")]
      [DisplayName("4")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetGroundKneelingFront4 { get; set; }

      [Category("Ground|Kneeling - Front")]
      [DisplayName("5")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetGroundKneelingFront5 { get; set; }

      [Category("Ground|Kneeling - Rear")]
      [DisplayName("1")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetGroundKneelingRear1 { get; set; }

      [Category("Ground|Kneeling - Rear")]
      [DisplayName("2")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetGroundKneelingRear2 { get; set; }

      [Category("Ground|Seated - Front")]
      [DisplayName("1")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetGroundSeatedFront1 { get; set; }

      [Category("Ground|Seated - Front")]
      [DisplayName("2")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetGroundSeatedFront2 { get; set; }

      [Category("Ground|Seated - Front")]
      [DisplayName("3")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetGroundSeatedFront3 { get; set; }

      [Category("Ground|Seated - Rear")]
      [DisplayName("1")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetGroundSeatedRear1 { get; set; }

      [Category("Ground|Seated - Rear")]
      [DisplayName("2")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetGroundSeatedRear2 { get; set; }

      [Category("Corner|Leaning - Front")]
      [DisplayName("1")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetCornerLeaningFront1 { get; set; }

      [Category("Corner|Leaning - Front")]
      [DisplayName("2")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetCornerLeaningFront2 { get; set; }

      [Category("Corner|Leaning - Front")]
      [DisplayName("3")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetCornerLeaningFront3 { get; set; }

      [Category("Corner|Leaning - Front")]
      [DisplayName("4")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetCornerLeaningFront4 { get; set; }

      [Category("Corner|Leaning - Front")]
      [DisplayName("5")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetCornerLeaningFront5 { get; set; }

      [Category("Corner|Leaning - Front")]
      [DisplayName("6")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetCornerLeaningFront6 { get; set; }

      [Category("Corner|Leaning - Rear")]
      [DisplayName("1")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetCornerLeaningRear1 { get; set; }

      [Category("Corner|Leaning - Rear")]
      [DisplayName("2")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetCornerLeaningRear2 { get; set; }

      [Category("Corner|Leaning - Rear")]
      [DisplayName("3")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetCornerLeaningRear3 { get; set; }

      [Category("Corner|Leaning - Rear")]
      [DisplayName("4")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetCornerLeaningRear4 { get; set; }

      [Category("Corner|Leaning - Rear")]
      [DisplayName("5")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetCornerLeaningRear5 { get; set; }

      [Category("Corner|Leaning - Rear")]
      [DisplayName("6")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetCornerLeaningRear6 { get; set; }

      [Category("Corner|Top Rope Stunned - Front")]
      [DisplayName("1")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetCornerTopRopeStunnedFront1 { get; set; }

      [Category("Corner|Top Rope Stunned - Front")]
      [DisplayName("2")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetCornerTopRopeStunnedFront2 { get; set; }

      [Category("Corner|Top Rope Stunned - Rear")]
      [DisplayName("1")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetCornerTopRopeStunnedRear1 { get; set; }

      [Category("Corner|Top Rope Stunned - Rear")]
      [DisplayName("2")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetCornerTopRopeStunnedRear2 { get; set; }

      [Category("Corner|Seated")]
      [DisplayName("1")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetCornerSeated1 { get; set; }

      [Category("Corner|Seated")]
      [DisplayName("2")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetCornerSeated2 { get; set; }

      [Category("Corner|Seated")]
      [DisplayName("3")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetCornerSeated3 { get; set; }

      [Category("Corner|Tree of Woe")]
      [DisplayName("1")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetCornerTreeOfWoe1 { get; set; }

      [Category("Corner|Tree of Woe")]
      [DisplayName("2")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetCornerTreeOfWoe2 { get; set; }

      [Category("Rope|Leaning")]
      [DisplayName("1")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetRopeLeaning1 { get; set; }

      [Category("Rope|Leaning")]
      [DisplayName("2")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetRopeLeaning2 { get; set; }

      [Category("Rope|Leaning")]
      [DisplayName("3")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetRopeLeaning3 { get; set; }

      [Category("Rope|Leaning")]
      [DisplayName("4")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetRopeLeaning4 { get; set; }

      [Category("Rope|Leaning")]
      [DisplayName("5")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetRopeLeaning5 { get; set; }

      [Category("Rope|Leaning")]
      [DisplayName("6")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetRopeLeaning6 { get; set; }

      [Category("Rope|Middle Rope")]
      [DisplayName("1")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetRopeMiddleRope1 { get; set; }

      [Category("Irish Whip|Rebound Action")]
      [DisplayName("1")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetIrishWhipReboundAction1 { get; set; }

      [Category("Irish Whip|Rebound Action")]
      [DisplayName("2")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetIrishWhipReboundAction2 { get; set; }

      [Category("Irish Whip|Rebound Attack")]
      [DisplayName("1")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetIrishWhipReboundAttack1 { get; set; }

      [Category("Irish Whip|Rebound Attack")]
      [DisplayName("2")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetIrishWhipReboundAttack2 { get; set; }

      [Category("Irish Whip|Rebound Attack")]
      [DisplayName("3")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetIrishWhipReboundAttack3 { get; set; }

      [Category("Irish Whip|PullBack Attack")]
      [DisplayName("1")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetIrishWhipPullBackAttack1 { get; set; }

      [Category("Irish Whip|PullBack Attack")]
      [DisplayName("2")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetIrishWhipPullBackAttack2 { get; set; }

      [Category("Apron|From Ring - Front")]
      [DisplayName("1")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetApronFromRingFront1 { get; set; }

      [Category("Apron|From Ring - Front")]
      [DisplayName("2")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetApronFromRingFront2 { get; set; }

      [Category("Apron|From Ring - Front")]
      [DisplayName("3")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetApronFromRingFront3 { get; set; }

      [Category("Apron|From Ring - Rear")]
      [DisplayName("1")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetApronFromRingRear1 { get; set; }

      [Category("Apron|From Apron - To Ring")]
      [DisplayName("1")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetApronFromApronToRing1 { get; set; }

      [Category("Apron|From Apron - To Ring")]
      [DisplayName("2")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetApronFromApronToRing2 { get; set; }

      [Category("Apron|From Apron - To Ringside")]
      [DisplayName("1")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetApronFromApronToRingSide1 { get; set; }

      [Category("Apron|From Apron - To Ringside")]
      [DisplayName("2")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetApronFromApronToRingSide2 { get; set; }

      [Category("Signatures|In-Ring")]
      [DisplayName("1")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetSignaturesInRing1 { get; set; }

      [Category("Signatures|In-Ring")]
      [DisplayName("2")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetSignaturesInRing2 { get; set; }

      [Category("Signatures|Ringside")]
      [DisplayName("1")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetSignaturesRingside1 { get; set; }

      [Category("Signatures|Ringside")]
      [DisplayName("2")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetSignaturesRingside2 { get; set; }

      [Category("Finisher|In-Ring")]
      [DisplayName("1")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetFinisherInRing1 { get; set; }

      [Category("Finisher|In-Ring")]
      [DisplayName("2")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetFinisherInRing2 { get; set; }

      [Category("Finisher|Ringside")]
      [DisplayName("1")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetFinisherRingside1 { get; set; }

      [Category("Finisher|Ringside")]
      [DisplayName("2")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetFinisherRingside2 { get; set; }

      [Category("Finisher|Ringside")]
      [DisplayName("3")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetFinisherRingside3 { get; set; }

      [Category("Finisher|Ladder")]
      [DisplayName("1")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetFinisherLadder1 { get; set; }

      [Category("Finisher|Ladder")]
      [DisplayName("2")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetFinisherLadder2 { get; set; }

      [Category("Finisher|Table")]
      [DisplayName("1")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetFinisherTable1 { get; set; }

      [Category("Finisher|Table")]
      [DisplayName("2")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetFinisherTable2 { get; set; }

      [Category("Finisher|Rumble")]
      [DisplayName("1")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetFinisherRumble1 { get; set; }

      [Category("Finisher|Rumble")]
      [DisplayName("2")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetFinisherRumble2 { get; set; }

      [Category("Finisher|Rumble")]
      [DisplayName("3")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetFinisherRumble3 { get; set; }

      [Category("Finisher|Rumble")]
      [DisplayName("4")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetFinisherRumble4 { get; set; }

      [Category("Finisher|1 vs 2")]
      [DisplayName("1")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetFinisher1V2 { get; set; }

      [Category("Finisher|Catching Finisher")]
      [DisplayName("1")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetFinisherCatching { get; set; }

      [Category("Finisher|Ledge Finisher")]
      [DisplayName("1")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetFinisherLedge { get; set; }

      [Category("Finisher|Hell in a Cell Finisher")]
      [DisplayName("1")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetFinisherHellInACell { get; set; }

      [Category("Finisher|Announcer Table Finisher")]
      [DisplayName("1")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetFinisherAnnouncerTable { get; set; }

      [Category("Diving|Top Rope")]
      [DisplayName("1")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetDivingTopRope1 { get; set; }

      [Category("Diving|Top Rope")]
      [DisplayName("2")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetDivingTopRope2 { get; set; }

      [Category("Diving|Top Rope")]
      [DisplayName("3")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetDivingTopRope3 { get; set; }

      [Category("Diving|Top Rope")]
      [DisplayName("4")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetDivingTopRope4 { get; set; }

      [Category("Diving|Middle Rope")]
      [DisplayName("1")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetDivingMiddleRope1 { get; set; }

      [Category("Diving|Middle Rope")]
      [DisplayName("2")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetDivingMiddleRope2 { get; set; }

      [Category("Diving|Ledge")]
      [DisplayName("1")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetDivingLedge1 { get; set; }

      [Category("Diving|Ledge")]
      [DisplayName("2")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetDivingLedge2 { get; set; }

      [Category("Diving|Equipmen Box")]
      [DisplayName("1")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetDivingEquipmentBox1 { get; set; }

      [Category("Diving|Equipment Box")]
      [DisplayName("2")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetDivingEquipmentBox2 { get; set; }

      [Category("Springboard|To Ring - Standing Front")]
      [DisplayName("1")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetSpringboardToRingStandingFront1 { get; set; }

      [Category("Springboard|To Ring - Standing Front")]
      [DisplayName("2")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetSpringboardToRingStandingFront2 { get; set; }

      [Category("Springboard|To Ring - Standing Front")]
      [DisplayName("3")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetSpringboardToRingStandingFront3 { get; set; }

      [Category("Springboard|To Ring - Standing Front")]
      [DisplayName("4")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetSpringboardToRingStandingFront4 { get; set; }

      [Category("Springboard|To Ring - Face Up")]
      [DisplayName("1")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetSpringboardToRingFaceUp1 { get; set; }

      [Category("Springboard|To Ring - Face Up")]
      [DisplayName("2")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetSpringboardToRingFaceUp2 { get; set; }

      [Category("Springboard|To Ring - Face Up")]
      [DisplayName("3")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetSpringboardToRingFaceUp3 { get; set; }

      [Category("Springboard|To Ring - Face Up")]
      [DisplayName("4")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetSpringboardToRingFaceUp4 { get; set; }

      [Category("Springboard|To Ringside - Standing Front")]
      [DisplayName("1")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetSpringboardToRingsideStandingFront1 { get; set; }

      [Category("Springboard|To Ringside - Standing Front")]
      [DisplayName("2")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetSpringboardToRingsideStandingFront2 { get; set; }

      [Category("Springboard|To Ringside - Standing Front")]
      [DisplayName("3")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetSpringboardToRingsideStandingFront3 { get; set; }

      [Category("Springboard|To Ringside - Face Up")]
      [DisplayName("1")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetSpringboardToRingsideFaceUp1 { get; set; }

      [Category("Springboard|To Ringside - Face Up")]
      [DisplayName("2")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetSpringboardToRingsideFaceUp2 { get; set; }

      [Category("Springboard|To Ringside - Face Up")]
      [DisplayName("3")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetSpringboardToRingsideFaceUp3 { get; set; }

      [Browsable(false)]
      public ObservableCollection<JObject> WrestlerMoves => this.wrestlerMoves;

      [Browsable(false)]
      public ObservableCollection<JObject> Combos => this.wrestlerCombos;
    }

    public class MotionSecondary : BaseEditor
    {
      private ObservableCollection<JObject> wrestlerMoves;
      private ObservableCollection<JObject> wrestlerMovesClimbRear;
      private ObservableCollection<JObject> wrestlerMovesClimbFront;

      public MotionSecondary()
      {
        this.wrestlerMoves = JsonConvert.DeserializeObject<ObservableCollection<JObject>>(JsonConvert.SerializeObject(App.FileData[App.Game]["Moves"]));
        this.wrestlerMovesClimbRear = JsonConvert.DeserializeObject<ObservableCollection<JObject>>(JsonConvert.SerializeObject(App.FileData[App.Game]["Moves_Climb_Rear"]));
        this.wrestlerMovesClimbFront = JsonConvert.DeserializeObject<ObservableCollection<JObject>>(JsonConvert.SerializeObject(App.FileData[App.Game]["Moves_Climb_Front"]));
        this.wrestlerMoves = new ObservableCollection<JObject>((IEnumerable<JObject>) this.wrestlerMoves.OrderBy<JObject, string>((Func<JObject, string>) (w => w.Name)));
      }

      [Category("Holds|Submission")]
      [DisplayName("1")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetHoldsSubmission1 { get; set; }

      [Category("Holds|Submission")]
      [DisplayName("2")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetHoldsSubmission2 { get; set; }

      [Category("Holds|Submission")]
      [DisplayName("3")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetHoldsSubmission3 { get; set; }

      [Category("Holds|Submission")]
      [DisplayName("4")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetHoldsSubmission4 { get; set; }

      [Category("Holds|Submission")]
      [DisplayName("5")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetHoldsSubmission5 { get; set; }

      [Category("Match Type|Table - Table Attack")]
      [DisplayName("1")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetMatchTypeTableTableAttack { get; set; }

      [Category("Match Type|Table - Table in Corner Attack")]
      [DisplayName("1")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetMatchTypeTableInCornerAttack { get; set; }

      [Category("Match Type|Table - Table Corner Attack")]
      [DisplayName("1")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetMatchTypeTableCornerAttack { get; set; }

      [Category("Match Type|Table - Table Attack (Opponent on Ropes)")]
      [DisplayName("1")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetMatchTypeTableAttackOpponentOnRopes { get; set; }

      [Category("Match Type|Table - Table Attack (Opponent on Apron)")]
      [DisplayName("1")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetMatchTypeTableAttackOpponentOnApron { get; set; }

      [Category("Match Type|Ladder - Light Attack")]
      [DisplayName("1")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetMatchTypeLadderLightAttack { get; set; }

      [Category("Match Type|Ladder - Heavy Attack")]
      [DisplayName("1")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetMatchTypeLadderHeavyAttack { get; set; }

      [Category("Match Type|Ladder - Grapple")]
      [DisplayName("1")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetMatchTypeLadderGrapple { get; set; }

      [Category("Match Type|Tag Team - Normal Tag Attacks")]
      [DisplayName("1")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetMatchTypeTagTeamNormalTagAttacks1 { get; set; }

      [Category("Match Type|Tag Team - Normal Tag Attacks")]
      [DisplayName("2")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetMatchTypeTagTeamNormalTagAttacks2 { get; set; }

      [Category("Match Type|Tag Team - Normal Tag Attacks")]
      [DisplayName("3")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetMatchTypeTagTeamNormalTagAttacks3 { get; set; }

      [Category("Match Type|Tag Team - Normal Tag Attacks")]
      [DisplayName("4")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetMatchTypeTagTeamNormalTagAttacks4 { get; set; }

      [Category("Match Type|Tag Team - Mixed Tag Attacks")]
      [DisplayName("1")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetMatchTypeMixedTagNormalTagAttacks1 { get; set; }

      [Category("Match Type|Tag Team - Mixed Tag Attacks")]
      [DisplayName("2")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetMatchTypeMixedTagNormalTagAttacks2 { get; set; }

      [Category("Match Type|Tag Team - Mixed Tag Attacks")]
      [DisplayName("3")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetMatchTypeMixedTagNormalTagAttacks3 { get; set; }

      [Category("Match Type|Tag Team - Mixed Tag Attacks")]
      [DisplayName("4")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetMatchTypeMixedTagNormalTagAttacks4 { get; set; }

      [Category("Match Type|Tag Team - Mixed Tag Finishers")]
      [DisplayName("1")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetMatchTypeMixedTagNormalTagFinishers1 { get; set; }

      [Category("Match Type|Tag Team - Mixed Tag Finishers")]
      [DisplayName("2")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetMatchTypeMixedTagNormalTagFinishers2 { get; set; }

      [Category("Match Type|Tag Team - Double Team")]
      [DisplayName("1")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetMatchTypeTagteamDoubleTeam1 { get; set; }

      [Category("Match Type|Tag Team - Double Team")]
      [DisplayName("2")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetMatchTypeTagteamDoubleTeam2 { get; set; }

      [Category("Match Type|Tag Team - Double Team")]
      [DisplayName("3")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetMatchTypeTagteamDoubleTeam3 { get; set; }

      [Category("Match Type|Tag Team - Double Team")]
      [DisplayName("4")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetMatchTypeTagteamDoubleTeam4 { get; set; }

      [Category("Match Type|Hell in a Cell")]
      [DisplayName("Ledge Throw")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetMatchTypeHellInACell1 { get; set; }

      [Category("Other Attacks|Barricade")]
      [DisplayName("1")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetOtherAttacksBarricade1 { get; set; }

      [Category("Other Attacks|Barricade")]
      [DisplayName("2")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetOtherAttacksBarricade2 { get; set; }

      [Category("Other Attacks|Comeback")]
      [DisplayName("1")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetOtherAttacksComeback { get; set; }

      [Category("Pre-Match|Warmup")]
      [DisplayName("1")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetPreMatchWarmup1 { get; set; }

      [Category("Pre-Match|Warmup")]
      [DisplayName("2")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetPreMatchWarmup2 { get; set; }

      [Category("Pre-Match|Warmup")]
      [DisplayName("3")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetPreMatchWarmup3 { get; set; }

      [Category("Pre-Match|Warmup")]
      [DisplayName("4")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetPreMatchWarmup4 { get; set; }

      [Category("Pre-Match|Warmup")]
      [DisplayName("5")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetPreMatchWarmup5 { get; set; }

      [Category("Pre-Match|Title Match (Champion)")]
      [DisplayName("1")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetPreMatchTitleMatchChampion { get; set; }

      [Category("Pre-Match|Title Match (Challenger)")]
      [DisplayName("1")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetPreMatchTitleMatchChallenger1 { get; set; }

      [Category("Pre-Match|Title Match (Challenger)")]
      [DisplayName("2")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetPreMatchTitleMatchChallenger2 { get; set; }

      [Category("Movement|Enter Ring")]
      [DisplayName("1")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetMovementEnterRing1 { get; set; }

      [Category("Movement|Enter Ring")]
      [DisplayName("2")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetMovementEnterRing2 { get; set; }

      [Category("Movement|Exit Ring")]
      [DisplayName("1")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetMovementExitRing1 { get; set; }

      [Category("Movement|Exit Ring")]
      [DisplayName("2")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetMovementExitRing2 { get; set; }

      [Category("Movement|Climb Top Rope")]
      [DisplayName("1")]
      [ItemsSourceProperty("WrestlerMovesClimbFront")]
      [Important]
      public JObject MovesetMovementClimbTopRope1 { get; set; }

      [Category("Movement|Climb Top Rope")]
      [DisplayName("2")]
      [ItemsSourceProperty("WrestlerMovesClimbRear")]
      [Important]
      public JObject MovesetMovementClimbTopRope2 { get; set; }

      [Category("Movement|Recovery")]
      [DisplayName("1")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetMovementRecovery { get; set; }

      [Category("Taunt|To Crowd - Standing")]
      [DisplayName("1")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetTauntToCrowdStanding1 { get; set; }

      [Category("Taunt|To Crowd - Standing")]
      [DisplayName("2")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetTauntToCrowdStanding2 { get; set; }

      [Category("Taunt|To Crowd - Standing")]
      [DisplayName("3")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetTauntToCrowdStanding3 { get; set; }

      [Category("Taunt|To Crowd - Standing")]
      [DisplayName("4")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetTauntToCrowdStanding4 { get; set; }

      [Category("Taunt|To Crowd - Standing")]
      [DisplayName("5")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetTauntToCrowdStanding5 { get; set; }

      [Category("Taunt|To Crowd - Corner")]
      [DisplayName("1")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetTauntToCrowdCorner1 { get; set; }

      [Category("Taunt|To Crowd - Corner")]
      [DisplayName("2")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetTauntToCrowdCorner2 { get; set; }

      [Category("Taunt|To Crowd - Corner")]
      [DisplayName("3")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetTauntToCrowdCorner3 { get; set; }

      [Category("Taunt|To Crowd - Top Rope Facing Ring")]
      [DisplayName("1")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetTauntToCrowdTopRopeFacingRing1 { get; set; }

      [Category("Taunt|To Crowd - Top Rope Facing Ring")]
      [DisplayName("2")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetTauntToCrowdTopRopeFacingRing2 { get; set; }

      [Category("Taunt|To Crowd - Top Rope Facing Ring")]
      [DisplayName("3")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetTauntToCrowdTopRopeFacingRing3 { get; set; }

      [Category("Taunt|To Crowd - Middle Rope")]
      [DisplayName("1")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetTauntToCrowdMiddleRope1 { get; set; }

      [Category("Taunt|To Crowd - Middle Rope")]
      [DisplayName("2")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetTauntToCrowdMiddleRope2 { get; set; }

      [Category("Taunt|To Crowd - Middle Rope")]
      [DisplayName("3")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetTauntToCrowdMiddleRope3 { get; set; }

      [Category("Taunt|To Crowd - Apron Facing Ring")]
      [DisplayName("1")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetTauntToCrowdApronFacingRing1 { get; set; }

      [Category("Taunt|To Crowd - Apron Facing Ring")]
      [DisplayName("2")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetTauntToCrowdApronFacingRing2 { get; set; }

      [Category("Taunt|To Crowd - Apron Facing Ring")]
      [DisplayName("3")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetTauntToCrowdApronFacingRing3 { get; set; }

      [Category("Taunt|To Crowd - Apron Facing Ringside")]
      [DisplayName("1")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetTauntToCrowdApronFacingRingside1 { get; set; }

      [Category("Taunt|To Crowd - Apron Facing Ringside")]
      [DisplayName("2")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetTauntToCrowdApronFacingRingside2 { get; set; }

      [Category("Taunt|To Crowd - Apron Facing Ringside")]
      [DisplayName("3")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetTauntToCrowdApronFacingRingside3 { get; set; }

      [Category("Taunt|To Opponent - Standing")]
      [DisplayName("1")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetTauntToOpponentStanding1 { get; set; }

      [Category("Taunt|To Opponent - Standing")]
      [DisplayName("2")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetTauntToOpponentStanding2 { get; set; }

      [Category("Taunt|To Opponent - Standing")]
      [DisplayName("3")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetTauntToOpponentStanding3 { get; set; }

      [Category("Taunt|To Opponent - Standing")]
      [DisplayName("4")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetTauntToOpponentStanding4 { get; set; }

      [Category("Taunt|To Opponent - Standing")]
      [DisplayName("5")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetTauntToOpponentStanding5 { get; set; }

      [Category("Taunt|To Opponent - Ground")]
      [DisplayName("1")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetTauntToOpponentStandingToGround1 { get; set; }

      [Category("Taunt|To Opponent - Ground")]
      [DisplayName("2")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetTauntToOpponentStandingToGround2 { get; set; }

      [Category("Taunt|To Opponent - Ground")]
      [DisplayName("3")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetTauntToOpponentStandingToGround3 { get; set; }

      [Category("Taunt|To Opponent - Ground")]
      [DisplayName("4")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetTauntToOpponentStandingToGround4 { get; set; }

      [Category("Taunt|To Opponent - Ground")]
      [DisplayName("5")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetTauntToOpponentStandingToGround5 { get; set; }

      [Category("Taunt|To Opponent - Corner")]
      [DisplayName("1")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetTauntToOpponentCorner1 { get; set; }

      [Category("Taunt|To Opponent - Corner")]
      [DisplayName("2")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetTauntToOpponentCorner2 { get; set; }

      [Category("Taunt|To Opponent - Corner")]
      [DisplayName("3")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetTauntToOpponentCorner3 { get; set; }

      [Category("Taunt|To Opponent - Top Rope Facing Ring")]
      [DisplayName("1")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetTauntToOpponentTopRopeFacingRing1 { get; set; }

      [Category("Taunt|To Opponent - Top Rope Facing Ring")]
      [DisplayName("2")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetTauntToOpponentTopRopeFacingRing2 { get; set; }

      [Category("Taunt|To Opponent - Top Rope Facing Ring")]
      [DisplayName("3")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetTauntToOpponentTopRopeFacingRing3 { get; set; }

      [Category("Taunt|To Opponent - Middle Rope")]
      [DisplayName("1")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetTauntToOpponentMiddleRope1 { get; set; }

      [Category("Taunt|To Opponent - Middle Rope")]
      [DisplayName("2")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetTauntToOpponentMiddleRope2 { get; set; }

      [Category("Taunt|To Opponent - Middle Rope")]
      [DisplayName("3")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetTauntToOpponentMiddleRope3 { get; set; }

      [Category("Taunt|To Opponent - Apron Facing Ring")]
      [DisplayName("1")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetTauntToOpponentApronFacingRing1 { get; set; }

      [Category("Taunt|To Opponent - Apron Facing Ring")]
      [DisplayName("2")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetTauntToOpponentApronFacingRing2 { get; set; }

      [Category("Taunt|To Opponent - Apron Facing Ring")]
      [DisplayName("3")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetTauntToOpponentApronFacingRing3 { get; set; }

      [Category("Taunt|To Opponent - Apron Facing Ringside")]
      [DisplayName("1")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetTauntToOpponentApronFacingRingside1 { get; set; }

      [Category("Taunt|To Opponent - Apron Facing Ringside")]
      [DisplayName("2")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetTauntToOpponentApronFacingRingside2 { get; set; }

      [Category("Taunt|To Opponent - Apron Facing Ringside")]
      [DisplayName("3")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetTauntToOpponentApronFacingRingside3 { get; set; }

      [Category("Taunt|Wake Up")]
      [DisplayName("1")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetTauntWakeUp1 { get; set; }

      [Category("Taunt|Wake Up")]
      [DisplayName("2")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetTauntWakeUp2 { get; set; }

      [Category("Taunt|Wake Up")]
      [DisplayName("3")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetTauntWakeUp3 { get; set; }

      [Category("Taunt|Wake Up")]
      [DisplayName("4")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetTauntWakeUp4 { get; set; }

      [Category("Taunt|Wake Up")]
      [DisplayName("5")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetTauntWakeUp5 { get; set; }

      [Category("Taunt|Wake Up")]
      [DisplayName("6")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetTauntWakeUp6 { get; set; }

      [Category("Taunt|Wake Up")]
      [DisplayName("7")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetTauntWakeUp7 { get; set; }

      [Category("Weight Detection|Standing")]
      [DisplayName("1")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetWeightDetectionStanding1 { get; set; }

      [Category("Weight Detection|Standing")]
      [DisplayName("2")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetWeightDetectionStanding2 { get; set; }

      [Category("Weight Detection|Running")]
      [DisplayName("1")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetWeightDetectionRunning1 { get; set; }

      [Category("Weight Detection|Running")]
      [DisplayName("2")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetWeightDetectionRunning2 { get; set; }

      [Category("Weight Detection|Front Grapple")]
      [DisplayName("1")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetWeightDetectionFrontGrapple1 { get; set; }

      [Category("Weight Detection|Front Grapple")]
      [DisplayName("2")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetWeightDetectionFrontGrapple2 { get; set; }

      [Category("Weight Detection|Rear Grapple")]
      [DisplayName("1")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetWeightDetectionRearGrapple1 { get; set; }

      [Category("Weight Detection|Rear Grapple")]
      [DisplayName("2")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetWeightDetectionRearGrapple2 { get; set; }

      [Category("Weight Detection|Supine Grapple")]
      [DisplayName("1")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetWeightDetectionSupineGrapple1 { get; set; }

      [Category("Weight Detection|Supine Grapple")]
      [DisplayName("2")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetWeightDetectionSupineGrapple2 { get; set; }

      [Category("Weight Detection|Supine Grapple")]
      [DisplayName("3")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetWeightDetectionSupineGrapple3 { get; set; }

      [Category("Weight Detection|Prone Grapple")]
      [DisplayName("1")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetWeightDetectionProneGrapple1 { get; set; }

      [Category("Weight Detection|Prone Grapple")]
      [DisplayName("2")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetWeightDetectionProneGrapple2 { get; set; }

      [Category("Weight Detection|Prone Grapple")]
      [DisplayName("3")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetWeightDetectionProneGrapple3 { get; set; }

      [Category("Weight Detection|Kneeling")]
      [DisplayName("1")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetWeightDetectionKneeling1 { get; set; }

      [Category("Weight Detection|Kneeling")]
      [DisplayName("2")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetWeightDetectionKneeling2 { get; set; }

      [Category("Weight Detection|Seated")]
      [DisplayName("1")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetWeightDetectionSeated1 { get; set; }

      [Category("Weight Detection|Seated")]
      [DisplayName("2")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetWeightDetectionSeated2 { get; set; }

      [Category("Weight Detection|Corner")]
      [DisplayName("1")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetWeightDetectionCorner1 { get; set; }

      [Category("Weight Detection|Corner")]
      [DisplayName("2")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetWeightDetectionCorner2 { get; set; }

      [Category("Weight Detection|Top Rope")]
      [DisplayName("1")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetWeightDetectionTopRope1 { get; set; }

      [Category("Weight Detection|Top Rope")]
      [DisplayName("2")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetWeightDetectionTopRope2 { get; set; }

      [Category("Weight Detection|Rope Stunned")]
      [DisplayName("1")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetWeightDetectionRopeStunned { get; set; }

      [Category("Weight Detection|Rebound Action")]
      [DisplayName("1")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetWeightDetectionReboundAction { get; set; }

      [Category("Weight Detection|Pullback Attack")]
      [DisplayName("1")]
      [ItemsSourceProperty("WrestlerMoves")]
      [Important]
      public JObject MovesetWeightDetectionPullbackAttack { get; set; }

      [Browsable(false)]
      public ObservableCollection<JObject> WrestlerMoves => this.wrestlerMoves;

      [Browsable(false)]
      public ObservableCollection<JObject> WrestlerMovesClimbFront => this.wrestlerMovesClimbFront;

      [Browsable(false)]
      public ObservableCollection<JObject> WrestlerMovesClimbRear => this.wrestlerMovesClimbRear;
    }
  }
}
