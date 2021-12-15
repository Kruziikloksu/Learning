using UnityEngine;
using System.Collections.Generic;

public class AssetBundleManager
{
    static AssetBundle assetbundle = null;

    static Dictionary<string, AssetBundle> DictionaryAssetBundle = new Dictionary<string, AssetBundle>();

    public static T LoadResource<T>(string assetBundleName, string assetBundleGroupName) where T : Object
    {
        if (string.IsNullOrEmpty(assetBundleGroupName))
        {
            return default(T);
        }
        if (!DictionaryAssetBundle.TryGetValue(assetBundleGroupName, out assetbundle))
        {
            assetbundle = AssetBundle.LoadFromFile(GetStreamingAssetsPath() + assetBundleGroupName);
            DictionaryAssetBundle.Add(assetBundleGroupName, assetbundle);
        }
        object obj = assetbundle.LoadAsset(assetBundleName, typeof(T));
        var one = obj as T;
        return one;
    }

    public static void UnLoadResource(string assetBundleGroupName)
    {
        if (DictionaryAssetBundle.TryGetValue(assetBundleGroupName, out assetbundle))
        {
            assetbundle.Unload(false);
            if (assetbundle != null)
            {
                assetbundle = null;
            }
            DictionaryAssetBundle.Remove(assetBundleGroupName);
            Resources.UnloadUnusedAssets();
        }
    }


    //StreamingAssetsPath
    public static string GetStreamingAssetsPath()
    {
        string StreamingAssetsPath =
        Application.streamingAssetsPath + "/";
        return StreamingAssetsPath;
    }
}
