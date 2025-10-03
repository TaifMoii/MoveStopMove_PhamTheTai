using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIMainMenu : Singleton<UIMainMenu>
{
    public TextMeshProUGUI coinText;

    private float coin { get; set; }

    public void SetCoin()
    {
        coinText.text = coin.ToString();
    }
}
