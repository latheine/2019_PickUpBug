using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EventTalk : MonoBehaviour
{

    [Header("1stEvent or not?")]
    [SerializeField] bool is1stEvent = false;

    //loadscene用
    [Header("LoadScene用")]
    private AsyncOperation async;
    public GameObject LoadingUi;
    public Slider slider;
    [Tooltip("次遷移したいシーン名")]
    public string StageName = default;
 
    [Header("EventTalk")]
    //TTB is TargetTextBox
    public int messegenum;
    public GameObject TTB;
    public GameObject infobox;
    public GameObject timerimage;
    [SerializeField] string[] messege;
    Text talk;

    [Space(10)]
    [SerializeField]int ClickCount = 0;


    // Start is called before the first frame update
    void Start()
    {

        talk = TTB.GetComponent<Text>();

    }

    // Update is called once per frame
    void Update()
    {

        /*スプレッドシートに書いて読み込むのが良さそう　以下参考文献
         * https://qiita.com/hideyuki_hori/items/32dd3d65dd447dabe282 
         * https://www.memory-lovers.blog/entry/2017/03/04/215206
        */

        if (Input.GetButtonDown("Search"))
        {

            if (ClickCount < messegenum)
            {

                Debug.Log("----test----");

                ClickCount++;

                talk.text = messege[ClickCount];

            }
            else
            {

                LoadingUi.SetActive(true);
                StartCoroutine("LoadScene");            

            }

        }

        if (is1stEvent){

            if (ClickCount == 2) timerimage.SetActive(true);
            if (ClickCount == 9) infobox.SetActive(true);

        }

    }
    IEnumerator LoadScene()
    {

        async = SceneManager.LoadSceneAsync(StageName);
        
        while(!async.isDone)
        {

            slider.value = async.progress;
            yield return null;

        }

    }

}
