using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubInventory : MonoBehaviour
{
    /// <summary>
    /// �A�N�e�B�u�ɂȂ������ɌĂ΂��֐�
    /// </summary>
    private void OnEnable()
    {
        if (this.gameObject.activeSelf)
            Time.timeScale = 1f;

        print("InventoryBotton");
    }


}
