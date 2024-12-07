using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "BubbleSpritePool", menuName = "Quiz/BubbleSpritePool")]
public class BubbleSpriteSO : ScriptableObject
{
    public List<Sprite> BubbleSprites = new List<Sprite>();

}
