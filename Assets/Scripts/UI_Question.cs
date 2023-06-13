using TMPro;
using UnityEngine;

public class UI_Question : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _questionText;
    [SerializeField] TextMeshProUGUI _translatedQuestionText;

    void OnEnable()
    {
        EventManager.OnCorrectAnswerSelected += DisplayQuestion;
    }

    void Start()
    {
        Invoke(nameof(DisplayQuestion), 0.01f);
    }

    void OnDisable()
    {
        EventManager.OnCorrectAnswerSelected -= DisplayQuestion;
    }

    void DisplayQuestion()
    {
        _questionText.text = QuizManager.Instance.GetCurrentQuestion().GetQuestion();
        _translatedQuestionText.text = QuizManager.Instance.GetCurrentQuestion().GetTranslatedQuestion();
    }
}
