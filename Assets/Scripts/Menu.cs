using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Menu : MonoBehaviour
{

    [SerializeField] GameObject MenuObject = null;
    [SerializeField] AudioMixer audioMixer = null;
    public bool IsActive = false;

    // Start is called before the first frame update
    void Start()
    {

        MenuObject = GameObject.FindWithTag("Menu");
        MenuObject.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.F1))
        {

            MenuObject.SetActive(!MenuObject.activeSelf);
          
            if (MenuObject.activeSelf)
            {

                Time.timeScale = 0f;
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;

            }
            else
            {

                Time.timeScale = 1f;
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;

            }

        }

    }
    //各種音量スライダー 
    public void SetMaster(float volume)
    {
        audioMixer.SetFloat("MasterVol", volume);
    }
    public void SetBGM(float volume)
    {
        audioMixer.SetFloat("BGMVol", volume);
    }
    public void SetSE(float volume)
    {
        audioMixer.SetFloat("SEVol", volume);
    }
    public void SetVoice(float volume)
    {
        audioMixer.SetFloat("VoiceVol", volume);
    }
}
