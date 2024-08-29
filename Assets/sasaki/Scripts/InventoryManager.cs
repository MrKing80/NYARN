using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] private GameObject toolbar = default;
    [SerializeField] private GameObject inventory = default;
    private GameObject[,] inventorySlots = new GameObject[3, 9];
    private int k = 0;
    private bool isOpen = false;
    private void Awake()
    {
        for(int i = 0; i < inventorySlots.GetLength(0);i++)
        {
            for(int j = 0; j < inventorySlots.GetLength(1);j++)
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

        if(isOpen)
        {
            
        }
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
            }
        }

    }
}
