using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogsAcceptor : Acceptor
{

    public GameObject text;

    public override void Accept(Visitor visitor)
    {

        text.SetActive(true);

        if (Input.GetMouseButton(0))
        {

            text.SetActive(false);

        }

    }


}

