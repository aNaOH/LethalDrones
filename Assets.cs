using System;
using System.IO;
using System.Reflection;
using UnityEngine;

namespace AbelMuak.Mods.LC.LethalDrones
{
    public static class Assets
    {
        // Replace mbundle with the Asset Bundle Name from your unity project 
        public static string charAssetBundleName = "lethaldrones_chars";
        public static string scrapsAssetBundleName = "lethaldrones_scrap";
        public static AssetBundle CharAssetBundle = null;
        public static AssetBundle ScrapAssetBundle = null;

        static string GetAssemblyLocation() => Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        public static void PopulateAssets()
        {

            if (CharAssetBundle == null)
            {
                Console.WriteLine($"AbelMuak.LethalDrones: Loading Characters at {charAssetBundleName}");
                CharAssetBundle = AssetBundle.LoadFromFile(Path.Combine(GetAssemblyLocation(), charAssetBundleName));
            }
            if (ScrapAssetBundle == null)
            {
                Console.WriteLine($"AbelMuak.LethalDrones: Loading Scraps at {scrapsAssetBundleName}");
                ScrapAssetBundle = AssetBundle.LoadFromFile(Path.Combine(GetAssemblyLocation(), scrapsAssetBundleName));
            }
        }
    }
}
