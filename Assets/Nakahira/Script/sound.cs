using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class sound : MonoBehaviour
{
    static bool existsInstance = false;
    void Awake()
    {
        SoundEffects();
        if (existsInstance)
        {

            Destroy(gameObject);

            return;

        }



        existsInstance = true;

        DontDestroyOnLoad(gameObject);

    }

    // Update is called once per frame
    public void SoundEffects()
    {
        GetComponent<AudioSource>().Play();

    }
}
