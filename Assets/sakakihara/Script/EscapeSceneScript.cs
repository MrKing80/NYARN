using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EscapeSceneScript : MonoBehaviour
{
    //出口につけるスクリプト
    //出口に触れたらシーン移動する

    //　8/22時点では自分のシーンをロードするようにしているよ

   private string sceneName;//シーン名取得用

    private void Start()
    {
         sceneName = SceneManager.GetActiveScene().name;//現ワールド名取得

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            SceneManager.LoadScene(sceneName);//すぐにシーン遷移するぞ
        }
    }

}
