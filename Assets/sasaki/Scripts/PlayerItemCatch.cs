using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItemCatch : MonoBehaviour
{
    private GameObject item = default;      //�A�C�e�����i�[����ϐ�

    private bool isItemTouch = false;       //�A�C�e�����E���邩�ǂ���
    private bool isDoNotThrow = false;      //�A�C�e�����̂Ă��邩�ǂ���
    
    private int i = 0;      //���X�g�̓Y����

    private const int zero = 0;   //���X�g�̂O�Ԗڂ��w��

    [SerializeField] private List<GameObject> items = new List<GameObject>();    //�A�C�e���̃��X�g

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //�A�C�e���擾
        if(isItemTouch && (Input.GetKeyDown("joystick button 0") || Input.GetKeyDown(KeyCode.Mouse0)))
        {
            items.Add(item);                //���X�g�ǉ�
            items[i].SetActive(false);      //�A�C�e�����\��
            i++;                            //�C���N�������g
            print("�Ƃ����I");
        }

        //�A�C�e���̂Ă�
        if (!isDoNotThrow && (Input.GetKeyDown("joystick button 1") || Input.GetKeyDown(KeyCode.Mouse1)))
        {
            if (items[zero] != null)
            {
                items[zero].SetActive(true);        //�A�C�e���\��
                items[zero].transform.position = this.transform.position;   //�����̑����֗��Ƃ�
                items.Remove(items[zero]);          //���X�g����폜
                i--;                                //�f�N�������g
            }
        }

        //�Y�������}�C�i�X�ɂȂ�Ƃ�0�ɂ���
        if (i < zero)
        {
            i = zero;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Item"))
        {
            item = collision.gameObject;    //�G�ꂽ�A�C�e���̏��擾
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Item"))
        {
            isItemTouch = true;         //�G��Ă����Ԃɂ���
            isDoNotThrow = true;        //�A�C�e���𗎂Ƃ��Ȃ��悤�ɂ���
            print("�A�C�e���I");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Item"))
        {
            isItemTouch = false;        //�G��Ă��Ȃ���Ԃɂ���
            isDoNotThrow = false;       //�A�C�e���𗎂Ƃ��Ȃ��悤�ɂ���
            print("�A�C�e��....");
        }
    }
}
