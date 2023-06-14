using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "newItemData", menuName = "Data/ItemData")]
public class ItemData : ScriptableObject    
{
    public GameObject PrefabItem;
    public int Quantity;
    public void increaseQuantity(int i)
    {
        Quantity = Quantity + i;
    }
    public void decreaseQuantity(int i)
    {
        Quantity = Quantity - i;
    }
 
}
