using UnityEngine;
using System.Collections;

public class EnemyChangeDirectionState : EnemyState
{
    public void Enter()
    {
        Debug.Log("Enter State ChangeDirection");
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
