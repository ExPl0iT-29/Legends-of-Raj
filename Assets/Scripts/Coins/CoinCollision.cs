using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollision : MonoBehaviour
{
    public CoinManager cm;
    //AudioManager audioManager;
    private void Awake() {
        //am = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManagerCoin>();
    }
    // Start is called before the first frame update
    void Start()
    {
        //cm = GetComponent<CoinManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Coin")){
            //audioManager.PlaySFX(audioManager.coin);
            Destroy(other.gameObject);
            cm.coinCount++;
        }
    }
}
