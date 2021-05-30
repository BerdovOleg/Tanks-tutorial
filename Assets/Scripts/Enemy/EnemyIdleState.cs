using UnityEngine;
using System.Collections;

public class EnemyIdleState : EnemyState
{
    private EnemyScript _Enemy;

    private float idleTimer;

    private float idleDuration =5f;

    public void Enter(EnemyScript Enemy)
    {
        Debug.Log("EnterState Idle");
        this._Enemy = Enemy;
        idleTimer = 0;
    }

    public void Exit()
    {
        Debug.Log("Exit State Idle");
    }

    public void Update()
    {
        Debug.Log("Update State Idle");
        Idel();
    }


    private void Idel()
    {
        idleTimer += Time.deltaTime; 
        //todo animation
        if (idleTimer>=idleDuration)
        {
            _Enemy.SetStateMove();
        }

    }
}
