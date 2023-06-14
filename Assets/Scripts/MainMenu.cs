using UnityEngine;
using UnityEngine.XR.Management;

public class MainMenu : MonoBehaviour
{
    void Start()
    {
        AudioManager.Instance.PlayMenuBackgroundMusic();
    }

    public void ExitGame()
    {
        XRGeneralSettings.Instance.Manager.StopSubsystems();
        XRGeneralSettings.Instance.Manager.DeinitializeLoader();
        Application.Quit();
    }
}
