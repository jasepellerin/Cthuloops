using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public float speed = 1f;
    public float tentionSpeed = 10f;
    public bool isLeftGuy = false;

    private float playerDistance;
    private GameCon gameCon;
    private bool canUseController = false;

    // Use this for initialization
    void Start()
    {
        gameCon = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameCon>();
        if ((gameCon.ctrl1Found && gameCon.isOnePlayer) || (gameCon.ctrl1Found && gameCon.ctrl2Found && !gameCon.isOnePlayer))
            canUseController = true;
    }

    // Update is called once per frame
    void Update()
    {
        playerDistance = gameCon.PlayerDistance();
        InputContoller();
    }

    void InputContoller()
    {
        if (gameCon.isOnePlayer)
        {
            if (isLeftGuy)
            {
                if ((Input.GetAxis("Horizontal") > 0 || (canUseController ? gameCon.controllerP1.LeftStickX.Value > 0 : false)) && transform.position.x < 5)
                    transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x + speed, transform.position.y), Time.deltaTime);
                if ((Input.GetAxis("Horizontal") < 0 || (canUseController ? gameCon.controllerP1.LeftStickX.Value < 0 : false)) && transform.position.x > -25)
                    transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x - speed, transform.position.y), Time.deltaTime);
            }
            else
            {
                if ((Input.GetAxis("Horizontal") > 0 || (canUseController ? gameCon.controllerP1.LeftStickX.Value > 0 : false)) && transform.position.x < 25)
                    transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x + speed, transform.position.y), Time.deltaTime);
                if ((Input.GetAxis("Horizontal") < 0 || (canUseController ? gameCon.controllerP1.LeftStickX.Value < 0 : false)) && transform.position.x > -5)
                    transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x - speed, transform.position.y), Time.deltaTime);

            }


            if ((Input.GetAxis("Vertical") > 0 || (canUseController ? gameCon.controllerP1.RightStickX.Value < 0 : false)) && playerDistance > gameCon.minPlayerDistance)
            {
                if (isLeftGuy)
                    transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x + speed, transform.position.y), Time.deltaTime);
                else
                    transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x - speed, transform.position.y), Time.deltaTime);
            }
            if ((Input.GetAxis("Vertical") < 0 || (canUseController ? gameCon.controllerP1.RightStickX.Value > 0 : false)) && playerDistance < gameCon.maxPlayerDistance)
            {
                if (isLeftGuy && transform.position.x > -25)
                    transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x - speed, transform.position.y), Time.deltaTime);
                else if (transform.position.x < 25)
                {
                    transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x + speed, transform.position.y), Time.deltaTime);
                }
            }

        }
        else
        {
            if (!isLeftGuy && transform.position.x > -25)
            {
                if ((Input.GetAxis("Horizontal") > 0 || (canUseController ? gameCon.controllerP1.LeftStickX.Value > 0 : false)) && playerDistance < gameCon.maxPlayerDistance)
                    transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x + speed, transform.position.y), Time.deltaTime);
                if ((Input.GetAxis("Horizontal") < 0 || (canUseController ? gameCon.controllerP1.LeftStickX.Value < 0 : false)) && playerDistance > gameCon.minPlayerDistance)
                    transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x - speed, transform.position.y), Time.deltaTime);

            }
            else if (transform.position.x < 25)
            {
                if ((Input.GetAxis("HorizontalP2") > 0 || (canUseController ? gameCon.controllerP2.LeftStickX.Value > 0 : false)) && playerDistance > gameCon.minPlayerDistance)
                    transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x + speed, transform.position.y), Time.deltaTime);
                if ((Input.GetAxis("HorizontalP2") < 0 || (canUseController ? gameCon.controllerP2.LeftStickX.Value < 0 : false)) && playerDistance < gameCon.maxPlayerDistance)
                    transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x - speed, transform.position.y), Time.deltaTime);
            }
        }
    }
}
