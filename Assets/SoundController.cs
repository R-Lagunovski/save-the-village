using UnityEngine;
using UnityEngine.UI;

public class SoundController : MonoBehaviour
{
    public Sprite currentSpr;
    public Sprite nextSpr;
    public AudioListener Audio;

    private Button btn;

    void Start()
    {
        btn = GetComponent<Button>();
    }

    public void Mute()
    {
        if (Audio.enabled)
            Audio.enabled = false;
        else
            Audio.enabled = true;

        btn.image.overrideSprite = nextSpr;
        (currentSpr, nextSpr) = (nextSpr, currentSpr);
    }

}
