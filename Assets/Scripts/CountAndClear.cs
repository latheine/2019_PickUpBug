using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountAndClear : MonoBehaviour
{

    /* クリアとゲームオーバーを一緒にした方が良さそう。
       現状スパゲティ */

    public GameObject scoreText;
    [SerializeField] GameObject clearCamera = null;
    [SerializeField] GameObject gameClearText = null;

    public static int Count;

    [SerializeField] string urMassage = null;
    GameObject timerObject;

    //クリアコルーチン呼び出し用　
    public static bool clearFlag;

    AudioSource audioSource;
    [SerializeField] AudioClip audioClip = default;

    void Start()
    {

        timerObject = GameObject.FindGameObjectWithTag("Timer");//Find系は重い上にバグの温床になりやすいとか？
        clearFlag = false;
        gameClearText.SetActive (false);

        audioSource = GetComponent<AudioSource>();

        Count = 0;

        /* メモ
         * https://docs.unity3d.com/ScriptReference/Display.html
        Debug.Log("displays connected: " + Display.displays.Length);
            // Display.displays[0] is the primary, default display and is always ON.
            // Check if additional displays are available and activate each.
        if (Display.displays.Length > 1)
            Display.displays[1].Activate();
        if (Display.displays.Length > 2)
            Display.displays[2].Activate();
            ...
        */

    }


    void Update()
    {

        scoreText.GetComponent<Text>().text = ((int)Count).ToString() + urMassage;

 
        if(clearFlag)
        {

            StartCoroutine("GameClear");
            clearFlag = false;
        }

    }
    //クリア処理
    public IEnumerator GameClear()
    {

        audioSource.clip = audioClip;
        audioSource.Play();

        //UI色々表示
        Time.timeScale = 0f;
        gameClearText.SetActive(true);
        clearCamera.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        yield return new WaitForSeconds(1.0f);
        //timerObject.GetComponent<Timer>().enabled = false;
        

    }

}
