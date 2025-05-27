using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private Animator zombie;
    private ParticleSystem blood;
    [SerializeField] Transform player;
    public float detectionRange = 50f;
    private bool playerInRange;
    public float attackRange = 3f;
    public float moveSpeed = 3f;
    private bool isAlive = true;
    private Rigidbody rb;
    private CapsuleCollider collider;
    public bool canSpawn;

    private void Start()
    {
        blood = GetComponent<ParticleSystem>();
        zombie = GetComponentInChildren<Animator>();
        collider = GetComponent<CapsuleCollider>();
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (canSpawn)
        {
            EnemySpawn();
            canSpawn = false;
            StartCoroutine(DelaySpawn());
        }
        if (isAlive)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, player.position);
            playerInRange = distanceToPlayer <= detectionRange;
            if (playerInRange)
            {
                zombie.SetBool("isRunning", true);
                transform.LookAt(player);
                transform.position += transform.forward * moveSpeed * Time.deltaTime;

                if (distanceToPlayer <= attackRange)
                {
                    AttackPlayer();
                }
                else
                {
                    zombie.SetBool("isAttacking", false);
                }
            }
            else if (!playerInRange)
            {
                zombie.SetBool("isRunning", false);
                zombie.SetBool("isAttacking", false);
            }
        }
    }
    public void Die()
    {
        rb.useGravity = false;
        collider.enabled = false;
        zombie.SetBool("Hit", true);
        blood.Play();
        isAlive =false;

        StartCoroutine(DisableEnemy(3f));
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRange);

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
    void AttackPlayer()
    {
        zombie.SetBool("isAttacking", true);
    }

    public void EnemySpawn()
    {
        GameObject temp;
        for (int i = 0; i < 10; i++)
        {
            temp = PoolScript.instance.GetEnemy();
            if (temp != null)
            {
                temp.GetComponent<Rigidbody>().useGravity = true;
                temp.GetComponent<CapsuleCollider>().enabled = true;
                temp.GetComponent<Enemy>().isAlive = true;
                temp.GetComponentInChildren<Animator>().SetBool("Hit", false);
                temp.GetComponentInChildren<Animator>().SetBool("isAttacking", false);
                temp.GetComponentInChildren<Animator>().SetBool("isRunning", false);
                temp.transform.position = new Vector3(Random.Range(player.transform.position.x + 50f, player.transform.position.x - 50f), 0.03f, Random.Range(player.transform.position.z + 50, player.transform.position.z - 50));
                temp.transform.rotation = Quaternion.identity;
                temp.SetActive(true);
            }
        }
    }

    IEnumerator DisableEnemy(float time)
    {
        yield return new WaitForSeconds(time);
        gameObject.SetActive(false);
    }
    IEnumerator DelaySpawn()
    {
        yield return new WaitForSeconds(10f);

        canSpawn = true;
    }
}
