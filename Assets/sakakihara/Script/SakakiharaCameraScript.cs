using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SakakiharaCameraScript : MonoBehaviour
{
    //カメラにつけるスクリプト
    //メインカメラに仮でつけてるカメラ移動スクリプト
    //MapCameraにつけるスクリプト


    [SerializeField] GameObject player;

    void Update()
    {
        Vector3 playerPos = this.player.transform.position;

        transform.position = new Vector3(
            playerPos.x, playerPos.y, transform.position.z);//プレイヤーのについてくぞ☆

    }
}
