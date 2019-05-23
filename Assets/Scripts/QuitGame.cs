using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class QuitGame : MonoBehaviour
{
   
    public void OnClick()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();

    }

}
