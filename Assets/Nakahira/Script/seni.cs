using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class seni : MonoBehaviour
{
    static bool existsInstance = false;

    void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;  //sceneLoadedに関数を追加

    }
    void Awake()
    {

        if (existsInstance)
        {

            Destroy(gameObject);

            return;

        }



        existsInstance = true;

        DontDestroyOnLoad(gameObject);

    }
    private void Update()
    {
        

    }


    //関数の定義
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (SceneManager.GetActiveScene().name == "shop")
        {
            GameObject child = this.transform.Find("GameObject").gameObject;
            child.gameObject.SetActive(true);
        }
    }
}
