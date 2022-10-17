using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{
    public int SelectedWeapon = 0;
    public static string gunName {get; private set;}
    void Start()
    {
        SwitchWeapon();
    }

    void Update()
    {
        WeaponCheck();
    }

    private void WeaponCheck()
    {
        int prevSelectedWeapon = SelectedWeapon;
        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if (SelectedWeapon >= transform.childCount - 1)
            {
                SelectedWeapon = 0;
            }
            else
            {
                SelectedWeapon++;
            }
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if (SelectedWeapon <= 0)
            {
                SelectedWeapon = transform.childCount - 1;
            }
            else
            {
                SelectedWeapon--;
            }

        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SelectedWeapon = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && transform.childCount >= 2)
        {
            SelectedWeapon = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && transform.childCount >= 3)
        {
            SelectedWeapon = 2;
        }
        if (prevSelectedWeapon != SelectedWeapon)
        {
            SwitchWeapon();
        }
    }


    public void SwitchWeapon()
    {
        int i = 0;
        foreach (Transform weapon in transform)
        {
            if (i == SelectedWeapon)
            {
                weapon.gameObject.SetActive(true);
                gunName = weapon.name;
            }
                

            else
                weapon.gameObject.SetActive(false);
            i++;
        }
    }

    public void SelectPizza()
    {
        foreach (Transform weapon in transform)
        {
            
                weapon.gameObject.SetActive(false);
           
        }
        transform.GetChild(3).gameObject.SetActive(true);
    }
}