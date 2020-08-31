using Assets.Scripts;
using Assets.Scripts.Weapons;
using System;
using UnityEngine;
using UnityEngine.UI;

public class HUDController : MonoBehaviour
{

    [SerializeField]
    private Text _currentAmmoDisplay;
    public Text CurrentAmmoDisplay
    {
        get => _currentAmmoDisplay;
        set => _currentAmmoDisplay = value;
    }

    [SerializeField]
    private Text _maxAmmoDisplay;
    public Text MaxAmmoDisplay
    {
        get => _maxAmmoDisplay;
        set => _maxAmmoDisplay = value;
    }


    [SerializeField]
    private Image _fillHealthImage;
    public Image FillHealthImage
    {
        get => _fillHealthImage;
        set => _fillHealthImage = value;
    }

    [SerializeField]
    private GameObject _ammoHUD;
    public GameObject AmmoHUD
    {
        get => _ammoHUD;
        set => _ammoHUD = value;
    }

    public GameObject Reticle;

    public void RefreshAmmoDisplay(Weapon weapon)
    {
        if(weapon is WeaponShootable weaponShootable)
        {
            CurrentAmmoDisplay.text = Convert.ToString(weaponShootable.CurrentClipSize);
            MaxAmmoDisplay.text = Convert.ToString(weaponShootable.CurrentAmmo);
        }
    }

    public void RefreshPlayerHealth(Health playerHealth)
    {
        if (playerHealth.MaxHealth <= 0.0f)
            FillHealthImage.fillAmount = 0.0f;
        else 
            FillHealthImage.fillAmount = playerHealth.CurrentHealth / playerHealth.MaxHealth;
    }

    public void DisplayWeaponUI(Weapon weapon)
    {
        switch (weapon.WeaponType)
        {
            case WeaponTypes.Knife:
                AmmoHUD.SetActive(false);
                break;
            case WeaponTypes.Pistol:
                AmmoHUD.SetActive(true);
                break;
            case WeaponTypes.AssaultRifleHK416:
                AmmoHUD.SetActive(true);
                break;
            default:
                break;
        }
    }

    //Called in a Scriptable Object
    public void HideRetice()
    {
        if (Reticle == null)
            return;

        Reticle.SetActive(false);
    }

    //Called in a Scriptable Object
    public void ShowReticle()
    {
        Reticle.SetActive(true);
    }

}