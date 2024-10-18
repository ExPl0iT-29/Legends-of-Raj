using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 100;
    //public GameObject deatheffect;

    public void TakeDamage (int damage){
        health -= damage;
        if(health <= 0){
            Die();
        }
    }

    void Die(){
        //Instantiate(deatheffect,transform.position , Quaternion.identity);
        Debug.Log("DeathEffect Instiantiated!");
        Destroy(gameObject);
    }
}
