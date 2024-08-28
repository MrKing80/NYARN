using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlotScript : MonoBehaviour
{
    [SerializeField] private Color selectedColor = default;
    [SerializeField] private Color notSelectedColor = default;
    private Image image = default;
    // Start is called before the first frame update
    void Start()
    {
        image = this.GetComponent<Image>();
        NotSelect();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Select()
    {
        image.color = selectedColor;
    }

    public void NotSelect()
    {
        image.color = notSelectedColor;
    }
}
