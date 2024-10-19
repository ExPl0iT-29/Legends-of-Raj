using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleporttoLvl3 : MonoBehaviour
{
    public GameObject ma;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D other) 
    {
        // Check if the object that collided has the tag "Player"
        if(other.gameObject.CompareTag("Player") && ma == true) 
        {
            // Load the scene named "cave"
            SceneManager.LoadScene("Lvl3");
        }
    }
}
