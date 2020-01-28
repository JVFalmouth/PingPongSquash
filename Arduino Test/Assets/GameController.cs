using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject ball;
    public Arduino arduino;
    public Canvas canvas;
    public BackWall backWall;

    public void StartGame()
    {
        canvas.enabled = false;
        arduino.toggleController();
        var ball_body = ball.GetComponent<Rigidbody>();
        ball_body.AddForce(Vector3.forward * 500);
        backWall.StartGame();
    }

    public void StopGame()
    {
        canvas.enabled = true;
        arduino.toggleController();
        ball.transform.position = new Vector3(5f, 0f, 0f);
        var ball_body = ball.GetComponent<Rigidbody>();
        ball_body.velocity = new Vector3(0f, 0f, 0f);
    }
}
