using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraray : MonoBehaviour
{
    public Camera camera;
    public GameObject aiueo;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        RaycastHit hit;
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
   
            if (Physics.Raycast(ray, out hit,10.0f))
            {
               if (Input.GetKeyDown("space"))
               {

                    Transform objectHit = hit.transform;
                    string gameobjectName = hit.collider.gameObject.name;
                    Debug.Log(gameobjectName);
                    Destroy(hit.collider.gameObject);
                    print("SpaceKey was prassed");

                }

            }
       
    }
}
