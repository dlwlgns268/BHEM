using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyCode : MonoBehaviour
{
    public int _maxHP = 0;
    public float _currHp = 0;
    public int Atk = 0;
    private int _dotAtk = 0;
    private int _def = 0;
    private Rigidbody2D _enemyRigid;
    private float _enemyAtkDelay = 0;
    private const float EnemySpeed = 16;
    public GameObject Enemy;
    public Transform Target;
    private const float EnemySight = 34;
    private const float EnemyAtkSight = 3.5f;
    public Animator _enemyAnimator;
    public float _direct = 3;
    public float _invincibleTime = 0f;
    public GameObject Player;
    public GameObject Bullet;

    private void Awake()
    {
        _enemyRigid = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        InvokeRepeating("Cliff", 3f, 3f);
        _enemyAtkDelay = 2;
        
        //Enemy State Definition
        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "Tutorial")
        {
            _maxHP = 0;
            _currHp = _maxHP;
            Atk = 0;
            _dotAtk = 0;
            _def = 0;
        }
        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "1-1")
        {
            _maxHP = Random.Range(777, 971);
            _currHp = _maxHP;
            Atk = Random.Range(34, 38);
            _dotAtk = 0;
            _def = Random.Range(26, 33);
        }
        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "1-2")
        {
            _maxHP = Random.Range(83, 98);
            _currHp = _maxHP;
            Atk = Random.Range(36, 39);
            _dotAtk = 0;
            _def = Random.Range(31, 38);
        }
        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "1-3")
        {
            _maxHP = Random.Range(90, 103);
            _currHp = _maxHP;
            Atk = Random.Range(37, 41);
            _dotAtk = 0;
            _def = Random.Range(38, 46);
        }                                                                                                                                   
    }

    // Update is called once per frame
    void Update()
    {
        _invincibleTime -= Time.deltaTime;
        if (_invincibleTime < 0)
        {
            _invincibleTime = 0;
        }
        float distance = Vector3.Distance(transform.position, Target.position);
        _enemyAtkDelay -= Time.deltaTime;
            if (_enemyAtkDelay <= 0 && distance <= EnemySight)
            {
                LockOnTarget();
                if (distance <= EnemyAtkSight)
                {
                    AttackToTarget();   
                }

                if (distance is <= EnemySight and >= EnemyAtkSight)
                {
                    MoveToTarget();
                }
            }
            else
            {
                _enemyRigid.velocity = new Vector2(_direct, _enemyRigid.velocity.y);
            }
            
            
            
        if (_currHp <= 0)
        {
            Destroy(gameObject);
        }   
    }
    
    //Enemy Damage Operation
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet") && _invincibleTime <= 0f)
        {
            Debug.Log("aya");
            _currHp -= (Player.GetComponent<PlayerState>().PlayerAtk - _def) * 0.2f;
            _invincibleTime = 0.03f;
        }

        if (collision.gameObject.CompareTag("Fallen"))
        {
            _currHp = 0;
        }
    }

    //Enemy AI
    private void LockOnTarget()
    {
        if (Target.position.x - transform.position.x < 0)
        {
            transform.localScale = new Vector3(-22, 22, 1);
        }
        else
        {
            transform.localScale = new Vector3(22, 22, 1);
        }
    }

    void MoveToTarget()
    {
        float dir = Target.position.x - transform.position.x;
        dir = (dir < 0) ? -1 : 1;
        transform.Translate(EnemySpeed * Time.deltaTime *new Vector2(dir, 0));
    }

    void AttackToTarget()
    {
        _enemyAtkDelay = 1.3f;
    }

    void Cliff()
    {
        if (_direct == 3)
        {
            _direct = -3;
        }
        else
        {
            _direct = 3;
        }
    }
}
