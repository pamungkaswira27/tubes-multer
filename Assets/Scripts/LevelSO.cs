using UnityEngine;

[CreateAssetMenu(fileName = "Level", menuName = "LenVR/Level Data")]
public class LevelSO : ScriptableObject
{
    [Header("Level Data")]
    [SerializeField] QuestionSO[] _questions;

    public QuestionSO GetQuestion(int index)
    {
        return _questions[index];
    }

    public int GetQuestionCount()
    {
        return _questions.Length;
    }
}
