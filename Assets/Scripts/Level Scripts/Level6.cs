using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level6 : MonoBehaviour
{
    public ButtonManager b;
    public Laser l;
    public LaserEnd le;
    public ExitManager ex;

    private void Start() {
        l.shootLaser = false;
    }

    private void Update() {
        if(b.getButtonState()) {
            l.shootLaser = true;
        }

        if(le.getState()) {
            ex.toggele(true);
        }
    }
}
