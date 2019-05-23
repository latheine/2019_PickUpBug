using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotation : MonoBehaviour
{

    void Update()
    {

        transform.Rotate(new Vector3(Random.Range(0, 180),
                                     Random.Range(0, 180),
                                     Random.Range(0, 180)
                                    ) * Time.deltaTime*2);

    }

}