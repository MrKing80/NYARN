using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventoryItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [Header("UI")]
    [SerializeField] private Image image;
    [SerializeField] private Text countText;

    public ItemData itemData;
    public int count = 1;
    [SerializeField] private bool textActive;
    [HideInInspector] public Transform parentAfterDrag;


    public void InitialiseItem(ItemData newItem)
    {
        itemData = newItem;
        image.sprite = newItem.ItemSprite;
        RefreshCount();
    }

    public void RefreshCount()
    {
        countText.text = count.ToString();
        textActive = count > 1;
        countText.gameObject.SetActive(textActive);
    }

    /// <summary>
    /// �h���b�O�J�n���ɌĂяo�����
    /// </summary>
    public void OnBeginDrag(PointerEventData eventData)
    {
        image.raycastTarget = false;
        parentAfterDrag = transform.parent;
        transform.SetParent(transform.root);
    }

    /// <summary>
    /// �h���b�O���ɌĂяo�����
    /// </summary>
    public void OnDrag(PointerEventData eventData)
    {
        Vector3 cameraPosition = Input.mousePosition;
        //Z���W�������Ȃ��Ƌ��������������Ȃ�
        cameraPosition.z = 10.0f; 
        Vector2 pos = Camera.main.ScreenToWorldPoint(cameraPosition);
        this.transform.position = pos;
    }

    /// <summary>
    /// �h���b�O�I���ɌĂяo�����
    /// </summary>
    public void OnEndDrag(PointerEventData eventData)
    {
        image.raycastTarget = true;
        transform.SetParent(parentAfterDrag);
    }
}
