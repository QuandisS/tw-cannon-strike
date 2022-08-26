using UnityEngine;

[CreateAssetMenu(fileName = "New Level", menuName = "Level")]
public class Level : ScriptableObject
{
    public string levelName;
    public int levelNum;
    public int ballsAvailable;
    public int ballsNeeded;
}
