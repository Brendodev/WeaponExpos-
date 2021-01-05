using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Weapons : MonoBehaviour
{
    [SerializeField] private WeaponData info;
    [SerializeField] private MeshRenderer _material;
    [SerializeField] private MeshFilter _mesh;
    [SerializeField] private UnityEvent Selected;
    [SerializeField] private UnityEvent UnSelected;


    private bool setFocus;
    private SetWeaponInfo _setWeaponInfo;

    private void Awake()
    {
        _mesh.sharedMesh = info.WeaponMesh;
        _material.material = info.WeaponMaterial;
    }

    private void Start()
    {
        _setWeaponInfo = GameObject.FindWithTag("WeaponInfo").GetComponent<SetWeaponInfo>();
    }

    private void OnMouseDown()
    {
        _setWeaponInfo.OpenWeaponPanel();
        _setWeaponInfo.weaponName.text = info.name;
        _setWeaponInfo.typeName.text = info.Type.ToString();
        _setWeaponInfo.weaponIcon.GetComponent<RawImage>().texture = info.Icon;
        _setWeaponInfo.damage.text = info.Damage.ToString();
       HardSetFocus(!setFocus);
    }
    
    private void HardSetFocus(bool value)
    {
        if (value)
        {
            Selected?.Invoke();
        }
        else
        {
            UnSelected?.Invoke();
        }
    }
}