using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainInventory : MonoBehaviour
{
    /// <summary>
    /// �A�N�e�B�u�ɂȂ������ɌĂ΂��֐�
    /// </summary>
    void OnEnable()
    {
        if (this.gameObject.activeSelf)
            Time.timeScale = 0f;

        print("MainInventory");
    }
}
