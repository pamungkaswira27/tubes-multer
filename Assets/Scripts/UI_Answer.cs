using TMPro;
using UnityEngine;

public class UI_Answer : MonoBehaviour
{
    [SerializeField] GameObject _answerButtonPrefab;
    [SerializeField] GameObject _translatedAnswerPrefab;
    [SerializeField] Transform _answerParent;

    TextMeshProUGUI _answerText;
    TextMeshProUGUI _translatedAnswerText;

    int _answerCount;

    void OnEnable()
    {
        EventManager.OnCorrectAnswerSelected += DisplayAnswer;
    }

    void Start()
    {
        Invoke(nameof(DisplayAnswer), 0.01f);
    }

    void OnDisable()
    {
        EventManager.OnCorrectAnswerSelected -= DisplayAnswer;
    }

    void DisplayAnswer()
    {
        ClearAnswer();

        _answerCount = QuizManager.Instance.GetCurrentQuestion().GetAnswerCount();

        for (int i = 0; i < _answerCount; i++)
        {
            GameObject answerButton = Instantiate(_answerButtonPrefab, _answerParent);
            GameObject translatedAnswer = Instantiate(_translatedAnswerPrefab, _answerParent);

            answerButton.GetComponent<UI_AnswerButton>().SetAnswerIndex(i);

            _answerText = answerButton.GetComponentInChildren<TextMeshProUGUI>();
            _translatedAnswerText = translatedAnswer.GetComponentInChildren<TextMeshProUGUI>();

            _answerText.text = QuizManager.Instance.GetCurrentQuestion().GetAnswer(i).Question;
            _translatedAnswerText.text = QuizManager.Instance.GetCurrentQuestion().GetTranslatedAnswer(i);

            translatedAnswer.SetActive(false);
        }
    }

    void ClearAnswer()
    {
        for (int i = 0; i < _answerParent.childCount; i++)
        {
            Destroy(_answerParent.GetChild(i).gameObject);
        }
    }
}
