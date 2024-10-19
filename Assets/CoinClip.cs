using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinClip : MonoBehaviour
{
    AudioManagerCoin am;
    // Start is called before the first frame update
    void Start()
    {
        am = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManagerCoin>();
    }

    // Update is called once per frame
    void Update()
    {   
        
    }
    private void OnCollisionEnter2D(Collision2D other) {
            if(other.gameObject.CompareTag("Player")){
                am.PlaySFX(am.music);
            }
        }
}
