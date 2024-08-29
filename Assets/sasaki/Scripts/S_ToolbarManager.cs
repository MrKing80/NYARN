using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class S_ToolbarManager : MonoBehaviour
{
    [SerializeField] private GameObject[] toolbarSlots = default;

    private int i = 0;

    private S_InventorySlotScript toolbarSlot = default;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        toolbarSlot = toolbarSlots[i].GetComponent<S_InventorySlotScript>();
        toolbarSlot.Select();

        if (Input.GetKeyDown("joystick button 4"))
        {
            if(i > 0)
            {
                i--;

                toolbarSlot = toolbarSlots[i + 1].GetComponent<S_InventorySlotScript>();
                toolbarSlot.NotSelect();

            }
            else
            {
                i = toolbarSlots.Length - 1;

                toolbarSlot = toolbarSlots[0].GetComponent<S_InventorySlotScript>();
                toolbarSlot.NotSelect();

            }

            print("LB");
        }
        if(Input.GetKeyDown("joystick button 5"))
        {
            if (toolbarSlots.Length - 1 > i)
            {
                i++;

                toolbarSlot = toolbarSlots[i - 1].GetComponent<S_InventorySlotScript>();
                toolbarSlot.NotSelect();

            }
            else
            {
                i = 0;

                toolbarSlot = toolbarSlots[toolbarSlots.Length - 1].GetComponent<S_InventorySlotScript>();
                toolbarSlot.NotSelect();

            }

            print("RB");
        }
    }

}
