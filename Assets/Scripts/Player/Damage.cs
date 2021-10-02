using UnityEngine;
using qASIC;
using System.Collections;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class Damage : MonoBehaviour
{
    int health = 100;
    int maxHealth;
    Vignette vignette;
    
    private void Start()
    {
        maxHealth = health;
        
        GameObject.FindWithTag("Volume").GetComponent<Volume>().profile.TryGet(out vignette);
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
        if(vignette)
        {
            float startIntensity = vignette.intensity.value;
            AnimationCurve curve = AnimationCurve.EaseInOut(0, 0, 0.5f, 1);
            for (float t = 0; t < 0.5f; t += Time.deltaTime)
            {
                vignette.intensity.value = Mathf.Lerp(startIntensity*maxHealth, maxHealth-health, curve.Evaluate(t))/maxHealth;
                yield return new WaitForEndOfFrame();
            }
        }
    }
}
