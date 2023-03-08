using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level5 : MonoBehaviour
{
    public PressurePlate p1;
    public PressurePlate p2;
    public PressurePlate p3;
    public PressurePlate p4;
    public PressurePlate p5;
    public PressurePlate p6;
    public Door d1;
    public Door d2;
    public BoxCollider2D d3;
    public BoxCollider2D d4;
    public BoxCollider2D d5;
    public ExitManager exit;

    private void Start() {
        exit.toggele(false);
    }

    private void Update() {
        if(p1.getState()) {
            d3.enabled = false;
        } else {
            if(!p2.getState()) d3.enabled = true;
        }

        if(p2.getState()) {
            d3.enabled = false;
            d1.toggleState(true);
        } else {
            if(!p1.getState()) d3.enabled = true;
            if(!p5.getState()) d1.toggleState(false);
        }

        if(p3.getState()) {
            d2.toggleState(true);
        } else {
            if(!p6.getState()) d2.toggleState(false);
        }

        if(p4.getState()) {
            d4.enabled = false;
        } else {
            d4.enabled = true;
        }

        if(p5.getState()) {
            d1.toggleState(true);
            d5.enabled = false;
        } else {
            if(!p2.getState()) d1.toggleState(false);
            if(!p6.getState()) d5.enabled = true;
        }

        if(p6.getState()) {
            d2.toggleState(true);
            d5.enabled = false;
        } else {
            if(!p5.getState()) d5.enabled = true;
            if(!p3.getState()) d2.toggleState(false);
        }

        if(p4.getState() && p5.getState() && p6.getState()) {
            exit.toggele(true);
        }
    }
}
