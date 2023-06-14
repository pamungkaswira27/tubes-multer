using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UI_AnswerFeedback : MonoBehaviour
{
    [SerializeField] Canvas _feedbackCanvas;
    [SerializeField] Image _feedbackImage;
    [SerializeField] Sprite _correctFeedbackImage;
    [SerializeField] Color _correctImageColor;
    [SerializeField] Sprite _wrongFeedbackImage;
    [SerializeField] Color _wrongImageColor;
    [Space]
    [SerializeField] float _feedbackDuration;

    void OnEnable()
    {
        EventManager.OnCorrectAnswerSelected += DisplayCorrectFeedback;
        EventManager.OnWrongAnswerSelected += DisplayWrongFeedback;
    }

    void OnDisable()
    {
        EventManager.OnCorrectAnswerSelected -= DisplayCorrectFeedback;
        EventManager.OnWrongAnswerSelected -= DisplayWrongFeedback;
    }

    void DisplayCorrectFeedback()
    {
        _feedbackImage.sprite = _correctFeedbackImage;
        _feedbackImage.color = _correctImageColor;
        _feedbackCanvas.enabled = true;

        Invoke(nameof(HideFeedback), _feedbackDuration);
    }

    void DisplayWrongFeedback()
    {
        _feedbackImage.sprite = _wrongFeedbackImage;
        _feedbackImage.color = _wrongImageColor;
        _feedbackCanvas.enabled = true;

        Invoke(nameof(HideFeedback), _feedbackDuration);
    }

    void HideFeedback()
    {
        _feedbackCanvas.enabled = false;
    }
}
