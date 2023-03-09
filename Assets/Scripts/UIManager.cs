using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] Image weaponUIBar;

    public void UpdateAmmuUI(float currentAmmo, float maxAmmo)
    {
        weaponUIBar.fillAmount = Mathf.InverseLerp(0, maxAmmo, currentAmmo);
    }
}
