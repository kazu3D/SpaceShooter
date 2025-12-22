using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 5;   //SerializeFieldでインスペクタで調整可能になる!!

    [SerializeField] AudioSource audioSource;   //インスペクタでAudioSourceをドラッグ
    [SerializeField] AudioClip hitSE;           //インスペクタでhitSEドラッグ
    [SerializeField] AudioClip damageSE;

    [SerializeField] int life = 3;  //残機
    [SerializeField] float invincibleTime = 1.5f;   //無敵時間
    bool isInvincible = false;
    void Start()
    {
        Application.targetFrameRate = 60;
    }

    void Update()
    {
        float moveX = 0f;
        float moveY = 0f;

        if(Keyboard.current.aKey.isPressed)
        {
            moveX = -1f;  //左に「1」移動
        }
        if(Keyboard.current.wKey.isPressed)
        {
            moveY = 1f;   //上に「1」移動
        }
        if(Keyboard.current.dKey.isPressed)
        {
            moveX = 1f;   //右に「1」移動
        }
        if(Keyboard.current.sKey.isPressed)
        {
            moveY = -1f;  //下に「1」移動
        }
        Vector3 direction = new Vector3(moveX, moveY, 0).normalized;    //new Vector3.normalizeで移動の長さ(斜め等)を揃える

        transform.Translate(direction * speed * Time.deltaTime, Space.World);   //ワールド座標で移動させる
    }


    public void Damage()
    {
        if (isInvincible) return;   //無敵中ならダメージ無効
        {
            life--;
            UIController.instance.SetLife(life);

            audioSource.PlayOneShot(damageSE);

            if(life <= 0)
            {
                StartCoroutine(DeadRoutine());
                return;
            }

            StartCoroutine(InvincibleRoutine());    //点滅＆無敵になる
        }
    }


    IEnumerator InvincibleRoutine()
    {
        isInvincible = true;

        SpriteRenderer sr = GetComponentInChildren<SpriteRenderer>();
        float t = 0f;

        while(t < invincibleTime)
        {
            sr.enabled = !sr.enabled;
            yield return new WaitForSeconds(0.1f);
            t += 0.1f;
        }
        sr.enabled = true;

        isInvincible = false;
    }



    IEnumerator DeadRoutine()
    {
        Collider2D col = GetComponent<Collider2D>();
        col.enabled = false;    //Collider無効化
        foreach(var c in GetComponentsInChildren<Collider2D>())      //もし子にColliderある場合は全部無効化
        {
            c.enabled = false;
        }

        var shooter = GetComponent<LaserGenerator>();   //弾を射撃しているスクリプト
        if(shooter != null)
        {
            shooter.enabled = false;
        }

        SpriteRenderer sr = GetComponentInChildren<SpriteRenderer>();
        for(int i = 0; i < 10; i++)
        {
            sr.enabled = !sr.enabled;
            yield return new WaitForSeconds(0.1f);
        }
        sr.enabled = false;     //完全に消す

        UIController.instance.ShowGameOver();   //UIにGAME OVER表示
    }


    public void PlayHitSE()
    {
        audioSource.PlayOneShot(hitSE);     //hitSEを鳴らす
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Enemy"))
        {
            Damage();
        }
    }
}