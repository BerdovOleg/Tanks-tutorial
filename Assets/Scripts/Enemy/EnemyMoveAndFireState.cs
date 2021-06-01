using UnityEngine;
using System.Collections;

public class EnemyMoveAndFireState : EnemyState
{
    private EnemyScript _Enemy;

    private float moveTimer;

    private float moveDuration = 5f;

    public void Enter(EnemyScript Enemy)
    {
        Debug.Log("Enter State MoveAndFire");
        this._Enemy = Enemy;
        moveTimer = 0;
    }

    public void Exit()
    {
        Debug.Log("Exit State MoveAndFire");
    }

    public void Update()
    {
        Move();
        _Enemy.Shoot();
    }

    private void Move()
    {
        moveTimer += Time.deltaTime;
        _Enemy.MoveToPoint();
        //todo animation
        if (moveTimer >= moveDuration)
        {
            _Enemy.SetStateChangeDir();
        }
    }
}
