using UnityEngine;

public class EnemyZigZagMove : MonoBehaviour
{
    [SerializeField] float moveSpeed = 3f;      //左へ進む速さ
    [SerializeField] float zigzagAmplitude = 2f;    //ジグザグ幅（上下にどれくらい揺れる？）
    [SerializeField] float zigzagSpeed = 3f;    //ジグザグの速さ（振動スピード）

    float startY;   //生まれた位置のY座標を記録する
    void Start()
    {
        startY = transform.position.y;      //スタート時のY位置を覚えておく
    }

    void Update()
    {
        transform.position += Vector3.left * moveSpeed * Time.deltaTime;    //左へ移動する

        float offsetY = Mathf.Sin(Time.time * zigzagSpeed) * zigzagAmplitude;   //上下方向に揺らす

        transform.position = new Vector3(transform.position.x, startY + offsetY, 0f);   //揺れを適用
    }
}