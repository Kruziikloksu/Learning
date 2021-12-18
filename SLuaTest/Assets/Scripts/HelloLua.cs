using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using SLua;


public class HelloLua : MonoBehaviour
{
    public LuaSvr luaSvr;
    UnityEngine.Object luaFile;
    LuaState luaState;
    LuaTable self;
    LuaFunction myLuaFunction;
    LuaFunction CreateCube;

    public static byte[] LuaReourcesFileLoader(string strFile, ref string fn)//读txt格式的lua文件
    {
        //这里为了测试就不先判断为空,开发的时候再加上
        //string filename = Application.dataPath + "/Resources/Lua/" + strFile.Replace('.', '/') + ".txt";
        string filename = Application.dataPath + "/StreamingAssets/Lua/" + strFile.Replace('.', '/') + ".txt";
        return File.ReadAllBytes(filename);
    }
    public void MyLuaFunction()
    {
        myLuaFunction.call();
    }
    public void LuaCreateCube()
    {
        CreateCube.call();
    }
    void Start()
    {
        luaSvr = new LuaSvr();// 初始化LuaSvr LuaSvr其实是对LuaState的一个封装
        LuaSvr.MainState luaMainState = LuaSvr.mainState;

        //测试
        Debug.Log("测试：");
        // 如果不用init方法初始化,在Lua中不能import
        luaSvr.init(null, () =>
        {
            luaMainState.loaderDelegate += LuaReourcesFileLoader;//在mainState的委托loaderDelegate里注册方法
            self = (LuaTable)luaSvr.start("Lua");
            myLuaFunction = luaMainState.getFunction("MyLuaFunction");
            CreateCube = luaMainState.getFunction("CreateCube");
        });
        //MyLuaFunction();
        //LuaCreateCube();
    }
}




























//svr.init 其实是将 UnityEngine 的一些常用函数压栈以便接下来在 Lua 中调用，在 Editor 中具体调用如下：
/*
    IntPtr L = mainState.L;
    LuaObject.init(L);
    if (!UnityEditor.EditorApplication.isPlaying)
    {
        doBind(L);
        doinit(mainState, flag);
        complete();
        mainState.checkTop();
    }
*/
//LuaObject.init(L) 的作用是为 lua 注入一些通用的方法， dobind 则是注入 UnityEngine 常用的一些方法
/*
    import "UnityEngine"
    function main()
        print("Lua创建了一个Cube")
        local cube = GameObject.CreatePrimitive(PrimitiveType.Cube)
    end
    main()
*/






