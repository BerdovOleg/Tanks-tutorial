using UnityEngine;
using System.Collections;

public class EnemyStopAndFireState : EnemyState
{
    public void Enter(EnemyScript Enemy)
    {
        Debug.Log("Enter State StopAndFire");
    }

    public void Exit()
    {
        Debug.Log("Exit State StopAndFire");
    }

    public void Update()
    {
        Debug.Log("Update State StopAndFire");
    }
}
