using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_Question : MonoBehaviour
{
    [SerializeField] Canvas _questionCanvas;
    [SerializeField] TextMeshProUGUI _questionText;
    [SerializeField] TextMeshProUGUI _translatedQuestionText;
    [SerializeField] Button _voiceOverButton;

    QuestionSO _currentQuestion;

    void OnEnable()
    {
        EventManager.OnCorrectAnswerSelected += DisplayQuestion;
        EventManager.OnWrongAnswerSelected += DisplayQuestion;
        EventManager.OnQuestionsAnswered += HideQuestion;
    }

    void Start()
    {
        Invoke(nameof(DisplayQuestion), 0.01f);
    }

    void OnDisable()
    {
        EventManager.OnCorrectAnswerSelected -= DisplayQuestion;
        EventManager.OnWrongAnswerSelected -= DisplayQuestion;
        EventManager.OnQuestionsAnswered -= HideQuestion;
    }

    void DisplayQuestion()
    {
        _currentQuestion = QuizManager.Instance.GetCurrentQuestion();

        _questionText.text = QuizManager.Instance.GetCurrentQuestion().GetQuestion();
        _translatedQuestionText.text = QuizManager.Instance.GetCurrentQuestion().GetTranslatedQuestion();
        _voiceOverButton.onClick.AddListener(() => AudioManager.Instance.PlayVoiceOver(_currentQuestion.GetQuestionVoiceOverClip()));
    }

    void HideQuestion()
    {
        _questionCanvas.enabled = false;
    }
}
