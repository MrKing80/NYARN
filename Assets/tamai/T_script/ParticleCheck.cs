using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleCheck : MonoBehaviour
{
    [SerializeField] private bool isItemObj = true;

    private void FixedUpdate()
    {
        // 子オブジェクトのコライダー取得
        isItemObj = this.GetComponentInChildren<CircleCollider2D>().enabled;

        // trueの時はリターン、falseの時は見えなくする
        if (isItemObj) return;
        this.gameObject.SetActive(false);
    }
}
