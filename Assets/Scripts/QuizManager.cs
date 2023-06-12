using UnityEngine;

public class QuizManager : MonoBehaviour
{
    public static QuizManager Instance;

    [SerializeField] LevelSO _levelData;
    [SerializeField] QuestionSO _currentQuestion;

    int _questionIndex = 0;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        _currentQuestion = _levelData.GetQuestion(_questionIndex);
    }

    public LevelSO GetLevelData()
    {
        return _levelData;
    }

    public QuestionSO GetCurrentQuestion()
    {
        return _currentQuestion;
    }

    public void GetNextQuestion()
    {
        _questionIndex++;
        _currentQuestion = _levelData.GetQuestion(_questionIndex);
    }
}
