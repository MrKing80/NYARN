using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [Header("�v���C���[�̑��x���߂���Ƃ�����`\\(^o^)/")]
    [SerializeField] private float speed = default;     //�v���C���[�̃X�s�[�h

    //private PlayerItemCatch itemCatch = default;

    private Rigidbody2D rig = default;                  //Rigidbody2D��ۑ�����ϐ�

    private Animator playerAnimator = default;

    private float inputX = 0f;      //�������̃C���v�b�g���ꂽ�l��ێ�����ϐ�
    private float inputY = 0f;      //�c�����̃C���v�b�g���ꂽ�l��ێ�����ϐ�

    private bool isWallTouch = false;   //�ǂɐG��Ă��邩

    PLAYER_STATUS state = PLAYER_STATUS.NULL;

    private enum PLAYER_STATUS
    {
        NULL,
        FORWARD,
        FORWARDWALK,
        LEFT,
        LEFTWALK,
        RIGHT,
        RIGHTWALK,
        BEHIND,
        BEHINDWALK,
    }

    /// <summary>
    /// �X�s�[�h���󂯓n���v���p�e�B
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
        if (Time.timeScale == 0)
        {
            return;
        }

        speed = SpeedProperty;

        inputX = Input.GetAxisRaw("Horizontal") * speed;    //�v���C���[�̉������̈ړ����x���i�[
        inputY = Input.GetAxisRaw("Vertical") * speed;      //�v���C���[�̏c�����̈ړ����x���i�[

        rig.velocity = new Vector2(inputX, inputY);

        MoveRotation();
    }

    private void MoveRotation()
    {

        if (inputX > 0)
        {
            state = PLAYER_STATUS.RIGHTWALK;
        }
        else if (inputX < 0)
        {
            state = PLAYER_STATUS.LEFTWALK;
        }

        if (inputY > 0)
        {
            state = PLAYER_STATUS.FORWARDWALK;
        }
        else if (inputY < 0)
        {
            state = PLAYER_STATUS.BEHINDWALK;
        }

        if(inputX == 0 && state == PLAYER_STATUS.LEFTWALK)
        {
            state = PLAYER_STATUS.LEFT;
        }
        else if(inputX == 0 && state == PLAYER_STATUS.RIGHTWALK)
        {
            state = PLAYER_STATUS.RIGHT;
        }

        if(inputY == 0 && state == PLAYER_STATUS.BEHINDWALK)
        {
            state = PLAYER_STATUS.BEHIND;
        }
        else if(inputY == 0 && state == PLAYER_STATUS.FORWARDWALK)
        {
            state = PLAYER_STATUS.FORWARD;
        }

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

        print(state);
    }
}
