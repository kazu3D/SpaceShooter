using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class UIController : MonoBehaviour
{
    public GameObject gameOverText;
    public GameObject restartText;

    public static UIController instance;

    [SerializeField] Image[] lifeIcons;     //アイコンを配列でセット


    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        BGMManager.instance.PlayBGM();
    }

    public void SetLife(int life)
    {
        for(int i = 0; i < lifeIcons.Length; i++)   //全アイコンループ
        {
            lifeIcons[i].enabled = (i < life);
        }
    }

    public void ShowGameOver()
    {
        gameOverText.SetActive(true);
        restartText.SetActive(false);

        BGMManager.instance.FadeOutBGM(2f);

        StartCoroutine(ShowPushStartRoutine());     //1秒後に「Push Start」も表示
    }

    IEnumerator ShowPushStartRoutine()
    {
        yield return new WaitForSeconds(1f);
        restartText.SetActive(true);

        StartCoroutine(RestartWaitRoutine());   //リスタート待機開始
    }

    IEnumerator RestartWaitRoutine()
    {
        while(true)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
            yield return null;
        }
    }
}