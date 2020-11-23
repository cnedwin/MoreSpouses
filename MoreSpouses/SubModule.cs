using HarmonyLib;
using System;
using TaleWorlds.Core;
using TaleWorlds.Library;
using TaleWorlds.Localization;
using TaleWorlds.MountAndBlade;
using SandBox.GauntletUI;
using TaleWorlds.CampaignSystem;
using System.IO;
using MoreSpouses;
using SueMoreSpouses.behavior;


namespace SueMoreSpouses
{
    public class SubModule : MBSubModuleBase
    {

        protected override void OnSubModuleLoad()
        {
            Harmony harmony = new Harmony("mod.sue.morespouses");
            harmony.PatchAll();
        }

        protected override void OnGameStart(Game game, IGameStarter gameStarterObject)
        {
            base.OnGameStart(game, gameStarterObject);

            LoadXMLFiles(gameStarterObject as CampaignGameStarter);

        }
        private void LoadXMLFiles(CampaignGameStarter gameInitializer)
        {
            // Load our additional strings
            gameInitializer.LoadGameTexts(BasePath.Name + "Modules/SueMoreSpouses/ModuleData/sue_chat_prisoner.xml");
            gameInitializer.AddBehavior(new SpouseFromPrisonerBehavior());
            gameInitializer.AddBehavior(new SpousesStatsBehavior());
            gameInitializer.AddBehavior(new SpouseClanLeaderFixBehavior());
            gameInitializer.AddBehavior(new SpousesSneakBehavior());

        }
    }
}