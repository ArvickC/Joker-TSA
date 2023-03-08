using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class PlayerHealth : MonoBehaviour {
    public float health = 20.0f;
    public GameObject volumeObject;
    public float rate = 0.05f;

    // PostProcessProfile profile;
    private static bool isTakingDamage = false;
    private Volume v;
    private VolumeProfile profile;

    private void Start() {
        v = volumeObject.GetComponent<Volume>();
        profile = v.profile;

        Vignette vg;
        if(profile.TryGet(out vg)) {
            vg.intensity.value = 0;
        }
    }

    private void Update() {
        if(isTakingDamage) {
            Vignette vignette;
            if(profile.TryGet(out vignette)) {
                vignette.intensity.value = Mathf.Lerp(vignette.intensity.value, 0.5f, rate);
            }
            if(health > 0) {
                health = Mathf.Lerp(health, -1f, rate);
            }
            v.profile = profile;
        } else {
            Vignette vignette;
            if(profile.TryGet(out vignette)) {
                if(vignette.intensity.value > 0) {
                    vignette.intensity.value = Mathf.Lerp(vignette.intensity.value, -1f, rate);
                }
            }
            if(health < 20) {
                health = Mathf.Lerp(health, 21f, rate);
            }
            v.profile = profile;
        }
        if(health <= 0) {
            // Game Over
            toggleDamage(false);
            Debug.Log("Restart Level");
        }
    }

    public void toggleDamage(bool takeDamage) {
        isTakingDamage = takeDamage;
    }

    public void toggleDamage() {
        toggleDamage(!isTakingDamage);
    }
}