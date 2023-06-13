using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] int _score;

    void OnEnable()
    {
        EventManager.OnCorrectAnswerSelected += AddScore;
    }

    void OnDisable()
    {
        EventManager.OnCorrectAnswerSelected -= AddScore;
    }

    public int GetPlayerScore()
    {
        return _score;
    }

    void AddScore()
    {
        _score++;

        if (_score >= QuizManager.Instance.GetLevelData().GetQuestionCount())
        {
            _score = QuizManager.Instance.GetLevelData().GetQuestionCount();
        }
    }
}
