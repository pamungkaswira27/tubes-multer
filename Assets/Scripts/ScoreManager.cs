using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] int _score;
    [SerializeField] int _maxScore;
    [SerializeField] int _finalScore;

    void OnEnable()
    {
        EventManager.OnCorrectAnswerSelected += AddScore;
        EventManager.OnQuestionsAnswered += CalculateFinalScore;
    }

    void Start()
    {
        _maxScore = QuizManager.Instance.GetLevelData().GetQuestionCount();
    }

    void OnDisable()
    {
        EventManager.OnCorrectAnswerSelected -= AddScore;
        EventManager.OnQuestionsAnswered -= CalculateFinalScore;
    }

    public int GetFinalScore()
    {
        return _finalScore;
    }

    void AddScore()
    {
        _score++;

        if (_score >= QuizManager.Instance.GetLevelData().GetQuestionCount())
        {
            _score = QuizManager.Instance.GetLevelData().GetQuestionCount();
        }
    }

    void CalculateFinalScore()
    {
        if (_score >= (_maxScore - 3))
        {
            _finalScore = 3;
        }
        else if (_score > 1 && _score <= (_maxScore - 4))
        {
            _finalScore = 2;
        }
        else if (_score == 1)
        {
            _finalScore = 1;
        }
        else
        {
            _finalScore = 0;
        }
    }
}
