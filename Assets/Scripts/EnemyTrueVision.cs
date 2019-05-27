using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTrueVision : MonoBehaviour
{

    public GameObject enemyObject;
    float test;
    Renderer[] renderer;

    // Start is called before the first frame update
    void Start()
    {

        renderer = enemyObject.GetComponentsInChildren<Renderer>();
        foreach (Renderer rend in renderer)
        {
            rend.material.SetFloat("_alphaFloat", 0.1f);
        }

    }

    //エリア内にプレイヤーがいる時敵のアルファ値を上げる
    void OnTriggerStay(Collider player)
    {

        foreach (Renderer rend in renderer)
        {
            rend.material.SetFloat("_alphaFloat", test);
        }
        if (player.tag =="Player" && test <=10f)
        {
            test += Time.deltaTime * 0.5f;
        }
 
    }

    void OnTriggerExit(Collider collider)
    {
        Invoke("AlphaReset", 60);
    }

    void AlphaReset()
    {

        foreach (Renderer rend in renderer)
        {
            rend.material.SetFloat("_alphaFloat",0.1f);
        }

    }

}
