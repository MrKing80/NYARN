using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToolbarManager : MonoBehaviour
{
    [SerializeField] private GameObject[] toolbarSlots = default;

    private int i = 0;

    private InventorySlotScript toolbarSlot = default;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        toolbarSlot = toolbarSlots[i].GetComponent<InventorySlotScript>();
        toolbarSlot.Select();

        if (Input.GetKeyDown("joystick button 4"))
        {
            if(i > 0)
            {
                i--;

                toolbarSlot = toolbarSlots[i + 1].GetComponent<InventorySlotScript>();
                toolbarSlot.NotSelect();

            }
            else
            {
                i = toolbarSlots.Length - 1;

                toolbarSlot = toolbarSlots[0].GetComponent<InventorySlotScript>();
                toolbarSlot.NotSelect();

            }

            print("LB");
        }
        if(Input.GetKeyDown("joystick button 5"))
        {
            if (toolbarSlots.Length - 1 > i)
            {
                i++;

                toolbarSlot = toolbarSlots[i - 1].GetComponent<InventorySlotScript>();
                toolbarSlot.NotSelect();

            }
            else
            {
                i = 0;

                toolbarSlot = toolbarSlots[toolbarSlots.Length - 1].GetComponent<InventorySlotScript>();
                toolbarSlot.NotSelect();

            }

            print("RB");
        }
    }

}
