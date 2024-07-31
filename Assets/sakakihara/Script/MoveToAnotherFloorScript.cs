using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToAnotherFloorScript : MonoBehaviour
{

    //FirstFloor�ȂǊK�i�O�ɂ���X�N���v�g
    //�ق��̊K�Ɉړ�

    [SerializeField] GameObject player;//�v���C���[
    [SerializeField] GameObject minMap;//  �~�j�}�b�v

    [Header("�K�w�Əo���ꏊ")]
    [SerializeField] GameObject firstFloorMap1;//��K
    [SerializeField] GameObject spawnPos1;//��K�o���ꏊ

    [SerializeField] GameObject secondFloorMap2;//��K
    [SerializeField] GameObject spawnPos2;//��K�o���ꏊ
    private void Start()
    {
        secondFloorMap2.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (this.tag == ("FirstFloor")) //��������K��������
            {
                firstFloorMap1.SetActive(false);
                minMap.SetActive(false);
                Invoke(nameof(MoveToTheSecondFloor),1f);//1�b��ɕ\��
            }

            if (this.tag == ("SecondFloor")) //��������K��������
            {
                secondFloorMap2.SetActive(false);
                minMap.SetActive(false);
                Invoke(nameof(MoveToTheFirstFloor), 1f);//1�b��ɕ\��
            }
        }
    }
    void MoveToTheSecondFloor()//2�K��\��
    {
        minMap.SetActive(true);
        secondFloorMap2.SetActive(true);
        player.transform.position = spawnPos2.transform.position;//�v���C���[��2�K�Ɉړ�
    }
    void MoveToTheFirstFloor()//1�K��\��
    {
        minMap.SetActive(true);
        firstFloorMap1.SetActive(true);
        player.transform.position = spawnPos1.transform.position;//�v���C���[��2�K�Ɉړ�
    }
}
