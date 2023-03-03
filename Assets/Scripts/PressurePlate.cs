using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public bool isPlayer = false;
    public float waitTime = 0.5f;
    private bool state = false;

    private void OnTriggerStay2D(Collider2D other) {
        if(isPlayer) {
            if(other.gameObject.CompareTag("Player")) {
                // Touching player
                state = true;
            }
        } else {
            if(other.gameObject.CompareTag("Box")) {
                // Touching box
                if(other.gameObject.GetComponent<ContinueousMoveableBox>() != null) {
                    // Continuous Box
                    StartCoroutine(continuousManager(other.gameObject));
                    state = true;
                } else {
                    // Normal Moveable Box
                    state = true;
                }
            }
        }
    }

    IEnumerator continuousManager(GameObject o) {
        yield return new WaitForSeconds(waitTime);
        o.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        yield return null;
    }

    private void OnTriggerExit2D(Collider2D other) {
        state = false;
    }

    public bool getState() {
        return state;
    }
}
