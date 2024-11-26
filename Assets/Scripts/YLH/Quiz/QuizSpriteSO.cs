using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "QuizSpritePool", menuName = "Quiz/QuizSpritePool")]
public class QuizSpriteSO : ScriptableObject
{
    public List<Sprite> QuizSprites = new List<Sprite>();
}
