using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlagManager: MonoBehaviour
{
    
    //ゲーム進行に関わるフラグの管理、及び条件達成後のシーン遷移。

    [SerializeField]
    GameObject infoTB = default; //TB=TextBox
    [SerializeField]
    GameObject playerTB = default;
    [SerializeField]
    GameObject Player = default;

    [Header("SChangeMsg,KegItemNum")]
    public string sceneChangeMessege_NotYet;
    public string sceneChangeMessege_Already;
    [SerializeField] int requiredNumber = default; //次のシーン遷移に何個キーアイテムが必要？
    [SerializeField] public static int playerProgressNum = 0; //今のキーアイテム取得状況
    Text playerMsg;

    [Header("KeyItem,CountAndCheck")]
    [SerializeField]
    GameObject[] keyItem = default;
    public int[] keyItemCount;　//指定のカウントになった時キーアイテム出現
    public bool[] isChecked; //キーアイテム出した？
    
    [Header("InfoMsg,FlagCount")]
    public int[] infoFlagCount; //infoメッセージ更新用
    [SerializeField]
    string[] messege = default;
    Text infoMsg;
    bool[] once;

    // Start is called before the first frame update
    void Start()
    {

        infoMsg = infoTB.GetComponent<Text>();
        infoMsg.text = messege[0];
        isChecked[0] = false;

        playerProgressNum = 0;

    }

    // Update is called once per frame
    void Update()
    {

        //infoMsg用　    *Break忘れるとフリーズ。
        for (int i = 0; i <= infoFlagCount.Length;)
        {

            if (CountAndClear.Count >= infoFlagCount[i]) //[0]～[i]全部が毎フレーム呼び出されているので改善したい。
            {                                           

                infoMsg.text = messege[i];
                i++;

            }
            else
            {
                break;
            }

        }

        //keyItem出現用
        for (int j = 0; j < keyItemCount.Length;)
        {

            if (CountAndClear.Count == keyItemCount[j] && !isChecked[j])
            {

                keyItem[j].SetActive(true);
                isChecked[j] = true;
                j++;

            }
            else
            {
                break;
            }

        }

    }

    //シーンチェンジエリア(仮)に入ったら
    void OnTriggerEnter(Collider collider)
    {

        //現在のキーアイテム取得数が最低必要数の条件満たしてるか確認
        if (playerProgressNum != requiredNumber && collider.CompareTag("Player"))
        {

            playerMsg = playerTB.GetComponent<Text>();
            playerMsg.text = sceneChangeMessege_NotYet;
            Debug.Log(playerProgressNum);

        }

        if (playerProgressNum == requiredNumber && collider.CompareTag("Player"))
        {

            playerMsg = playerTB.GetComponent<Text>();
            playerMsg.text = sceneChangeMessege_Already;

            CountAndClear.clearFlag = true;

        }

    }

}
