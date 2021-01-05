using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetWeaponInfo : MonoBehaviour
{
    public GameObject WeaponInfo;
    public GameObject weaponIcon;
    public Text weaponName;
    public Text typeName;
    public Text damage;
 

    public void OpenWeaponPanel()
    {
        WeaponInfo.SetActive(true);
    }

    public void CloseWeaponPanel()
    {
        WeaponInfo.SetActive(false);
    }
}
