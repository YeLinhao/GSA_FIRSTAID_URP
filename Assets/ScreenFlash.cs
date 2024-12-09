using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScreenFlash : MonoBehaviour
{
    private Image image; // 用于控制颜色
    private Color targetColor = Color.clear; // 闪烁目标颜色
    private float flashDuration = 0.5f; // 单次闪烁持续时间
    private bool isFlashing = false; // 是否正在闪烁

    void Awake()
    {
        image = GetComponent<Image>();
        if (image != null)
        {
            image.color = Color.clear; // 初始颜色透明
        }
    }

    public void Flash(Color color, float duration)
    {
        if (isFlashing) return;

        flashDuration = duration;
        targetColor = color;
        StartCoroutine(FlashRoutine());
    }

    private System.Collections.IEnumerator FlashRoutine()
    {
        isFlashing = true;

        // 渐变至目标颜色
        float elapsed = 0f;
        while (elapsed < flashDuration / 2f)
        {
            elapsed += Time.deltaTime;
            image.color = Color.Lerp(Color.clear, targetColor, elapsed / (flashDuration / 2f));
            yield return null;
        }

        // 渐变回透明
        elapsed = 0f;
        while (elapsed < flashDuration / 2f)
        {
            elapsed += Time.deltaTime;
            image.color = Color.Lerp(targetColor, Color.clear, elapsed / (flashDuration / 2f));
            yield return null;
        }

        image.color = Color.clear; // 确保最终是透明
        isFlashing = false;
    }
}
