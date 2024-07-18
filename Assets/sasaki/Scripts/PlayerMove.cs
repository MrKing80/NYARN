using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [Header("プレイヤーの速度調節するとこだよ～")]
    [SerializeField] private float speed = default;     //プレイヤーのスピード

    //private PlayerItemCatch itemCatch = default;

    private Rigidbody2D rig = default;                  //Rigidbody2Dを保存する変数

    private float inputX = 0f;      //横方向のインプットされた値を保持する変数
    private float inputY = 0f;      //縦方向のインプットされた値を保持する変数

    private bool isWallTouch = false;   //壁に触れているか

    //public float SpeedProperty
    //{
    //    get { return speed; }
    //    set { speed = value; }
    //}

    void Start()
    {
        rig = this.GetComponent<Rigidbody2D>();
        //itemCatch = this.GetComponent<PlayerItemCatch>();
    }

    // Update is called once per frame
    void Update()
    {
        //speed = SpeedProperty;

        inputX = Input.GetAxisRaw("Horizontal") * speed;    //プレイヤーの横方向の移動速度を格納
        inputY = Input.GetAxisRaw("Vertical") * speed;      //プレイヤーの縦方向の移動速度を格納

        rig.velocity = new Vector2(inputX, inputY);

        #region//プレイヤーのオブジェクトが手に入ったら調整必須

        //下の処理は移動に応じて角度が変わる処理　※ここから

        if (inputX > 0)
        {
            this.transform.rotation = Quaternion.Euler(0f, 0f, -90f);
        }
        else if (inputX < 0)
        {
            this.transform.rotation = Quaternion.Euler(0f, 0f, 90f);
        }

        if (inputY > 0)
        {
            this.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
        else if (inputY < 0)
        {
            this.transform.rotation = Quaternion.Euler(0f, 0f, 180f);
        }

        //※ここまで
        #endregion
    }
}
