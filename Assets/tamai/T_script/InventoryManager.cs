using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager instance;

    private int maxStackedItems = 4;
    public InventorySlot[] inventorySlots;
    public GameObject inventoryItemPrefab;
    private GameObject player;
    [SerializeField] private bool isTrigger;
    // 現在どのスロットが選択されているかを追跡
    private int selectedSlot = -1;

    private void Awake()
    {
        instance = this;
        isTrigger = true;
//        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Start()
    {
        ChangeSelectedSlot(0);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F)){
            isTrigger = !isTrigger;
        }

        if (Input.inputString != null)
        {
            bool isNumber = int.TryParse(Input.inputString, out int number);
            if (isTrigger)
            {
                if (isNumber && number > 0 && number < 9)
                {
                    ChangeSelectedSlot(number - 1);
                }
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.E) && number > 0 && number < 33)
                {
                    number++;
                    ChangeSelectedSlot(number - 1);
                }
            }
        }

        /*
        if (Input.GetKeyDown(KeyCode.X))
        {
            ItemData itemKey = GetSelectedItem(true);
            if(itemKey != null)
            {
                Debug.Log("Item" + itemKey);
            }else
            {
                Debug.Log("Not Item");
            }
        }*/
    }

    private void ChangeSelectedSlot(int newValue)
    {
        if (selectedSlot >= 0)
        {
            inventorySlots[selectedSlot].Deselect();
        }

        inventorySlots[newValue].Select();
        selectedSlot = newValue;
    }

    public bool AddItem(ItemData item)
    {
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            InventorySlot slot = inventorySlots[i];
            InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
            if (itemInSlot != null && itemInSlot.itemData == item 
                && itemInSlot.count < maxStackedItems && itemInSlot.itemData)
            {
                itemInSlot.count++;
                itemInSlot.RefreshCount();
                return true;
            }
        }

        for (int i = 0; i < inventorySlots.Length; i++)
        {
            InventorySlot slot = inventorySlots[i];
            InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
            if (itemInSlot == null)
            {
                SpawnNewItem(item, slot);
                return true;
            }
        }
        return false;
    }
    private void SpawnNewItem(ItemData item, InventorySlot slot)
    {
        GameObject newItemGo = Instantiate(inventoryItemPrefab, slot.transform);
        InventoryItem inventoryItem = newItemGo.GetComponent<InventoryItem>();
        inventoryItem.InitialiseItem(item);
    }
    public ItemData GetSelectedItem(bool use)
    {
        InventorySlot slot = inventorySlots[selectedSlot];
        InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
        if (itemInSlot != null)
        {
            ItemData item = itemInSlot.itemData;
            if(use == true)
            {
                itemInSlot.count--;
                
                if(itemInSlot.count <= 0)
                {
                    Destroy(itemInSlot.gameObject);
                }
                else
                {
                    itemInSlot.RefreshCount();
                }
            }
            return item;
        }
        return null;
    }
}
