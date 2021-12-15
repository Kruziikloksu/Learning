using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SLua;

public class hello: MonoBehaviour
{
    private static LuaState ls_state;//先声明一个state
    void Start()
    {
        //LuaState一定要在Awake方法或Start或需要用到的时候再进行初始化
        ls_state = new LuaState();//初始化state
        ls_state.doString("print(\"Hello Lua!\")");//state的打印
    }
}
