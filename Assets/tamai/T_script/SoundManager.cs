using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    // シングルトン用にスタティック
    public static SoundManager instance;
    [SerializeField] private AudioSource bgmAudioSource;

    void Awake()
    {
        // シングルトン
        if(instance == null)
        {
            instance = this;
            // シーンを跨いでも音量を引継ぎできる。
            DontDestroyOnLoad(gameObject);
        } else
        {
            Destroy(gameObject);
        }
    }
    
    public void SetBGMVolume(float volume)
    {
        // スライダーと連携して音量の調節
        bgmAudioSource.volume = volume;
    }
}
