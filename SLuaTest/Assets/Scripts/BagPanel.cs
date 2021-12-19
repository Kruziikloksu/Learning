using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using SLua;

[CustomLuaClass]
public class BagPanel : MonoBehaviour
{
    public static BagPanel instance;
    public Text itemInfo;
    public GameObject slotGrid;
    public ItemSlot itemSlot;
    public ItemSO thisItem;
    public BagSO myBag;

    public string luaFileName = "BagPanel";


    public LuaFunction updateItemInfo;
    public LuaFunction closeBagPanel;
    public LuaFunction createNewItem;
    public LuaFunction refreshItems;
    public LuaFunction dropTheseItem;

    public LuaSvr luaSvr;
    LuaState luaState;
    LuaTable self;

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
    void Awake()
    {
        if (instance != null)
        {
            Destroy(this);
        }
        instance = this;
    }

    private void OnEnable()
    {
        if (instance != null)
        {
            Destroy(this);
        }
        instance = this;

        myBag = AssetBundleManager.LoadResource<BagSO>("Bag", "bagpanel");

        luaSvr = new LuaSvr();// 初始化LuaSvr
        LuaSvr.MainState luaMainState = LuaSvr.mainState;
        //用init方法初始化
        luaSvr.init(null, () =>
        {
            luaMainState.loaderDelegate += LuaReourcesFileLoader;
            self = (LuaTable)luaSvr.start(luaFileName);
            closeBagPanel = luaMainState.getFunction("CloseBagPanel");
            createNewItem = luaMainState.getFunction("CreateNewItem");
            refreshItems = luaMainState.getFunction("RefreshItems");
            dropTheseItem = luaMainState.getFunction("DropTheseItem");
        });
        RefreshItems();
    }

    public static void UpdateItemInfo(string itemInfo)
    {
        instance.itemInfo.text = itemInfo.ToString();
    }
    public void CreateNewItem(ItemSO itemDataSO)
    {
        createNewItem.call(itemDataSO);
    }
    public void RefreshItems() 
    {
        refreshItems.call();
    }
    public void DropTheseItem()
    {
        dropTheseItem.call();
    }
    public void CloseBagPanel()
    {
        closeBagPanel.call();
    }
}
