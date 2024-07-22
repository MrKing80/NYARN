using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class S_EscapeSceneScript : MonoBehaviour
{
    //出口につけるスクリプト
    //出口に触れたらシーン移動する

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            SceneManager.LoadScene("MainGameScene");//すぐにシーン遷移するぞ
        }
    }
}
