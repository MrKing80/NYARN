using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShutdownScript : MonoBehaviour
{
    [SerializeField] private float shutdownTime;    //ゲーム終了までの時間

    [SerializeField] private GameObject title;//タイトルアイテム
    [SerializeField] private GameObject confirmationScreen;//終了確認画面
    [SerializeField, Multiline(5)]//説明欄（４行）
    private string buttonMemo
        = ("ShouldIStopPlayingGames()   //ゲームやめるボタン押したら \n ShutdownYes()   //はい、やめます \n ShutdownNo()    //いいえ、やめません ");


    public void ShouldIStopPlayingGames()   //ゲームやめるボタン押したら
    {
        title.SetActive(false);
        confirmationScreen.SetActive(true);
    }

    public void ShutdownYes()   //はい、やめます
    {
        Invoke("GameShutdown", shutdownTime);
    }

    public void ShutdownNo()    //いいえ、やめません
    {
        title.SetActive(true);
        confirmationScreen.SetActive(false);
    }


    private void GameShutdown()
    {
        Application.Quit();     //ゲームを終了する
    }
}
