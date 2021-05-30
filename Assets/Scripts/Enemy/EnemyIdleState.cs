using UnityEngine;
using System.Collections;

public class EnemyIdleState : EnemyState
{
    public void Enter()
    {
        Debug.Log("EnterState Idle");
    }

    public void Exit()
    {
        Debug.Log("Exit State Idle");
    }

    public void Update()
    {
        Debug.Log("Update State Idle");
    }
}
