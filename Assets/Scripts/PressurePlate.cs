using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public bool isPlayer = false;
    public bool isBoth = false;
    public float waitTime = 0.5f;
    public GameObject light;
    private bool state = false;

    private void Start() {
        light.SetActive(false);
    }

    private void OnTriggerStay2D(Collider2D other) {
        if(isPlayer) {
            if(other.gameObject.CompareTag("Player")) {
                // Touching player
                state = true;
                light.SetActive(true);
            }
        } else if(!isPlayer) {
            if(other.gameObject.CompareTag("Box")) {
                // Touching box
                if(other.gameObject.GetComponent<ContinueousMoveableBox>() != null) {
                    // Continuous Box
                    StartCoroutine(continuousManager(other.gameObject));
                    state = true;
                    light.SetActive(true);
                } else {
                    // Normal Moveable Box
                    state = true;
                    light.SetActive(true);
                }
            }
        }

        if(isBoth) {
            if(other.gameObject.CompareTag("Player")) {
                // Touching player
                state = true;
                light.SetActive(true);
            }
            if(other.gameObject.CompareTag("Box")) {
                // Touching box
                if(other.gameObject.GetComponent<ContinueousMoveableBox>() != null) {
                    // Continuous Box
                    StartCoroutine(continuousManager(other.gameObject));
                    state = true;
                    light.SetActive(true);
                } else {
                    // Normal Moveable Box
                    state = true;
                    light.SetActive(true);
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
        light.SetActive(false);
    }

    public bool getState() {
        return state;
    }
}
