using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QTEVisualizer : MonoBehaviour
{
    public GameObject iconPrefab;        // UI 图标的预制体
    public Transform iconParent;         // 图标生成的父物体 
    public KeySpriteMappingSO keySpriteMappingSO;

    private List<GameObject> generatedIcons = new List<GameObject>();//easy for control and delete

    /// <summary>
    /// 根据按键序列生成按键图标
    /// </summary>
    public void VisualizeKeySequence(List<KeyCode> keySequence)
    {
        ClearIcons(); // 清理已有图标

        foreach (var key in keySequence)
        {
            Sprite icon = keySpriteMappingSO.GetIcon(key);
            if (icon != null)
            {
                GameObject iconObject = Instantiate(iconPrefab, iconParent);
                iconObject.GetComponent<Image>().sprite = icon;
                generatedIcons.Add(iconObject);
            }
        }
    }

    private void ClearIcons()
    {
        foreach (var icon in generatedIcons)
        {
            Destroy(icon);
        }
        generatedIcons.Clear();
    }
}
