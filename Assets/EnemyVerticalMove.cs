using UnityEngine;

public class EnemyVerticalMove : MonoBehaviour
{
    [SerializeField] float moveSpeed = 2f;      //左へ進む速さ
    [SerializeField] float amplitude = 1f;      //上下の幅
    [SerializeField] float frequency = 2f;      //上下の速さ

    float startY;   //最初のY座標を保存
    void Start()
    {
        startY = transform.position.y;
    }

    void Update()
    {
        transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);         //左に進む

        float newY = startY + Mathf.Sin(Time.time * frequency) * amplitude;     //上下に揺れる

        transform.position = new Vector3(transform.position.x, newY, transform.position.z);     //位置を更新
    }
}