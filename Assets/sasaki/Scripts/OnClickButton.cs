using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


/// <summary>
/// ポーズメニューのボタンに使うスクリプト
/// </summary>
public class OnClickButton : MonoBehaviour
{
    /// <summary>
    /// タイトルへ戻るボタン用の関数
    /// </summary>
    public void GoToTitle()
    {
        SceneManager.LoadScene("SampleTitle");
    }

    /// <summary>
    /// 再開する用の変数
    /// </summary>
    public void RetrunToGame()
    {
        Time.timeScale = 1;
        this.gameObject.SetActive(false);
    }
}
