using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinMapLevelScript : MonoBehaviour
{
    /*
    
    //ミニマップに表示させるか
    //アイテムや警備員につけてね

    //「EnemyMinimapDisplayScript」と「TreasureMinimapDisplayScript」に分割
    //子オブジェクトに("Light")がないとエラーが出るため没

    private int minMapLevel;//マップのレベル

    [Header("「敵・索敵範囲・宝」生成用オブジェクト")]
    [SerializeField] GameObject enemyPrefab;//敵生成用オブジェクト
    [SerializeField] GameObject lightPrefab;//索敵範囲生成用オブジェクト
    [SerializeField] GameObject treasurePrefab;//宝生成用オブジェクト

    private GameObject gameObjectC;//子である索敵範囲取得用オブジェクト

    private bool isChild;//子オブジェクト有無判定

    private void Start()
    {

        minMapLevel = SakakiharaMapLevelScript.MAPLevel;//他スクリプトからマップのレベル取得

        if (transform.Find("Light").transform.IsChildOf(transform))//索敵範囲オブジェクトがあるかどうか
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
                EnemyDisplay();
                break;

            case 2://2 敵の表示+索敵範囲表示！
                EnemyDisplay();
                EnemySearchRangeDisplay();
                break;

            case 3://3 敵の表示+索敵範囲表示+宝物表示！
                EnemyDisplay();
                EnemySearchRangeDisplay();
                TreasureDisplay();
                break;

            default:
                break;
        }
    }
   private void EnemyDisplay()//敵の表示
    {
        if (this.gameObject.CompareTag("Enemy"))//敵か
        {
            GameObject enemyObj = Instantiate(enemyPrefab);    //自分に生成
            enemyObj.transform.parent = this.transform;
            enemyObj.transform.localPosition = Vector3.zero;
        }
    }
    private void EnemySearchRangeDisplay()//索敵範囲
    {
        if (isChild && gameObjectC.gameObject.CompareTag("Light"))//索敵範囲か
        {
            GameObject lightObj = Instantiate(lightPrefab);//自分に生成
            lightObj.transform.parent = gameObjectC.transform;
            lightObj.transform.localPosition = Vector3.zero;
        }
    }
    private void TreasureDisplay()//宝の表示
    {
        if (this.gameObject.CompareTag("Treasure"))//宝か
        {
            GameObject treasureObj = Instantiate(treasurePrefab);//自分に生成
            treasureObj.transform.parent = this.transform;
            treasureObj.transform.localPosition = Vector3.zero;
        }
    }

    */
}
