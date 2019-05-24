using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PatrolSystem : MonoBehaviour
{

    public int damageToPlayer = 20;
    public float Speed = 1f;
    public float chaseSpeed = 3f;
    public float patrolSpeed = 1f;
    public float rotationSpeed = 1f;
    public float posRange = 10f;
    public float searchRange = 90f;
    private Vector3 targetPos;
    private float changeTarget = 50f;
    private bool IsAttack = false;

    private Animator animator;
    [SerializeField] float animSpeed = default;
    [SerializeField] AudioClip enemyIdle = null;
    [SerializeField] AudioClip enemyAttack = null;
    AudioSource audioSource;
    bool m_Play;
    bool m_Loop; 

    public float distanceToPlayer;
    public float targetDistance;

    public GameObject player;

    //ランダムに取得
    Vector3 GetRandomPosition(Vector3 currentpos)
    {
       
        return new Vector3(Random. Range(-posRange + currentpos.x, posRange + currentpos.x),
            0,Random.Range(-posRange + currentpos.z, posRange + currentpos.z));

    }

    void patrol()
    {

      
        //目的地Posに障害物がある事を考えて手前で変更
        if (targetDistance < changeTarget)
        {

            targetPos = GetRandomPosition(transform.position);
            audioSource.loop = false;

        }

        audioSource.clip = enemyIdle;
        audioSource.Play();
        audioSource.loop = true;

        //Debug.Log("patrol loaded");

        //向きを取得
        //https://docs.unity3d.com/ScriptReference/Quaternion.html
        Quaternion targetRotation = Quaternion.LookRotation(targetPos - transform.position);
        
        //移動
        transform.Translate(Vector3.forward * Speed * patrolSpeed * Time.deltaTime);

        //向きを変更
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * Speed * rotationSpeed);


    }

    void chase()
    {

        //Playerを追う為に向きを取得
        Quaternion playerRotation = Quaternion.LookRotation(player.transform.position - transform.position);
        //向き変更
        transform.rotation = Quaternion.Slerp(transform.rotation, playerRotation,
            Time.deltaTime * rotationSpeed * 10f);
        //移動
        transform.Translate(Vector3.forward * Speed * chaseSpeed * Time.deltaTime);

    }

    IEnumerator AttackToPlayer()
    {

        //コルーチンの連続稼働防止
        if (IsAttack)
        {

            //Debug.Log("CoroutineBreak");
            yield break;           

        }

        //コルーチン稼働フラグ
        IsAttack = true;

        PlayerSystem.PlayerHealth -= damageToPlayer;
        Debug.Log("Attack!");

        //AnimSpeed = 0f;
        animator.SetTrigger("Attack");
        audioSource.clip = enemyAttack;
        audioSource.Play();

        //稼働フラグオフ
        yield return new WaitForSeconds(3);
        IsAttack = false;

    }


    // Start is called before the first frame update
    void Start()
    {       

        //巡回用pos
        targetPos = GetRandomPosition(transform.position);

        //animator、audiosource取得
        animator = this.gameObject.GetComponent<Animator>();
        animSpeed = 0f;
        audioSource = this.gameObject.GetComponent<AudioSource>();

        //自動でプレイヤーセット(必要なければ消す)
        player = GameObject.FindWithTag("Player");
        player.GetComponent<PlayerSystem>();

    }

    // Update is called once per frame
    void Update()
    {

        /*SqrMagnitudeでベクトル2乗の長さを返す。Distanceよりこっちの方が計算が高速らしい。
          https://docs.unity3d.com/ja/2018.3/ScriptReference/Vector3.html (ScriptReference(Vector3))
          http://cocokyoro.hateblo.jp/entry/2016/06/15/033835 (ただの適当な開発記)
          ところでマグニチュードとは
          [主な意味]
          大小、重大、(恒星の)光度、(光度による)等級... */
        targetDistance = Vector3.SqrMagnitude(transform.position - targetPos);

        distanceToPlayer = Vector3.SqrMagnitude(transform.position - player.transform.position);

        //モードの指定　遠ければ巡回　近ければチェイス、接近で攻撃
        if (distanceToPlayer > searchRange)
        {

            patrol();
            animSpeed = Speed * 3f;
            animator.SetFloat("Speed", animSpeed);

        }
        else if (3f < distanceToPlayer && distanceToPlayer < searchRange)
        {

            chase();
            animSpeed = Speed * 10f;
            animator.SetFloat("Speed", animSpeed);

        }
        else
        {

            audioSource.loop = false;
            StartCoroutine("AttackToPlayer");         

        }

    }

}
