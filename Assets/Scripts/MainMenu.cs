using UnityEngine;
using UnityEngine.XR.Management;

public class MainMenu : MonoBehaviour
{
    public void ExitGame()
    {
        XRGeneralSettings.Instance.Manager.StopSubsystems();
        XRGeneralSettings.Instance.Manager.DeinitializeLoader();
        Application.Quit();
    }
}
