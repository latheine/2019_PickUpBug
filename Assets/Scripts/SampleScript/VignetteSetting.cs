using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class VignetteSetting : MonoBehaviour
{

    bool ON;

    PostProcessVolume processVolume;
    Vignette vignette;

    void Update()
    {

        if (ON)
        {

            OverrideNoise();

        }

    }

    void OverrideNoise()
    {

        vignette.enabled.Override(true);
        vignette.intensity.Override(0f);
        //public PostProcessVolume QuickVolume(int layer, float priority, params PostProcessEffectSettings[] settings)
        processVolume = PostProcessManager.instance.QuickVolume(8, 100f, vignette);
        Debug.Log("Override");

    }


    // Start is called before the first frame update
    void Start()
    {

        vignette = ScriptableObject.CreateInstance<Vignette>();

        Invoke("OverrideNoise", 1f);

    }

}
