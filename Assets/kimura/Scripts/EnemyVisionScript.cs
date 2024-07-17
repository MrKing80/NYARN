using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class EnemyVisionScript : MonoBehaviour
{
    public Vector2 VisionVec;//視線の向き
    private float _myRotation;//視線の角度
    private float _radians;//角度を向きに変換するための数値
    RaycastHit2D TestRay;//テスト用のレイ

    // Start is called before the first frame update
    void Start()
    {
        _myRotation = this.transform.rotation.z;//視線の角度を取得
    }

    // Update is called once per frame
    void Update()
    {
        _radians = _myRotation * Mathf.Deg2Rad;//視線の角度を向きに変換
        VisionVec = new Vector2(Mathf.Cos(_radians), Mathf.Sin(_radians));//ラジアンから視線の向きを取得
        TestRay = Physics2D.Raycast(this.transform.position, VisionVec, 5f);
        Debug.DrawRay(this.transform.position, VisionVec * 10f, Color.green);
        if (Input.GetKeyDown(KeyCode.Return))//動作するか確かめるテスト
        {
            _myRotation += 90;
            print("おした");
        }
    }
}
