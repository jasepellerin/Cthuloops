using UnityEngine;
using System.Collections;

public class RopeBounce : MonoBehaviour {
    public float bounceForce = 500f;
    public float angleForce = .0001f;
    public Transform centerPiece;
    
    private GameCon gameCon;

	// Use this for initialization
	void Start () {
        gameCon = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameCon>();
	}
	
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag != "Player" && other.gameObject.tag != "RopeSegment")
        {
            Rigidbody2D otherBody = other.transform.GetComponent<Rigidbody2D>();
            if (otherBody != null)
            {
                float angleAmount = AngleDir(other.transform.position, centerPiece.position);
                otherBody.AddForce(Vector2.up * bounceForce * (gameCon.PlayerDistance() - gameCon.minPlayerDistance));
                otherBody.AddForce(Vector2.right * angleForce * (gameCon.PlayerDistance() - gameCon.minPlayerDistance) * angleAmount *-1);
            }
        }


    }

    public static float AngleDir(Vector2 A, Vector2 B)
    {
        return -A.x * B.y + A.y * B.x;
    }


}
