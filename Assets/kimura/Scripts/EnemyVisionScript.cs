using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class EnemyVisionScript : MonoBehaviour
{
    public Vector2 VisionVec;//視線の向き
    public float _myRotation;//視線の角度
    public Transform VisionTrans;
    public bool isPatrol = true;
    private float _radians;//角度を向きに変換するための数値
    RaycastHit2D TestRay;//テスト用のレイ
    // Start is called before the first frame update
    void Start()
    {
        VisionTrans = this.GetComponent<Transform>();
        _myRotation = VisionTrans.rotation.z;//視線の角度を取得
    }

    // Update is called once per frame
    void Update()
    {
        if (isPatrol)
        {
            VisionControl();
        }
       
        if (Input.GetKeyDown(KeyCode.Return))//動作するか確かめるテスト
        {
            _myRotation += 90;
            print("おした");
            
        }
    }

    void VisionControl()
    {
        _radians = _myRotation * Mathf.Deg2Rad;//視線の角度を向きに変換
        VisionVec = new Vector2(Mathf.Cos(_radians), Mathf.Sin(_radians));//ラジアンから視線の向きを取得
    }
}
