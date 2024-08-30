using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InveMag : MonoBehaviour
{
    public GameObject invetoryMenu;
    private bool menuActivated;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L) && menuActivated)
        {
            invetoryMenu.SetActive(false);
            menuActivated = false;
        }

        if (Input.GetKeyDown(KeyCode.L) && !menuActivated)
        {
            invetoryMenu.SetActive(true);
            menuActivated = true;
        }
    }
}
