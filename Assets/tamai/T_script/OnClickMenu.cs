using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClickMenu : MonoBehaviour
{
    public GameObject inventory;
    [SerializeField] private GameObject botton;
    [SerializeField] private bool isTrigger = true;
    [SerializeField] private bool isTrigger2 = false;

    private void Start()
    {
        botton = GameObject.FindGameObjectWithTag("MainInventoryBotton");
    }

    private void Update()
    {
        OnClickCheck();
    }

    private void OnClickCheck()
    {
        if (Input.GetKeyDown(KeyCode.C) || Input.GetKeyDown(KeyCode.Tab))
        {
            if (isTrigger)
            {
                inventory.gameObject.SetActive(isTrigger);
                botton.gameObject.SetActive(isTrigger2);
            }
            else if(!isTrigger)
            {
                inventory.gameObject.SetActive(isTrigger);
                botton.gameObject.SetActive(isTrigger2);
            }

            isTrigger = !isTrigger;
            isTrigger2 = !isTrigger2;
        }
    }
}
