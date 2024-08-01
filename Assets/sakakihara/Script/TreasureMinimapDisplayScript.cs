using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureMinimapDisplayScript : MonoBehaviour
{
    //�~�j�}�b�v�ɕ\�������邩
    //��ɂ��Ă�

    //�uMinMapLevelScript�v���番��
    //�q�I�u�W�F�N�g���Ȃ��ꍇ������

    private int minMapLevel;//�}�b�v�̃��x��

    [Header("�u��v�����p�I�u�W�F�N�g")]
    [SerializeField] GameObject treasurePrefab;//�󐶐��p�I�u�W�F�N�g

    // Start is called before the first frame update
    void Start()
    {
        minMapLevel = SakakiharaMapLevelScript.MAPLevel;//���X�N���v�g����}�b�v�̃��x���擾

        if (minMapLevel >= 3)
        {
            TreasureDisplay();
        }
    }

    private void TreasureDisplay()//��̕\��
    {
        GameObject treasureObj = Instantiate(treasurePrefab);//�����ɐ���
        treasureObj.transform.parent = this.transform;
        treasureObj.transform.localPosition = Vector3.zero;
    }
}
