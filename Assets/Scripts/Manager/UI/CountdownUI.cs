using UnityEngine;
using TMPro;
using System.Collections;

public class CooldownUI : MonoBehaviour
{
    public TextMeshProUGUI text;   // gán Text UI vào đây


    // Bắt đầu cooldown với số giây
    public void StartCooldown(float seconds)
    {
        StopAllCoroutines();            // nếu đang chạy trước đó thì dừng
        StartCoroutine(CoCooldown(seconds));
    }

    private IEnumerator CoCooldown(float duration)
    {
        float t = duration;
        while (t > 0f)
        {
            // Chỉ hiển thị số nguyên giây
            text.text = Mathf.CeilToInt(t).ToString();

            yield return null;
            t -= Time.deltaTime;
        }

        // về 0
        text.text = "0";
    }
}
