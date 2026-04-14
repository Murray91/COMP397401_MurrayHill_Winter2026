using UnityEngine;
using UnityEngine.EventSystems;

public class SimpleLookInput : MonoBehaviour, IDragHandler, IPointerUpHandler
{
    public CameraManager cameraManager;

    public float sensitivity = 0.1f; // control speed

    public void OnDrag(PointerEventData eventData)
    {
        // Scale down touch delta so it's not crazy fast
        Vector2 delta = eventData.delta * sensitivity;

        cameraManager.SetLookInput(delta);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        cameraManager.SetLookInput(Vector2.zero);
    }
}