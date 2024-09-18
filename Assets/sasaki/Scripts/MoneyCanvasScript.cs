using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoneyCanvasScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().name != "MainGameScene")
        {
            this.gameObject.GetComponent<Canvas>().enabled = false;
        }
        else
        {
            this.gameObject.GetComponent<Canvas>().enabled = true;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name != "MainGameScene")
        {
            this.gameObject.GetComponent<Canvas>().enabled = false;
        }
        else
        {
            this.gameObject.GetComponent<Canvas>().enabled = true;
        }

    }
}
