using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public GameObject openState;
    public GameObject closedState;
    public BoxCollider2D box;

    private void Start() {
        openState.SetActive(false);
        closedState.SetActive(true);
    }

    public void toggleState(bool x) {
        openState.SetActive(x);
        closedState.SetActive(!x);
        box.enabled = !x;
    }
}
