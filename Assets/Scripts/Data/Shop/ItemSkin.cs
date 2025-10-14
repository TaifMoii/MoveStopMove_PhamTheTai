using TMPro;
using UnityEngine;

public enum ItemType
{
    Equipped,
    UnEquipped
}
public class ItemSkin : MonoBehaviour
{

    public TextMeshProUGUI priceText;
    public UnityEngine.UI.Image iconImage;
    public UnityEngine.UI.Button buttonBuy;
    public UnityEngine.UI.Button buttonEquip;
    public UnityEngine.UI.Button buttonUnEquip;
    public GameObject lockImage;
    public ItemType currentType;

    public DataSkin skinData;
    public bool isLocked;
    ItemType itemType;

    // playerData = GameManager.Ins.PlayerData;
    PlayerData playerData => GameManager.Ins.PlayerData;



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

    public void Init(ItemType type)
    {
        if (isLocked)
        {
            LockInit();
            return;
        }
        SwitchItemType(type);
    }

    public void SwitchItemType(ItemType type)
    {
        itemType = type;
        switch (itemType)
        {
            case ItemType.Equipped:
                buttonBuy.gameObject.SetActive(false);
                buttonEquip.gameObject.SetActive(false);
                buttonUnEquip.gameObject.SetActive(true);
                lockImage.SetActive(false);
                break;
            case ItemType.UnEquipped:
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

    public void SkinInit(DataSkin skinDatas, ShopSkinUI shopSkinUI)
    {
        skinData = skinDatas;
        iconImage.sprite = skinData.icon;
        priceText.text = skinData.price.ToString();
    }
    public void Buy()
    {
        isLocked = false;
        Init(ItemType.UnEquipped);
        playerData.BuySkin(skinData.index);
    }
    private void Equip()
    {
        Init(ItemType.Equipped);
        ShopSkinUI.Ins.UpdateSkin(skinData.index);
        playerData.EquipSkin(skinData.index);
    }

    private void UnEquip()
    {
        Debug.Log("UnEquip");
        Init(ItemType.UnEquipped);
    }

}

