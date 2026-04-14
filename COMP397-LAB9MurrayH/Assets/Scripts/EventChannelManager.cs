using UnityEngine;

public class EventChannelManager : MonoBehaviour
{
    public static EventChannelManager instance;

    public GameEvent onJump;
    public GameEvent onShoot;

    private void Awake()
    {
        instance = this;
    }
}
