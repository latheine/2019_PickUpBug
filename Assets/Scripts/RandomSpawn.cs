using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawn : MonoBehaviour
{

    public GameObject TargetObject;
    public float MinRange, MaxRange;
    public int Limit;
    public bool rdmRotation = false;

    // Start is called before the first frame update
    void Start()
    {

        //limit(n)以下であればセットされたオブジェクトをランダムに生成する
        for (int i = 0; i <= Limit; i++)
        {          

            if (rdmRotation)
            {

                Instantiate(TargetObject, new Vector3(Random.Range(MinRange, MaxRange),
                Random.Range(10, 50),
                Random.Range(MinRange, MaxRange)),
                Quaternion.Euler(Random.Range(0, 180),
                Random.Range(0, 180),
                Random.Range(0, 180)));

                /*
                 * float x = (Random.Range(nf,nf);
                 * float y = (Random.Range(nf,nf);
                 * float z = (Random.Range(nf,nf);
                 * float xr = (Random.Range(nf,nf);
                 * float yr = (Random.Range(nf,nf);
                 * float zr = (Random.Range(nf,nf);
                 * Instantiate(TargetObject, new Vector3(x,y,z),Quaternion.Euler(xr,yr,zr));
                 * 
                 * 上記の方が読みやすい気もする。
                 * https://docs.unity3d.com/2018.1/Documentation/ScriptReference/Random.Range.html
                */

            }
            else
            {

                Instantiate(TargetObject, new Vector3(Random.Range(MinRange, MaxRange),
                Random.Range(10, 50),
                Random.Range(MinRange, MaxRange)), Quaternion.identity);

            }

        }

    }

}
