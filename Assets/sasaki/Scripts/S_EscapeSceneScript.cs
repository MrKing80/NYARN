using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class S_EscapeSceneScript : MonoBehaviour
{
    //出口につけるスクリプト
    //出口に触れたらシーン移動する

    [SerializeField] private TMP_Text clearUi;

    private void Start()
    {
        clearUi.enabled = false;   
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            clearUi.enabled = true;
            StartCoroutine(LoadScene());
        }
    }

    private IEnumerator LoadScene()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("MainGameScene");//すぐにシーン遷移するぞ
    }
}
