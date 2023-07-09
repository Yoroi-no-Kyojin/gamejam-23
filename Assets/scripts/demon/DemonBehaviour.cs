using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonBehaviour : MonoBehaviour
{
    [SerializeField] float attackRange, chaseRange, health, walkSpeed;
    [SerializeField] Collider hitterCollider;
    private Rigidbody demonRigidbody;
    private Animator animator;
    private bool recovered;
    private Transform playerTransform;
    private bool dead;

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Vector3 start = new Vector3(), end = new Vector3();
        start.y = end.y = transform.position.y;
        
        for(int i = 0; i < 360; ++i)
        {
            start.x = transform.position.x + attackRange * Mathf.Cos((i - 1) * Mathf.Deg2Rad);
            start.z = transform.position.z + attackRange * Mathf.Sin((i - 1) * Mathf.Deg2Rad);
            end.x = transform.position.x + attackRange * Mathf.Cos(i * Mathf.Deg2Rad);
            end.z = transform.position.z + attackRange * Mathf.Sin(i * Mathf.Deg2Rad);

            Gizmos.DrawLine(start, end);
        }

        Gizmos.color = Color.green;
        start = new Vector3();
        end = new Vector3();
        start.y = end.y = transform.position.y;

        for(int i = 0; i < 360; ++i)
        {
            start.x = transform.position.x + chaseRange * Mathf.Cos((i - 1) * Mathf.Deg2Rad);
            start.z = transform.position.z + chaseRange * Mathf.Sin((i - 1) * Mathf.Deg2Rad);
            end.x = transform.position.x + chaseRange * Mathf.Cos(i * Mathf.Deg2Rad);
            end.z = transform.position.z + chaseRange * Mathf.Sin(i * Mathf.Deg2Rad);

            Gizmos.DrawLine(start, end);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        dead = false;
        demonRigidbody = GetComponent<Rigidbody>();
        animator = transform.GetChild(0).GetComponent<Animator>();
        recovered = true;
        playerTransform = GameObject.Find("player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(dead)
        {
            return;
        }

        float fallSpeed = demonRigidbody.velocity.y;
        Vector3 displacementVector = playerTransform.position - transform.position;
        displacementVector.y = 0;
        float distance = displacementVector.magnitude;

        if(distance <= attackRange)
        {
            animator.SetBool("attack", true);

            if(!animator.GetCurrentAnimatorStateInfo(0).IsName("die"))
            {
                Vector3 direction = (playerTransform.position - transform.position).normalized;
                direction.y = 0;
                transform.forward = direction;
            }

            demonRigidbody.velocity = new Vector3(0, fallSpeed, 0);
        }
        else
        {
            animator.SetBool("attack", false);

            if(distance <= chaseRange)
            {
                Vector3 direction = (playerTransform.position - transform.position).normalized;
                direction.y = 0;
                transform.forward = direction;
                demonRigidbody.velocity = direction.normalized * walkSpeed + new Vector3(0, fallSpeed, 0);

                animator.SetBool("move", true);
            }
            else
            {
                animator.SetBool("move", false);
            }
        }
    }

    public void SetEnabledHitterCollider(bool enabled)
    {
        hitterCollider.enabled = enabled;
    }

    public void SetRecovered(bool recovered)
    {
        this.recovered = recovered;
    }

    public void Die()
    {
        dead = true;
    }

    void OnTriggerEnter(Collider other)
    {
        if(dead)
        {
            return;
        }

        if(!animator.GetCurrentAnimatorStateInfo(0).IsName("die") && other.gameObject.layer == LayerMask.NameToLayer("player-hitter"))
        {
            health -= playerTransform.gameObject.GetComponent<PlayerBehaviour>().GetDamage();

            if(health <= 0)
            {
                animator.SetTrigger("die");
            }
            else if(recovered)
            {
                animator.SetTrigger("hit");

                recovered = false;
            }
        }
    }
}
