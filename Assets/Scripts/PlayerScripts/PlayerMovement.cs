using System.Collections;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;

public class PlayerMovement : MonoBehaviour
{
    private float horizontal;
    private float speed = 8f;
    [SerializeField]private float jumpingPower = 16f;
    private bool isFacingRight = true;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField]  float  fallMultipler;
    private bool grounded;

    [SerializeField] Animator anim;



    // Dashing Variables
    private bool canDash = true;
    private bool isDashing;
    private float DashingPower = 24f;
    private float dashingTime = 0.2f;
    private float DashingCooldown = 0f;
    UnityEngine.Vector2 vecGravity;

    private float cooldownTimer = Mathf.Infinity;

    [SerializeField] TrailRenderer Tr;

    void Start(){
        vecGravity = new Vector2(0, -Physics.gravity.y);
    }


    void Update()
    {
        //Prevents Player from moving jumping and flipping during a dash
        if(isDashing){
            return;
        }
        
        if(!Global.playmode) return;

        horizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump") && IsGrounded()) {
            rb.velocity = new UnityEngine.Vector2(rb.velocity.x, jumpingPower);
            anim.SetTrigger("jump");
        }

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f) {
            rb.velocity = new UnityEngine.Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
             }

        Flip();

        if(rb.velocity.y < 0){
            rb.velocity -= vecGravity *fallMultipler *Time.deltaTime;
        }
    }

    private void FixedUpdate() {
        //Prevents Player from moving jumping and flipping during a dash
        if(isDashing){
            return;
        }
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);

        anim.SetBool("run", horizontal != 0);
        //anim.SetBool("grounded", grounded);
        // Triggering Dash
        if(Input.GetKeyDown(KeyCode.LeftShift) && canDash){
            StartCoroutine(Dash());
        }
        if(Input.GetButtonDown("Fire1")){
            Attack();
        }
    }

    private bool IsGrounded() {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void Flip() {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f) {
            isFacingRight = !isFacingRight;
            transform.Rotate(0f,180f,0f);
        }
    }

    // Coroutine for Dashing
    private IEnumerator Dash(){
        canDash = false;
        isDashing = true;
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;
        rb.velocity = new Vector2(transform.localScale.x * DashingPower, 0f);  //transform.localscale represents player flipping 
        // Starts the dash
        Tr.emitting = true;
        // Waits for sometime
        yield return new WaitForSeconds(dashingTime);
        // Defaults everything to normal after the dash
        Tr.emitting = false;
        rb.gravityScale = originalGravity;
        isDashing = false;
        yield return new WaitForSeconds(DashingCooldown);
        canDash = true;
    }
    private void Attack()
    {
        anim.SetTrigger("attack");
        cooldownTimer = 0;
        // Reset the attack trigger after a short delay
        Invoke(nameof(ResetAttackTrigger), 0.1f);
    }

    private void ResetAttackTrigger()
    {
        anim.ResetTrigger("attack");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
            grounded = true;
    }
}