using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinueousMoveableBox : MonoBehaviour
{
    private Rigidbody2D rb;

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D other) {
        rb.velocity = Vector2.zero;
    }
}
