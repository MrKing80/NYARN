using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonGuid : MonoBehaviour
{
    private GameObject aButton = default;

    private void Awake()
    {
        aButton = GameObject.Find("AButton");
    }
    // Start is called before the first frame update
    void Start()
    {
        aButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            aButton.SetActive(true);
            aButton.transform.position = this.transform.position;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            aButton.SetActive(false);
        }
    }
}
