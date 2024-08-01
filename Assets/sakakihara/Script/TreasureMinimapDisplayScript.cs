using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureMinimapDisplayScript : MonoBehaviour
{
    //ミニマップに表示させるか
    //宝につけてね

    //「MinMapLevelScript」から分離
    //子オブジェクトがない場合こっち

    private int minMapLevel;//マップのレベル

    [Header("「宝」生成用オブジェクト")]
    [SerializeField] GameObject treasurePrefab;//宝生成用オブジェクト

    // Start is called before the first frame update
    void Start()
    {
        minMapLevel = SakakiharaMapLevelScript.MAPLevel;//他スクリプトからマップのレベル取得

        if (minMapLevel >= 3)
        {
            TreasureDisplay();
        }
    }

    private void TreasureDisplay()//宝の表示
    {
        GameObject treasureObj = Instantiate(treasurePrefab);//自分に生成
        treasureObj.transform.parent = this.transform;
        treasureObj.transform.localPosition = Vector3.zero;
    }
}
