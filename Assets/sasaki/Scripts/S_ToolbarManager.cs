using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class S_ToolbarManager : MonoBehaviour
{
    [SerializeField] private GameObject[] toolbarSlots = default;

    private S_InventorySlotScript toolbarSlot = default;

    private Image image = default;

    private Sprite sprite = default;

    private int i = 0;

    private int j = 0;

    private bool isGet = false;

    private bool isFull = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        print(isFull);

        toolbarSlot = toolbarSlots[i].GetComponent<S_InventorySlotScript>();
        toolbarSlot.Select();

        if (isGet)
        {
            for (j = 0; j < toolbarSlots.Length; j++)
            {
                image = toolbarSlots[j].transform.GetChild(0).GetComponent<Image>();

                if (image.sprite == null)
                {
                    isFull = false;

                    if (image.sprite == sprite)
                    {

                        break;
                    }
                    else
                    {
                        image.sprite = sprite;
                        break;
                    }

                }
            }

            if (j >= toolbarSlots.Length - 1)
            {
                isFull = true;
            }

            isGet = false;
        }

        if (Input.GetKeyDown("joystick button 4"))
        {
            if (i > 0)
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

        }
        if (Input.GetKeyDown("joystick button 5"))
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


        }
    }

    public void GetItemImage(Sprite itemImage)
    {
        sprite = itemImage;
        isGet = true;
    }

    public bool SetIsFullFlg()
    {
        bool isFullFlg = isFull;
        return isFullFlg;
    }

}
