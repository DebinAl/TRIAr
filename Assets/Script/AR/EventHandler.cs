using System;
using UnityEngine;

public class EventHandler : MonoBehaviour
{
    public static EventHandler Instance;

    public event Action<string> OnPressed;
    private void Awake()
    {
        Instance = this; 
    }

    public void Pressed(string obj)
    {
        Debug.Log($"Send: {obj}");
        OnPressed?.Invoke(obj);
    }

}
