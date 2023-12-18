using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ApplicationEventMenu : MonoBehaviour
{
    [SerializeField] Canvas _aboutUs;
    [SerializeField] Button[] _menuButtons;
    [SerializeField] Button _closeButtons;

    private void OnEnable()
    {
        _aboutUs.enabled = false;
    }
    public void OnCameraButtonPressed()
    {
        SceneManager.LoadScene("ARScene");
    }

    public void OnAboutButtonPressed()
    {
        ButtonStatus(false);
        _aboutUs.enabled = true;
    }

    public void OnCloseButtonPressed()
    {
        _aboutUs.enabled = false;
        ButtonStatus(true);
    }

    private void ButtonStatus(bool status)
    {
        foreach (var button in _menuButtons)
        {
            button.enabled = status;
        }

        _closeButtons.enabled = !status;
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
