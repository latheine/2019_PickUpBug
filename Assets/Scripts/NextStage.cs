using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NextStage : MonoBehaviour
{

    private AsyncOperation async; //https://docs.unity3d.com/ja/current/ScriptReference/AsyncOperation.html　
    public GameObject LoadingUi;
    public Slider slider;

    /* 最近Warning出るようになったっぽい？
     * defaultリテラルはC#7.1以上でのみ使用可能らしいが、
     * それ以下でも一応書いておけばコンソールは静かになる?
     * https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-7-1 (Microsoft What's new in C# 7.1)
     */

    [SerializeField] string StageName = default;

    public void OnClick()
    {

        LoadingUi.SetActive(true);
        StartCoroutine(LoadScene());

        Debug.Log("ButtonPushed");
        Time.timeScale = 1f;    

    }
    IEnumerator LoadScene()
    {

        async = SceneManager.LoadSceneAsync(StageName); //LoadSceneだとvoid -> asyncでエラーが出る。

        //動作が終わってなければ
        while (!async.isDone)
        {

            slider.value = Mathf.Clamp01(async.progress / 0.9f); //progressで進捗状況を表示

            /*
             *for(async.progress <= 0.9f){} 
             * Mathf関数一覧
             * https://docs.unity3d.com/ja/current/ScriptReference/Mathf.html
            */

            yield return null;

        }

    }

}
