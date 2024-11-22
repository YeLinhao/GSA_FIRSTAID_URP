using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QTEVisualizer : MonoBehaviour
{
    public GameObject iconPrefab;        // UI ͼ���Ԥ����
    public Transform iconParent;         // ͼ�����ɵĸ����� 
    public KeySpriteMappingSO keySpriteMappingSO;

    private List<GameObject> generatedIcons = new List<GameObject>();//easy for control and delete

    /// <summary>
    /// ���ݰ����������ɰ���ͼ��
    /// </summary>
    public void VisualizeKeySequence(List<KeyCode> keySequence)
    {
        ClearIcons(); // ��������ͼ��

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
