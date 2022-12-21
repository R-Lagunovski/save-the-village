using UnityEngine;

public class CloseScreenScript : MonoBehaviour
{
    private GameObject currentScreen;

    void Start()
    {
        currentScreen = GetComponent<GameObject>();
    }

    // Update is called once per frame
    public void ChangeScreen(GameObject nextScreen)
    {
        currentScreen.SetActive(false);
        nextScreen.SetActive(true);        
    }
}
