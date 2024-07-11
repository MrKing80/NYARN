using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float speed = default;     //�v���C���[�̃X�s�[�h

    private Rigidbody2D rig = default;                  //Rigidbody2D��ۑ�����ϐ�
    private Vector3 wallPos = default;                  
    private float inputX = 0f;      //�������̃C���v�b�g���ꂽ�l��ێ�����ϐ�
    private float inputY = 0f;      //�c�����̃C���v�b�g���ꂽ�l��ێ�����ϐ�

    private bool isWallTouch = false;   //�ǂɐG��Ă��邩
    // Start is called before the first frame update
    void Start()
    {
        rig = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        inputX = Input.GetAxisRaw("Horizontal") * speed;    //�v���C���[�̉������̈ړ����x���i�[
        inputY = Input.GetAxisRaw("Vertical") * speed;      //�v���C���[�̏c�����̈ړ����x���i�[

        //rig.velocity = new Vector2(inputX, inputY) * Time.deltaTime;
        #region//�v���C���[�̃I�u�W�F�N�g����ɓ������璲���K�{
        
        //���̏����͈ړ��ɉ����Ċp�x���ς�鏈���@����������

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

        //�������܂�
        #endregion

        if (!isWallTouch)
        {
            this.transform.position += (new Vector3(inputX, inputY) * Time.deltaTime);  //�ǂɐG��Ă��Ȃ���Έړ�
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
