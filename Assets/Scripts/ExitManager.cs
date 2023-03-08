using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class ExitManager : MonoBehaviour
{
    public float waitSeconds = 1f;
    public GameObject volumeObject;
    public float rate = 0.1f;

    private Volume v;
    private VolumeProfile profile;

    public GameObject closedState;
    public GameObject openState;

    private bool isDoorOpen = false;
    private bool isColliding = false;
    public bool fadeIn = true;
    bool fadeOut = false;

    private void Start() {
        closedState.SetActive(true);
        openState.SetActive(false);

        v = volumeObject.GetComponent<UnityEngine.Rendering.Volume>();
        profile = v.profile;

        ColorAdjustments c;
        if(profile.TryGet(out c)) {
            c.postExposure.value = -10f;
            v.profile = profile;
        }
    }

    private void Update() {
        if(fadeIn) {
            ColorAdjustments c;
            if(profile.TryGet(out c)) {
                c.postExposure.value = Mathf.Lerp(c.postExposure.value, 0f, rate);
                if(c.postExposure.value >= -0.05) {
                    c.postExposure.value = 0;
                    fadeIn = false;
                }
                v.profile = profile;
            }
        }

        if(isDoorOpen) {
            closedState.SetActive(false);
            openState.SetActive(true);
        }

        if(isColliding) {
            ColorAdjustments c;
            if(profile.TryGet(out c)) {
                c.postExposure.value = Mathf.Lerp(c.postExposure.value, -10f, rate);
                v.profile = profile;
            }
            StartCoroutine(changeScene());
        }

        if(Input.GetKeyDown(KeyCode.R)) {
            fadeOut = true;
            StartCoroutine(changeSceneRestart());
        }

        if(fadeOut) {
            ColorAdjustments c;
            if(profile.TryGet(out c)) {
                c.postExposure.value = Mathf.Lerp(c.postExposure.value, -10f, rate);
                v.profile = profile;
            }
        }

        if(Input.GetKeyDown(KeyCode.Escape)) {
            Application.Quit();
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(isDoorOpen) {
            // Win
            isColliding = true;
        }
    }

    IEnumerator changeScene() {
        yield return new WaitForSeconds(waitSeconds);
        fadeOut = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        yield return null;
    }

    IEnumerator changeSceneRestart() {
        yield return new WaitForSeconds(waitSeconds);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        yield return null;
    }

    public void toggele(bool state) {
        isDoorOpen = state;
    }
}
