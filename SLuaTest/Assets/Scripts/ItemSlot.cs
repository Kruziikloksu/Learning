using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using SLua;

[CustomLuaClass]
public class ItemSlot : MonoBehaviour {

    BagSO itemBag;
    public ItemSO thisItem;
    public Text itemName;
    public Text itemHeldNum;
    public Image itemImage;
    public string itemInfo;
    public string luaFileName = "BagPanel";




    public static byte[] LuaReourcesFileLoader(string strFile, ref string fn)//读txt格式的lua
    {
        string filename = Application.dataPath + "/StreamingAssets/Lua/" + strFile.Replace('.', '/') + ".txt";
        return File.ReadAllBytes(filename);
    }

    public void DeleteThisItem()
    {
        thisItem.itemHeldNum --;
        BagPanel.instance.RefreshItems();
    }
    public void ItemOnClicked()
    {
        BagPanel.instance.thisItem = thisItem;
        BagPanel.UpdateItemInfo(thisItem.itemDescription);
        //BagPanel.instance.itemInfo.text = thisItem.itemDescription;
    }
    private void Awake()
    {
        //itemBag = AssetBundleManager.LoadResource<BagSO>("Bag", "bagpanel");
    }
    private void OnEnable()
    {
        //BagPanel.RefreshItems();
        //instance.itemInfo.text = "";//文本重置

    }
}
