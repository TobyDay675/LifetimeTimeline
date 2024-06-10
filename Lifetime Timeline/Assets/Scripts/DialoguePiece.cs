using UnityEngine;

[System.Serializable]
public struct DialoguePiece
{
    public string name;
    public Sprite icon;
    public Sprite dialogueBox;
    [TextArea(3, 10)]
    public string sentence;
}