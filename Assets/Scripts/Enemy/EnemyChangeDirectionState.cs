using UnityEngine;
using System.Collections;

public class EnemyChangeDirectionState : EnemyState
{
    private EnemyScript _Enemy;
    public void Enter(EnemyScript Enemy)
    {
        Debug.Log("Enter State ChangeDirection");
        this._Enemy = Enemy;
        _Enemy.ChangeDir();
        _Enemy.SetStateStop();
    }

    public void Exit()
    {
        Debug.Log("Exit State ChangeDirection");
    }

    public void Update()
    {
        Debug.Log("Update State ChangeDirection");
    }

}
