using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class GrainSetting : MonoBehaviour
{
    bool ON;

    PostProcessVolume processVolume;
    Grain grain;

    void Update()
    {

        if (ON)
        {

            OverrideNoise();

        }

    }
    
    void OverrideNoise()
    {

        grain.enabled.Override(true);
        grain.intensity.Override(1f);
        //public PostProcessVolume QuickVolume(int layer, float priority, params PostProcessEffectSettings[] settings)
        processVolume = PostProcessManager.instance.QuickVolume(8, 100f, grain);
        Debug.Log("Override");

    }


    // Start is called before the first frame update
    void Start()
    {
 
        grain = ScriptableObject.CreateInstance<Grain>();

        Invoke("OverrideNoise",5f);

    }

}
