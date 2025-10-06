using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIGamePlay : UICanvas
{
    public TextMeshProUGUI enemyLiveText;

    public void Update()
    {
        enemyLiveText.text = Level.Ins.maxEnemy.ToString();
    }
    void Start()
    {
        enemyLiveText.text = Level.Ins.maxEnemy.ToString() + 1;
    }


}
