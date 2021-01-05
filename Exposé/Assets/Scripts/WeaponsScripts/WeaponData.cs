using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "weapondata", menuName = "Weapon Data", order = 51)]
public class WeaponData : ScriptableObject
{
    public enum THREAT
    {
        Big,
        Medium,
        Small
    }

    public enum TYPE
    {
        Sword,
        Axe,
        Mace,
        Lance
    }

    [SerializeField] private string weaponName;
    [SerializeField] private TYPE weaponType;
    [SerializeField] private Texture icon;
    [SerializeField] private int damage;
    [SerializeField] private Material weaponMaterial;
    [SerializeField] private Mesh Weaponmesh;

    public string Name
    {
        get { return weaponName; }
    }

    public TYPE Type
    {
        get { return weaponType; }
    }
    public Texture Icon
    {
        get { return icon; }
    }
    public int Damage
    {
        get { return damage; }
    }
    
    public Mesh WeaponMesh
    {
        get { return Weaponmesh; }
    }
    
    public Material WeaponMaterial
    {
        get { return weaponMaterial; }
    }
}

