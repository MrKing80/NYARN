using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinMapCameraScript : MonoBehaviour
{
    //MapCameraにつけるスクリプト
    //ミニマップと大きいマップ両方に表示する場合はレイヤーを「MinMap」にしてください
    //大きいマップに表示したくないものはレイヤーを「NotBegMap」にしてください


    [SerializeField] GameObject player;//追いかける対象

    [SerializeField] GameObject bigMapObject;//大きいマップ
    [SerializeField] GameObject minMapObject;//みにマップ
    [SerializeField] GameObject mapObject;//マップ

    private Camera cameraComponent;//カメラコンポーネント
    private float bigCameraSize = -47;//大きいマップのカメラ表示範囲
    private float minCameraSize = -15;//ミニマップのカメラ表示範囲
    Vector3 mapTransform;//マップの位置取得

    private bool isBigMap = false;//大きいマップ表示してるか
    private bool isBigMapFrag = false;//同じボタンで切り替えるためのフラグ


    private void Start()
    {
        cameraComponent = this.gameObject.GetComponent<Camera>();//カメラのカメラ取得
        bigMapObject.SetActive(false);//大きいマップ表示しない
        mapTransform = mapObject.transform.position;//map位置取得
    }
    void Update()
    {
        if (!isBigMap) //大きいマップ出して無い時
        {
            CameraMove();//プレイヤーにカメラがついていく
        }

        if (Input.GetKey(KeyCode.X))
        {
            if (!isBigMapFrag)
            {
                isBigMap = true;//大きいマップ表示してる判定

                cameraComponent.orthographicSize = bigCameraSize;//カメラの表示範囲を大きくする
                transform.position = new Vector3(mapTransform.x, mapTransform.y, transform.position.z);//カメラ固定
                cameraComponent.LayerCullingHide("NotBegMap"); // 指定したレイヤーを非表示

                minMapObject.SetActive(false);//みにマップ非表示
                bigMapObject.SetActive(true);//大きいマップ表示
            }

            if (isBigMapFrag)
            {
                isBigMap = false;//大きいマップ消してる判定

                cameraComponent.orthographicSize = minCameraSize;//カメラの表示範囲を戻す
                cameraComponent.LayerCullingShow("NotBegMap"); // 指定したレイヤーを表示

                bigMapObject.SetActive(false); //大きいマップ非表示
                minMapObject.SetActive(true);//みにマップ表示
            }
        }
       if (Input.GetKeyUp(KeyCode.X))
        {
            if (!isBigMap)
            {
                isBigMapFrag = false;//マップを表示するためのフラグ
            }
             if (isBigMap)
            {
                isBigMapFrag = true;//マップを消すためのフラグ
            }
        }

       
    }
    void CameraMove()//プレイヤー追尾
    {
        Vector3 playerPos = this.player.transform.position;

        transform.position = new Vector3(
            playerPos.x, playerPos.y, transform.position.z);//プレイヤーのについてくぞ☆
    }
}
