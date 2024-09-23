using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToTitleButtonScript : MonoBehaviour
{
    //コンテニュー画面でのタイトル戻るかどうか
    //解釈違いのため没
    [SerializeField, Multiline(1)]//説明欄
    private string scriptMemo = ("コンテニュー画面でのタイトル戻るかどうか");

    [Header("ゲームに戻る？セットを入れる")]
    [SerializeField] private GameObject ReviveButtons;
    [Header("ほんとにタイトルに戻る？セットを入れる")]
    [SerializeField] private GameObject TitleButtons;

    [Header("ボタンメモ")]
    [SerializeField, Multiline(5)]//説明欄（４行）
    private string buttonsMemo = ("・GoBackToTheTitle() →復活しないを選択 \n ・IllStopAfterAll() //やっぱタイトル行くのやめる \n ・ReturnToTitle() //タイトルに戻るに同意 \n  \n");

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
        SceneManager.LoadScene("SampleTitle");//すぐにシーン遷移するぞ
    }
}
