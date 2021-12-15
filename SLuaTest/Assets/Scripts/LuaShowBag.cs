using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using SLua;

public class LuaShowBag : MonoBehaviour {

    public GameObject bagPanel;
    //public Button showBagButton;
    public string luaFileName="ShowBag";
    LuaFunction showBag;

    public LuaSvr luaSvr;
    LuaState luaState;
    LuaTable self;

    public static byte[] LuaReourcesFileLoader(string strFile, ref string fn)//读txt格式的lua
    {
        string filename = Application.dataPath + "/StreamingAssets/Lua/" + strFile.Replace('.', '/') + ".txt";
        return File.ReadAllBytes(filename);
    }

    public void ShowBag()
    {
        showBag.call(bagPanel);   
    }

    // Use this for initialization
    void Start()
    {
        bagPanel =AssetBundleManager.LoadResource<GameObject>("BagPanel","bagpanel" );

        luaSvr = new LuaSvr();// 初始化LuaSvr LuaSvr是对LuaState的一个封装
        LuaSvr.MainState luaMainState = LuaSvr.mainState;
        // 如果不用init方法初始化,在Lua中不能import
        luaSvr.init(null, () =>
        {
            luaMainState.loaderDelegate += LuaReourcesFileLoader;//在mainState的委托loaderDelegate里注册方法
            self = (LuaTable)luaSvr.start(luaFileName);
            showBag = luaMainState.getFunction("ShowBag");
        });


    }

}
