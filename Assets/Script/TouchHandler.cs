using UnityEngine;

public class TouchHandler : MonoBehaviour
{
    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                if (Physics.Raycast(Camera.main.ScreenPointToRay(touch.position), out RaycastHit hit))
                {
                    Debug.Log($"Hit: {hit.collider.gameObject.tag}");
                    EventHandler.Instance.Pressed(hit.collider.gameObject.tag);
                }
                else
                {
                    Debug.Log("Didnt hit");
                }
            }
        }
    }
}
