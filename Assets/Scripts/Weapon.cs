using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [Header("Weapon Pramaters")]
    [SerializeField] float fireRate = 15f;
    [SerializeField] public float maxAmmo = 50;
    [SerializeField] public float currentAmmo;
    float cuurentAmmuPrecentage;
    [SerializeField] Transform MuzzleLocation;
    Animator animator;
    int WeaponKickAnimarorTriggerID;
    UIManager uIManager;
    float nextTimeToFire = 0f;
    bool isReloding = false;

    [Header("Weapon VFX")]
    [SerializeField] private GameObject hitSparkGreen;
    [SerializeField] private GameObject hitSparkRed;
    [SerializeField] private GameObject muzzleFlash;
    [SerializeField] private GameObject projectile;
    [SerializeField] Material weaponMatetial;
    [SerializeField] float ColorChangeLeprDuration = 1f;
    [SerializeField] Color weaponMagFullColor;
    [SerializeField] Color weaponMagHalff;
    [SerializeField] Color weaponMagEmpty;
    bool isColorChangeActive = false;

    [Header("Weapon Audio")]
    [SerializeField] AudioClip shootingAudioClip;
    [SerializeField] AudioClip reloadAudioClip;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        currentAmmo = maxAmmo;
        weaponMatetial.SetColor("_EmissionColor", weaponMagFullColor);
        audioSource = GetComponent<AudioSource>();
        uIManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        //uIManager.UpdateAmmoText(currentAmmo,maxAmmo);
        animator = GetComponent<Animator>();
        WeaponKickAnimarorTriggerID = Animator.StringToHash("WeaponFire");
    }


    // Update is called once per frame
    void Update()
    {
        CheckWeaponAmmoStatusAndUpdateColor();
    }

    public void Shooting()
    {
        //Check Fire Rate
        if (Time.time >= nextTimeToFire && currentAmmo > 0 && isReloding == false)
        {
            //Shooting Visual Effect and update paramatares
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
            //uIManager.UpdateAmmoText(currentAmmo,maxAmmo);
            //Weapon Recoil
            animator.SetTrigger(WeaponKickAnimarorTriggerID);

            //Raycast
            Ray rayOrigin = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            if (Physics.Raycast(rayOrigin, out RaycastHit hitInfo))
            {
                //Debug.Log(hitInfo.transform.name);

                //Destroy(myProjectile, 2f);
                if (hitInfo.transform.CompareTag("Enemy"))
                {
                    GameObject myHitSpark = Instantiate(hitSparkRed, hitInfo.point, Quaternion.identity);
                    Destroy(myHitSpark, 1f);
                    hitInfo.transform.GetComponent<Enemy>().TakeDamage();
                }
                else
                {
                    GameObject myHitSpark = Instantiate(hitSparkGreen, hitInfo.point, Quaternion.identity);
                    Destroy(myHitSpark, 1f);
                    //hitInfo.transform.GetComponent<MeshRenderer>().material.color = Color.red;
                }
            }
        } 
    }

    void CheckWeaponAmmoStatusAndUpdateColor()
    {
        cuurentAmmuPrecentage = (currentAmmo / maxAmmo) * 100;
        if (cuurentAmmuPrecentage <= 50 && cuurentAmmuPrecentage > 20)
        {
            if (isColorChangeActive == false && weaponMatetial.GetColor("_EmissionColor") != weaponMagHalff)
            {
                StartCoroutine(WeaponColorChangeLerp(weaponMagHalff, ColorChangeLeprDuration));
            }
        }
        else if (cuurentAmmuPrecentage <= 20)
        {
            if (isColorChangeActive == false && weaponMatetial.GetColor("_EmissionColor") != weaponMagEmpty)
            {
                StartCoroutine(WeaponColorChangeLerp(weaponMagEmpty, ColorChangeLeprDuration));
            }
        }
    }

    IEnumerator WeaponColorChangeLerp(Color endValue, float duration)
    {
        isColorChangeActive = true;
        float t = 0;
        Color startValue = weaponMatetial.GetColor("_EmissionColor");
        while (t < duration)
        {
            weaponMatetial.SetColor("_EmissionColor", Color.Lerp(startValue, endValue, t / duration));
            t += Time.deltaTime;
            yield return null;//wait till next fram
        }
        weaponMatetial.SetColor("_EmissionColor", endValue);
        isColorChangeActive = false;
    }

    public IEnumerator Realod() {
        isReloding = true;
        animator.SetTrigger("WeaponReload");
        StartCoroutine(WeaponColorChangeLerp(weaponMagFullColor, 1f));
        audioSource.clip = reloadAudioClip;
        audioSource.Play();
        yield return new WaitForSeconds(1f);
        audioSource.Stop();
        audioSource.clip = shootingAudioClip;
        currentAmmo = maxAmmo;
        //uIManager.UpdateAmmoText(currentAmmo, maxAmmo);
        isReloding = false;
    }

}
