using UnityEngine;

[CreateAssetMenu(fileName = "Question", menuName = "LenVR/Question")]
public class QuestionSO : ScriptableObject
{
    [Header("Original")]
    [SerializeField, TextArea(2, 4)] string _question;
    [SerializeField, TextArea(2, 4)] string[] _answers;

    [Header("Translated")]
    [SerializeField, TextArea(2, 4)] string _translatedQuestion;
    [SerializeField, TextArea(2, 4)] string[] _translatedAnswers;

    [SerializeField] int _correctAnswerIndex;

    public string GetQuestion()
    {
        return _question;
    }

    public string GetAnswer(int index)
    {
        return _answers[index];
    }

    public string GetTranslatedQuestion()
    {
        return _translatedQuestion;
    }

    public string GetTranslatedAnswer(int index)
    {
        return _translatedAnswers[index];
    }

    public int GetCorrectAnswerIndex()
    {
        return _correctAnswerIndex;
    }

    public int GetAnswerCount()
    {
        return _answers.Length;
    }
}
