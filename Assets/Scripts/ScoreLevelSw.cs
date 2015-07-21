using UnityEngine;
using System.Collections;

public class ScoreLevelSw : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	IEnumerator FadeOut () {
		float fadeTime = GameObject.Find ("FadeManager").GetComponent<Fading> ().BeginFade (1);
		yield return new WaitForSeconds (fadeTime);
		Application.LoadLevel (Application.loadedLevel + 1);
	}
}
