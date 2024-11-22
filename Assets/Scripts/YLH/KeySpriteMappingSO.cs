using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "KeySpriteMapping", menuName = "QTE/KeySpriteMapping")]
public class KeySpriteMappingSO : ScriptableObject
{
    [System.Serializable]
    public class KeyIconPair
    {
        public KeyCode key;       // 按键
        public Sprite icon;       // 图标
    }

    public List<KeyIconPair> keyIcons = new List<KeyIconPair>();

    /// <summary>
    /// 根据按键获取对应的图标
    /// </summary>
    public Sprite GetIcon(KeyCode key)
    {
        foreach (var pair in keyIcons)
        {
            if (pair.key == key)
                return pair.icon;
        }
        return null; // 找不到时返回 null
    }
}
