using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserEnd : MonoBehaviour
{
    private bool state;

    public void toggleState(bool x) {
        state = x;
    }

    private void Start() {
        InvokeRepeating("toggleStateOff", 0.0f, 0.5f);
    }

    private void toggleStateOff() {
        state = false;
    }

    public bool getState() {
        return state;
    }
}
