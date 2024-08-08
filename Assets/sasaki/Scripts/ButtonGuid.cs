using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonGuid : MonoBehaviour
{
    //�{�^���q���gUI�̃I�u�W�F�N�g�i�[
    private GameObject aButton = default;
    private void Awake()
    {
        aButton = GameObject.Find("AButton");   //�q���g�I�u�W�F�N�g��T���Ċi�[����
    }
    // Start is called before the first frame update
    void Start()
    {
        aButton.SetActive(false);   //��\��
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        //�v���C���[���G��Ă�����{�^���\��
        if (collision.gameObject.CompareTag("Player"))
        {
            aButton.SetActive(true);
            aButton.transform.position = this.transform.position;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        //�v���C���[�����ꂽ��{�^����\��
        if (collision.gameObject.CompareTag("Player"))
        {
            aButton.SetActive(false);
        }
    }
}
