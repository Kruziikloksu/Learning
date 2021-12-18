using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SLua;
using System.IO;

[CustomLuaClass]
public class TestSOToLua : MonoBehaviour {

    public ItemSO thisItem;
    [SerializeField]
    public LuaSvr luaSvr;
    LuaState luaState;
    LuaTable self;

    public OpenLuaFile openLuaFile;

    public string luaFileName = "SOToLua";
    public static byte[] LuaReourcesFileLoader(string strFile, ref string fn)//读txt格式的lua
    {
        //string filename = Application.dataPath + "/Resources/Lua/" + strFile.Replace('.', '/') + ".txt";
        string filename = Application.dataPath + "/StreamingAssets/Lua/" + strFile.Replace('.', '/') + ".txt";
        return File.ReadAllBytes(filename);
    }

    LuaFunction getSOData;
    void Start()
    {
        //openLuaFile = AssetBundleManager.LoadResource<OpenLuaFile>(, );

        luaSvr = new LuaSvr();// 初始化LuaSvr LuaSvr是对LuaState的一个封装
        LuaSvr.MainState luaMainState = LuaSvr.mainState;
        // 如果不用init方法初始化,在Lua中不能import
        luaSvr.init(null, () =>
        {
            luaMainState.loaderDelegate += LuaReourcesFileLoader;//在mainState的委托loaderDelegate里注册方法
            self = (LuaTable)luaSvr.start(luaFileName);
            //getSOData = luaMainState.getFunction("getSOData");
        });
    }
    public int GetSOId()
    {
        return thisItem.itemId;
    }
}
