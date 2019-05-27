using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Text : MonoBehaviour
{

    [SerializeField] GameObject TTB = default; //TargetTextBox
    GameObject Auto_Player = default;
    public string messege;
    Text text;
    [SerializeField] bool once = false;
    bool isChecked = false;

    // Start is called before the first frame update
    void Start()
    {
       
        Auto_Player = GameObject.FindWithTag("Player");

    }

    void OnTriggerEnter(Collider collider)
    {

        if (isChecked == false && collider.CompareTag("Player"))
        {

            text = TTB.GetComponent<Text>();
            text.text = messege;
            if(once) isChecked = true;
            
        }
      
    }
    
}
