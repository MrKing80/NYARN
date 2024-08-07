using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{    
    [SerializeField,Header("ポーズメニューのオブジェクトを入れるところだよー")] private GameObject pauseCanvas = default;
    
    //ポーズオブジェクトを格納する変数
    private GameObject pause = default;
    
    //ポーズしているか
    private bool isPause = false;
    // Start is called before the first frame update
    void Start()
    {
        pause = Instantiate(pauseCanvas, transform.position, Quaternion.identity);  //ポーズオブジェクト生成
        pause.SetActive(false); //非表示
    }

    // Update is called once per frame
    void Update()
    {
        //スタートボタンもしくはESCキー
        if (Input.GetKeyDown("joystick button 7") || Input.GetKeyDown(KeyCode.Escape))
        {
            //一時停止していたら一時停止をやめる
            if(isPause)
            {
                pause.SetActive(false);
                Time.timeScale = 1;
                isPause = false;
            }
            //一時停止していなければ一時停止をする
            else if(!isPause)
            {
                pause.SetActive(true);
                Time.timeScale = 0;
                isPause = true;
            }
        }
    }
}
