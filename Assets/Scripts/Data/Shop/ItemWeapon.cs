using TMPro;
using UnityEngine;

public enum WeaponType

{
    Locked,
    Equipped,
    UnEquipped
}
public class ItemWeapon : MonoBehaviour
{

    public TextMeshProUGUI priceText;
    public UnityEngine.UI.Image iconImage;
    public UnityEngine.UI.Button buttonBuy;
    public UnityEngine.UI.Button buttonEquip;
    public UnityEngine.UI.Button buttonUnEquip;
    public GameObject lockImage;
    public WeaponType currentType;

    DataWeapon weaponData;
    DataSkin skinData;
    WeaponType itemType;

    void Awake()
    {
        Init(WeaponType.Locked);
        buttonBuy.onClick.AddListener(Buy);
        buttonUnEquip.onClick.AddListener(UnEquip);
    }
    void OnDestroy()
    {
        buttonBuy.onClick.RemoveListener(Buy);
        buttonUnEquip.onClick.RemoveListener(UnEquip);
    }

    public void Init(WeaponType type)
    {
        lockImage.SetActive(true);
        SwitchItemType(type);
    }

    public void SwitchItemType(WeaponType type)
    {
        itemType = type;
        switch (itemType)
        {
            case WeaponType.Locked:
                buttonBuy.gameObject.SetActive(true);
                buttonEquip.gameObject.SetActive(false);
                buttonUnEquip.gameObject.SetActive(false);
                lockImage.SetActive(true);
                break;
            case WeaponType.Equipped:
                buttonBuy.gameObject.SetActive(false);
                buttonEquip.gameObject.SetActive(true);
                buttonUnEquip.gameObject.SetActive(false);
                lockImage.SetActive(false);
                break;
            case WeaponType.UnEquipped:
                buttonBuy.gameObject.SetActive(false);
                buttonEquip.gameObject.SetActive(false);
                buttonUnEquip.gameObject.SetActive(true);
                lockImage.SetActive(false);
                break;
            default:
                break;
        }
    }
    public void WeaponInit(DataWeapon weaponDatas)
    {
        weaponData = weaponDatas;
        iconImage.sprite = weaponData.icon;
        priceText.text = weaponData.price.ToString();
    }

    public void Buy()
    {
        Init(WeaponType.UnEquipped);
        ShopWeaponUI.Ins.UpdateWeapon(this, weaponData);
    }
    private void Equip()
    {
        Debug.Log("Equip");
        Init(WeaponType.UnEquipped);
        ShopWeaponUI.Ins.UpdateWeapon(this, weaponData);
    }

    private void UnEquip()
    {
        Debug.Log("UnEquip");
        Init(WeaponType.Equipped);
        ShopWeaponUI.Ins.UpdateWeapon(this, weaponData);
    }

}

