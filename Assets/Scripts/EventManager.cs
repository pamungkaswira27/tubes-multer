public static class EventManager
{
    public delegate void CorrectAnswer();
    public static event CorrectAnswer OnCorrectAnswerSelected;
    public static void Fire_OnCorrectAnswerSelected()
    {
        OnCorrectAnswerSelected?.Invoke();
    }
}
