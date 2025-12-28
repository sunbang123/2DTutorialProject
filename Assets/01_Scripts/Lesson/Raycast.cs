using UnityEngine;

public class Raycast : MonoBehaviour
{
    private float speed = 5.0f;

    private void Update()
    {
        float amtMove = speed * Time.deltaTime;
        float hor = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * hor * amtMove);

        Debug.DrawRay(transform.position, transform.forward * 8, Color.red);

        RaycastHit hit; // 이 선언이 빠졌을 수 있음

        if (Physics.Raycast(transform.position, transform.forward, out hit, 8))
        {
            Debug.Log(hit.collider.gameObject.name);
        }
    }
}
