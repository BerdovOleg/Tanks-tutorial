using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthControl : MonoBehaviour
{
    public float MaxPlayerHealth;
    public float CurrentPlayerHealth;
    public float resist;
    public float defens;


    // Start is called before the first frame update
    void Start()
    {
        SetMaxHealth();
    }

    private void SetMaxHealth()
    {
        CurrentPlayerHealth = MaxPlayerHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (CurrentPlayerHealth<=0)
        {
            isDead();
        }
        
    }

    private void isDead()
    {
        print("//TODO VOID IS DEAD!<<<<<<<<<<<<<<<<<<<<<");
    }

    public void takeDamage(float damage)
    {
        //CurrentPlayerHealth = CurrentPlayerHealth - (damage * (resist + defens));
        CurrentPlayerHealth = CurrentPlayerHealth - damage;
    }


}
