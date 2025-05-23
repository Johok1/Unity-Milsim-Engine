using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Entity : MonoBehaviour
{
    public float health = 50f;

    public void TakeDamage(float amt)
    {
        health -= amt;
        KillIfDead();
    }

    private void KillIfDead()
    {

        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        //destroys object script is attached to 
        Destroy(gameObject);
    }

    public abstract bool CompareTo(Entity entity); 

}
