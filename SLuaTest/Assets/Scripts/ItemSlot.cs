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
        /*
        //string filename = Application.dataPath + "/Resources/Lua/" + strFile.Replace('.', '/') + ".txt";
        string filename = Application.dataPath + "/StreamingAssets/Lua/" + strFile.Replace('.', '/') + ".txt";
        return File.ReadAllBytes(filename);
        */
        LuaResourse thisLuaRes = AssetBundleManager.LoadResource<LuaResourse>(strFile, "myluares");
        return System.Text.Encoding.Default.GetBytes(thisLuaRes.LuaString);
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
    }
}
