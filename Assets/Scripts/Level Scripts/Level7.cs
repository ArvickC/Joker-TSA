using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level7 : MonoBehaviour
{
    public LaserEnd l1;
    public LaserEnd l2;
    public PressurePlate p1;
    public PressurePlate p2;
    public PressurePlate p3;
    public Door d;
    public ExitManager ex;
    public Laser las;
    public LeverManager lev;
    public float wait = 1f;
    private bool isNeeded = true;

    private void Start() {
        ex.toggele(false);
        las.shootLaser = false;
    }

    private void Update() {
        if(p1.getState()) {
            if(isNeeded) {
                if(l1.getState()) {
                    StopCoroutine(waitForS());
                    d.toggleState(true);
                    isNeeded = false;
                }
            } else {
                StopCoroutine(waitForS());
                d.toggleState(true);
            }
        } else {
            Debug.Log(p2.getState() + " " + l2.getState());
            if(!p2.getState() || !l2.getState()) {
                Debug.Log("Off p1");
                StartCoroutine(waitForS());
            }
        }

        if(l2.getState() && p2.getState()) {
            StopCoroutine(waitForS());
            d.toggleState(true);
        } else {
            if(isNeeded) {
                if(!l1.getState() || !p1.getState()) StartCoroutine(waitForS());
            } else {
                if(!p1.getState()) StartCoroutine(waitForS());
            }
        }

        if(p2.getState() && p3.getState()) {
            ex.toggele(true);
        }

        if(lev.getLeverState()) {
            las.shootLaser = true;
        } else {
            las.shootLaser = false;
        }
    }

    IEnumerator waitForS() {
        yield return new WaitForSeconds(wait);
        d.toggleState(false);
        yield return null;
    }
}
