using qASIC.AudioManagment;
using UnityEngine;
using System.Collections;

public class PlayRandomLoop : MonoBehaviour
{
    [Range(0, 1)]
    [SerializeField] float firstProbability;
    [SerializeField] float maxTimeGap;

    [SerializeField] string channel;
    [SerializeField] AudioData clip1;
    [SerializeField] AudioData clip2;
    float time = 0;
    private void Awake()
    {
        StartCoroutine(PlayAndAwaitEndOfClip());
    }

    IEnumerator PlayAndAwaitEndOfClip()
    {
        float drawed =  Random.Range(0.0f, 1.0f);
        AudioData clip = drawed < firstProbability ? clip1 : clip2;
        AudioManager.Play(channel, clip);
        while (time < clip.clip.length)
            time += 0.5f;
            yield return new WaitForSeconds(0.5f);
        StartCoroutine(AwaitGap());
    }

    IEnumerator AwaitGap()
    {
        float gap = Random.Range(1, maxTimeGap);
        time = 0;
        while(time < gap)
        {
            time += 0.5f;
            yield return new WaitForSeconds(0.5f);

        }
    }

}
