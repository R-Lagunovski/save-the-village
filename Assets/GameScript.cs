using System.Runtime.ExceptionServices;
using UnityEngine;
using UnityEngine.UI;

public class GameScript : MonoBehaviour
{
    public Timer YearTimer;
    public Timer FoodTimer;
    public HiringTimer SettlerTimer;
    public HiringTimer WarriorTimer;
    public WarTimer WarTimer;

    public Image YearTimerImage;
    public Image FoodTimerImage;
    public Image WarTimerImage;

    public Text SettlerText;
    public Text WheatText;
    public Text WarriorText;
    public Text WarEnemyText;
    public Text FirstWaveNumberText;
    public Text FirstWaveText;

    public Text SettlerLoseText;
    public Text WaveLoseText;
    public Text WarriorLoseText;

    public Text SettlerWinText;
    public Text WaveWinText;
    public Text WarriorWinText;

    public GameObject LoseCanvas;
    public GameObject WinCanvas;
    public GameObject GameCanvas;
    public GameObject WarTextObject;

    public Button SettlerButton;
    public Button WarriorButton;

    public int settlersCount;
    public int warriorCount;
    public int wheatCount;
    public int enemyCount;
    public int firstWaveWithEnemy;

    public int wheatForYear;
    public int foodForYear;

    public int settlerCost;
    public int warriorCost;

    private int wave;

    public AudioSource SettlerAudio;
    public AudioSource WheatAudio;
    public AudioSource WarriorAudio;
    public AudioSource WarAudio;
    public AudioSource FoodAudio;


    [SerializeField] private StateMachine StateMachine;


    void Start()
    {
        wave = 1;
        SettlerText.text = settlersCount.ToString();
        WarriorText.text = warriorCount.ToString();
        WheatText.text = wheatCount.ToString();
        WarEnemyText.text = enemyCount.ToString();
        FirstWaveNumberText.text = firstWaveWithEnemy.ToString();
    }

    void Update()
    {
        if (YearTimer.isEnd)
        {
            wheatCount += settlersCount * wheatForYear;
            WheatText.text = wheatCount.ToString();
            WheatAudio.Play();
        }

        if (FoodTimer.isEnd)
        {
            FoodAudio.Play();
            wheatCount -= warriorCount * foodForYear;
            if (wheatCount < 0)
               Lose();
            WheatText.text = wheatCount.ToString();
        }

        if (SettlerTimer.isEnd)
        {
            settlersCount += 1;
            SettlerButton.interactable = true;
            SettlerAudio.Play();
        }
            

        if (WarriorTimer.isEnd)
        {
            warriorCount += 1;
            WarriorButton.interactable = true;
            WarriorAudio.Play();
        }
        
        if (WarTimer.isEnd)
        {
            if (firstWaveWithEnemy == 0)
            {
                WarTextObject.SetActive(false);
                FirstWaveText.text = "следующее нападение через:";
                if (enemyCount > warriorCount)
                    Lose();
                else
                {
                    warriorCount -= enemyCount;
                    enemyCount += wave * 4;
                    if (wave == 10)
                        Win();
                    wave++;
                }
            }
            else
            {
                firstWaveWithEnemy -= 1;
                FirstWaveNumberText.text = (firstWaveWithEnemy).ToString();
            }
            
        }

        if ((wheatCount >= 600) && (settlersCount >= 100)) 
        {
            Win();
        }

        UpdateText();
    }

    // Update is called once per frame
    private void UpdateText()
    {
        SettlerText.text = settlersCount.ToString();
        WarriorText.text = warriorCount.ToString();
        WheatText.text = wheatCount.ToString();
        WarEnemyText.text = enemyCount.ToString();

        FirstWaveNumberText.text = firstWaveWithEnemy.ToString();
    }

    public void HireSettler()
    {
        if ((wheatCount - settlerCost) >= 0)
        {
            wheatCount -= settlerCost;
            SettlerButton.interactable = false;
            UpdateText();
        }
        
    }

    public void HireWarrior()
    {
        if ((wheatCount - warriorCost) >= 0)
        {
            wheatCount -= warriorCost;
            WarriorButton.interactable = false;
            UpdateText();
        }
    }

    private void Lose()
    {
        SettlerLoseText.text = settlersCount.ToString();
        WarriorLoseText.text = warriorCount.ToString();
        WaveLoseText.text = wave.ToString();

        StateMachine.UpdateScreen(LoseCanvas);
    }

    private void Win()
    {
        SettlerWinText.text = settlersCount.ToString();
        WarriorWinText.text = warriorCount.ToString();
        WaveWinText.text = wave.ToString();

        StateMachine.UpdateScreen(WinCanvas);
    }

}
