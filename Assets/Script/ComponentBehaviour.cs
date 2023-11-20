using UnityEngine;
using UnityEngine.EventSystems;

public class ComponentBehaviour : MonoBehaviour
{
    [SerializeField] private Sprite[] _sprite;

    private Vector3 _cameraPos;
    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    private void Start()
    {
        EventHandler.Instance.OnPressed += ChangePage;
    }

    private void Update()
    {
        _cameraPos = Camera.main.transform.forward;
        transform.LookAt(_cameraPos);
    }

    public void ChangePage(string obj)
    {
        Debug.Log("ChangePage() Invoked");
        Debug.Log($"Name: {tag}, String: {obj}");
        if (_spriteRenderer != null && CompareTag(obj))
        {
            if(_spriteRenderer.sprite == _sprite[0])
            {
                _spriteRenderer.sprite = _sprite[1];
            }
            else
            {
                _spriteRenderer.sprite = _sprite[0];
            }
        }
    }
}
