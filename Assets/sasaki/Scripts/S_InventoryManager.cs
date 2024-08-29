using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class S_InventoryManager : MonoBehaviour
{
    [SerializeField] private GameObject toolbar = default;
    [SerializeField] private GameObject inventory = default;
    private GameObject item;
    private GameObject[,] inventorySlots = new GameObject[3, 9];
    private S_InventorySlotScript inventorySlotScript = default;
    private int k = 0;
    private int v = 0;
    private int h = 0;
    private bool isOpen = false;
    private bool isHorizontalButtonPush = false;
    private bool isVerticalButtonPush = false;

    private void Awake()
    {
        for (int i = 0; i < inventorySlots.GetLength(0); i++)
        {
            for (int j = 0; j < inventorySlots.GetLength(1); j++)
            {
                inventorySlots[i, j] = inventory.transform.GetChild(k).gameObject;
                print(inventorySlots[i, j]);
                k++;
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        inventory.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        InventoryOpenAndClose();
        InventorySelect();

        print(item);
    }

    private void InventoryOpenAndClose()
    {
        if (Input.GetKeyDown("joystick button 3"))
        {
            if (inventory.activeSelf == true)
            {
                isOpen = false;
                inventory.SetActive(false);
            }
            else if (inventory.activeSelf == false)
            {
                isOpen = true;
                inventory.SetActive(true);

                inventorySlotScript = inventorySlots[v, h].GetComponent<S_InventorySlotScript>();
                inventorySlotScript.Select();

            }
        }

    }

    private void InventorySelect()
    {
        if (isOpen)
        {

            if (Input.GetAxisRaw("D-padHorizontal") == 1 && !isHorizontalButtonPush)
            {
                isHorizontalButtonPush = true;

                inventorySlotScript = inventorySlots[v, h].GetComponent<S_InventorySlotScript>();
                inventorySlotScript.NotSelect();

                if (h < inventorySlots.GetLength(1) - 1)
                {
                    h++;
                }

                inventorySlotScript = inventorySlots[v, h].GetComponent<S_InventorySlotScript>();
                inventorySlotScript.Select();

            }
            else if (Input.GetAxisRaw("D-padHorizontal") == 0 && isHorizontalButtonPush)
            {
                isHorizontalButtonPush = false;
            }

            if (Input.GetAxisRaw("D-padHorizontal") == -1 && !isHorizontalButtonPush)
            {
                isHorizontalButtonPush = true;

                inventorySlotScript = inventorySlots[v, h].GetComponent<S_InventorySlotScript>();
                inventorySlotScript.NotSelect();

                if (h > 0)
                {
                    h--;
                }

                inventorySlotScript = inventorySlots[v, h].GetComponent<S_InventorySlotScript>();
                inventorySlotScript.Select();

            }
            else if (Input.GetAxisRaw("D-padHorizontal") == 0 && isHorizontalButtonPush)
            {
                isHorizontalButtonPush = false;
            }

            if (Input.GetAxisRaw("D-padVertical") == 1 && !isVerticalButtonPush)
            {
                isVerticalButtonPush = true;

                inventorySlotScript = inventorySlots[v, h].GetComponent<S_InventorySlotScript>();
                inventorySlotScript.NotSelect();

                if (v > 0)
                {
                    v--;
                }

                inventorySlotScript = inventorySlots[v, h].GetComponent<S_InventorySlotScript>();
                inventorySlotScript.Select();

            }
            else if (Input.GetAxisRaw("D-padVertical") == 0 && isVerticalButtonPush)
            {
                isVerticalButtonPush = false;
            }

            if (Input.GetAxisRaw("D-padVertical") == -1 && !isVerticalButtonPush)
            {
                isVerticalButtonPush = true;

                inventorySlotScript = inventorySlots[v, h].GetComponent<S_InventorySlotScript>();
                inventorySlotScript.NotSelect();

                if (v < inventorySlots.GetLength(0) - 1)
                {
                    v++;
                }

                inventorySlotScript = inventorySlots[v, h].GetComponent<S_InventorySlotScript>();
                inventorySlotScript.Select();

            }
            else if (Input.GetAxisRaw("D-padVertical") == 0 && isVerticalButtonPush)
            {
                isVerticalButtonPush = false;
            }

        }

    }

    public void GetItemInfo(GameObject getItem)
    {
        item = getItem;
    }
}
