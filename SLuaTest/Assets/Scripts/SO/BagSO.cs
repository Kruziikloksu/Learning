using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewBag", menuName = "Data/Bag")]
public class BagSO : ScriptableObject {

    public List<ItemSO> itemInBag = new List<ItemSO>();
}
