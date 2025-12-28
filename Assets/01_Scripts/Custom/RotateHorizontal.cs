using UnityEngine;

public class RotateHorizontal : MonoBehaviour
{
    public float speed = 0.1f;
    public static float angleZ;
    public static bool isRotating = false;
    public static RotateHorizontal instance;

    private void Start()
    {
        instance = this;
    }

    public void RotateRight()
    {
        // Z축 기준 시계방향 회전
        this.transform.Rotate(0, 0, -speed);
    }

    public void RotateLeft()
    {
        this.transform.Rotate(0, 0, +speed);
    }

    // 필요시 이동 멈추기
    public void StopMoving()
    {
        CancelInvoke();
        angleZ = -this.transform.eulerAngles.z;
    }

    // 위로 이동으로 전환
    public void StartRotateRight()
    {
        isRotating = true;
        StopMoving();

        if(OnKeyPressMove_Custom.leftFlag)
            InvokeRepeating("RotateLeft", 0f, 0.05f);
        else
            InvokeRepeating("RotateRight", 0f, 0.05f);

        Invoke("StopMoving", 0.5f);
        isRotating = false;
    }

    // 아래로 이동으로 전환
    public void StartRotateLeft()
    {
        isRotating = true;
        StopMoving();

        if (OnKeyPressMove_Custom.leftFlag)
            InvokeRepeating("RotateRight", 0f, 0.05f);
        else
            InvokeRepeating("RotateLeft", 0f, 0.05f);
        Invoke("StopMoving", 0.5f);
        isRotating = false;
    }
}
