using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float MaxTime;
    public bool isEnd;

    private float currentTime;
    private Image img;

    // Start is called before the first frame update
    void Start()
    {
        img = GetComponent<Image>();
        currentTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        isEnd = false;
        currentTime += Time.deltaTime;

        if (currentTime >= MaxTime)
        {
            isEnd = true;
            currentTime = 0;
        }

        img.fillAmount = currentTime / MaxTime;
    }
}
