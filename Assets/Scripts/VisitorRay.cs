using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisitorRay : Visitor
{

    private Ray ray;
    private Vector3 rayPos;
    public Camera camera;
    public GameObject hasItem;
    [SerializeField] float RayDistance;
    RaycastHit hit;

    // Visitor->Acceptor
    // https://www.techscore.com/tech/DesignPattern/Visitor.html/ Visitorパターンサンプル(Java) TECHSCORE
    public override void Visit(ItemAcceptor acceptor)
    {

        acceptor.Accept(this);
        Debug.Log("loading ItemAcceptor");

    }

    public override void Visit(LogsAcceptor acceptor)
    {

        acceptor.Accept(this); 
        Debug.Log("loading LogsAcceptor");
       
    }

    public override void Visit(DoorAcceptor acceptor)
    {

        acceptor.Accept(this);
        Debug.Log("loading DoorAcceptor");

    }

    void Start()
    {
       
        ray = new Ray();
        rayPos = camera.ScreenToWorldPoint(Input.mousePosition);
        
    }

    void Update()
    {
        ray = camera.ScreenPointToRay(Input.mousePosition);
        if (Input.GetButton("Search"))
        {
            
            RaycastHit hit;

            //もし対象にAcceptorがついてるなら
            if(Physics.Raycast(ray,out hit,RayDistance))
            {

                GameObject Tobject = hit.collider.gameObject;

                ItemAcceptor item = Tobject.GetComponent<ItemAcceptor>();
                if (item != null) Visit(item);

                LogsAcceptor logs = Tobject.GetComponent<LogsAcceptor>();
                if (logs != null) Visit(logs);

                DoorAcceptor door = Tobject.GetComponent<DoorAcceptor>();
                if (door != null) Visit(door);

            }

        }

        //以下キューブを掴む動作
        /*
        if(Input.GetButton("Fire2"))
        {
            Rigidbody rigidbody;
            Transform TOtransform;
            ray = camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray,out hit,RayDistance))
            {

                GameObject Tobject = hit.collider.gameObject;

                if(Tobject.gameObject.tag == "Cube")
                {

                    
                    rigidbody = Tobject.GetComponent<Rigidbody>();
                    rigidbody.isKinematic = true;
                    TOtransform = Tobject.GetComponent<Transform>();
                    TOtransform.SetParent(hasItem.transform);

                }

            }
        }*/

        if (Physics.Raycast(ray, out hit, RayDistance))
        {

            Rigidbody rigidbody;
            Transform toTransform;

            ray = camera.ScreenPointToRay(Input.mousePosition);
            GameObject Tobject = hit.collider.gameObject;

            //Debug.Log("hit");

            if (Tobject.gameObject.tag == "Cube")
            {
                
                toTransform = Tobject.GetComponent<Transform>();
                rigidbody = Tobject.GetComponent<Rigidbody>();
                //Debug.Log("&Cube");

                if (Input.GetButton("Fire2"))
                {

                    
                    rigidbody.isKinematic = true;

                    /*hasItemと同じ座標にする。
                     カメラRayと同じ位置にする方法の方がよいのだろうか
                    */

                    toTransform.SetParent(hasItem.transform);

                    //Debug.Log("Fire2");

                }
                else
                {

                    toTransform.SetParent(null);
                    rigidbody.isKinematic = false;

                }

            }

        }

    }

}
    