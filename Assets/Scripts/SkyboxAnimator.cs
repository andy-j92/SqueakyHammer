using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyboxAnimator : MonoBehaviour {

    int step = 1;

    // Update is called once per frame
    void Update () {
        var skybox = RenderSettings.skybox;

        step += 1;
        step %= 360;

        skybox.SetInt("Rotation", step);
        RenderSettings.skybox = skybox;
    }
}
