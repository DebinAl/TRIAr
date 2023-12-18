using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ApplicationEventLP : MonoBehaviour
{
    public void OnStartButtonPressed()
    {
        SceneManager.LoadScene("MainMenu");
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
