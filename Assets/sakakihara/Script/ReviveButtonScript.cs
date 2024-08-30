using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReviveButtonScript : MonoBehaviour
{
    //コンテニュー画面を消すためのスクリプト
    //解釈違いのため没

    public void Onclick()
    {
        Time.timeScale = 1;
        SceneManager.UnloadSceneAsync("ContinuationScenes");//Yes押したらコンテニュー画面消す
    }
}
