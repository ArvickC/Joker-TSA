using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mirror : MonoBehaviour
{
    public Vector2 direction = Vector2.up;
    public float pushForce = 10f;

    private Rigidbody2D rb;
    
    private void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Player")) {
            Vector2 pushDirection = new Vector2(
                other.transform.position.x - transform.position.x,
                other.transform.position.y - transform.position.y
            );
            rb.AddForce(pushDirection * pushForce);
        } else {
            rb.velocity = Vector2.zero;
        }
    }

    private void OnCollisionExit2D(Collision2D other) {
        if (other.gameObject.CompareTag("Player")) {
            rb.velocity = Vector2.zero;
        }
    }

    public Vector2 getDirection() {
        return direction;
    }
}
