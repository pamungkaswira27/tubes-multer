using System;

public static class EventManager
{
    public delegate void CorrectAnswer();
    public static event CorrectAnswer OnCorrectAnswerSelected;
    public static void Fire_OnCorrectAnswerSelected()
    {
        OnCorrectAnswerSelected?.Invoke();
    }

    public delegate void WrongAnswer();
    public static event WrongAnswer OnWrongAnswerSelected;
    public static void Fire_OnWrongAnswerSelected()
    {
        OnWrongAnswerSelected?.Invoke();
    }

    public static event Action OnQuestionsAnswered;
    public static void Fire_OnQuestionsAnswered()
    {
        OnQuestionsAnswered?.Invoke();
    }
}
