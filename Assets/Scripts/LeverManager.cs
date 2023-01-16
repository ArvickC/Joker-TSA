using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverManager : MonoBehaviour
{
    public SpriteRenderer leverOn;
    public SpriteRenderer leverOff;
    public bool startingState = false;
    public float cooldown = 0.5f;

    private bool isOver = false;
    private bool isOn = false;
    private bool isCoolDown = false;
    private bool isPlayer1 = false;

    private void Start() {
        isOn = startingState;
        leverOff.enabled = !startingState;
        leverOn.enabled = startingState;
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
        if(isOver && ((Input.GetAxisRaw("Interact1") > 0 && isPlayer1) || (Input.GetAxisRaw("Interact2") > 0 && !isPlayer1)) && !isCoolDown) {
            toggleButton();
            StartCoroutine(Wait(cooldown));
        }
    }

    // For exteral scripts to get button state
    public bool getLeverState() {
        return isOn;
    }

    // External scripts can toggle button
    // Return's new state
    public bool toggleButton() {
        isOn = !isOn;
        leverOff.enabled = !leverOff.enabled;
        leverOn.enabled = !leverOn.enabled;
        return isOn;
    }

    public bool toggleButton(bool state) {
        isOn = state;
        leverOff.enabled = !state;
        leverOn.enabled = state;
        return isOn;
    }

    IEnumerator Wait(float seconds) {
        isCoolDown = true;
        yield return new WaitForSeconds(seconds);
        isCoolDown = false;
        yield return null;
    }
}
