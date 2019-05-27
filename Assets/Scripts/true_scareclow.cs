using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class true_scareclow : MonoBehaviour
{
    //TrueScareClow用　PatrolSystem
    public float Speed = 1f;
    public float patrolSpeed = 1f;
    public float rotationSpeed = 1f;
    public float posRange = 10f;
    private Vector3 targetPos;
    private float changeTarget = 50f;

    private Animator animator;
    [SerializeField] float animSpeed = default;

    public float targetDistance;

    //ランダムに取得
    Vector3 GetRandomPosition(Vector3 currentpos)
    {

        return new Vector3(Random.Range(-posRange + currentpos.x, posRange + currentpos.x),
        0, Random.Range(-posRange + currentpos.z, posRange + currentpos.z));

    }

    void patrol()
    {

        if (targetDistance < changeTarget)
        {
            targetPos = GetRandomPosition(transform.position);
        }

        Quaternion targetRotation = Quaternion.LookRotation(targetPos - transform.position);
        transform.Translate(Vector3.forward * Speed * patrolSpeed * Time.deltaTime);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * Speed * rotationSpeed);

    }

       // Start is called before the first frame update
    void Start()
    {

        targetPos = GetRandomPosition(transform.position);
        animator = this.gameObject.GetComponent<Animator>();
        animSpeed = 0f;

    }

    // Update is called once per frame
    void Update()
    {

        targetDistance = Vector3.SqrMagnitude(transform.position - targetPos);      
        patrol();
        animSpeed = Speed * 3f;
        animator.SetFloat("Speed", animSpeed);

    }
    
    //範囲内で持続ダメージ、Terrainの端に来たらチェンジPos
    void OnTriggerStay(Collider collider)
    {
        if (collider.tag == ("Player")) PlayerSystem.PlayerHealth -= 2.5f * Time.deltaTime;
        else if (collider.tag == ("Terrain")) targetPos = GetRandomPosition(transform.position);
    }

}