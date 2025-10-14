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

    public DataWeapon weaponData;
    public bool isLocked;
    WeaponType itemType;
    PlayerData playerData;

    void Awake()
    {
        isLocked = true;
        LockInit();
        buttonBuy.onClick.AddListener(Buy);
        buttonUnEquip.onClick.AddListener(UnEquip);
        buttonEquip.onClick.AddListener(Equip);
    }
    void OnDestroy()
    {
        buttonBuy.onClick.RemoveListener(Buy);
        buttonUnEquip.onClick.RemoveListener(UnEquip);
        buttonEquip.onClick.RemoveListener(Equip);
    }

    public void Init(WeaponType type)
    {
        if (isLocked)
        {
            LockInit();
            return;
        }
        SwitchItemType(type);
    }

    public void SwitchItemType(WeaponType type)
    {
        itemType = type;
        switch (itemType)
        {
            case WeaponType.Equipped:
                buttonBuy.gameObject.SetActive(false);
                buttonEquip.gameObject.SetActive(false);
                buttonUnEquip.gameObject.SetActive(true);
                lockImage.SetActive(false);
                break;
            case WeaponType.UnEquipped:
                buttonBuy.gameObject.SetActive(false);
                buttonEquip.gameObject.SetActive(true);
                buttonUnEquip.gameObject.SetActive(false);
                lockImage.SetActive(false);
                break;
            default:
                break;
        }
    }
    public void LockInit()
    {
        buttonBuy.gameObject.SetActive(true);
        buttonEquip.gameObject.SetActive(false);
        buttonUnEquip.gameObject.SetActive(false);
        lockImage.SetActive(true);
    }
    public void WeaponInit(DataWeapon weaponDatas, ShopWeaponUI shopWeaponUI)
    {
        weaponData = weaponDatas;
        iconImage.sprite = weaponData.icon;
        priceText.text = weaponData.price.ToString();
    }

    public void Buy()
    {
        isLocked = false;
        Init(WeaponType.UnEquipped);
        playerData.BuyWeapon(weaponData.index);
    }
    private void Equip()
    {
        Init(WeaponType.Equipped);
        ShopWeaponUI.Ins.UpdateWeapon(weaponData.index);
        playerData.EquipWeapon(weaponData.index);
    }

    private void UnEquip()
    {
        Init(WeaponType.UnEquipped);
    }

}

