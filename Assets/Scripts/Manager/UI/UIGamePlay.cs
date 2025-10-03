using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIGamePlay : Singleton<UIGamePlay>
{
    public TextMeshProUGUI enemyLiveText;

    public void UpdateEnemy()
    {
        enemyLiveText.text = Level.Ins.maxEnemy.ToString();
    }
    void Start()
    {
        enemyLiveText.text = Level.Ins.maxEnemy.ToString();

    }
}
