using UnityEngine;
using UnityEngine.UI;

public class WarTimer : MonoBehaviour
{
    public float MaxTime;
    public bool isEnd;

    private float currentTime;
    private Image img;

    // Start is called before the first frame update
    void Start()
    {
        img = GetComponent<Image>();
        currentTime = MaxTime;

    }

    // Update is called once per frame
    void Update()
    {
        isEnd = false;
        currentTime -= Time.deltaTime;

        if (currentTime <= 0)
        {
            isEnd = true;
            currentTime = MaxTime;
        }

        img.fillAmount = currentTime / MaxTime;
    }
}
