using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int health = 5;
    [SerializeField] private GameObject brokenEnemy;
    [SerializeField] private GameObject deathExplosion;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage()
    {
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
