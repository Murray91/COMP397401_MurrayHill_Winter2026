using UnityEngine;
using System;

[CreateAssetMenu(menuName = "Events/GameEvent")]
public class GameEvent : ScriptableObject
{
    private Action listeners;

    public void Raise()
    {
        Debug.Log("EVENT RAISED: " + name);
        listeners?.Invoke();
    }

    public void Register(Action listener)
    {
        listeners += listener;
    }

    public void Unregister(Action listener)
    {
        listeners -= listener;
    }
}
