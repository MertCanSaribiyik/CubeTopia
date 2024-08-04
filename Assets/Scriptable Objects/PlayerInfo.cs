using UnityEngine;

[CreateAssetMenu(fileName = "PlayerInfo", menuName = "new Player Info")]
public class PlayerInfo : ScriptableObject
{
    public int score = 0;
    public Color backgroundColor = Color.white;
}
