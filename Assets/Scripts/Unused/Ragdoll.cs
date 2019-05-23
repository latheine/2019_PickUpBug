using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ragdoll : MonoBehaviour
{

    //対象プレハブのセット、フラグ
    public GameObject RagdollPrefab;
    public GameObject AlivePrefab;
    public GameObject Scoretext;
    Rigidbody RB;
    Animator Anim;
    private bool Flag;
    float DFsec;

    
    private void Start()
    {

        //初期化
        AlivePrefab.SetActive(true);
        RagdollPrefab.SetActive(false);


        Flag = false;
        RB = AlivePrefab.GetComponent<Rigidbody>();

    }

    //もしPlayerが範囲に入ったら・・・
    void OnTriggerEnter(Collider col)
    {

        if (col.CompareTag("Player"))
        {

            //FreezeRoatationの解除、デバッグログ、フラグのオン
            RB.constraints = RigidbodyConstraints.None;
            Debug.Log("Checked");
            CountAndClear.Count++;
            Flag = true;

            //int->string
            //Scoretext.GetComponent<Text>().text = ((int)killcount).ToString() + " Kill!";

        }

    }

    //もしFlagがTrueならフレーム毎にDFsecを増加
    void Update()
    {

        if(Flag)
        {

            DFsec += Time.deltaTime;

            //条件を満たしたのでラグドールと置換
            if (DFsec >= 5.0f)
            {

                Debug.Log("呼ばれました");
                AlivePrefab.SetActive(false);
                RagdollPrefab.SetActive(true);

            }

        }

    }

}