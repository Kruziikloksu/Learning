using System;
using System.IO;
using UnityEditor;
using UnityEngine;
using System.Collections.Generic;

public class AssetBundleEditor
{
    //static string assetBundlePathWin64 = "AssetBundles/Win64";//路径
    static string assetBundlePathWin64 = Application.streamingAssetsPath;//路径
    [MenuItem("AssetBundle/BuildAssetBundles/Win64ABToStreamingAssets")]
    public static void BuildAssetBundles()
    {
        BuildAssetBundles(assetBundlePathWin64, BuildTarget.StandaloneWindows64);
    }
    public static void BuildAssetBundles(string assetBundlePath, BuildTarget buildTarget)
    {
        if (Directory.Exists(assetBundlePath))
        {
            Directory.Delete(assetBundlePath, true);
        }
        Directory.CreateDirectory(assetBundlePath);
        BuildPipeline.BuildAssetBundles(assetBundlePath, BuildAssetBundleOptions.UncompressedAssetBundle, buildTarget);

        AssetDatabase.Refresh();
    }
    //StreamingAssetsPath
    public static string GetStreamingAssetsPath()
    {
        string StreamingAssetsPath =
        Application.streamingAssetsPath + "/";
        return StreamingAssetsPath;
    }
}
