using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewLua", menuName = "Data/LuaResource")]
public class LuaResourse : ScriptableObject {
    [TextArea(50,500)]
    public string LuaString;
}
