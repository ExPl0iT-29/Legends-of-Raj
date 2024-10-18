using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform FirePoint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!Global.playmode) return;
        if(Input.GetButtonDown("Fire1")){
            Shoot();
        }
    }
    public void Shoot(){
        Instantiate(bulletPrefab, FirePoint.position, FirePoint.rotation);
    }
}
