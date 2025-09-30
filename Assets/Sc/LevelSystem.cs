using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class Weapon
{
    [Header("武器データ")]
    public GameObject GameObject;   // 実際の武器Prefab
    public int WeaponWeight;        // 抽選用の重み
    public bool IsUnlocked = false; // 解放済みフラグ
    public Sprite WeaponIcon;       // UI用アイコン
}

public class LevelSystem : MonoBehaviour
{
    [Header("武器データ")]
    [SerializeField] private List<Weapon> _weaponData;

    [Header("レベルアップ設定")]
    [SerializeField] private int _expToLevelUp = 10;
    [SerializeField] private GameObject _levelEfect;
    [SerializeField] private Transform _pleyerPoj;

    [Header("UI設定")]
    [SerializeField] private Text _levelUpCountText;   // Lv表示用
    [SerializeField] private Transform _weaponUIParent; // 左上に並べる親 (Vertical Layout Group付き)
    [SerializeField] private GameObject _weaponUIPrefab; // アイコンPrefab (Imageコンポ付き)

    private int _currentExp;
    private int _levelUpCount = 1;
    private System.Random _random;

    private void Start()
    {
        _random = new System.Random();
        UpdateLevelUpUI();
    }

    // 経験値追加
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
        SEManager.Instance.PlayLevelUpSE(); // SE再生
        UnlockWeapon();                     // 武器解放
        Instantiate(_levelEfect, _pleyerPoj);

        UpdateLevelUpUI();
    }

    // 武器解放処理
    private void UnlockWeapon()
    {
        List<Weapon> lockedWeapons = _weaponData.FindAll(w => !w.IsUnlocked);

        if (lockedWeapons.Count == 0)
        {
            Debug.Log("すべての武器が解放済みです");
            return;
        }

        // 抽選用の合計Weight計算
        int totalWeight = 0;
        foreach (var weapon in lockedWeapons)
        {
            totalWeight += weapon.WeaponWeight;
        }

        int randomWeapon = _random.Next(0, totalWeight);

        // 重み付き抽選
        foreach (var weapon in lockedWeapons)
        {
            randomWeapon -= weapon.WeaponWeight;
            if (randomWeapon < 0)
            {
                // ゲーム上で有効化
                weapon.GameObject.SetActive(true);
                weapon.IsUnlocked = true;
                Debug.Log($"解放された武器: {weapon.GameObject.name}");

                // UI追加
                AddWeaponUI(weapon);

                break;
            }
        }
    }

    // UIアイコン追加
    private void AddWeaponUI(Weapon weapon)
    {
        if (_weaponUIPrefab != null && _weaponUIParent != null)
        {
            GameObject newUI = Instantiate(_weaponUIPrefab, _weaponUIParent);

            // プレハブに Image がついている前提
            Image img = newUI.GetComponent<Image>();
            if (img != null && weapon.WeaponIcon != null)
            {
                img.sprite = weapon.WeaponIcon;
            }
        }
    }

    // レベルアップUI更新
    private void UpdateLevelUpUI()
    {
        if (_levelUpCountText != null)
        {
            _levelUpCountText.text = $"Lv. {_levelUpCount}";
        }
    }
}
