using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventoryItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] private ItemData itemData;
    [SerializeField] private int itemNum;
    [Header("UI")] [SerializeField] private Image image;
    [HideInInspector] public Transform parentAfterDrag;


    public void InitialiseItem(ItemData newItem)
    {
        itemData = newItem;
        image.sprite = newItem.itemImage;
    }

    /// <summary>
    /// ドラッグ開始時に呼び出される
    /// </summary>
    public void OnBeginDrag(PointerEventData eventData)
    {
        image.raycastTarget = false;
        parentAfterDrag = transform.parent;
        transform.SetParent(transform.root);
    }

    /// <summary>
    /// ドラッグ中に呼び出される
    /// </summary>
    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    /// <summary>
    /// ドラッグ終わりに呼び出される
    /// </summary>
    public void OnEndDrag(PointerEventData eventData)
    {
        image.raycastTarget = true;
        transform.SetParent(parentAfterDrag);
    }
}
