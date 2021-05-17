using Newtonsoft.Json;
using PrisonerInfluenceGainMod.Patches;
using System.IO;
using TaleWorlds.MountAndBlade;

namespace PrisonerInfluenceGainMod
{
	public class PrisonerInfluenceGainModSubModule : MBSubModuleBase
	{
		public static float Multiplier { get; set; }

		protected override void OnBeforeInitialModuleScreenSetAsRoot()
		{
			using (StreamReader file = File.OpenText("../../Modules/PrisonerInfluenceGainMod/bin/Win64_Shipping_Client/settings.json"))
			{
				var definition = new { Multiplier = 1 };
				var settings = JsonConvert.DeserializeAnonymousType(file.ReadToEnd(), definition);
				PrisonerInfluenceGainModSubModule.Multiplier = settings.Multiplier;
			}
			
			GainKingdomInfluenceActionPatch.DoPatching();
        }
	}
}
