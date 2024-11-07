using ModelReplacement;
using UnityEngine;

namespace AbelMuak.Mods.LC.LethalDrones
{
    public class MRSDN : BodyReplacementBase
    {
        protected override GameObject LoadAssetsAndReturnModel()
        { 
            string model_name = "SDN";
            return Assets.CharAssetBundle.LoadAsset<GameObject>(model_name);
        }
    }

    public class MRUziDoorman : BodyReplacementBase
    {
        protected override GameObject LoadAssetsAndReturnModel()
        {
            string model_name = "UziDoorman";
            return Assets.CharAssetBundle.LoadAsset<GameObject>(model_name);
        }
    }
}