using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemeyProjectile : MonoBehaviour
{
    Rigidbody rigidbody;
    [SerializeField] GameObject hitParticle;
    [SerializeField] GameObject projectileMesh;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, 10f);
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.AddForce(transform.forward * 500f);
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            other.GetComponent<Player>().TakeDamage();
            projectileMesh.SetActive(false);
            rigidbody.velocity = Vector3.zero;
            hitParticle.SetActive(true);
            Destroy(this.gameObject, 0.5f);
        }

        if (other.CompareTag("Enemy") == false)
        {
            Destroy(this.gameObject, 0.5f);
        }
    }
}
