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


    //public Button showBagButton;
    public string luaFileName = "BagPanel";


    LuaFunction updateItemInfo;
    LuaFunction closeBagPanel;
    public LuaFunction createNewItem;
    public LuaFunction refreshItems;
    public LuaFunction dropTheseItem;

    public LuaSvr luaSvr;
    LuaState luaState;
    LuaTable self;

    public static byte[] LuaReourcesFileLoader(string strFile, ref string fn)//读txt格式的lua
    {
        //string filename = Application.dataPath + "/Resources/Lua/" + strFile.Replace('.', '/') + ".txt";
        string filename = Application.dataPath + "/StreamingAssets/Lua/" + strFile.Replace('.', '/') + ".txt";
        return File.ReadAllBytes(filename);
    }


    void Awake()
    {
        if (instance != null)
        {
            Destroy(this);
        }
        instance = this;
        //myBag = AssetBundleManager.LoadResource<BagSO>("Bag", "bagpanel");


    }

    private void OnEnable()
    {
        myBag = AssetBundleManager.LoadResource<BagSO>("Bag", "bagpanel");

        //instance.itemInfo.text = "";//文本重置
        
        luaSvr = new LuaSvr();// 初始化LuaSvr LuaSvr是对LuaState的一个封装
        LuaSvr.MainState luaMainState = LuaSvr.mainState;
        // 如果不用init方法初始化,在Lua中不能import
        luaSvr.init(null, () =>
        {
            luaMainState.loaderDelegate += LuaReourcesFileLoader;//在mainState的委托loaderDelegate里注册方法
            self = (LuaTable)luaSvr.start(luaFileName);
            closeBagPanel = luaMainState.getFunction("CloseBagPanel");
            createNewItem = luaMainState.getFunction("CreateNewItem");
            refreshItems = luaMainState.getFunction("RefreshItems");
            dropTheseItem = luaMainState.getFunction("DropTheseItem");
        });
        //thisItem = myBag.itemInBag[3];
        RefreshItems();
        //CreateNewItem(thisItem);

    }

    public static void UpdateItemInfo(string itemInfo)
    {
        //updateItemInfo.call(itemInfo);
        instance.itemInfo.text = itemInfo.ToString();
    }
    /*
    //public void AddNewItem()
    //{
    //    if (!myBag.itemInBag.Contains(thisItem))
    //    {
    //        myBag.itemInBag.Add(thisItem);
    //        CreateNewItem(thisItem);
    //    }
    //    RefreshItems();
    //}
    */
    public void CreateNewItem(ItemSO itemDataSO)
    {

        createNewItem.call(itemDataSO);
    }
    /*
if (itemDataSO.itemHeldNum > 0)
{
    ItemSlot newItem = Instantiate(instance.itemSlot, instance.slotGrid.transform.position, Quaternion.identity);
    newItem.gameObject.transform.SetParent(instance.slotGrid.transform);
    newItem.thisItem = itemDataSO;
    newItem.itemName.text = itemDataSO.itemName.ToString();
    newItem.itemHeldNum.text = itemDataSO.itemHeldNum.ToString();
    newItem.itemInfo = itemDataSO.itemDescription;
}
*/
    public void RefreshItems()  //刷新Action
    {

        refreshItems.call();
    }
    /*
    //for (int i = 0; i < instance.slotGrid.transform.childCount; i++)
    //{
    //    if (instance.slotGrid.transform.childCount == 0)
    //    {
    //        break;
    //    }
    //    Destroy(instance.slotGrid.transform.GetChild(i).gameObject);
    //}
    //for (int i = 0; i < instance.myBag.itemInBag.Count; i++)
    ////foreach(ItemSO itemSO in myBag.itemInBag)
    //{
    //    thisItem = myBag.itemInBag[i]; ;
    //    //CreateNewItem(myBag.itemInBag[i]);
    //    CreateNewItem(thisItem);
    //}
    */
    public void DropTheseItem()
    {
        //myBag.itemInBag.Remove(thisItem);
        //RefreshItems();
        dropTheseItem.call();
    }
    public void CloseBagPanel()
    {
        closeBagPanel.call();
    }
}
