using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class SakakiharaGameOver : MonoBehaviour
{
    //コンテニュー画面を出すためのスクリプト
    //解釈違いのため没

    [SerializeField] private TMP_Text gameOverUI;//ゲームオーバーテキストを入れる
    [SerializeField] private float TimeToDisplay;//コンテニュー出すまでの時間

    private bool isTr = false;//コンテニュー画面が出ているのか確認

    void Update()
    {
        if (isTr)//コンテニュー画面出していたら出さないようにする
        {
            return;
        }
        if (gameOverUI.enabled)//ゲームオーバー出てるときにコンテニュー画面出す
        {
            Invoke("ContinuationStart", TimeToDisplay);
            isTr = true;
        }
        else
        {
            isTr = false;
            
        }


    }
    private void ContinuationStart()    //他のスクリプト上に出す
    {
        gameOverUI.enabled = false;
        SceneManager.LoadSceneAsync("ContinuationScenes", LoadSceneMode.Additive);
    }
}

