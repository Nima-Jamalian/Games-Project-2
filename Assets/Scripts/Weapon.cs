using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [Header("Weapon Pramaters")]
    [SerializeField] private float fireRate = 15f;
    [SerializeField] public int maxAmmo = 50;
    [SerializeField] public int currentAmmo;
    [SerializeField] private Transform MuzzleLocation;
    private Animator animator;
    private int WeaponKickAnimarorTriggerID;
    private UIManager uIManager;
    private float nextTimeToFire = 0f;
    private bool isReloding = false;

    [Header("Weapon VFX")]
    [SerializeField] private GameObject hitSpark;
    [SerializeField] private GameObject muzzleFlash;
    [SerializeField] private GameObject projectile;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        currentAmmo = maxAmmo;
        audioSource = GetComponent<AudioSource>();
        uIManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        uIManager.UpdateAmmoText(currentAmmo,maxAmmo);
        animator = GetComponent<Animator>();
        WeaponKickAnimarorTriggerID = Animator.StringToHash("WeaponFire");
    }

    // Update is called once per frame
    void Update()
    {
        
    
    }

    public void RayCasting()
    {
        //Check Fire Rate
        if (Time.time >= nextTimeToFire && currentAmmo > 0 && isReloding == false)
        {
            //Update Ammo
            currentAmmo--;
            //Update Fire rate
            nextTimeToFire = Time.time + 1f / fireRate;
            //Shoot Audio
            audioSource.Play();
            //Muzzle Flash
            GameObject myMuzzleFlash =  Instantiate(muzzleFlash, MuzzleLocation.position, Quaternion.identity);
            Destroy(myMuzzleFlash, 1f);
            //Projectile
            Instantiate(projectile, MuzzleLocation.transform.position, Camera.main.transform.rotation);
            //Update ammo UI
            uIManager.UpdateAmmoText(currentAmmo,maxAmmo);
            //Weapon Recoil
            animator.SetTrigger(WeaponKickAnimarorTriggerID);
            //Check for Ray Hit
            Ray rayOrigin = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            if (Physics.Raycast(rayOrigin, out RaycastHit hitInfo))
            {
                Debug.Log(hitInfo.transform.name);
                GameObject myHitSpark = Instantiate(hitSpark, hitInfo.transform.position, Quaternion.identity);
                Destroy(myHitSpark, 1f);
                //Destroy(myProjectile, 2f);
                if (hitInfo.transform.CompareTag("Enemy"))
                {
                    hitInfo.transform.GetComponent<Enemy>().TakeDamage();
                }
            }
        } 
    }

    public void Reload()
    {
        isReloding = true;
        StartCoroutine(ReloadDely());
    }

    private IEnumerator ReloadDely() {
        yield return new WaitForSeconds(1.5f);
        currentAmmo = maxAmmo;
        uIManager.UpdateAmmoText(currentAmmo, maxAmmo);
        isReloding = false;
    }

}
