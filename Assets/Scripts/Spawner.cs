using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	public float spawnTime = 1f;
	public float spawnDelay = 3f;
	public GameObject sacrifice0;
	public GameObject sacrifice1;
	public GameObject sacrifice2;
	public Transform dropSpawn;
	private AudioSource[] screamSource;
    private GameCon gameCon;
    private bool hasStarted = false;
	private GameObject[] sacrifices = new GameObject[3];
	private int sacNumber;

	// Use this for initialization
	void Start () {
        gameCon = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameCon>();
		screamSource = this.GetComponents<AudioSource>();
		sacrifices [0] = sacrifice0;
		sacrifices [1] = sacrifice1;
		sacrifices [2] = sacrifice2;
	}

    void Update()
    {
        if (gameCon.hasLogedIn && !hasStarted)
        {
            hasStarted = true;
            InvokeRepeating("Spawn", spawnTime, spawnDelay);
        }
    }
	
	// Spawn the sacrifices
	void Spawn () {
		Vector3 location;
		location.x = dropSpawn.position.x + Random.Range(-10f, 10f);
		location.y = dropSpawn.position.y;
		location.z = dropSpawn.position.z;
		sacNumber = Random.Range (0, 3);
		Instantiate (sacrifices[sacNumber], location , dropSpawn.rotation);
		if (!screamSource[sacNumber].isPlaying) {
			screamSource[sacNumber].Play ();
		}


	}
}