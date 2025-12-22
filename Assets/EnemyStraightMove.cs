using UnityEngine;

public class EnemyStraightMove: MonoBehaviour
{
    [SerializeField] float speed = 3f;      //ˆÚ“®‘¬“x

    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);     //¶•ûŒü‚ÖˆÚ“®

        if(transform.position.x < -10f)
        {
            Destroy(gameObject);
        }
    }
}