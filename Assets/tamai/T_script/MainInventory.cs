using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainInventory : MonoBehaviour
{
    /// <summary>
    /// アクティブになった時に呼ばれる関数
    /// </summary>
    void OnEnable()
    {
        if (this.gameObject.activeSelf)
            Time.timeScale = 0f;

        print("MainInventory");
    }
}
