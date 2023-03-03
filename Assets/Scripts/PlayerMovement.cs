using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public bool player1 = true;
    public float moveSpeed = 30f;
    public Transform spawn;

    private float hMove = 0f;
    private float vMove = 0f;

    private void Start() {
        // Move player to spawn
        gameObject.transform.position = spawn.position;
    }

    private void Update() {
        if(player1) { // Player 1
            hMove = Input.GetAxisRaw("Horizontal1") * moveSpeed;
            vMove = Input.GetAxisRaw("Vertical1") * moveSpeed;
        }
        else { // Player 2
            hMove = Input.GetAxisRaw("Horizontal2") * moveSpeed;
            vMove = Input.GetAxisRaw("Vertical2") * moveSpeed;
        }
    }

    private void FixedUpdate() {
        // Move player
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(hMove, vMove);
    }

    public bool getIsPlayer1() {
        return player1;
    }
}
