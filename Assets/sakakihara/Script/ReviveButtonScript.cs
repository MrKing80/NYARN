using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReviveButtonScript : MonoBehaviour
{
    //コンテニュー画面を消すためのスクリプト
    //解釈違いのため没
    [SerializeField, Multiline(1)]//説明欄
    private string scriptMemo = ("コンテニュー画面を消すためのスクリプト");


    public void Onclick()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainGameScene");//Yes押したらコンテニュー画面消す
    }
}
