using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicCircle : MonoBehaviour
{
    // Start is called before the first frame update

    void OnTriggerStay(Collider item)
    {
        if(item.tag == "movable")
        {
            CountAndClear.clearFlag = true;
        }

    }

}
