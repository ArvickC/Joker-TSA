using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public SpriteRenderer buttonOn;
    public SpriteRenderer buttonOff;
    public bool startingState = false;
    public float waitTime = 0.5f;

    private bool isOver = false;
    private bool isPressed = false;
    private bool isWaiting = false;
    private bool isPlayer1 = false;

    private void Start() {
        isPressed = startingState;
        buttonOff.enabled = !startingState;
        buttonOn.enabled = startingState;
    }

    private void OnTriggerStay2D(Collider2D other) {
        if(other.gameObject.tag == "Player") {
            if(other.gameObject.GetComponent<PlayerMovement>().player1) isPlayer1 = true; 
            else isPlayer1 = false;

            isOver = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.tag == "Player") {
            isOver = false;
        }
    }

    private void Update() {
        if(isOver && ((Input.GetAxisRaw("Interact1") > 0 && isPlayer1) || (Input.GetAxisRaw("Interact2") > 0 && !isPlayer1)) && !isWaiting) {
            toggleButton();
            StartCoroutine(Wait(waitTime));
        }
    }

    // For exteral scripts to get button state
    public bool getButtonState() {
        return isPressed;
    }

    // External scripts can toggle button
    public bool toggleButton() {
        isPressed = !isPressed;
        buttonOff.enabled = !buttonOff.enabled;
        buttonOn.enabled = !buttonOn.enabled;
        return isPressed;
    }

    public bool toggleButton(bool state) {
        isPressed = state;
        buttonOff.enabled = !state;
        buttonOn.enabled = state;
        return isPressed;
    }

    IEnumerator Wait(float seconds) {
        isWaiting = true;
        yield return new WaitForSeconds(seconds);
        toggleButton(false);
        isWaiting = false;
        yield return null;
    }
}
