using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [Header("Enemey Properties")]
    [SerializeField] private int health = 5;
    [SerializeField] private GameObject brokenEnemy;
    [SerializeField] private GameObject deathExplosion;
    [SerializeField] private GameObject projectile;
    [Header("Enemy VFX")]
    [SerializeField] AudioSource takeDamageAudioSource;
    [SerializeField] AudioSource attackAudioSource;
    [SerializeField] Transform projectileSpawnPoint;
    [Header("Enemy AI")]
    private NavMeshAgent navMeshAgent;
    [SerializeField] private Transform playerLookAtTarget;
    [SerializeField] private LayerMask isGround, isPlayer;
    //Patroling
    [SerializeField] private Vector3 walkPos;
    [SerializeField] private bool walkPosSet;
    [SerializeField] private float walkPosRange;
    //Attacking
    [SerializeField] private float attackTime;
    private bool alreadyAttacked;
    //States
    [SerializeField] private float sightRange, attackRange;
    [SerializeField] private bool isPlayerInSightRange, isPlayerInAttackRange;
    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        //Check for sight and attack range
        isPlayerInSightRange = Physics.CheckSphere(transform.position, sightRange,isPlayer);
        isPlayerInAttackRange = Physics.CheckSphere(transform.position, attackRange, isPlayer);

        if(isPlayerInSightRange == false && isPlayerInAttackRange == false)
        {
            Patroling();
        } else if(isPlayerInSightRange == true && isPlayerInAttackRange == false)
        {
            ChasePlayer();
        } else if(isPlayerInSightRange == true && isPlayerInAttackRange == true)
        {
            AttackPlayer();
        }

        if (navMeshAgent.velocity == Vector3.zero)
        {
            walkPosSet = false;
        }
    }

    private void Patroling() {
        if(walkPosSet == false)
        {
            SearchForWalkPose();
        } else
        {
            navMeshAgent.SetDestination(walkPos);
        }

        Vector3 distanceToWalk = transform.position - walkPos;

        if(distanceToWalk.magnitude < 1f)
        {
            walkPosSet = false;
        }


    }

    private void SearchForWalkPose()
    {
        float randomZ = Random.Range(-walkPosRange, walkPosRange);
        float randomX = Random.Range(-walkPosRange, walkPosRange);

        walkPos = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPos, -transform.up, 2f, isGround))
        {
            walkPosSet = true;
        }
    }

    private void ChasePlayer()
    {
        navMeshAgent.SetDestination(playerLookAtTarget.position);
    }

    private void AttackPlayer()
    {
        //Make Enemey stop from moving
        navMeshAgent.SetDestination(transform.position);
        transform.LookAt(playerLookAtTarget);

        if(alreadyAttacked == false)
        {
            //Attack Code here
            attackAudioSource.Play();
            Instantiate(projectile, projectileSpawnPoint.position, projectileSpawnPoint.rotation);
            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), attackTime);
        }
    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }


    public void TakeDamage()
    {
        takeDamageAudioSource.Play();
        health--;
        if(health <= 0)
        {
            Death();
        }
    }

    public void Death()
    {
        GameObject myDeathExplosion =  Instantiate(deathExplosion, transform.position, Quaternion.identity);
        Destroy(myDeathExplosion, 1f);
        GameObject myBrokenEnemy = Instantiate(brokenEnemy, transform.position, Quaternion.identity);
        Rigidbody[] myBrokenEnemyRigiBodiesCollection = myBrokenEnemy.GetComponentsInChildren<Rigidbody>();
        foreach(var item in myBrokenEnemyRigiBodiesCollection)
        {
            item.AddExplosionForce(600, transform.position, 1);
        }
        Destroy(this.gameObject);
    }
}
