using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollision : MonoBehaviour
{
    public CoinManager cm;
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
            Destroy(other.gameObject);
            cm.coinCount++;
        }
    }
}
