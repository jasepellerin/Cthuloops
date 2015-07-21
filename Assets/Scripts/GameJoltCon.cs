using UnityEngine;
using System.Collections;

public class GameJoltCon : MonoBehaviour {
    private GameCon gameCon;

    void Awake ()
    {
        Object.DontDestroyOnLoad(gameObject);
    }

	// Use this for initialization
	void Start () 
    {
        gameCon = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameCon>();

        GameJolt.UI.Manager.Instance.ShowSignIn((bool success) =>
        {
            if (success)
            {
                Debug.Log("The user signed in!");
                gameCon.hasLogedIn = true;
            }
            else
            {
                Debug.Log("The user failed to signed in or closed the window :(");
            }
        });
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
