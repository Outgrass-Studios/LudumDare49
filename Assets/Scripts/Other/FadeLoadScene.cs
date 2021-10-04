using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeLoadScene : MonoBehaviour
{
    [SerializeField] float fadeDuration = 3f;
    [SerializeField] Color fadeColor = Color.black;

    public void LoadScene(string sceneName)
    {
        if (!Application.CanStreamedLevelBeLoaded(sceneName)) return;
        FadeController.Fade(fadeColor, fadeDuration, new Action(() =>
        {
            SceneManager.LoadScene(sceneName);
        }));
    }
}