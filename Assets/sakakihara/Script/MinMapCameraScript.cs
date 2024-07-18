using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinMapCameraScript : MonoBehaviour
{
    //MapCameraにつけるスクリプト

    [SerializeField] GameObject player;//追いかける対象

    [SerializeField] GameObject bigMapObject;//大きいマップ

    private Camera cameraComponent;//カメラコンポーネント
    private float bigCameraSize = -47;//大きいマップのカメラ表示範囲
    private float minCameraSize = -15;//ミニマップのカメラ表示範囲

    private float bigMapPg_x = 11.5f;//大きいマップ時のカメラ位置X
    private float bigMapPg_y = 25.6f;//大きいマップ時のカメラ位置Y

    private bool isBigMap = false;

    private void Start()
    {
        cameraComponent = this.gameObject.GetComponent<Camera>();
        bigMapObject.SetActive(false);
    }
    void Update()
    {
        if (!isBigMap) //大きいマップ出して無い時
        {
            CameraMove();//プレイヤーにカメラがついていく
        }

        if (Input.GetKey(KeyCode.X))
        {
            isBigMap = true;//大きいマップ表示してる判定
            bigMapObject.SetActive(true);//大きいマップ表示
            cameraComponent.orthographicSize = bigCameraSize;//カメラの表示範囲を大きくする
            transform.position = new Vector3(bigMapPg_x, bigMapPg_y, transform.position.z);//カメラ固定
        }

        if (Input.GetKey(KeyCode.C))
        {
            isBigMap = false;//大きいマップ消してる判定
            bigMapObject.SetActive(false); //大きいマップ消す
            cameraComponent.orthographicSize = minCameraSize;//カメラの表示範囲を戻す
        }




    }
    void CameraMove()//プレイヤー追尾
    {
        Vector3 playerPos = this.player.transform.position;

        transform.position = new Vector3(
            playerPos.x, playerPos.y, transform.position.z);//プレイヤーのについてくぞ☆
    }
}
