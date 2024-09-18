using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    // �V���O���g���p�ɃX�^�e�B�b�N
    public static SoundManager instance;
    [SerializeField] private AudioSource bgmAudioSource;

    void Awake()
    {
        // �V���O���g��
        if(instance == null)
        {
            instance = this;
            // �V�[�����ׂ��ł����ʂ����p���ł���B
            DontDestroyOnLoad(gameObject);
        } else
        {
            Destroy(gameObject);
        }
    }
    
    public void SetBGMVolume(float volume)
    {
        // �X���C�_�[�ƘA�g���ĉ��ʂ̒���
        bgmAudioSource.volume = volume;
    }
}
