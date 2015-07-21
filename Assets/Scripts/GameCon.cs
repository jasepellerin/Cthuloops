using UnityEngine;
using System.Collections;
using InControl;
using UnityEngine.UI;

public class GameCon : MonoBehaviour {

    const int MULTI_START_VAL = 1;
    const int TABLEID = 0;
    const string EXTRA_DATA = "";

    public float maxPlayerDistance = 16f;
    public float minPlayerDistance = 5f;
    public Transform player1;
    public Transform player2;
    public bool ctrl1Found = false;
    public bool ctrl2Found = false;
    public InputDevice controllerP1;
    public InputDevice controllerP2;
    public int score = 0;
    public float multiplyerIncrement = .1f;
    public float scoreMultiplyer = MULTI_START_VAL;
    public float buildingDistructionRate = .01f;
    public float buildingHeath;
    public float cthuluMood = 100f;
    public float angerRate = .001f;
    
    public Text scoreText;
    public Text multiplyerText;
    public Image buildingBar;
    public Slider MoodBar;
    
    public bool isOnePlayer = true;
    public bool hasLogedIn = false;


    private bool hasSentScore = false;
    private bool gameOver = false;
    

    void Awake()
    {
        if (InputManager.Devices[0] != null)
        {
            controllerP1 = InputManager.Devices[0];
            ctrl1Found = true;
        }

        if (InputManager.Devices[1] != null)
        { 
            controllerP2 = InputManager.Devices[1];
            ctrl2Found = true;
        }
        
    }

	// Use this for initialization
	void Start () {
		score = 0;
        buildingHeath = buildingBar.fillAmount;
	}
	
	// Update is called once per frame
	void Update () {



        if (hasLogedIn)
        {

            if (cthuluMood >= 0)
                cthuluMood -= angerRate;

            if (cthuluMood <= 75f)
            {
                buildingHeath -= ((1 - cthuluMood / 100)) * buildingDistructionRate * Time.deltaTime;
            }

            scoreText.text = "Score: " + score.ToString();
            multiplyerText.text = "X" + scoreMultiplyer.ToString();
            buildingBar.fillAmount = buildingHeath;
            MoodBar.value = cthuluMood;

            if (buildingHeath <= 0)
            {
                gameOver = true;
                LogOut();
            }
        }
        
	}

    public float PlayerDistance()
    {

        return Vector2.Distance(player1.position, player2.position);
    }

    public void ResetMulti()
    {
        scoreMultiplyer = MULTI_START_VAL;
    }

    void LogOut()
    {
        if (!hasSentScore)
        {
            //GameJolt.API.Scores.Add(score, scoreText.text, TABLEID, EXTRA_DATA);
            GameJolt.API.Manager.Instance.CurrentUser.SignOut();
            hasSentScore = true;
        }
        Application.Quit();
    }

    
}
