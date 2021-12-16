using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SLua;

[CreateAssetMenu(fileName = "NewItem", menuName = "Data/Item")]
[CustomLuaClass]
public class ItemSO : ScriptableObject {

    public Sprite itemImage;
    public string itemName;
    public int itemId;
    public int itemHeldNum;
    [TextArea]
    public string itemDescription;

}
