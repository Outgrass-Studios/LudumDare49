using UnityEngine;
using System;
using qASIC;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FadeController : MonoBehaviour
{
    [SerializeField] Image image;
    [SerializeField] AnimationCurve animationCurve;
    [SerializeField] Color defaultColor;
    [SerializeField] float sceneLoadDuration;

    public static FadeController Singleton { get; private set; }
    public static Color CurrentColor { get; private set; }

    public static bool IsFading { get; private set; }
    Action OnFadeEnd;
    float time;
    float duration;

    Color startColor;
    Color endColor;

    private void Awake()
    {
        CurrentColor = defaultColor;
        ApplyCurrentColor();
        AssignSingleton();
    }

    private void OnEnable() =>
        SceneManager.sceneLoaded += (Scene scene, LoadSceneMode mode) => Fade(Color.clear, sceneLoadDuration);

    private void OnDisable() =>
        SceneManager.sceneLoaded -= (Scene scene, LoadSceneMode mode) => Fade(Color.clear, sceneLoadDuration);

    void AssignSingleton()
    {
        if (Singleton == null)
        {
            DontDestroyOnLoad(gameObject);
            Singleton = this;
            qDebug.Log("Assigned fade controller", "system");
            return;
        }
        if (Singleton != this) Destroy(gameObject);
    }

    static bool CheckSingleton()
    {
        if (Singleton != null) return true;
        qDebug.LogError("Fade controller has not been assigned!");
        return false;
    }

    public static void Fade(Color color, float duration) =>
        Fade(color, duration, new Action(() => { }));

    public static void Fade(Color color, float duration, Action onEnd)
    {
        if (!CheckSingleton()) return;

        Singleton.OnFadeEnd = onEnd;
        Singleton.time = 0f;
        Singleton.duration = duration;
        Singleton.startColor = CurrentColor;
        Singleton.endColor = color;
        IsFading = true;
    }

    private void Update()
    {
        if (!IsFading || image == null) return;

        time += Time.deltaTime;
        CurrentColor = Color.Lerp(startColor, endColor, animationCurve.Evaluate(time / duration));
        ApplyCurrentColor();

        if (time < duration) return;
        time = 0f;
        duration = 0f;
        IsFading = false;
        OnFadeEnd?.Invoke();
    }

    void ApplyCurrentColor()
    {
        if (image == null) return;
        image.color = CurrentColor;
    }
}
