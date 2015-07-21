using UnityEngine;
using System.Collections;

public class ThuluMouth : MonoBehaviour {
    private GameCon gameCon;

    void Start()
    {
        gameCon = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameCon>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Sacrifice")
        {
            SacrificeCon sacCon = other.GetComponent<SacrificeCon>();
            Destroy(other.gameObject);
            if (gameCon.cthuluMood + sacCon.moodValue <= 100)
                gameCon.cthuluMood += sacCon.moodValue * 2;
            else
                gameCon.cthuluMood = 100;
        }
    }

}
