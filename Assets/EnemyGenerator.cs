using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    [SerializeField] GameObject[] enemyPrefabs;    //生成したい敵Prefabを複数登録
    [SerializeField] float interval = 0.8f;     //生成する間隔
    [SerializeField] float minY = -3f;          //ランダムY位置の下限
    [SerializeField] float maxY = 3f;           //ランダムY位置の上限

    float timer;   //経過時間を数える用
    void Update()
    {
        timer += Time.deltaTime;    //毎フレーム時間を加算

        if(timer > interval)
        {
            timer = 0f;
            SpawnEnemy();
        }
    }

    void SpawnEnemy()
    {
        if (enemyPrefabs.Length == 0) return;
        {
            int index = Random.Range(0, enemyPrefabs.Length);    //0～enemyPrefabs.Lengthの中でランダムに選ぶ

            float spawnY = Random.Range(minY, maxY);               //敵の生成位置をY（-3f～3f）のランダムに設定
            Vector3 spawnPos = new Vector3(10f, spawnY, 0f);       //敵が生成される位置

            Instantiate(enemyPrefabs[index], spawnPos, Quaternion.identity);
        }
    }
}