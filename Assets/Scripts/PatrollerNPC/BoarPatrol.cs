using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.UIElements;

public class BoarPatrol : MonoBehaviour
{
    public GameObject PosA;
    public GameObject PosB;
    private Rigidbody2D rb;
    private Animator anim;
    private Transform currentPoint;
    [SerializeField]private float speed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        currentPoint = PosB.transform;
        anim.SetBool("isRunning",true);
    }

    // Update is called once per frame
    void Update()
    {
        UnityEngine.Vector2 point = currentPoint.position - transform.position;
        if(currentPoint == PosB.transform){
            rb.velocity = new UnityEngine.Vector2(speed , 0);
        } else {
            rb.velocity = new UnityEngine.Vector2(-speed ,0);
        }
        if (UnityEngine.Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == PosB.transform)
        {
            currentPoint = PosA.transform;
        }
        if (UnityEngine.Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == PosA.transform)
        {
            currentPoint = PosB.transform;
        }
    }
}
