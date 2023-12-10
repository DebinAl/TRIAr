using UnityEngine;
using UnityEngine.SceneManagement;

public class ApplicationEventAR : MonoBehaviour
{
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
