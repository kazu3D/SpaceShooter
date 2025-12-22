using UnityEngine;

public class Enemy : MonoBehaviour
{
    public void Die()
    {
        ScoreManager.instance.AddScore(1);
        Destroy(gameObject);
    }
}