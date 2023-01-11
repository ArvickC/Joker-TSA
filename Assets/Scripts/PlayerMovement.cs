using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public bool player1 = true;
    public float moveSpeed = 30f;
    public Transform spawn;

    private float move = 0f;
    private bool isJump = false;

    private void Start() {
        // Move player to spawn
        gameObject.transform.position = spawn.position;
    }

    private void Update() {
        if(player1) { // Player 1
            move = Input.GetAxisRaw("Horizontal1") * moveSpeed;
            if(Input.GetButtonDown("Jump1")) {
                isJump = true;
            }
        }
        else { // Player 2
            move = Input.GetAxisRaw("Horizontal2") * moveSpeed;
            if(Input.GetButtonDown("Jump2")) {
                isJump = true;
            }
        }

    }

    private void FixedUpdate() {
        // Move player
        controller.Move(move * Time.fixedDeltaTime, false, isJump);
        isJump = false;
    }
}
