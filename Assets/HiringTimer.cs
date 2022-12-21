using UnityEngine;
using UnityEngine.UI;

public class HiringTimer : MonoBehaviour
{
    public float MaxTime;
    public bool isEnd;
    
    public bool hiring;

    private float currentTime;
    private Image img;

    // Start is called before the first frame update
    void Start()
    {
        img = GetComponent<Image>();
        hiring = false;
    }

    // Update is called once per frame
    private void Update()
    {
        isEnd = false;
        if (hiring)
        {
            Timer();
        }
    }
    private void Timer()
    {
        currentTime += Time.deltaTime;

        if (currentTime >= MaxTime)
        {
            currentTime = 0;
            hiring = false;
            isEnd = true;
            return;
        }

        img.fillAmount = currentTime / MaxTime;
    }

    public void StartHiring()
    {
        hiring = true;
        currentTime = 0;
    }
}
