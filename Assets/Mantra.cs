using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Mantra : MonoBehaviour
{
    //AudioManager audioManager;
    public bool mantra;
    //
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player")) {
            //audioManager.PlaySFX(audioManager.mantra);
            mantra = true;
            gameObject.SetActive(false);
        }
    }
}
