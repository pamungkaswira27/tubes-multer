using UnityEngine;
using UnityEngine.UI;

public class UI_EndScreen : MonoBehaviour
{
    [SerializeField] Canvas _endScreenCanvas;
    [SerializeField] GameObject _starImagePrefab;
    [SerializeField] Transform _starImageParent;
    [SerializeField] Color _passedColor;
    [SerializeField] Color _failedColor;

    ScoreManager _scoreManager;

    void Awake()
    {
        _scoreManager = FindObjectOfType<ScoreManager>();
    }

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

        Invoke(nameof(DisplayResult), 0.1f);
    }

    void DisplayResult()
    {
        for (int i = 0; i < 3; i++)
        {
            GameObject starImage = Instantiate(_starImagePrefab, _starImageParent);
            Image image = starImage.GetComponent<Image>();

            if (i < _scoreManager.GetFinalScore())
            {
                image.color = _passedColor;
            }
            else
            {
                image.color = _failedColor;
            }
        }
    }
}
