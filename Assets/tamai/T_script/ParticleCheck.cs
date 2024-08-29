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
        // アイテムオブジェクトが見えるときはリターン、見えないときはエフェクトを消す
//        if (itemObj.gameObject.activeSelf) return;
        if (isItemObj) return;
        this.gameObject.SetActive(false);
    }
}
