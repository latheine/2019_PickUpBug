using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSystem : MonoBehaviour
{

    public static float PlayerMaxHealth;
    public static float PlayerHealth;
    [SerializeField] GameObject Auto_Timer;
    public float PMH;
    public float PH;
    //SceneChangeFlag


    // Start is called before the first frame update
    void Start()
    {
    
        //初期化
        PlayerMaxHealth = 100;
        PlayerHealth = PlayerMaxHealth;
        Auto_Timer = GameObject.FindWithTag("Timer");     

    }

    // Update is called once per frame
    void Update()
    {

        //可視化
        PMH = PlayerMaxHealth;
        PH = PlayerHealth;

        //動作確認用HP自然減少
        //PlayerHealth -= Time.deltaTime;

        if (PlayerHealth <= 0)
        {

            Auto_Timer.GetComponent<TimerAndGameOver>().CallGameOver();

        }else if(PlayerHealth > PlayerMaxHealth)
        {

            PlayerHealth = PlayerMaxHealth;

        }

    }

}
