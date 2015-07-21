using UnityEngine;
using System.Collections;

public class DeathZONE : MonoBehaviour {
    private GameCon gameCon;
	public ParticleSystem bloods;
	private Quaternion rotation;

    void Start()
    {
        gameCon = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameCon>();
		rotation.Set (0, 1, 1, 0);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
		Instantiate (bloods, other.attachedRigidbody.position, rotation);
        Destroy(other.gameObject);
        gameCon.ResetMulti();
    }
}
