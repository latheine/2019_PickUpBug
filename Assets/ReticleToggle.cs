using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReticleToggle : MonoBehaviour
{
    Toggle toggle;
    [SerializeField]GameObject Reticle;
    void Start()
    {
        toggle = GetComponent<Toggle>();
    }
    // Update is called once per frame
    public void ChageToggle()
    {
        Reticle.SetActive(!Reticle.activeSelf);
    }
}
