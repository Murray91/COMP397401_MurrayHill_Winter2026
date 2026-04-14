using UnityEngine;

[CreateAssetMenu(fileName = "New Achievement", menuName = "Achievements/Achievement")]
public class Achievement : ScriptableObject
{
    public string achievementName;
    public bool unlocked;

    public void Unlock()
    {
        if (unlocked) return;

        unlocked = true;
        Debug.Log("?? ACHIEVEMENT UNLOCKED: " + achievementName);
    }
}
