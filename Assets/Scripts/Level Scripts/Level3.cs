using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level3 : MonoBehaviour
{
    public PressurePlate p1;
    public PressurePlate p2;
    public PressurePlate p3;
    public ExitManager exit;

    private void Update() {
        if(p1.getState() && p2.getState() && p3.getState()) {
            exit.toggele(true);
        }
    }
    private void Start() {
        exit.toggele(false);
    }
}
