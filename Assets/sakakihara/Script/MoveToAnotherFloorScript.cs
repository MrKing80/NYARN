using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToAnotherFloorScript : MonoBehaviour
{

    //FirstFloor�ȂǊK�i�O�ɂ���X�N���v�g
    //�ق��̊K�Ɉړ�
    [Header("�v���C���[")]
    [SerializeField] GameObject player;//�v���C���[
    [Header("�~�j�}�b�v�B�iMinMaps�j")]
    [SerializeField] GameObject minMap;//  �~�j�}�b�v
    [Header("�ǂݍ��ݔw�i�iLoadingBackground�j")]
    [SerializeField] GameObject loadingBackground;//�ǂݍ��ݔw�i
    private float loadingTime = 0.5f;//�ǂݍ��ݎ���

    [Header("�K�w�Əo���ꏊ")]
    [Header("��K")]
    [SerializeField] GameObject firstFloorMap1;//��K
    [SerializeField] GameObject spawnPos1;//��K�o���ꏊ
    [Header("��K")]
    [SerializeField] GameObject secondFloorMap2;//��K
    [SerializeField] GameObject spawnPos2;//��K�o���ꏊ

    private void Start()
    {
        loadingBackground.SetActive(false);//�ǂݍ��݉�ʔ�\��
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        player.SetActive(false);//�v���C���[��\��

        if (collision.CompareTag("Player"))
        {
            if (this.tag == ("FirstFloor")) //��������K��������
            {
                firstFloorMap1.SetActive(false);//�}�b�v��\��
                minMap.SetActive(false);//�~�j�}�b�v��\��

                loadingBackground.SetActive(true);//�ǂݍ��݉�ʕ\��

                Invoke(nameof(MoveToTheSecondFloor), loadingTime);//1�b��ɕ\��
            }

            if (this.tag == ("SecondFloor")) //������2�K��������
            {
                secondFloorMap2.SetActive(false);//�}�b�v��\��
                minMap.SetActive(false);//�~�j�}�b�v��\��

                loadingBackground.SetActive(true);//�ǂݍ��݉�ʕ\��

                Invoke(nameof(MoveToTheFirstFloor), loadingTime);//1�b��ɕ\��
            }
        }
    }

    private void MoveToTheSecondFloor()//2�K��\��
    {
        player.SetActive(true);//�v���C���[�\��
        player.transform.position = spawnPos2.transform.position;//�v���C���[��2�K�Ɉړ�

        minMap.SetActive(true);//�~�j�}�b�v��\��
        secondFloorMap2.SetActive(true);//1�K��\��

        loadingBackground.SetActive(false);//�ǂݍ��݉�ʔ�\��
    }

    private void MoveToTheFirstFloor()//1�K��\��
    {
        player.SetActive(true);//�v���C���[�\��
        player.transform.position = spawnPos1.transform.position;//�v���C���[��1�K�Ɉړ�

        minMap.SetActive(true);//�~�j�}�b�v��\��
        firstFloorMap1.SetActive(true);//1�K��\��

        loadingBackground.SetActive(false);//�ǂݍ��݉�ʔ�\��
    }
}
