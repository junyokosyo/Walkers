using UnityEngine;
using UnityEngine.UI;

public class WeaponUIManager : MonoBehaviour
{
    [SerializeField] private GameObject weaponUIPrefab; // 武器UIのPrefab
    [SerializeField] private Transform uiParent;        // WeaponUIParentを指定

    public void AddWeaponUI(Sprite weaponIcon)
    {
        // UI生成
        GameObject newUI = Instantiate(weaponUIPrefab, uiParent);

        // アイコンがImageなら差し替える
        Image img = newUI.GetComponent<Image>();
        if (img != null && weaponIcon != null)
        {
            img.sprite = weaponIcon;
        }
    }
}
