using UnityEngine;

public class SoundSlider : MonoBehaviour
{
    public void SetBGMVolume(float volume)
    {
        // 0�`1�̊ԂŃ{�����[������
        SoundManager.instance.SetBGMVolume(volume);
    }
}
