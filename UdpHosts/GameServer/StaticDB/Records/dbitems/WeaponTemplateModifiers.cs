namespace GameServer.Data.SDB.Records.dbitems;
public record class WeaponTemplateModifiers
{
    // public Vec3 FpVisualOrient { get; set; }
    // public Vec3 FpVisualOffset { get; set; }
    // public Vec2 AiSwayMin { get; set; }
    // public Vec2 AiSwayMax { get; set; }
    public float SlidePerBurstMult { get; set; }
    public float RunMinspreadAdd { get; set; }
    public float RunPerriseMult { get; set; }
    public int EquipExitMs { get; set; }
    public float MinSpreadFrac { get; set; }
    public float JumpRiseRampMult { get; set; }
    public float MaxSpreadMult { get; set; }
    public float MinDamageMult { get; set; }
    public float HeadshotMult { get; set; }
    public int MsSpreadReturnDelay { get; set; }
    public float RunSlideRampMult { get; set; }
    public float Agility { get; set; }
    public float SpreadPerBurstMult { get; set; }
    public float OvermaxRisePermanentFracMult { get; set; }
    public int MinDamage { get; set; }
    public float HitshakeMult { get; set; }
    public int MsPerBurst { get; set; }
    public int MsChargeupMax { get; set; }
    public int JitterRampTime { get; set; }
    public float MaxSlideMult { get; set; }
    public float SpreadRampExponent { get; set; }
    public float RunPerslideMult { get; set; }
    public float MinSpreadMult { get; set; }
    public float OvermaxSlidePermanentFracMult { get; set; }
    public int DamagePerRound { get; set; }
    public float MinAmmoPerBurstMult { get; set; }
    public float MaxAmmoMult { get; set; }
    public float MinSlideFrac { get; set; }
    public uint? DefaultUnderbarrelId { get; set; }
    public float RisePerBurst { get; set; }
    public float NoSpreadChanceMult { get; set; }
    public int EquipEnterMs { get; set; }
    public float AmmoPerBurstMult { get; set; }
    public uint? MeleeAbilityId { get; set; }
    public uint? AttackAbilityId { get; set; }
    public int AiSwayHperiod { get; set; }
    public float ReloadPenaltyMult { get; set; }
    public uint WeaponId { get; set; }
    public float MinSpread { get; set; }
    public float JumpSlideRampMult { get; set; }
    public float SlidePerBurst { get; set; }
    public float JumpMinspreadAdd { get; set; }
    public float MaxRiseMult { get; set; }
    public float MsPerBurstMult { get; set; }
    public uint? OverchargeAbility { get; set; }
    public int MsOverchargeDelay { get; set; }
    public float MinSlidePerBurst { get; set; }
    public int MsAgilityReturn { get; set; }
    public uint? BurstAbilityId { get; set; }
    public float RisePerBurstMult { get; set; }
    public float TargetingRangeMult { get; set; }
    public float MaxJitter { get; set; }
    public int MsChargeup { get; set; }
    public int ReloadTime { get; set; }
    public float MaxRise { get; set; }
    public float ReloadTimeMult { get; set; }
    public float CamRecoilBase { get; set; }
    public uint? ReloadAbility { get; set; }
    public float MinRisePerBurst { get; set; }
    public float MsChargeupMaxMult { get; set; }
    public int MsReturn { get; set; }
    public float MinRoundsPerBurstMult { get; set; }
    public float RangeMult { get; set; }
    public float Range { get; set; }
    public float OvermaxRisePermanentFrac { get; set; }
    public float MaleScaleAdd { get; set; }
    public float MinSlidePerBurstMult { get; set; }
    public float MinRiseFrac { get; set; }
    public float RisePermanentFracMult { get; set; }
    public float InitialJitter { get; set; }
    public float JumpPerslideMult { get; set; }
    public float RoundsPerBurstMult { get; set; }
    public int MsBurstDuration { get; set; }
    public float ClipRegenMsMult { get; set; }
    public float HeadshotMultMult { get; set; }
    public int RiseRampTime { get; set; }
    public float DamagePerRoundMult { get; set; }
    public int MsChargeupMin { get; set; }
    public int ReloadPenalty { get; set; }
    public float TargetingRange { get; set; }
    public float CamRecoilShake { get; set; }
    public int MsAgilityReturnDelay { get; set; }
    public int ClipRegenMs { get; set; }
    public int MsSpreadReturn { get; set; }
    public float MaxSlide { get; set; }
    public int AiSwayVperiod { get; set; }
    public float OvermaxSlidePermanentFrac { get; set; }
    public int CamRecoilRecoverMs { get; set; }
    public float SpreadPerBurst { get; set; }
    public float AimassistCosMult { get; set; }
    public float BaseClipSizeMult { get; set; }
    public float SlideRampExponent { get; set; }
    public int SpreadRampTime { get; set; }
    public float StartingSpreadMult { get; set; }
    public float RunRiseRampMult { get; set; }
    public float SlidePermanentFrac { get; set; }
    public float StartingSpread { get; set; }
    public float RiseRampExponent { get; set; }
    public float FpVisualFov { get; set; }
    public float MsChargeupMinMult { get; set; }
    public uint? ClipEmptyAbility { get; set; }
    public int MsRiseReturnDelay { get; set; }
    public float MaxSpread { get; set; }
    public float MinRisePerBurstMult { get; set; }
    public int WeaponFlags { get; set; }
    public float AimassistCos { get; set; }
    public uint? DefaultScopeId { get; set; }
    public int AiSwayConvergenceMs { get; set; }
    public float NoSpreadChance { get; set; }
    public float JumpPerriseMult { get; set; }
    public float SlidePermanentFracMult { get; set; }
    public float FemaleScaleAdd { get; set; }
    public int SlideRampTime { get; set; }
    public float MsChargeupMult { get; set; }
    public float RisePermanentFrac { get; set; }
    public short BaseClipSize { get; set; }
    public ushort? DefaultAmmoId { get; set; }
    public short AnimArmedPriority { get; set; }
    public short MaxAmmo { get; set; }
    public sbyte AnimArmedId { get; set; }
    public sbyte AnimFireType { get; set; }
    public sbyte AnimReloadType { get; set; }
    public sbyte MinRoundsPerBurst { get; set; }
    public sbyte RoundsPerBurst { get; set; }
    public sbyte RoundReload { get; set; }
    public sbyte BurstbonusPerTarget { get; set; }
    public sbyte MinAmmoPerBurst { get; set; }
    public sbyte AnimChargeType { get; set; }
    public byte? UiReticleName { get; set; }
    public sbyte? SlotIndex { get; set; }
    public sbyte MaxTargets { get; set; }
    public sbyte FireType { get; set; }
    public sbyte AmmoPerBurst { get; set; }
}