using UnityEngine;
using System.Collections;
using InControl;

public class GameCon : MonoBehaviour {
    public float maxPlayerDistance = 16f;
    public float minPlayerDistance = 5f;
    public Transform player1;
    public Transform player2;
    public bool ctrl1Found = false;
    public bool ctrl2Found = false;
    public InputDevice controllerP1;
    public InputDevice controllerP2;
    public int score = 0;
    public float buildingHeath = 100;
    public float cthuluMood = 100;
    

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
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public float PlayerDistance()
    {

        return Vector2.Distance(player1.position, player2.position);
    }
}
