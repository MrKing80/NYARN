using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [Header("プレイヤーの速度調節するとこだよ～\\(^o^)/")]
    [SerializeField] private float speed = default;     //プレイヤーのスピード

    //private PlayerItemCatch itemCatch = default;

    private Rigidbody2D rig = default;                  //Rigidbody2Dを保存する変数

    private Animator playerAnimator = default;

    private float inputX = 0f;      //横方向のインプットされた値を保持する変数
    private float inputY = 0f;      //縦方向のインプットされた値を保持する変数

    private bool isWallTouch = false;   //壁に触れているか

    PLAYER_STATUS state = default;

    /// <summary>
    /// プレイヤーのアニメーションの遷移先を決める列挙型定数
    /// </summary>
    private enum PLAYER_STATUS
    {
        FORWARD,        //前向き
        FORWARDWALK,    //前向きに歩く
        LEFT,           //左向き
        LEFTWALK,       //左向きに歩く
        RIGHT,          //右向き
        RIGHTWALK,      //右向きに歩く
        BEHIND,         //後ろ向き
        BEHINDWALK,     //後ろ向きに歩く
    }

    /// <summary>
    /// スピードを受け渡すプロパティ
    /// </summary>
    public float SpeedProperty
    {
        get { return speed; }
        set { speed = value; }
    }

    void Start()
    {
        rig = this.GetComponent<Rigidbody2D>();
        playerAnimator = this.GetComponent<Animator>();
        //itemCatch = this.GetComponent<PlayerItemCatch>();
    }

    // Update is called once per frame
    void Update()
    {
        //一時停止されていたら処理をしない
        if (Time.timeScale == 0)
        {
            return;
        }

        speed = SpeedProperty;

        inputX = Input.GetAxisRaw("Horizontal") * speed;    //プレイヤーの横方向の移動速度を格納
        inputY = Input.GetAxisRaw("Vertical") * speed;      //プレイヤーの縦方向の移動速度を格納

        rig.velocity = new Vector2(inputX, inputY);

        MoveRotation();
    }

    /// <summary>
    /// プレイヤーの向きとアニメーションのステータスを決める関数
    /// </summary>
    private void MoveRotation()
    {
        //プレイヤーが横方向に移動したとき方向に応じてプレイヤーのステータスを変更
        if (inputX > 0)
        {
            state = PLAYER_STATUS.RIGHTWALK;
        }
        else if (inputX < 0)
        {
            state = PLAYER_STATUS.LEFTWALK;
        }

        //プレイヤーが縦方向に移動したとき方向に応じてプレイヤーのステータスを変更
        if (inputY > 0)
        {
            state = PLAYER_STATUS.FORWARDWALK;
        }
        else if (inputY < 0)
        {
            state = PLAYER_STATUS.BEHINDWALK;
        }

        //プレイヤーが横方向の移動をやめたときプレイヤーのステータスに応じてステータスを変更
        if(inputX == 0 && state == PLAYER_STATUS.LEFTWALK)
        {
            state = PLAYER_STATUS.LEFT;
        }
        else if(inputX == 0 && state == PLAYER_STATUS.RIGHTWALK)
        {
            state = PLAYER_STATUS.RIGHT;
        }

        //プレイヤーが縦方向の移動をやめたときプレイヤーのステータスに応じてステータスを変更
        if (inputY == 0 && state == PLAYER_STATUS.BEHINDWALK)
        {
            state = PLAYER_STATUS.BEHIND;
        }
        else if(inputY == 0 && state == PLAYER_STATUS.FORWARDWALK)
        {
            state = PLAYER_STATUS.FORWARD;
        }

        //プレイヤーのステータスに応じてアニメーションを切り替える
        switch (state)
        {
            case PLAYER_STATUS.FORWARD:
                playerAnimator.SetBool("forward", true);
                playerAnimator.SetBool("forwardwalk", false);
                playerAnimator.SetBool("left", false);
                playerAnimator.SetBool("leftwalk", false);
                playerAnimator.SetBool("right", false);
                playerAnimator.SetBool("rightwalk", false);
                playerAnimator.SetBool("behind", false);
                playerAnimator.SetBool("behindwalk", false);
                break;

            case PLAYER_STATUS.FORWARDWALK:
                playerAnimator.SetBool("forward", false);
                playerAnimator.SetBool("forwardwalk", true);
                playerAnimator.SetBool("left", false);
                playerAnimator.SetBool("leftwalk", false);
                playerAnimator.SetBool("right", false);
                playerAnimator.SetBool("rightwalk", false);
                playerAnimator.SetBool("behind", false);
                playerAnimator.SetBool("behindwalk", false);
                break;

            case PLAYER_STATUS.LEFT:
                playerAnimator.SetBool("forward", false);
                playerAnimator.SetBool("forwardwalk", false);
                playerAnimator.SetBool("left", true);
                playerAnimator.SetBool("leftwalk", false);
                playerAnimator.SetBool("right", false);
                playerAnimator.SetBool("rightwalk", false);
                playerAnimator.SetBool("behind", false);
                playerAnimator.SetBool("behindwalk", false);
                break;

            case PLAYER_STATUS.LEFTWALK:
                playerAnimator.SetBool("forward", false);
                playerAnimator.SetBool("forwardwalk", false);
                playerAnimator.SetBool("left", false);
                playerAnimator.SetBool("leftwalk", true);
                playerAnimator.SetBool("right", false);
                playerAnimator.SetBool("rightwalk", false);
                playerAnimator.SetBool("behind", false);
                playerAnimator.SetBool("behindwalk", false);
                break;

            case PLAYER_STATUS.RIGHT:
                playerAnimator.SetBool("forward", false);
                playerAnimator.SetBool("forwardwalk", false);
                playerAnimator.SetBool("left", false);
                playerAnimator.SetBool("leftwalk", false);
                playerAnimator.SetBool("right", true);
                playerAnimator.SetBool("rightwalk", false);
                playerAnimator.SetBool("behind", false);
                playerAnimator.SetBool("behindwalk", false);
                break;

            case PLAYER_STATUS.RIGHTWALK:
                playerAnimator.SetBool("forward", false);
                playerAnimator.SetBool("forwardwalk", false);
                playerAnimator.SetBool("left", false);
                playerAnimator.SetBool("leftwalk", false);
                playerAnimator.SetBool("right", false);
                playerAnimator.SetBool("rightwalk", true);
                playerAnimator.SetBool("behind", false);
                playerAnimator.SetBool("behindwalk", false);
                break;

            case PLAYER_STATUS.BEHIND:
                playerAnimator.SetBool("forward", false);
                playerAnimator.SetBool("forwardwalk", false);
                playerAnimator.SetBool("left", false);
                playerAnimator.SetBool("leftwalk", false);
                playerAnimator.SetBool("right", false);
                playerAnimator.SetBool("rightwalk", false);
                playerAnimator.SetBool("behind", true);
                playerAnimator.SetBool("behindwalk", false);
                break;

            case PLAYER_STATUS.BEHINDWALK:
                playerAnimator.SetBool("forward", false);
                playerAnimator.SetBool("forwardwalk", false);
                playerAnimator.SetBool("left", false);
                playerAnimator.SetBool("leftwalk", false);
                playerAnimator.SetBool("right", false);
                playerAnimator.SetBool("rightwalk", false);
                playerAnimator.SetBool("behind", false);
                playerAnimator.SetBool("behindwalk", true);
                break;

            default:
                playerAnimator.SetBool("forward", false);
                playerAnimator.SetBool("forwardwalk", false);
                playerAnimator.SetBool("left", false);
                playerAnimator.SetBool("leftwalk", false);
                playerAnimator.SetBool("right", false);
                playerAnimator.SetBool("rightwalk", false);
                playerAnimator.SetBool("behind", false);
                playerAnimator.SetBool("behindwalk", false);
                break;
        }
    }
}
