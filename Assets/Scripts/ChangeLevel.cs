using UnityEngine;
using System.Collections;

public class ScoreLevelSw : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}

	public void menuScreen () {
		selectScreen (1);
	}

	public void playScreen () {
		selectScreen (2);
	}

	public void scoreScreen () {
		selectScreen (3);
	}

	void selectScreen (int levelID) {
		Application.LoadLevel (levelID);
	}

	public void exitKey () {
		Application.Quit();
	}

	void Update() {
		if (Input.GetKey("escape"))
			selectScreen (1);
		
	}
}
