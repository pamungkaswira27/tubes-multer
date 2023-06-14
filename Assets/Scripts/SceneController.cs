using DG.Tweening;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneController : MonoBehaviour
{
    [SerializeField] CanvasGroup _fadeImage;
    [SerializeField] float _fadeDuration;
    [SerializeField] float _transitionDuration;

    void OnEnable()
    {
        _fadeImage.alpha = 1f;
        _fadeImage.blocksRaycasts = false;
        _fadeImage.DOFade(0f, _fadeDuration).SetEase(Ease.InOutExpo);
    }

    public void LoadGameplayScene()
    {
        StartCoroutine(FadeSceneCoroutine(SceneName.GAMEPLAY));
    }

    public void LoadMainMenuScene()
    {
        StartCoroutine(FadeSceneCoroutine(SceneName.MAIN_MENU));
    }

    IEnumerator FadeSceneCoroutine(string sceneName)
    {
        _fadeImage.alpha = 0f;
        _fadeImage.blocksRaycasts = false;
        _fadeImage.DOFade(1f, _fadeDuration).SetEase(Ease.InOutExpo);

        yield return new WaitForSeconds(_transitionDuration + _fadeDuration);

        SceneManager.LoadScene(sceneName);
    }
}
