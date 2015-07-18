using UnityEngine;
using System.Collections;

public class GoalCon : MonoBehaviour {

    private GameCon gameCon;

    void Start()
    {
        gameCon = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameCon>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(other);
        gameCon.score += 100;
    }
}
