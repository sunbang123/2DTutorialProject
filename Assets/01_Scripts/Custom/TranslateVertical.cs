using UnityEngine;

public class TranslateVertical : MonoBehaviour
{
    public float speed = 0.1f;

    public void TranslateDown()
    {
        // 현재 rotation의 회전된 각도에 따라 그 방향을 향해 서서히 내려가도록
        // transform.up은 오브젝트의 로컬 "위" 방향 벡터
        // 아래로 이동하려면 -transform.up 방향으로 이동
        Vector3 direction = -transform.up;
        this.gameObject.transform.position += direction * speed;
    }
    
    public void TranslateUp()
    {
        // 현재 rotation의 회전된 각도에 따라 그 방향을 향해 서서히 올라가도록
        // transform.up은 오브젝트의 로컬 "위" 방향 벡터
        Vector3 direction = transform.up;
        this.gameObject.transform.position += direction * speed;
    }

    // 필요시 이동 멈추기
    public void StopMoving()
    {
        CancelInvoke();
    }

    // 위로 이동으로 전환
    public void StartMovingUp()
    {
        StopMoving();
        InvokeRepeating("TranslateUp", 0f, 0.05f);
        Invoke("StopMoving", 0.5f);
    }

    // 아래로 이동으로 전환
    public void StartMovingDown()
    {
        StopMoving();
        InvokeRepeating("TranslateDown", 0f, 0.05f);
        Invoke("StopMoving", 0.5f);
    }
}
