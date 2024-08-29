using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToTitleButtonScript : MonoBehaviour
{
    //コンテニュー画面でのタイトル戻るかどうか
    //解釈違いのため没

   [SerializeField] private GameObject ReviveButtons;
   [SerializeField] private GameObject TitleButtons;
    [SerializeField, Multiline(5)]//説明欄（４行）
    private string layerMemo = ("GoBackToTheTitle()//復活しないを選択 \n IllStopAfterAll()//やっぱタイトル行くのやめる \n ReturnToTitle()//タイトルに戻るに同意 \n 0 \n");

    public void GoBackToTheTitle()//復活しないを選択
    {
        ReviveButtons.SetActive(false);
        TitleButtons.SetActive(true);
    }
    public void IllStopAfterAll()//やっぱタイトル行くのやめる
    {
        ReviveButtons.SetActive(true);
        TitleButtons.SetActive(false);
    }

    public void ReturnToTitle()//タイトルに戻るに同意
    {
        SceneManager.LoadScene("TitleScene");//すぐにシーン遷移するぞ
    }
}
