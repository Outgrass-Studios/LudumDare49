using UnityEngine;
using qASIC;
using System.Collections;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class PlayerDamage : MonoBehaviour
{
    int health = 100;
    int maxHealth;
    Volume volume;
    [SerializeField] AnimationCurve animationCurve = AnimationCurve.EaseInOut(0, 0, 0.5f, 1);
    [SerializeField] AnimationCurve intensityCurve = AnimationCurve.EaseInOut(0f, 0f, 1f, 1f);

    [Header("Fade animation")]
    [SerializeField] Color fadeColor;
    [SerializeField] float fadeDuration;

    private void Start()
    {
        maxHealth = health;

        volume = GameObject.FindWithTag("Volume")?.GetComponent<Volume>();
        if (volume != null)
            volume.weight = intensityCurve.Evaluate(0f);
    }
    public void Hurt(int damagePoints)
    {
        health -= damagePoints;
        if (health <= 0)
            Kill();
        UpdateEffects();
    }
    public void Kill()
    {
        qDebug.Log("Player was killed", "player");
        CursorManager.ChangeMovementState("death", false);
        CursorManager.ChangeLookState("death", false);
        FadeController.Fade(fadeColor, fadeDuration, new System.Action(() =>
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            CursorManager.ChangeMovementState("death", true);
            CursorManager.ChangeLookState("death", true);
        }));
    }
    public void Heal(int healPoints)
    {
        health += healPoints;
        if (health > maxHealth)
            health = maxHealth;
        UpdateEffects();
    }
    private void UpdateEffects()
    {
        StopAllCoroutines();
        StartCoroutine(AnimateVignette());
    }
    private IEnumerator AnimateVignette()
    {
        if(volume)
        {
            float startIntensity = volume.weight;
            for (float t = 0; t < 0.5f; t += Time.deltaTime)
            {
                volume.weight = intensityCurve.Evaluate(Mathf.Lerp(startIntensity*maxHealth, maxHealth-health, animationCurve.Evaluate(t))/maxHealth);
                yield return new WaitForEndOfFrame();
            }
        }
    }
}
