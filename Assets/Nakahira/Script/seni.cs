using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class seni : MonoBehaviour
{
    static bool existsInstance = false;

    void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;  //sceneLoaded‚ÉŠÖ”‚ğ’Ç‰Á

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


    //ŠÖ”‚Ì’è‹`
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (SceneManager.GetActiveScene().name == "shop")
        {
            GameObject child = this.transform.Find("GameObject").gameObject;
            child.gameObject.SetActive(true);
        }
    }
}
