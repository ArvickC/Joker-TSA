using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1 : MonoBehaviour
{
    public PressurePlate pressurePlate1;
    public PressurePlate pressurePlate2;
    public ExitManager exitManager;

    private void Start() {
        exitManager.toggele(false);
    }

    private void Update() {
        if(pressurePlate1.getState() && pressurePlate2.getState()) {
            exitManager.toggele(true);
        }
    }
}
