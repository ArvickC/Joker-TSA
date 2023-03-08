using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class Laser : MonoBehaviour
{
    public LineRenderer beam;
    public int maxReflections = 3;
    public float maxLength = 30f;
    public LayerMask layerDetection;
    public Vector2 direction = Vector2.right;
    public GameObject[] players;

    private void Start() {
        Physics2D.queriesStartInColliders = false;
    }

    private void Update() {
        beam.positionCount = 1;
        beam.SetPosition(0, transform.position);

        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right, maxLength, layerDetection);

        bool isMirror = false;
        GameObject mirror = null;

        for(int i=0;i<maxReflections;i++) {
            beam.positionCount += 1;

            if(hit.collider != null) {
                isMirror = false;

                if(hit.collider.CompareTag("Mirror")) {
                    /*
                    mirrorHitPoint = hit.point;
                    mirrorHitNormal = -1*hit.normal;
                    Debug.Log(hit.normal);
                    hit = Physics2D.Raycast((Vector2)hit.point, Vector2.Reflect(hit.point, -1*hit.normal).normalized, maxLength, layerDetection);
                    */

                    Debug.Log("Collide");

                    mirror = hit.collider.gameObject;
                    beam.SetPosition(beam.positionCount-1, mirror.transform.position);
                    hit = Physics2D.Raycast((Vector2)hit.point, mirror.GetComponent<Mirror>().getDirection(), maxLength, layerDetection);
                    isMirror = true;
                } else if(hit.collider.CompareTag("LaserEnd")) {
                    beam.SetPosition(beam.positionCount-1, hit.point);
                    hit.collider.gameObject.GetComponent<LaserEnd>().toggleState(true);
                    break;
                } else if(hit.collider.CompareTag("Player")) {
                    beam.SetPosition(beam.positionCount-1, hit.point);
                    hit.collider.gameObject.GetComponent<PlayerHealth>().toggleDamage(true);
                } else {
                    togglePlayerHealth();
                    beam.SetPosition(beam.positionCount-1, hit.point);
                    break;
                }
            } else {
                if(isMirror) {
                    /*
                    beam.SetPosition(beam.positionCount-1, (mirrorHitPoint + Vector2.Reflect(mirrorHitPoint, mirrorHitNormal).normalized*maxLength));
                    */
                    Ray ray = new Ray(mirror.transform.position, mirror.GetComponent<Mirror>().getDirection());
                    beam.SetPosition(beam.positionCount-1, ray.GetPoint(maxLength));
                    break;
                } else {
                    beam.SetPosition(beam.positionCount-1, transform.position + transform.right * maxLength);
                }
            }
        }
    }

    void togglePlayerHealth() {
        foreach(GameObject p in players) {
            p.GetComponent<PlayerHealth>().toggleDamage(false);
        }
    }
}
