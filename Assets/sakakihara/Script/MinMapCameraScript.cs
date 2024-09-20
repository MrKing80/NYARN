using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinMapCameraScript : MonoBehaviour
{
    //MapCameraにつけるスクリプト
    //ミニマップと大きいマップ両方に表示する場合はレイヤーを「MinMap」にしてください
    //大きいマップに表示したくないものはレイヤーを「NotBegMap」にしてください

    [Header("ミニマップで追尾する対象")]
    [SerializeField] GameObject player;//追いかける対象

    [Header("大きいマップ")]
    [SerializeField] GameObject bigMapObject;//大きいマップ
    [Header("小さいマップ")]
    [SerializeField] GameObject minMapObject;//みにマップ
    [Header("タイルマップで作ったMapを入れる")]
    [SerializeField] GameObject mapObject;//マップ

    private Camera cameraComponent;//カメラコンポーネント
    private float bigCameraSize = -47;//大きいマップのカメラ表示範囲
    private float minCameraSize = -15;//ミニマップのカメラ表示範囲
    Vector3 mapTransform;//マップの位置取得

    private bool isBigMap = false;//大きいマップ表示してるか
    private bool isBigMapFrag = false;//同じボタンで切り替えるためのフラグ

    //回転用
    //Vector3 playerRotationPos;
    //float roPog;

    private void Start()
    {
        cameraComponent = this.gameObject.GetComponent<Camera>();//カメラのCamera取得
        bigMapObject.SetActive(false);//大きいマップ表示しない
        mapTransform = mapObject.transform.position;//投影するmap位置取得
    }
    void Update()
    {

        if (!isBigMap) //大きいマップ出して無い時
        {
            CameraMove();//プレイヤーにカメラがついていく
            //CameraRotation();//マップ回転用
        }

        if (Input.GetKeyDown(KeyCode.C) || Input.GetKeyDown(KeyCode.Tab) || Input.GetKeyDown("joystick button 6"))//キー押したら
        {
            if (!isBigMapFrag)
            {
                BigMap();
            }

            if (isBigMapFrag)
            {
                NotBigMap();
            }
        }
        if (Input.GetKey(KeyCode.C) || Input.GetKey(KeyCode.Tab) || Input.GetKeyDown("joystick button 6"))
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

    private void CameraMove()//プレイヤー追尾
    {
        Vector3 playerPos = this.player.transform.position;

        transform.position = new Vector3(playerPos.x, playerPos.y, transform.position.z);//プレイヤーのについてくぞ☆
    }

    private void BigMap()//大きいマップ表示
    {
        isBigMap = true;//大きいマップ表示してる判定
        Time.timeScale = 0;
        cameraComponent.orthographicSize = bigCameraSize;//カメラの表示範囲を大きくする
        transform.position = new Vector3(mapTransform.x, mapTransform.y, transform.position.z);//カメラ固定
        cameraComponent.LayerCullingHide("NotBigMap"); // 指定したレイヤーを非表示

        minMapObject.SetActive(false);//みにマップ非表示
        bigMapObject.SetActive(true);//大きいマップ表示
    }

    void NotBigMap()//大きいマップ消してる
    {
        isBigMap = false;//大きいマップ消してる判定
        Time.timeScale = 1;
        cameraComponent.orthographicSize = minCameraSize;//カメラの表示範囲を戻す
        cameraComponent.LayerCullingShow("NotBigMap"); // 指定したレイヤーを表示

        bigMapObject.SetActive(false); //大きいマップ非表示
        minMapObject.SetActive(true);//みにマップ表示
    }
    //private void CameraRotation() //マップ回転用　※プレイヤーが→を向いた際回転し続けるためコメント化
    //{
    //    //☆
    //    Vector3 playerRotationPos = this.player.transform.eulerAngles;
    //    Vector3 cameraRotationPos = this.gameObject.transform.eulerAngles;
    //    //☆

    //    //Vector3 roPos = new Vector3(0, 0, playerRotationPos.z);

    //    //☆
    //    if (cameraRotationPos.z - 180f == playerRotationPos.z)
    //    {
    //        return;
    //    }
    //    else if (cameraRotationPos.z - 180f > playerRotationPos.z - 1f)//0=180-180
    //    {
    //        //transform.Translate(new Vector3(0, 0, -1) * Time.deltaTime);
    //        roPog -= Time.deltaTime * 90;//反時計回り
    //                                     //Time.deltaTime * 20f;
    //        this.gameObject.transform.rotation = Quaternion.Euler(0, 0, roPog);
    //    }
    //    else if (cameraRotationPos.z - 180f < playerRotationPos.z - 1f)
    //    {
    //        //transform.Translate(Vector3.back * Time.deltaTime);
    //        roPog += Time.deltaTime * 90;//時計回り
    //        //Time.deltaTime * 20f;
    //        this.gameObject.transform.rotation = Quaternion.Euler(0, 0, roPog);
    //    }
    //    //☆

    //    //transform.rotation = Quaternion.Euler(0, 0, playerRotationPos.z - 180f);//☆

    //    //Quaternion rot = Quaternion.LookRotation(roPos);

    //    //rot = Quaternion.Slerp(this.transform.rotation, rot, Time.deltaTime * 2f);
    //    //this.transform.rotation = rot;
    //}
}
