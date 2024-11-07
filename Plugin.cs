using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using ModelReplacement;

namespace AbelMuak.Mods.LC.LethalDrones
{
    [BepInPlugin(ModGUID, "Lethal Drones", "1.0.1")]
    [BepInDependency("com.abelmuak.libs.lethalthings", BepInDependency.DependencyFlags.HardDependency)]
    [BepInDependency("meow.ModelReplacementAPI", BepInDependency.DependencyFlags.HardDependency)]
    [BepInDependency(LethalLib.Plugin.ModGUID, BepInDependency.DependencyFlags.HardDependency)]
    public class Plugin : BaseUnityPlugin
    {

        public const string ModGUID = "com.abelmuak.lc.lethaldrones";
        public static ManualLogSource logger;
        private void Awake()
        {
            logger = Logger;

            Assets.PopulateAssets();

            Scrap.Register();

            ModelReplacementAPI.RegisterSuitModelReplacement("Lethal Drones - N", typeof(MRSDN));
            ModelReplacementAPI.RegisterSuitModelReplacement("Lethal Drones - Uzi", typeof(MRUziDoorman));

            Harmony harmony = new Harmony(ModGUID);
            harmony.PatchAll();
            Logger.LogInfo($"Plugin {ModGUID} is loaded!");
        }
    }

}