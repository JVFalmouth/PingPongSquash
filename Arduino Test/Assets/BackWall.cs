using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackWall : MonoBehaviour
{
    public Material player1;
    public Material player2;
    public Collider[] P1Colliders = new Collider[3];
    public Collider[] P2Colliders = new Collider[3];
    public GameObject gameController;

    bool turn = false;

    Color off_red = new Color(1f, 0f, 0f, 0.5f);
    Color on_red = new Color(1f, 0f, 0f, 1f);
    Color off_blue = new Color(0f, 0f, 1f, 0.5f);
    Color on_blue = new Color(0f, 0f, 1f, 1f);

    public void StartGame()
    {
        turn = false;
        player1.SetColor("_Color", off_red);
        player2.SetColor("_Color", on_blue);
        foreach (Collider collider in P1Colliders)
        {
            collider.enabled = false;
        }
        foreach (Collider collider in P2Colliders)
        {
            collider.enabled = true;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (turn)
        {
            player1.SetColor("_Color", off_red);
            player2.SetColor("_Color", on_blue);
            foreach (Collider collider in P1Colliders) {
                collider.enabled = !collider.enabled;
            }
            foreach (Collider collider in P2Colliders)
            {
                collider.enabled = !collider.enabled;
            }
        }
        else
        {
            player2.SetColor("_Color", off_blue);
            player1.SetColor("_Color", on_red);
            foreach (Collider collider in P1Colliders)
            {
                collider.enabled = !collider.enabled;
            }
            foreach (Collider collider in P2Colliders)
            {
                collider.enabled = !collider.enabled;
            }
        }

        turn = !turn;
    }

    public void ResetPaddles()
    {
        player2.SetColor("_Color", on_blue);
        player1.SetColor("_Color", on_red);
    }

    void OnApplicationQuit()
    {
        ResetPaddles();
    }
}
