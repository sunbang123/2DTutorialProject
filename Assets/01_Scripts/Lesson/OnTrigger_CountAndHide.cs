using UnityEngine;

public class OnTrigger_CountAndHide : MonoBehaviour
{
    public string targetObjectName;
    public int addValue = 1;

    private void Start()
    {
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.name == targetObjectName)
        {
            GameCounter.value += addValue;

            this.gameObject.SetActive(false);

            Destroy(this.gameObject, 1f); // 1초 후에 파괴
        }
    }
}
