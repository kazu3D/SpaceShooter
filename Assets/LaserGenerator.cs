using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.InputSystem;

public class LaserGenerator : MonoBehaviour
{
    [SerializeField] GameObject laserPrefab;    //弾のPrefabをInspectorでセット
    [SerializeField] Transform muzzle;          //Muzzle(Empty)をInspectorでセット
    [SerializeField] float fireCooldown = 0.2f; //連射間隔(秒)
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip fireSE;

    float cooldownTimer = 0f;
    void Update()
    {
        cooldownTimer -= Time.deltaTime;

        bool fire = Mouse.current.leftButton.isPressed;   //左クリックで弾を発射

        if(fire && cooldownTimer <= 0f)
        {
            Fire();
            cooldownTimer = fireCooldown;
        }
    }
    
    void Fire()
    {
        if (laserPrefab == null || muzzle == null) return;
        {
            Instantiate(laserPrefab, muzzle.position, muzzle.rotation);

            audioSource.PlayOneShot(fireSE);
        }
    }
}