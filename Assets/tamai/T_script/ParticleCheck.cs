using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleCheck : MonoBehaviour
{
    [SerializeField] private GameObject itemObj;
    [SerializeField] private bool isItemObj = true;

    // Start is called before the first frame update
    void Start()
    {
        itemObj = GameObject.FindGameObjectWithTag("item");
        isItemObj = GameObject.FindGameObjectWithTag("Item").GetComponent<SpriteRenderer>().enabled;
    }

    // Update is called once per frame
    void Update()
    {
        // �A�C�e���I�u�W�F�N�g��������Ƃ��̓��^�[���A�����Ȃ��Ƃ��̓G�t�F�N�g������
//        if (itemObj.gameObject.activeSelf) return;
        if (isItemObj) return;
        this.gameObject.SetActive(false);
    }
}
