using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Actions;

namespace PrisonerInfluenceGainMod.Patches
{
    [HarmonyPatch(typeof(GainKingdomInfluenceAction), "ApplyForLeavingTroopToGarrison")]
    class GainKingdomInfluenceActionPatch
    {
        public static void DoPatching()
        {
            var harmony = new Harmony("mod.bannerlord.prisonerinfluencegain");
            harmony.PatchAll();
        }

        static void Prefix(Hero hero, ref float value)
        {
            value *= PrisonerInfluenceGainModSubModule.Multiplier;
        }
    }
}
