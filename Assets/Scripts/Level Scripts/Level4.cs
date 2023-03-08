using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level4 : MonoBehaviour
{
    public Door p1;
    public Door p2;
    public PressurePlate p1_1;
    public PressurePlate p1_2;
    public PressurePlate e1;
    public PressurePlate e2;
    public PressurePlate e3;
    public PressurePlate e4;
    public ExitManager exit;

    private void Start() {
        exit.toggele(false);
        p1.toggleState(false);
        p2.toggleState(false);
    }

    private void Update() {
        if(p1_1.getState() && p1_2.getState()) {
            p1.toggleState(true);
        }
        if(e1.getState() && e2.getState() && e3.getState()) {
            p2.toggleState(true);
            if(e4.getState()) {
                exit.toggele(true);
            }
        }
    }
}
