using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubInventory : MonoBehaviour
{
    /// <summary>
    /// アクティブになった時に呼ばれる関数
    /// </summary>
    private void OnEnable()
    {
        if (this.gameObject.activeSelf)
            Time.timeScale = 1f;

        print("InventoryBotton");
    }


}
