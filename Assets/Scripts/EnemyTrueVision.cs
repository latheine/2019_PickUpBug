using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTrueVision : MonoBehaviour
{

    public GameObject enemyObject;
    float test = 0.1f;
    Renderer[] renderer;
    bool isActive;

    // Start is called before the first frame update
    void Start()
    {
        isActive = false;
        renderer = enemyObject.GetComponentsInChildren<Renderer>();
        foreach (Renderer rend in renderer)
        {
            rend.material.SetFloat("_alphaFloat", 0.1f);
        }

    }

    //エリア内にプレイヤーがいる時敵のアルファ値を上げる
    void OnTriggerStay(Collider player)
    {

        if (player.tag == "Player")
        {

            foreach (Renderer rend in renderer)
            {
                rend.material.SetFloat("_alphaFloat", test);
            }

            if (test <= 10f)
            {
                test += Time.deltaTime * 0.5f;
            }

        }
 
    }

    void OnTriggerExit(Collider player)
    {
        if (player.tag == "Player" && !isActive)
        {
            StartCoroutine("AlphaReset");
            isActive = true;
        }
    }

    IEnumerator AlphaReset()
    {
        //Debug.Log("Called");
        yield return new WaitForSeconds(60f);
        foreach (Renderer rend in renderer)
        {
            rend.material.SetFloat("_alphaFloat", 0.1f);
        }
        test = 0.1f;
        StopCoroutine("AlphaReset");
        //Debug.Log("StopCoroutine");
        isActive = false;
    }

}
