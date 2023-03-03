using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedDoor : MonoBehaviour
{
    public bool isPlayer1 = true;

    private void OnTriggerStay2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player")) {
            GameObject o = other.gameObject;
            if(isPlayer1) {
                // Player 1 (Blue)
                if(!o.GetComponent<PlayerMovement>().getIsPlayer1()) {
                    // False
                    o.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                }
            } else {
                // Player 2 (Red)
                if(o.GetComponent<PlayerMovement>().getIsPlayer1()) {
                    // True
                    o.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                }
            }
        } else {
            if(other.gameObject.GetComponent<Rigidbody2D>() != null) {
                other.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            }
        }
    }
}
