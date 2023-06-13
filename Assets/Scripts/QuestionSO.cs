using UnityEngine;

[CreateAssetMenu(fileName = "Question", menuName = "LenVR/Question")]
public class QuestionSO : ScriptableObject
{
    [Header("Original")]
    [SerializeField, TextArea(2, 4)] string _question;
    [SerializeField] Answer[] _answers;

    [Header("Translated")]
    [SerializeField, TextArea(2, 4)] string _translatedQuestion;
    [SerializeField, TextArea(2, 4)] string[] _translatedAnswers;

    [Header("Voice Over")]
    [SerializeField] AudioClip _questionVoiceOverClip;
    [SerializeField] AudioClip[] _answerVoiceOverClip;

    public string GetQuestion()
    {
        return _question;
    }

    public Answer GetAnswer(int index)
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

    public int GetAnswerCount()
    {
        return _answers.Length;
    }

    public AudioClip GetQuestionVoiceOverClip()
    {
        return _questionVoiceOverClip;
    }

    public AudioClip GetAnswerVoiceOverClip(int index)
    {
        return _answerVoiceOverClip[index];
    }
}
