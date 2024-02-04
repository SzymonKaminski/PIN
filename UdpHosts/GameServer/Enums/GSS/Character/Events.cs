﻿using System.Diagnostics.CodeAnalysis;

namespace GameServer.Enums.GSS.Character;

[SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1602:EnumerationItemsMustBeDocumented", Justification = "https://github.com/themeldingwars/Documentation/wiki/Messages-Character#events")]
internal enum Events
{
    PartialUpdate = 1, // Delete
    KeyFrame = 4, // Delete
    MarketRequestComplete = 83,
    ReceiveWeaponTweaks = 84,
    TookDebugWeaponHitPublic = 85,
    TookDebugWeaponHit = 86,
    DebugWeaponStats = 87,
    RewardInfo = 88,
    ProgressionXpRefresh = 89,
    ReceivedDeferredXP = 90,
    PublicCombatLog = 91,
    PrivateCombatLog = 92,
    AnimationUpdated = 93,
    RaiaNPCDebugging = 94,
    WeaponProjectileFired = 95,
    AbilityProjectileFired = 96,
    ProjectileHitReported = 97,
    Stumble = 98,
    QuickChat = 99,
    ProximityTextChat = 100,
    JumpActioned = 101,
    JumpRolled = 102,
    Respawned = 103,
    CalledForHelp = 104,
    TookHit = 105,
    AlmostHit = 106,
    DealtHit = 107,
    Killed = 108,
    WarnLockTargeted = 109,
    CurrentPoseUpdate = 110,
    ConfirmedPoseUpdate = 111,
    PublicDebugMovementUpdate = 112,
    ForcedMovement = 113,
    ForcedMovementCancelled = 114,
    GrappleClimbPermission = 115,
    AbilityActivated = 116,
    AbilityFailed = 117,
    AbilityCooldowns = 118,
    NPCInteraction = 119,
    OpenMovieDialog = 120,
    PrivateDialog = 121,
    PublicDialog = 122,
    AddOrUpdateInteractives = 123,
    RemoveInteractives = 124,
    InteractionProgressed = 125,
    InteractionCompleted = 126,
    InteractedWithProgressed = 127,
    InteractedWithCompleted = 128,
    InventoryUpdate = 129,
    UnlocksUpdate = 130,
    WorkbenchUpdate = 131,
    SimulateLootPickup = 132,
    DisplayRewards = 133,
    TrackerEvent = 134,
    TrackerPulse = 135,
    PriorityTargetSet = 136,
    ResourceNodeCompletedEvent = 137,
    FoundResourceAreas = 138,
    GeographicalReportResponse = 139,
    ResourceLocationInfosRespons = 140,
    UiNamedVariableUpdate = 141,
    DuelNotification = 142,
    NewUiQuery = 143,
    UiQueryCancelled = 144,
    FetchQueueInfo_Response = 145,
    MatchQueueResponse = 146,
    ChallengeCreateResponse = 147,
    CharacterLoaded = 148,
    VendorTokenMachineResponse = 149,
    SalvageResponse = 150,
    RepairResponse = 151,
    SlotModuleResponse = 152,
    UnslotAllModulesResponse = 153,
    SlotGearResponse = 154,
    SlotVisualResponse = 155,
    SlotVisualMultiResponse = 156,
    TinkeringPlanResponse = 157,
    UnlockContentSuccess = 158,
    PushBehavior = 159,
    PopBehavior = 160,
    SelfReviveResponse = 161,
    ApplyCameraShake = 162,
    ReceivedWebUIMessage = 163,
    ExitingAttachment = 164,
    LootDistributionStartEvt = 165,
    LootDistributionUpdateEvt = 166,
    LootDistributionCompletionEvt = 167,
    ForcedWeaponSwap = 168,
    ChatPartyUpdate = 169,
    BagInventoryUpdate = 170,
    LevelUpEvent = 171,
    FactionReputationUpdate = 172,
    TutorialStateInitializeEvt = 173,
    TutorialStateUpdateEvt = 174,
    DailyLoginRewardsUpdateEvt = 175,
    Fabrication_FetchAllInstances_Response = 176,
    Fabrication_FetchAllRecipes_Response = 177,
    Fabrication_FetchInstance_Response = 178,
    Fabrication_Start_Response = 179,
    Fabrication_ApplyAction_Response = 180,
    Fabrication_GenerateResult_Response = 181,
    Fabrication_Finalize_Response = 182,
    Fabrication_Claim_Response = 183,
    PostStatEvent = 184,
    BountyRerollProductInfoUpdateEvt = 185,
    EliteLevels_InitAllFrames = 186,
    EliteLevels_InitFrame = 187,
    EliteLevels_UpgradesChanged = 188,
    EliteLevels_UnusedPointsChanged = 189,
    EliteLevels_IncreaseXp = 190,
    EliteLevels_IncreaseLevel = 191,
    EliteLevels_RerollCompleted = 192,
    EliteLevels_Initialized_Info = 193,
    FriendsListChanged = 194,
    FriendsListResponse = 195,
    PerkRespecTimerReset = 196
}