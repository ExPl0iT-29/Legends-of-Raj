using UnityEngine;

public class EnemyAnimator : MonoBehaviour
{
    public Animator animator;
    public float speed = 2f;

    private bool isAttacking = false;
    private bool isHit = false;
    private Rigidbody2D rb;
    private GameObject player;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        if (player == null) return; // Early exit if player is not found

        // Check for attack conditions
        if (ShouldAttack() && !isAttacking && !isHit)
        {
            AttackState();
        }

        // Check for hit conditions
        if (ShouldHit() && !isAttacking && !isHit)
        {
            HitState();
        }

        // Set animator parameters
        animator.SetBool("IsAttacking", isAttacking);
        animator.SetBool("IsHit", isHit);

        // Move the enemy towards the player if not attacking or hit
        if (!isAttacking && !isHit)
        {
            MoveTowardsPlayer();
        }
    }

    void AttackState()
    {
        isAttacking = true;
        animator.SetTrigger("Attack");
        Debug.Log("Enemy attacking!");
        // Here you might want to implement attack logic (damage, etc.)
        Invoke("EndAttack", 1f); // Adjust the duration as needed
    }

    void EndAttack()
    {
        isAttacking = false;
    }

    void HitState()
    {
        isHit = true;
        animator.SetTrigger("Hit");
        Debug.Log("Enemy hit!");
        // Implement hit logic here (reduce health, etc.)
        Invoke("RecoverFromHit", 1f); // Adjust the duration as needed
    }

    void RecoverFromHit()
    {
        isHit = false;
    }

    bool ShouldAttack()
    {
        return Vector2.Distance(transform.position, player.transform.position) < 3f;
    }

    bool ShouldHit()
    {
        return player != null && Physics2D.OverlapCircle(transform.position, 1f, LayerMask.GetMask("PlayerAttack"));
    }

    void MoveTowardsPlayer()
    {
        Vector2 direction = (player.transform.position - transform.position).normalized;
        rb.velocity = direction * speed;
    }
}