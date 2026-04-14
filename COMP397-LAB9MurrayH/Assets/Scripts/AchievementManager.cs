using UnityEngine;

public class AchievementManager : MonoBehaviour
{
    public Achievement firstJump;
    public Achievement firstShot;

    private void Start()
    {
        if (EventChannelManager.instance == null)
        {
            Debug.LogError("EventChannelManager NOT FOUND!");
            return;
        }

        EventChannelManager.instance.onJump.Register(OnJump);
        EventChannelManager.instance.onShoot.Register(OnShoot);
    }

    private void OnDestroy()
    {
        if (EventChannelManager.instance == null) return;

        EventChannelManager.instance.onJump.Unregister(OnJump);
        EventChannelManager.instance.onShoot.Unregister(OnShoot);
    }

    private void OnJump()
    {
        Debug.Log("EVENT RECEIVED: Jump");
        firstJump?.Unlock();
    }

    private void OnShoot()
    {
        Debug.Log("EVENT RECEIVED: Shoot");
        firstShot?.Unlock();
    }
}