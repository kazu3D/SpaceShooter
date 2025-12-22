using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class LaserController : MonoBehaviour
{
    [SerializeField] float speed = 8f;
    [SerializeField] float lifeTime = 3f;   //3•b‚Å©“®”jŠü

    PlayerController player;
    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<PlayerController>();

        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        transform.Translate(transform.right * speed * Time.deltaTime, Space.World);   //ƒ[ƒ‹ƒhÀ•W‚Å‰E•ûŒü‚Éi‚ß‚é
    }

    private void OnTriggerEnter2D(Collider2D other)     //š“G‚Ìcollider‚ÉG‚ê‚½‚çŒÄ‚Î‚ê‚é
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<Enemy>().Die();

            player.PlayHitSE();     //–½’†‚ÌSE‚ğ–Â‚ç‚·

            Destroy(other.gameObject);      //“G‚ğ“|‚·

            Destroy(gameObject);    //’e‚ğÁ‚·
        }
    }
}