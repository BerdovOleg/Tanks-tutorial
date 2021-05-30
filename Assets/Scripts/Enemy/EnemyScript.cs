using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    private Dictionary<Type, EnemyState> StateMap;
    private EnemyState CurrentState;

    [SerializeField]float randomFactor;

    [SerializeField] float moveSpeed = 0.5f;

    bool _direction;


    void Start()
    {
        this.InitState();
        this.SetStateByDefault();
    }

    void Update()
    {
        if (this.CurrentState != null) this.CurrentState.Update();
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
        transform.Translate(GetDirection() * moveSpeed * Time.deltaTime);       
    }

    public Vector2 GetDirection()
    {
        return _direction ? Vector2.down : Vector2.up;
        return _direction ? Vector2.left : Vector2.right;

    }

    public void ChangeDir()
    { 
        transform.rotation = Quaternion.AngleAxis(transform.rotation.z +90, Vector3.forward);
    }

    public void Shoot()
    {

    }
}
