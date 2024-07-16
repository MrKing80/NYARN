using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SakakiharaCameraScript : MonoBehaviour
{
    //仮でつけたカメラ移動スクリプト

    [SerializeField] GameObject player;

    void Update()
    {
        Vector3 playerPos = this.player.transform.position;

            transform.position = new Vector3(
                playerPos.x, playerPos.y, transform.position.z);//プレイヤーのについてくぞ☆

    }
}
