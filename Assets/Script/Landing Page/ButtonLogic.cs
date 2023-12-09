using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonLogic : MonoBehaviour
{
    public void GetStartedButtonPressed()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
