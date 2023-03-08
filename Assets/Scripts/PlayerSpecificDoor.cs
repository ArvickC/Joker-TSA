using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpecificDoor : MonoBehaviour
{
    public bool isPlayer1 = true;

    private void OnTriggerEnter2D(Collider2D other) {
        
    }

    private void OnCollisionEnter2D(Collision2D other) {
        PlayerMovement p = other.gameObject.GetComponent<PlayerMovement>();
        if(p != null) {
            if(isPlayer1 && p.getIsPlayer1()) {
                Physics2D.IgnoreCollision(GetComponent<Collider2D>(), other.collider, true);
            } else if(!isPlayer1 && !p.getIsPlayer1()) {
                Physics2D.IgnoreCollision(GetComponent<Collider2D>(), other.collider, true);
            }
        }
    }

    private void OnCollisionExit2D(Collision2D other) {
        PlayerMovement p = other.gameObject.GetComponent<PlayerMovement>();
        if(p != null) {
            if(isPlayer1 && p.getIsPlayer1()) {
                Physics2D.IgnoreCollision(GetComponent<Collider2D>(), other.collider, true);
            } else if(!isPlayer1 && !p.getIsPlayer1()) {
                Physics2D.IgnoreCollision(GetComponent<Collider2D>(), other.collider, true);
            }
        }
    }
}
