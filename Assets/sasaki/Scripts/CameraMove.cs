using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [Header ("�v���C���[������Ƃ�����`")]
    [SerializeField] private GameObject player = default;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPos = player.transform.position;  //�|�W�V�����擾

        this.transform.position = new Vector3(playerPos.x,playerPos.y,this.transform.position.z);   //�J�����̃|�W�V������ύX
    }
}
