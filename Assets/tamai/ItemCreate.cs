using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCreate : MonoBehaviour
{
    [SerializeField] private ItemDataBase itemLists;
    //    [SerializeField] private GameObject itemObject;
    [SerializeField] [Range(0, 1)] private int itemID;

    void Start()
    {
//        itemObject = itemLists.GetItemLists()[itemID].ItemObject;

    }

    void Update()
    {
        Debug.Log(itemLists.GetItemLists()[itemID].ItemID + " : " + itemLists.GetItemLists()[itemID].Name +
                itemLists.GetItemLists()[itemID].Price + itemLists.GetItemLists()[itemID].Weight);
    }
}
