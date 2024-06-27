using UnityEngine;

public class MoveBetween : MonoBehaviour
{
    public float speed = 5.0f;
    public float leftLimit = -10.0f;
    public float rightLimit = 10.0f;

    private float direction = 1.0f;  // 移動方向

    void Update()
    {
        // 移動角色
        transform.Translate(speed * direction * Time.deltaTime, 0, 0);

        // 檢查是否超出範圍，反轉方向
        if (transform.position.x >= rightLimit || transform.position.x <= leftLimit)
        {
            direction *= -1;  // 反轉方向
        }
    }
}
