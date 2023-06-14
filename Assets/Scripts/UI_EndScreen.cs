using UnityEngine;

public class UI_EndScreen : MonoBehaviour
{
    [SerializeField] Canvas _endScreenCanvas;

    void OnEnable()
    {
        EventManager.OnQuestionsAnswered += DisplayEndScreen;
    }

    void OnDisable()
    {
        EventManager.OnQuestionsAnswered -= DisplayEndScreen;
    }

    void DisplayEndScreen()
    {
        _endScreenCanvas.enabled = true;
    }
}
