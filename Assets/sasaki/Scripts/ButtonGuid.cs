using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonGuid : MonoBehaviour
{
    //ボタンヒントUIのオブジェクト格納
    private GameObject aButton = default;
    private void Awake()
    {
        aButton = GameObject.Find("AButton");   //ヒントオブジェクトを探して格納する
    }
    // Start is called before the first frame update
    void Start()
    {
        aButton.SetActive(false);   //非表示
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        //プレイヤーが触れていたらボタン表示
        if (collision.gameObject.CompareTag("Player"))
        {
            aButton.SetActive(true);
            aButton.transform.position = this.transform.position;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        //プレイヤーが離れたらボタン非表示
        if (collision.gameObject.CompareTag("Player"))
        {
            aButton.SetActive(false);
        }
    }
}
