using UnityEngine;
using System.Collections;

public class BowlGoalCon : MonoBehaviour {
    GameCon gameCon;
    SacrificeCon sacCon;
	public ParticleSystem milk;
	private Quaternion rotation;
	private Vector3 position;
	private AudioSource splashSource;

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.tag);
        if (other.tag == "Sacrifice")
        {
            sacCon = other.GetComponent<SacrificeCon>();

            gameCon.score += Mathf.FloorToInt(sacCon.scoreValue * gameCon.scoreMultiplyer);
            
            if (gameCon.cthuluMood + sacCon.moodValue <= 100)
                gameCon.cthuluMood += sacCon.moodValue;
            else
                gameCon.cthuluMood = 100;
            
            gameCon.scoreMultiplyer += gameCon.multiplyerIncrement;
			position = other.attachedRigidbody.position;
			position.z = -150;
			Instantiate (milk, position, rotation);
			if (!splashSource.isPlaying) {
				splashSource.Play ();
			}
            Destroy(other.gameObject);
        }
    }

	// Use this for initialization
	void Start () {
        gameCon = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameCon>();
		rotation.Set (0, 0, 0, 0);
		splashSource = this.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}