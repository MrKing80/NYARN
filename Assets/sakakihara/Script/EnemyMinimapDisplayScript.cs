using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMinimapDisplayScript : MonoBehaviour
{
    //�~�j�}�b�v�ɕ\�������邩
    //�x�����ɂ��Ă�

    //�uMinMapLevelScript�v���番��
    //���G�͈͂Ȃǎq�I�u�W�F�N�g������ꍇ������
    //�q�I�u�W�F�N�g�̖��O���u�@Light�@�v�ɂ��Ȃ��Ɠ����܂���

    private int minMapLevel;//�}�b�v�̃��x��

    [Header("�G�~�j�}�b�v�����p�I�u�W�F�N�g")]
    [SerializeField] GameObject enemyPrefab;//�G�����p�I�u�W�F�N�g
    [Header("���G�͈͐����p�I�u�W�F�N�g")]
    [SerializeField] GameObject lightPrefab;//���G�͈͐����p�I�u�W�F�N�g

    private GameObject gameObjectC;//�q�ł�����G�͈͎擾�p�I�u�W�F�N�g

    private bool isChild;//�q�I�u�W�F�N�g�L������

    private void Start()
    {

        if (transform.Find("Light").transform.IsChildOf(transform))//�q�I�u�W�F�N�g��("Light")�����邩
        {
            isChild = true;
            gameObjectC = transform.Find("Light").gameObject; ;//���G�͈̓I�u�W�F�N�g�擾
        }
        else
        {
            isChild = false;
        }

        minMapLevel = SakakiharaMapLevelScript.MAPLevel;//���X�N���v�g����}�b�v�̃��x���擾

        if (minMapLevel >= 1)
        {
            EnemyDisplay();
        }
        if (minMapLevel >= 2)
        {
            EnemySearchRangeDisplay();
        }
    }

    private void EnemyDisplay()//�G�̕\��
    {
           GameObject enemyObj = Instantiate(enemyPrefab);    //�����ɐ���
            enemyObj.transform.parent = this.transform;
            enemyObj.transform.localPosition = Vector3.zero;
    }

    private void EnemySearchRangeDisplay()//���G�͈�
    {
            GameObject lightObj = Instantiate(lightPrefab);//�����ɐ���
            lightObj.transform.parent = gameObjectC.transform;
            lightObj.transform.localPosition = Vector3.zero;
    }
}
