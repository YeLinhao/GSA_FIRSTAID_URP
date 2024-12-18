using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "KeySpriteMapping", menuName = "QTE/KeySpriteMapping")]
public class KeySpriteMappingSO : ScriptableObject
{
    [System.Serializable]
    public class KeyIconPair
    {
        public KeyCode key;       // ����
        public Sprite icon;       // ͼ��
    }

    public List<KeyIconPair> keyIcons = new List<KeyIconPair>();

    /// <summary>
    /// return icon by keyCode
    /// </summary>
    public Sprite GetIcon(KeyCode key)
    {
        foreach (var pair in keyIcons)
        {
            if (pair.key == key)
                return pair.icon;
        }
        return null; // return null when there's nothing
    }
}
