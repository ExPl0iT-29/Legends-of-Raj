using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public GameManagerScript Game_Manager;
    [SerializeField] public float health;
    [SerializeField] public float maxHealth;
    public Image healthBar;
    private bool isDead;

    // Start is called before the first frame update
    void Start()
    {
        maxHealth = health;
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.fillAmount = Mathf.Clamp(health / maxHealth ,0,1);

        if(health <= 0 && !isDead){
            isDead = true;
            gameObject.SetActive(false);
            Debug.Log("Dead");
            Game_Manager.gameOver(); 
        }
    }
}
