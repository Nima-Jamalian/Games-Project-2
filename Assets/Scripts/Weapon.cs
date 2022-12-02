using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private float fireRate = 15f;
    private float nextTimeToFire = 0f;


    [SerializeField] private GameObject hitSpark;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RayCasting()
    {
        Debug.Log("Time.Time: " + Time.time);
        Debug.Log("Next Time to Fire: " + nextTimeToFire);
        if (Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;

            audioSource.Play();

            Ray rayOrigin = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            if (Physics.Raycast(rayOrigin, out RaycastHit hitInfo))
            {
                Debug.Log(hitInfo.transform.name);
                GameObject myHitSpark = Instantiate(hitSpark, hitInfo.transform.position, Quaternion.identity);
                Destroy(myHitSpark, 1f);
                if (hitInfo.transform.CompareTag("Enemy"))
                {
                    hitInfo.transform.GetComponent<Enemy>().Death();
                }

            }
        }

    }
}
