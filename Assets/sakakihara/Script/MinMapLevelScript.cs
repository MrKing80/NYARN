using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinMapLevelScript : MonoBehaviour
{
    //ミニマップに表示させるか

    GameObject myGameObject;
    private int minMapLevel;

    //[SerializeField] GameObject enemyPrefab;//生成用オブジェクト

    [SerializeField] GameObject minMapObj;//子オブジェクト
    SpriteRenderer minMapObjSpriteRenderer;//

    private void Awake()
    {

        minMapObj = this.gameObject.transform.GetChild(0).gameObject;//子オブジェクト取得
        minMapObjSpriteRenderer = minMapObj.GetComponent<SpriteRenderer>();
    }
    //void Start()
    //{
    //    //myGameObject = this.gameObject; //自分取得

    //    minMapObj = transform.GetChild(0).gameObject;//子オブジェクト取得
    //    minMapObjSpriteRenderer = minMapObj.GetComponent<SpriteRenderer>();
    
    //}

    // Update is called once per frame
    void Update()
    {
        minMapLevel = SakakiharaMapLevelScript.MAPLevel;
        switch (minMapLevel)
        {
            case 1:
                if (this.gameObject.CompareTag("Enemy"))
                {
                    //myGameObject = Instantiate(enemyPrefab);    //自分に生成

                    minMapObjSpriteRenderer.enabled = true;  // 子オブジェクト有効化
                }
                break;
            default:
                minMapObjSpriteRenderer.enabled = false;
                break;
        }


    }
}
