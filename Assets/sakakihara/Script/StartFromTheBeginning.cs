using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartFromTheBeginning : MonoBehaviour
{
    //タイトルのスタートボタンにつけるスクリプト
    [SerializeField, Multiline(1)]//説明欄
    private string scriptMemo = ("ボタンを押したらすぐゲームが始まるスクリプト");

    private void Awake()
    {
        SceneManager.LoadSceneAsync("Volume_AND_Tutorial", LoadSceneMode.Additive);
    }

    public void FirstStageStarts()   //ボタン押したら
    {
        SceneManager.LoadScene("MainGameScene");//すぐにシーン遷移するぞ
    }
}
