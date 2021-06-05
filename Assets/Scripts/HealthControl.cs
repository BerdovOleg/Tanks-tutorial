using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthControl : MonoBehaviour
{
    public float MaxHealth;
    public float CurrentHealth;
    public float resist;
    public float defens;


    // Start is called before the first frame update
    void Start()
    {
        SetMaxHealth();
    }

    private void SetMaxHealth()
    {
        CurrentHealth = MaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (CurrentHealth <= 0)
        {
            isDead();
        }

    }

    private void isDead()
    {
        print("//TODO VOID IS DEAD!<<<<<<<<<<<<<<<<<<<<<");
        Destroy(this.gameObject);
    }

    public void takeDamage(float damage)
    {
        //CurrentPlayerHealth = CurrentPlayerHealth - (damage * (resist + defens));
        CurrentHealth = CurrentHealth - damage;
    }


}
