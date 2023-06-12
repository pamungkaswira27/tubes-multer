using UnityEngine;

public class UI_AnswerButton : MonoBehaviour
{
    int _answerIndex;

    public void SetAnswerIndex(int index)
    {
        _answerIndex = index;
    }

    public void Answer()
    {
        QuizManager.Instance.AnswerQuestion(_answerIndex);
    }
}
