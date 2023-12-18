using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ApplicationEventAR : MonoBehaviour
{
    GameObject _instantiated;
    [SerializeField] GameObject[] _prefabs;

    [SerializeField] GameObject _canvas;
    [SerializeField] GameObject _text;

    private void Start()
    {
        _canvas.SetActive(false);
        EventHandler.Instance.OnPressed += Instance_OnPressed;
    }

    private void OnDisable()
    {
        EventHandler.Instance.OnPressed -= Instance_OnPressed;
    }

    private void Instance_OnPressed(string obj)
    {

        foreach (GameObject prefab in _prefabs)
        {
            if (prefab.name.Equals(obj))
            {
                Debug.Log($"{prefab.name} + {obj}");
                _canvas.SetActive(true);
                _text.GetComponent<TextMeshProUGUI>().text = obj;

                if(_instantiated != null)
                {
                    Destroy(_instantiated);
                }

                _instantiated = Instantiate(prefab, new Vector3(0f, -0.19f, 0.5f), Quaternion.identity);
            }
        }
    }
    
    public void OnZoomInButtonPressed()
    {
        _instantiated.transform.localScale = _instantiated.transform.localScale + new Vector3(0.1f, 0.1f, 0.1f);
    }

    public void OnZoomOutButtonPressed()
    {
        _instantiated.transform.localScale = _instantiated.transform.localScale - new Vector3(0.1f, 0.1f, 0.1f);
    }

    public void OnBackButtonPressed()
    {
        _canvas.SetActive(false);
        Destroy(_instantiated);
    }

    private void OnEscapeButtonPressed()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                SceneManager.LoadScene("MainMenu");
            }
        }
    }

    private void Update()
    {
        OnEscapeButtonPressed();
    }
}
