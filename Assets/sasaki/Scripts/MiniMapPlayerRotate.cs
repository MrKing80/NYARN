using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMapPlayerRotate : MonoBehaviour
{
    private float inputX = 0f;      //横方向のインプットされた値を保持する変数
    private float inputY = 0f;      //縦方向のインプットされた値を保持する変数

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        inputX = Input.GetAxisRaw("Horizontal");   //プレイヤーの横方向の値を格納
        inputY = Input.GetAxisRaw("Vertical");      //プレイヤーの縦方向の値を格納

        //プレイヤーが横方向に移動したとき方向に応じて回転
        if (inputX > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, -90);
        }
        else if (inputX < 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 90);
        }

        //プレイヤーが縦方向に移動したとき方向に応じて回転
        if(inputY > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if(inputY < 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 180);
        }
    }

}
