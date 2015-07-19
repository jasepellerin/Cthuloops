using UnityEngine;
using System.Collections;

public class SplashHandler : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Invoke("startFade", 5);
	}
	
	void startFade () { 
		float fadeTime = GameObject.Find ("FadeManager").GetComponent<Fading> ().BeginFade (1);
		Invoke ("nextScreen", fadeTime);
	}

	void nextScreen () {
		Application.LoadLevel (Application.loadedLevel + 1);
	}
}
