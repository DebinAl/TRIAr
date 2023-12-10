using UnityEngine;
using UnityEngine.SceneManagement;

public class ApplicationEventMenu : MonoBehaviour
{
    public void OnCameraButtonPressed()
    {
        SceneManager.LoadScene("ARScene");
    }

    private void OnEscapeButtonPressed()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                Application.Quit();

                return;
            }
        }
    }

    private void Update()
    {
        OnEscapeButtonPressed();
    }
}
