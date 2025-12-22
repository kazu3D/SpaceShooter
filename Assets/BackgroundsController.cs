using UnityEngine;

public class BackgroundsController : MonoBehaviour
{
    [SerializeField] float scrollSpeed = 2f;        //背景が流れる速度
    [SerializeField] float resetPosition = -20f;    //左端に到達したと判断する地点
    [SerializeField] float startPosition = 20f;     //右端にワープさせる地点
    void Update()
    {
        transform.Translate(-scrollSpeed * Time.deltaTime, 0, 0);   //左へ移動

        if(transform.position.x <= resetPosition)
        {
            transform.position = new Vector3(startPosition, transform.position.y, transform.position.z);
        }
    }
}