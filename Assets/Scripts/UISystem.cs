using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.CrossPlatformInput;
using UnityStandardAssets.Utility;
using UnityEngine;
using UnityEngine.UI;
using Footsteps;

public class UISystem : MonoBehaviour
{
    public GameObject player;
    public PlayerSystem playerSystem;
    public FPS firstPersonController;


    //public Image GaugeYellow;
    public Image GaugeOrange;
    public Image HealthGauge;
    public Text HealthText;

    // Start is called before the first frame update
    void Start()
    {

        //player = GameObject.FindGameObjectWithTag("Player");
        firstPersonController = player.GetComponent<FPS>();
        playerSystem.GetComponent<PlayerSystem>();
        HealthText.GetComponent<Text>();
        this.initParameter();
        
    }

    // Update is called once per frame
    void Update()
    {

        GaugeOrange.fillAmount = firstPersonController.Stamina / firstPersonController.MaxStamina;
        HealthGauge.fillAmount = playerSystem.PH / playerSystem.PMH;
        HealthText.text = ((int)playerSystem.PH).ToString();

    }

    private void initParameter()
    {

        GaugeOrange.fillAmount = 1;
        HealthGauge.fillAmount = 1;

    }

}
