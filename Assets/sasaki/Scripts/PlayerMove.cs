using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float speed = default;     //プレイヤーのスピード

    private Rigidbody2D rig = default;                  //Rigidbody2Dを保存する変数
    private Vector3 wallPos = default;                  
    private float inputX = 0f;      //横方向のインプットされた値を保持する変数
    private float inputY = 0f;      //縦方向のインプットされた値を保持する変数

    private bool isWallTouch = false;   //壁に触れているか
    // Start is called before the first frame update
    void Start()
    {
        rig = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        inputX = Input.GetAxisRaw("Horizontal") * speed;    //プレイヤーの横方向の移動速度を格納
        inputY = Input.GetAxisRaw("Vertical") * speed;      //プレイヤーの縦方向の移動速度を格納

        //rig.velocity = new Vector2(inputX, inputY) * Time.deltaTime;
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

        if (!isWallTouch)
        {
            this.transform.position += (new Vector3(inputX, inputY) * Time.deltaTime);  //壁に触れていなければ移動
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall") || collision.gameObject.CompareTag("Obstacle"))
        {
            wallPos = collision.transform.position;
            isWallTouch = true;
        }

    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Wall") || collision.gameObject.CompareTag("Obstacle"))
        {
            isWallTouch = false;
        }
    }
}
