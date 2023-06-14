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
        AudioManager.Instance.PlaySchoolBackgroundMusic();
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

    public void AnswerQuestion(int answerIndex)
    {
        if (_currentQuestion == null) return;

        if (_currentQuestion.GetAnswer(answerIndex).IsCorrect)
        {
            AudioManager.Instance.PlayCorrectAnswerSoundEffect();
            GetNextQuestion();
            EventManager.Fire_OnCorrectAnswerSelected();
        }
        else
        {
            AudioManager.Instance.PlayWrongAnswerSoundEffect();
            GetNextQuestion();
            EventManager.Fire_OnWrongAnswerSelected();
        }
    }

    void GetNextQuestion()
    {
        _questionIndex++;

        if (_questionIndex < _levelData.GetQuestionCount())
        {
            _currentQuestion = _levelData.GetQuestion(_questionIndex);
        }
        else
        {
            EventManager.Fire_OnQuestionsAnswered();
        }
    }
}
