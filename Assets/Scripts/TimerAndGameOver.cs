using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerAndGameOver : MonoBehaviour
{
    
    public float time = 60f; //ｔを大文字にすると既存のTimeと被る
    public GameObject GameOverCamera;
    public GameObject gameover;
    AudioSource audioSource = default;
    [SerializeField] AudioClip audioClip = default;

    [SerializeField] GameObject titleButton = default;
    GameObject PlayerObject = default;


    private float PH;
    private bool IsPlaying;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        IsPlaying = true;
        audioSource = GetComponent<AudioSource>();

        //floatからintへcastしてstring表示
            GetComponent<Text>().text = ((int)time).ToString();
            PlayerObject = GameObject.FindWithTag("Player");

        //UI初期化
            gameover.SetActive(false);
            GameOverCamera.SetActive(false);
            titleButton.SetActive(false);

            PlayerObject.GetComponent<CharacterController>();

    }

    // Update is called once per frame
    void Update()
    {
        if (IsPlaying)
        {

            time -= Time.deltaTime;

            if (time < 0)
            {
                CallGameOver();
            }

            //もしマイナスになったら表示は０に
            if (time < 0) time = 0;

            GetComponent<Text>().text = ((int)time).ToString();

        }

    }

    public void CallGameOver()
    {

        //タイムアップで呼び出しorHP0で
        if(IsPlaying)
        { 
            StartCoroutine("GameOver");
            IsPlaying = false;
        }

    }

    //ゲームオーバー処理
    public IEnumerator GameOver()
    {

        //GameOverSoundを設定
        audioSource.clip = audioClip;
        audioSource.Play();

        //UI色々表示
        Time.timeScale = 0f;
        GameOverCamera.SetActive(true);
        gameover.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        titleButton.GetComponent<Button>();
        titleButton.SetActive(true);

        yield return new WaitForSeconds(1.0f);

    }

}
