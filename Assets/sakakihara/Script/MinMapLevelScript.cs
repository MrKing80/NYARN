using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinMapLevelScript : MonoBehaviour
{
    //�~�j�}�b�v�ɕ\�������邩

    GameObject myGameObject;
    private int minMapLevel;

    //[SerializeField] GameObject enemyPrefab;//�����p�I�u�W�F�N�g

    [SerializeField] GameObject minMapObj;//�q�I�u�W�F�N�g
    SpriteRenderer minMapObjSpriteRenderer;//

    private void Awake()
    {

        minMapObj = this.gameObject.transform.GetChild(0).gameObject;//�q�I�u�W�F�N�g�擾
        minMapObjSpriteRenderer = minMapObj.GetComponent<SpriteRenderer>();
    }
    //void Start()
    //{
    //    //myGameObject = this.gameObject; //�����擾

    //    minMapObj = transform.GetChild(0).gameObject;//�q�I�u�W�F�N�g�擾
    //    minMapObjSpriteRenderer = minMapObj.GetComponent<SpriteRenderer>();
    
    //}

    // Update is called once per frame
    void Update()
    {
        minMapLevel = SakakiharaMapLevelScript.MAPLevel;
        switch (minMapLevel)
        {
            case 1:
                if (this.gameObject.CompareTag("Enemy"))
                {
                    //myGameObject = Instantiate(enemyPrefab);    //�����ɐ���

                    minMapObjSpriteRenderer.enabled = true;  // �q�I�u�W�F�N�g�L����
                }
                break;
            default:
                minMapObjSpriteRenderer.enabled = false;
                break;
        }


    }
}
