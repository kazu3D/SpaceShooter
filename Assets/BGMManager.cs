using System.Collections;
using UnityEngine;

public class BGMManager : MonoBehaviour
{
    public static BGMManager instance;

    [SerializeField] AudioSource bgmSource;

    public void Awake()
    {
        instance = this;
    }

    public void PlayBGM()
    {
        bgmSource.Play();
    }

    public void FadeOutBGM(float duration = 2f)   //GAME OVER時にフェードアウト
    {
        StartCoroutine(FadeOutRoutine(duration));
    }

    IEnumerator FadeOutRoutine(float duration)
    {
        float startVolume = bgmSource.volume;
        float t = 0f;

        while(t < duration)
        {
            t += Time.deltaTime;
            bgmSource.volume = Mathf.Lerp(startVolume, 0f, t / duration);
            yield return null;
        }

        bgmSource.volume = 0f;
    }
}