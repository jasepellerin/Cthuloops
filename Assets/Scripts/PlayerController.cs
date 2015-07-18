using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public float speed = 10f;
	public float tentionSpeed = 5f;
	public bool isLeftGuy = false;
	
	private float playerDistance;
	private bool isOnePlayer = false;
	private GameCon gameCon;
	
	// Use this for initialization
	void Start () {
		gameCon = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameCon>();
	}
	
	// Update is called once per frame
	void Update () {
		playerDistance = gameCon.PlayerDistance();        
		InputContoller();
	}
	
	
	void InputContoller()
	{
		if (isOnePlayer)
		{
			if (Input.GetAxis("Horizontal") > 0)
				transform.Translate(new Vector3(speed, 0, 0) * Time.deltaTime);
			if (Input.GetAxis("Horizontal") < 0)
				transform.Translate(new Vector3(speed * (-1), 0, 0) * Time.deltaTime);
			if (Input.GetAxis("Vertical") > 0 && playerDistance > gameCon.minPlayerDistance)
			{
				if (isLeftGuy)
					transform.Translate(new Vector3(tentionSpeed, 0, 0) * Time.deltaTime);
				else
					transform.Translate(new Vector3(tentionSpeed * (-1), 0, 0) * Time.deltaTime);
			}
			if (Input.GetAxis("Vertical") < 0 && playerDistance < gameCon.maxPlayerDistance)
			{
				if (isLeftGuy)
					transform.Translate(new Vector3(tentionSpeed * (-1), 0, 0) * Time.deltaTime);
				else
					transform.Translate(new Vector3(tentionSpeed, 0, 0) * Time.deltaTime);
			}
		}
		else
		{
			if (!isLeftGuy)
			{
				if (Input.GetAxis("Horizontal") > 0 && playerDistance < gameCon.maxPlayerDistance)
					transform.Translate(new Vector3(speed, 0, 0) * Time.deltaTime);
				if (Input.GetAxis("Horizontal") < 0 && playerDistance > gameCon.minPlayerDistance)
					transform.Translate(new Vector3(speed * (-1), 0, 0) * Time.deltaTime);
				
			}
			else
			{
				if (Input.GetAxis("HorizontalP2") > 0 && playerDistance > gameCon.minPlayerDistance)
					transform.Translate(new Vector3(speed, 0, 0) * Time.deltaTime);
				if (Input.GetAxis("HorizontalP2") < 0 && playerDistance < gameCon.maxPlayerDistance)
					transform.Translate(new Vector3(speed * (-1), 0, 0) * Time.deltaTime);
			}
		}
	}
}