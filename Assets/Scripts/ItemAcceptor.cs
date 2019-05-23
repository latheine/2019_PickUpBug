using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemAcceptor : Acceptor
{
    public GameObject targetTB;
    GameObject ThisItem;
    private AudioSource audioSource;
    [SerializeField] AudioClip audioClip;

    //当てはまるものがあれば
    [Header("Choose one option what is true")]
    [Tooltip("キーアイテム")]
    [SerializeField] bool isKey = false;
    [Tooltip("回復アイテム")]
    [SerializeField] bool isPotion = false;
    [Tooltip("タイム増加アイテム")]
    [SerializeField] bool isTimer = false;
    [Tooltip("キーアイテム取得時のメッセージ")]
    [SerializeField] string messege = default;

    [SerializeField] bool DEBUG = false;

    public TimerAndGameOver timer;

    private void Start()
    {

        ThisItem = this.gameObject;
        /*ランダムに生成された各オブジェクトにスクリプトがついているので
        　ItemAcceptorとして1つのスクリプトにまとめるのではなく
        　キーアイテム用Acceptor、タイマー用Acceptor...etcと分けたほうが良い気がしてきた。      
        　https://en.wikipedia.org/wiki/Visitor_pattern#C#_example　(Wikipedia [Visitor Pattern C#])
        */
        audioSource = ThisItem.GetComponent<AudioSource>();

    }

    public override void Accept(Visitor visitor)
    {

        /* ObjectがDestroyされるとコンポーネントも消える為PlayClipAtPointを使用。
         * 音量に関してはScript側で指定が無ければ１。
         * https://docs.unity3d.com/ScriptReference/AudioSource.PlayClipAtPoint.html
        */
        AudioSource.PlayClipAtPoint(audioClip, transform.position,0.7f);
        Debug.Log(gameObject.name);
        Text SetWord = targetTB.GetComponent<Text>();
        //SetWord.text = "I got a " + gameObject.name;       

        //もしこれがキーアイテムならカウント++
        if (isKey)
        {

            FlagManager.playerProgressNum++;
            SetWord.text = messege;

        }
        else if (isPotion)
        {

            PlayerSystem.PlayerHealth += 50;

        }
        else if (isTimer)
        {

            timer.time += 50f;

        }else
        {

            CountAndClear.Count++;

        }

        if (DEBUG) CountAndClear.clearFlag = true;
        
        Destroy(gameObject);

    }

}
