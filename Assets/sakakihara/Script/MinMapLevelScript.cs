using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinMapLevelScript : MonoBehaviour
{
    //ミニマップに表示させるか

    private int minMapLevel;//マップのレベル

    [SerializeField] GameObject enemyPrefab;//敵生成用オブジェクト
    [SerializeField] GameObject lightPrefab;//索敵範囲生成用オブジェクト
    [SerializeField] GameObject treasurePrefab;//宝生成用オブジェクト

    private GameObject gameObjectC;//索敵範囲オブジェクト

    private bool isChild;//子オブジェクト有無判定

    private void Start()
    {

        minMapLevel = SakakiharaMapLevelScript.MAPLevel;//他スクリプトからマップのレベル取得

        if (GameObject.Find("Light").transform.IsChildOf(transform))//索敵範囲オブジェクトがあるかどうか
        {
            isChild = true;
            gameObjectC = transform.Find("Light").gameObject;//索敵範囲オブジェクト取得
        }
        else
        {
            isChild = false;
        }

        switch (minMapLevel)
        {
            case 1://1 敵の表示！
                if (this.gameObject.CompareTag("Enemy"))//敵の表示
                {
                    GameObject enemyObj = Instantiate(enemyPrefab);    //自分に生成
                    enemyObj.transform.parent = this.transform;
                    enemyObj.transform.localPosition = Vector3.zero;
                }
                break;

            case 2://2 敵の表示+索敵範囲表示！
                if (this.gameObject.CompareTag("Enemy"))//敵の表示
                {
                    GameObject enemyObj = Instantiate(enemyPrefab);//自分に生成
                    enemyObj.transform.parent = this.transform;
                    enemyObj.transform.localPosition = Vector3.zero;
                }
                if (isChild && gameObjectC.gameObject.CompareTag("Light"))//索敵範囲
                {
                    GameObject lightObj = Instantiate(lightPrefab);//自分に生成
                    lightObj.transform.parent = gameObjectC.transform;
                    lightObj.transform.localPosition = Vector3.zero;
                }
                break;

            case 3://3 敵の表示+索敵範囲表示+宝物表示！
                if (this.gameObject.CompareTag("Enemy"))//敵の表示
                {
                    GameObject enemyObj = Instantiate(enemyPrefab);//自分に生成
                    enemyObj.transform.parent = this.transform;
                    enemyObj.transform.localPosition = Vector3.zero;
                }
                if (isChild && gameObjectC.gameObject.CompareTag("Light"))//索敵範囲
                {
                    GameObject lightObj = Instantiate(lightPrefab);//自分に生成
                    lightObj.transform.parent = gameObjectC.transform;
                    lightObj.transform.localPosition = Vector3.zero;
                }
                if (this.gameObject.CompareTag("Treasure"))//宝の表示
                {
                    GameObject treasureObj = Instantiate(treasurePrefab);//自分に生成
                    treasureObj.transform.parent = this.transform;
                    treasureObj.transform.localPosition = Vector3.zero;
                }
                break;

            default:
                break;
        }
    }

}
