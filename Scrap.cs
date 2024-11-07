using LethalLib.Modules;
using AbelMuak.Libs.LethalHelper;
using UnityEngine;
using Newtonsoft.Json;

namespace AbelMuak.Mods.LC.LethalDrones
{

    public static class Scrap
    {

        //God forgive me for this
        //This functions are still here just for preservation
        public static Item[] GetItems()
        {
            Item[] items = new Item[8];

            items[0] = Assets.ScrapAssetBundle.LoadAsset<Item>("Assets/Projects/LethalDrones/Scrap/Scrap_JCPen.asset");
            items[1] = Assets.ScrapAssetBundle.LoadAsset<Item>("Assets/Projects/LethalDrones/Scrap/Scrap_Nanite.asset");
            items[2] = Assets.ScrapAssetBundle.LoadAsset<Item>("Assets/Projects/LethalDrones/Scrap/Scrap_UziNeck.asset");
            items[3] = Assets.ScrapAssetBundle.LoadAsset<Item>("Assets/Projects/LethalDrones/Scrap/Scrap_WDHead.asset");
            items[4] = Assets.ScrapAssetBundle.LoadAsset<Item>("Assets/Projects/LethalDrones/Scrap/Scrap_JPlush.asset");
            items[5] = Assets.ScrapAssetBundle.LoadAsset<Item>("Assets/Projects/LethalDrones/Scrap/Scrap_VPlush.asset");
            items[6] = Assets.ScrapAssetBundle.LoadAsset<Item>("Assets/Projects/LethalDrones/Scrap/Scrap_NPlush.asset");
            items[7] = Assets.ScrapAssetBundle.LoadAsset<Item>("Assets/Projects/LethalDrones/Scrap/Scrap_UziPlush.asset");

            return items;
        }
        public static int[] GetRarities()
        {
            int[] rarities = new int[8];

            rarities[0] = 30;
            rarities[1] = 45;
            rarities[2] = 50;
            rarities[3] = 70;
            rarities[4] = 69;
            rarities[5] = 69;
            rarities[6] = 69;
            rarities[7] = 69;

            return rarities;
        }

        public static void Register()
        {
            Plugin.logger.LogInfo("Loading Scrap list");

            TextAsset scrapListFile = Assets.ScrapAssetBundle.LoadAsset<TextAsset>("Assets/Projects/LethalDrones/ScrapList.json");
            //var scrapList = GetItems();
            //var raritiesList = GetRarities();

            ScrapInfoJSON[] scrapList = JsonConvert.DeserializeObject<ScrapInfoJSON[]>(scrapListFile.text) ?? new ScrapInfoJSON[0];

            Plugin.logger.LogInfo("Scrap list loaded, info:");
            Plugin.logger.LogInfo("Scrap count:" + scrapList.Length);

            foreach (var info in scrapList)
            //for (int i = 0; i < scrapList.ScrapInfos.Count; i++)
            {
                Item item = Assets.ScrapAssetBundle.LoadAsset<Item>(info.ItemDef);

                NetworkPrefabs.RegisterNetworkPrefab(item.spawnPrefab);
                Items.RegisterScrap(item, info.Rarity, (Levels.LevelTypes)info.LevelType);

                Plugin.logger.LogInfo($"Registered {item.itemName} (scrap)");
            }

        }
    }
}
