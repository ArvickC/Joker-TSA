using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2 : MonoBehaviour
{
    public GameObject player1Door;
    public GameObject player2Door;
    public PressurePlate pressurePlateP1;
    public PressurePlate pressurePlateP2;
    public PressurePlate pressurePlateE1;
    public PressurePlate pressurePlateE2;
    public ExitManager exitManager;

    private void Start() {
        player1Door.GetComponent<Door>().toggleState(false);
        player2Door.GetComponent<Door>().toggleState(false);
        exitManager.toggele(false);
    }

    private void Update() {
        if(pressurePlateP1.getState() && pressurePlateP2.getState()) {
            player2Door.GetComponent<Door>().toggleState(true);
        }

        if(pressurePlateE1.getState()) {
            player1Door.GetComponent<Door>().toggleState(true);
        }

        if(pressurePlateE1.getState() && pressurePlateE2.getState()) {
            exitManager.toggele(true);
        }
    }
}
