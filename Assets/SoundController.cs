using UnityEngine;
using UnityEngine.UI;

public class SoundController : MonoBehaviour
{
    public Sprite currentSpr;
    public Sprite nextSpr;
    public AudioSource Audio;

    private Button btn;

    void Start()
    {
        btn = GetComponent<Button>();
    }

    public void Mute()
    {
        if (Audio.isPlaying)
            Audio.Pause();
        else
            Audio.Play();

        btn.image.overrideSprite = nextSpr;
        (currentSpr, nextSpr) = (nextSpr, currentSpr);
    }

}
