using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartFromTheBeginning : MonoBehaviour
{
    //タイトルのスタートボタンにつけるスクリプト


    private void Awake()
    {
        SceneManager.LoadSceneAsync("Volume_AND_Tutorial", LoadSceneMode.Additive);
    }

    public void FirstStageStarts()   //ボタン押したら
    {
        SceneManager.LoadScene("MainGameScene");//すぐにシーン遷移するぞ
    }
}
