using UnityEngine;

public class SoundSlider : MonoBehaviour
{
    public void SetBGMVolume(float volume)
    {
        // 0〜1の間でボリューム調整
        SoundManager.instance.SetBGMVolume(volume);
    }
}
