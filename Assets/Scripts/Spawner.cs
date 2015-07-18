using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	public float spawnTime = 3f;
	public float spawnDelay = 4f;
	public GameObject dropper;
	public Transform dropSpawn;

	// Use this for initialization
	void Start () {
		InvokeRepeating ("Spawn", spawnTime, spawnDelay);
	}
	
	// Spawn the droppers
	void Spawn () {
		Instantiate (dropper, dropSpawn.position, dropSpawn.rotation);
	}
}
