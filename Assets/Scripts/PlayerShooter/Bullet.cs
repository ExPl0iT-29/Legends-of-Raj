using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float speed = 20f;
    public Rigidbody2D rb;
    public int damage = 40;

    private Shake shake;
    // Start is called before the first frame update
    void Start()
    {
        shake = GameObject.FindGameObjectWithTag("ScreenShake").GetComponent<Shake>();
        rb.velocity = transform.right * speed; 
    }

    void OnTriggerEnter2D(Collider2D hitInfo) {
        shake.camShake();
        Enemy enemy = hitInfo.GetComponent<Enemy>();
        if(enemy != null){
            enemy.TakeDamage(damage);
        }
        Destroy(gameObject);
    }

}
