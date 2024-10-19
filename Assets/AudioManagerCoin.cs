using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagerCoin : MonoBehaviour
{
    public AudioSource CoinSource;
    public AudioClip music;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlaySFX(AudioClip clip){
        CoinSource.PlayOneShot(clip);
    }
}
