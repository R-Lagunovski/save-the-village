using UnityEngine;
using UnityEngine.UI;

public class ButtoninteractableScript : MonoBehaviour
{
    private Button btn;

    public HiringTimer Timer;

    public GameScript Game;

    // Start is called before the first frame update
    void Start()
    {
        btn = GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!Timer.hiring)
        {
            if (btn.name.Contains("Settler"))
            {
                if (Game.wheatCount < Game.settlerCost)
                    btn.interactable = false;
                else
                    btn.interactable = true;

            }

            if (btn.name.Contains("Warrior"))
            {
                if (Game.wheatCount < Game.warriorCost)
                    btn.interactable = false;
                else
                    btn.interactable = true;

            }
        }
        
        
    }
}
