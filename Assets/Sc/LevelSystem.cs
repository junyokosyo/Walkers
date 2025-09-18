using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class Weapon
{
    public GameObject GameObject;
    public int WeaponWeight;
    public bool IsUnlocked = false;
}

public class LevelSystem : MonoBehaviour
{
    [Header("����f�[�^")]
    [SerializeField] private List<Weapon> _weaponData;

    [Header("���x���A�b�v�ݒ�")]
    [SerializeField] private int _expToLevelUp;
    [SerializeField] private GameObject _levelEfect;
    [SerializeField] private Transform _pleyerPoj;

    [Header("UI")]
    [SerializeField] private Text _levelUpCountText; // ���x���A�b�v�񐔕\���p

    private int _currentExp;
    private int _levelUpCount = 1; // ���x���A�b�v��
    private System.Random _random;

    private void Start()
    {
        _random = new System.Random();
        UpdateLevelUpUI(); // �����\��
    }

    // �o���l��ǉ�����
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
        _levelUpCount++;
        SEManager.Instance.PlayLevelUpSE();
        UnlockWeapon();
        Instantiate(_levelEfect, _pleyerPoj);

        UpdateLevelUpUI();
    }

    // ����������
    private void UnlockWeapon()
    {
        List<Weapon> lockedWeapons = _weaponData.FindAll(w => !w.IsUnlocked);

        if (lockedWeapons.Count == 0)
        {
            Debug.Log("���ׂĂ̕��킪����ς݂ł�");
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
                Debug.Log($"������ꂽ����: {weapon.GameObject.name}");
                break;
            }
        }
    }
    private void UpdateLevelUpUI()
    {
        if (_levelUpCountText != null)
        {
            _levelUpCountText.text = $"Lv. {_levelUpCount}";
        }
    }
}
