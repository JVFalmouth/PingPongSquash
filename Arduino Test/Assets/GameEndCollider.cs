using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEndCollider : MonoBehaviour
{
    public GameController gameController;
    public BackWall backWall;
    void OnCollisionEnter(Collision collision)
    {
        gameController.StopGame();
        backWall.ResetPaddles();
    }
}
