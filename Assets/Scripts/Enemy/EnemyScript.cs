using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    private Dictionary<Type, EnemyState> StateMap;
    private EnemyState CurrentState;

    //параметры передвижения
    [SerializeField] float moveSpeed = 0.5f;//скорость передвижения
    Vector2 Direction;// напровление танка

    //параметры стрельбы
    [SerializeField] Transform[] _gun; //пушки
    [SerializeField] GameObject[] _bulet;//патроны
    [SerializeField] float bullSpeed; //скорость патрона
    [SerializeField] float CooldownTime = 1.5f; // скорость перезарядки
    [SerializeField] bool CanMakeShoot = true;
    float CooldownTimer;



    void Start()
    {
        Direction = Vector2.up;
        this.InitState();
        this.SetStateByDefault();        
    }

    void Update()
    {
        if (this.CurrentState != null) this.CurrentState.Update();
        CanMakeShoot = canShoot();
    }

    private void InitState()
    {
        this.StateMap = new Dictionary<Type, EnemyState>();

        this.StateMap[typeof(EnemyIdleState)] = new EnemyIdleState();
        this.StateMap[typeof(EnemyMoveAndFireState)] = new EnemyMoveAndFireState();
        this.StateMap[typeof(EnemyChangeDirectionState)] = new EnemyChangeDirectionState();
        this.StateMap[typeof(EnemyStopAndFireState)] = new EnemyStopAndFireState();
    }

    private void SetState(EnemyState newState)
    {
        if (this.CurrentState != null) this.CurrentState.Exit();

        this.CurrentState = newState;
        this.CurrentState.Enter(this);
    }

    private void SetStateByDefault()
    {
        this.SetStateIdle();
    }

    private EnemyState GetState<T>() where T : EnemyState
    {
        var type = typeof(T);
        return this.StateMap[type];

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            SetStateStop();
        }
        else if (collision.gameObject.tag == "Enemy")
        {
            Physics2D.IgnoreCollision(collision.gameObject.GetComponent<Collider2D>(), this.GetComponent<Collider2D>());
        }
        else
        {
            SetStateChangeDir();
        }
        
    }


    public void SetStateIdle()
    {
        var state = this.GetState<EnemyIdleState>();
        this.SetState(state);
    }

    public void SetStateMove()
    {
        var state = this.GetState<EnemyMoveAndFireState>();
        this.SetState(state);
    }

    public void SetStateChangeDir()
    {
        var state = this.GetState<EnemyChangeDirectionState>();
        this.SetState(state);
    }

    public void SetStateStop()
    {
        var state = this.GetState<EnemyStopAndFireState>();
        this.SetState(state);
    }



    public void MoveToPoint()//todo необходимо движение по направлению
    {
        transform.Translate(Direction * (moveSpeed * Time.deltaTime),Space.World);
        //transform.position = Vector3.Lerp(transform.position, Direction, Time.deltaTime * moveSpeed);
    }

 

    public void ChangeDir(int i)
    {
        if (i == 0)
        {
            transform.rotation = Quaternion.AngleAxis(0, Vector3.forward);
            Direction = Vector2.up;
        }
        else if (i == 1)
        {
            transform.rotation = Quaternion.AngleAxis(180, Vector3.forward);
            Direction = Vector2.down;
        }
        else if (i == 2)
        {
            transform.rotation = Quaternion.AngleAxis(-90, Vector3.forward);
            Direction = Vector2.right;
        }
        else if (i == 3)
        {
            transform.rotation = Quaternion.AngleAxis(90, Vector3.forward);
            Direction = Vector2.left;
        }
    }

    public void Shoot()
    {
        if (CanMakeShoot)
        {
            for (int i = 0; i < _gun.Length; i++)
            {
                GameObject bull = Instantiate(_bulet[i], new Vector2(_gun[i].position.x, _gun[i].position.y), transform.rotation);
                Destroy(bull, 3f);
                bull.tag = "EnemyBull";
                //Physics2D.IgnoreCollision(bull.GetComponent<Collider2D>(), this.GetComponent<Collider2D>());
                if (Direction == Vector2.up)
                {
                    bull.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, bullSpeed), ForceMode2D.Impulse);
                }
                else if (Direction == Vector2.down)
                {
                    bull.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, -bullSpeed), ForceMode2D.Impulse);
                }
                else if (Direction == Vector2.left)
                {
                    bull.GetComponent<Rigidbody2D>().AddForce(new Vector2(-bullSpeed, 0f), ForceMode2D.Impulse);
                }
                else if (Direction == Vector2.right)
                {
                    bull.GetComponent<Rigidbody2D>().AddForce(new Vector2(bullSpeed, 0f), ForceMode2D.Impulse);
                }
            }
        }
        else print("We no make shooting!");       
       
    }
    private bool canShoot()
    {  
        CooldownTimer += Time.deltaTime;
        if (CooldownTimer <= CooldownTime)
        {
            return false;
        }
        else
        {
            CooldownTimer = 0;
            return true;
        }

    }    
}
