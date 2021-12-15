using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "NewItem", menuName = "Data/Item")]
public class ItemSO : ScriptableObject {

    public Sprite itemImage;
    public string itemName;
    public int itemId;
    public int itemHeldNum;
    [TextArea]
    public string itemDescription;

}
