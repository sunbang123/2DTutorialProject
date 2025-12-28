using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class OnKeyPressMove_Custom : MonoBehaviour
{
    public float speed = 2;
    public float rotationSpeed = 10f; // 회전 속도
    public static OnKeyPressMove_Custom instance;
    float vx = 0;
    float vy = 0;
    public static bool leftFlag = false;
    Rigidbody2D rbody;
    public GameObject FisherTool;
    public GameObject Bait;

    [Header("Virtual Joystick")]
    public VirtualJoystick virtualJoystick; // 가상 조이스틱 참조

    void Start()
    {
        instance = this.GetComponent<OnKeyPressMove_Custom>();
        rbody = GetComponent<Rigidbody2D>();
        rbody.gravityScale = 0;
        rbody.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    void Update()
    {
        vx = 0;
        vy = 0;

        // VirtualJoystick 입력 처리
        if (virtualJoystick != null)
        {
            float joystickX = virtualJoystick.Horizontal;
            float joystickY = virtualJoystick.Vertical;

            // 조이스틱 입력이 있을 때만 처리 (dead zone 적용)
            if (Mathf.Abs(joystickX) > 0.1f || Mathf.Abs(joystickY) > 0.1f)
            {
                vx = joystickX * speed;
                vy = joystickY * speed;

                // 좌우 방향 플래그 설정
                if (joystickX > 0.1f)
                {
                    leftFlag = false; // 오른쪽
                }
                else if (joystickX < -0.1f)
                {
                    leftFlag = true; // 왼쪽
                }
            }
        }

        if (Input.GetKey("right"))
        {
            vx = speed;
            leftFlag = false;
        }
        if (Input.GetKey("left"))
        {
            vx = -speed;
            leftFlag = true;
        }
        if (Input.GetKey("up"))
        {
            vy = speed;
        }
        if (Input.GetKey("down"))
        {
            vy = -speed;
        }
    }

    void FixedUpdate()
    {
        rbody.linearVelocity = new Vector2(vx, vy);
        // 물리적으로 자연스러운 회전
        Quaternion targetRotation = Quaternion.Euler(0, leftFlag ? 0 : 180, 0);
        this.transform.rotation = Quaternion.Slerp(
            this.transform.rotation,
            targetRotation,
            rotationSpeed * Time.fixedDeltaTime
        );

        //함수 FixedUpdate():
        //    rbody의 속도 ← (vx, vy)

        //    // 자연스러운 회전
        //    만약(leftFlag가 true):
        //        목표회전 ← (0, 0, 0)
        //    아니면:
        //        목표회전 ← (0, 180, 0)
        //    끝
        //        현재회전을 목표회전으로 부드럽게 보간
        //    (Slerp 사용, 속도 = rotationSpeed * deltaTime)
        //끝
    }

    public void StepBack()
    {
        Debug.Log("Trigger entered by: " + this.gameObject.name);

        if (leftFlag)
        {
            transform.position = new Vector3(transform.position.x + 0.5f, transform.position.y, transform.position.z);
        }
        else
        {
            transform.position = new Vector3(transform.position.x - 0.5f, transform.position.y, transform.position.z);
        }

        SpriteRenderer spriteRenderer = Bait.GetComponent<SpriteRenderer>();
        Color originalColor = spriteRenderer.color;
        spriteRenderer.color = Color.red;
        Invoke("ResetColor", 0.2f);
    }

    void ResetColor()
    {
        SpriteRenderer spriteRenderer = Bait.GetComponent<SpriteRenderer>();
        spriteRenderer.color = Color.white;
    }
}