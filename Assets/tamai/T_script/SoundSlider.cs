using UnityEngine;

public class SoundSlider : MonoBehaviour
{
    public void SetBGMVolume(float volume)
    {
        // 0`1‚ÌŠÔ‚Åƒ{ƒŠƒ…[ƒ€’²®
        SoundManager.instance.SetBGMVolume(volume);
    }
}
