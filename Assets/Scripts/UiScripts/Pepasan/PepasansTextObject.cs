using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static StoryScene;

[CreateAssetMenu(fileName = "NewPepasanText", menuName = "Data/New Pepasan Text")]
[System.Serializable]
public class PepasansTextObject : ScriptableObject
{
    public List<string> sentences;
}
