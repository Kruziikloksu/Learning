using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class AssetBundleSample : MonoBehaviour
{

    public RawImage imageToChange;

    public string imageName1= "Image01";
    public string imageName2= "Image02";
    public string assetBundleName= "uiresources";


    private void Start()
    {
        Debug.Log(AssetBundleManager.GetStreamingAssetsPath());

    }
    public void OnClickLoad()
    {
        imageToChange.texture = AssetBundleManager.LoadResource<Texture>(imageName1, assetBundleName);

    }

    public void OnClickLoad2()
    {
        imageToChange.texture = AssetBundleManager.LoadResource<Texture>(imageName2, assetBundleName);
    }
}
