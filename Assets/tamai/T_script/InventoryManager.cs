using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager instance;
    public PlayerItemCatch playerItem;

    private int maxStackedItems = 4;
    // Slot管理
    public InventorySlot[] inventorySlots;
    // 
    public GameObject inventoryItemPrefab;
    [SerializeField] private Vector3 playerPos;
    [SerializeField] private bool isTrigger;
    // 現在どのスロットが選択されているかを追跡
    private int selectedSlot = -1;
    private string itemName;

    private void Awake()
    {
        instance = this;
        isTrigger = true;
    }

    private void Start()
    {
        ChangeSelectedSlot(0);
    }

    private void Update()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;

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
    /*
    /// <summary>
    /// 捨てるあいてむさがし
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    public bool DumpItem(ItemData item)
    {
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            InventorySlot slot = inventorySlots[i];
            InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
            if (itemInSlot != null && itemInSlot.itemData == item
                && itemInSlot.count < maxStackedItems && itemInSlot.itemData)
            {

                // 新しくアイテムを作る
                GameObject itemToDrop = new GameObject(playerItem.catchItemID.ToString());
                ItemCreate newItem = itemToDrop.AddComponent<ItemCreate>();
                newItem.item.artName = playerItem.items[playerItem.catchItemID].artName;
                newItem.itemSprite = itemSprite;

                // マップに置く画像
                SpriteRenderer sp = itemToDrop.AddComponent<SpriteRenderer>();
                sp.sprite = itemSprite;
                sp.sortingOrder = 5;

                // コライダー追加
                itemToDrop.AddComponent<BoxCollider2D>();

                // 置き場所
                itemToDrop.transform.position = GameObject.FindGameObjectWithTag("Player").transform.position;


                return true;
            }
        }

        /*
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
        
    }*/

    private void SpawnNewItem(ItemData item, InventorySlot slot)
    {
        GameObject newItemGo = Instantiate(inventoryItemPrefab, slot.transform);
        InventoryItem inventoryItem = newItemGo.GetComponent<InventoryItem>();
        inventoryItem.InitialiseItem(item);
    }

    public ItemData GetSelectedItem(bool use)
    {
        InventorySlot slot = inventorySlots[selectedSlot];
        // インベントリの中身参照
        InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
        if (itemInSlot != null)
        {
            ItemData item = itemInSlot.itemData;
            if(use == true)
            {
                itemInSlot.count--;
                Debug.Log("Item");

                // インベントリアイテムを判別して足元に生成


                if (itemInSlot.count <= 0)
                {
                    // インベントリアイテムを消す
                    Destroy(itemInSlot.gameObject);
                }
                else
                {
                   // Instantiate(itemInSlot.gameObject, playerPos, Quaternion.identity);

                    // 数字を消す
                    itemInSlot.RefreshCount();
                }
            }
            return item;
        }
        return null;
    }
    /*
                     GameObject newItem = itemInSlot.gameObject;
                Instantiate(newItem, playerPos, Quaternion.identity);
                InventoryItem inventoryItem = newItem.GetComponent<InventoryItem>();
                inventoryItem.InitialiseItem(item);
     
     */
}
