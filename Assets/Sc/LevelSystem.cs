using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Weapon
{
    public GameObject GameObject;
    public int WeaponWeight;
    public bool IsUnlocked = false; 
}

public class LevelSystem : MonoBehaviour
{
    [SerializeField] private List<Weapon> _weaponData;
    [SerializeField] private int _expToLevelUp;

    private int _currentExp;
    private System.Random _random;

    private void Start()
    {
        _random = new System.Random();
    }

    public void AddExp(int exp)
    {
        _currentExp += exp;
        if (_currentExp >= _expToLevelUp)
        {
            LevelUp();
            _currentExp = 0; 
        }
    }
    

    private void LevelUp()
    {
        UnlockWeapon();
    }

    private void UnlockWeapon()
    {
        
        List<Weapon> lockedWeapons = _weaponData.FindAll(w => !w.IsUnlocked);

        if (lockedWeapons.Count == 0)
        {
            Debug.Log("‚·‚×‚Ä‚Ì•Ší‚ª‰ğ•úÏ‚İ‚Å‚·");
            return;
        }

        
        int totalWeight = 0;
        foreach (var weapon in lockedWeapons)
        {
            totalWeight += weapon.WeaponWeight;
        }

        int randomWeapon = _random.Next(0, totalWeight);

        foreach (var weapon in lockedWeapons)
        {
            randomWeapon -= weapon.WeaponWeight;
            if (randomWeapon < 0)
            {
                weapon.GameObject.SetActive(true);
                weapon.IsUnlocked = true;
                Debug.Log($"‰ğ•ú‚³‚ê‚½•Ší: {weapon.GameObject.name}");
                break;
            }
        }
    }

}
