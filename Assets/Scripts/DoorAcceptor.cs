using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAcceptor : Acceptor
{

    Quaternion from;
    Quaternion to;

    float t = 0;
    public GameObject DoorObject;
    private Animator animator;
    private AudioSource audiosource;
    private bool m_Play;

    void Start()
    {

        m_Play = true;
        animator = DoorObject.GetComponent<Animator>();
        audiosource = DoorObject.GetComponent<AudioSource>();

    }
      

    public override void Accept(Visitor visitor)
    {

        animator.SetTrigger("DoorTrigger");
        Debug.Log("loading DoorAccepter");
        if(m_Play)
        {

            audiosource.Play();
            m_Play = false;

        }

        if (t < 1)
        {

            t += Time.deltaTime;
            transform.rotation = Quaternion.Slerp(from, to, t);

        }
        
        //transform.Rotate(new Vector3(0, 90f, 0) Time.time);

    }

}
