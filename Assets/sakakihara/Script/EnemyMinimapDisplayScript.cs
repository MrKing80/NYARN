using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMinimapDisplayScript : MonoBehaviour
{
    //ミニマップに表示させるか
    //警備員につけてね

    //「MinMapLevelScript」から分離
    //索敵範囲など子オブジェクトがある場合こっち
    //子オブジェクトの名前を「　Light　」にしないと動きません

    private int minMapLevel;//マップのレベル

    [Header("敵ミニマップ生成用オブジェクト")]
    [SerializeField] GameObject enemyPrefab;//敵生成用オブジェクト
    [Header("索敵範囲生成用オブジェクト")]
    [SerializeField] GameObject lightPrefab;//索敵範囲生成用オブジェクト

    private GameObject gameObjectC;//子である索敵範囲取得用オブジェクト

    private bool isChild;//子オブジェクト有無判定

    private void Start()
    {

        if (transform.Find("Light").transform.IsChildOf(transform))//子オブジェクトに("Light")があるか
        {
            isChild = true;
            gameObjectC = transform.Find("Light").gameObject; ;//索敵範囲オブジェクト取得
        }
        else
        {
            isChild = false;
        }

        minMapLevel = SakakiharaMapLevelScript.MAPLevel;//他スクリプトからマップのレベル取得

        if (minMapLevel >= 1)
        {
            EnemyDisplay();
        }
        if (minMapLevel >= 2)
        {
            EnemySearchRangeDisplay();
        }
    }

    private void EnemyDisplay()//敵の表示
    {
           GameObject enemyObj = Instantiate(enemyPrefab);    //自分に生成
            enemyObj.transform.parent = this.transform;
            enemyObj.transform.localPosition = Vector3.zero;
    }

    private void EnemySearchRangeDisplay()//索敵範囲
    {
            GameObject lightObj = Instantiate(lightPrefab);//自分に生成
            lightObj.transform.parent = gameObjectC.transform;
            lightObj.transform.localPosition = Vector3.zero;
    }
}
