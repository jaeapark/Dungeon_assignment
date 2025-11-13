using UnityEngine;

public class JumpPad : MonoBehaviour
{
    [Header("점프력 설정")]
    public float jumpForce = 13f;

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("점프패드 사용");
        if (collision.gameObject.CompareTag("Player"))
        {
            Rigidbody playerRb = collision.gameObject.GetComponent<Rigidbody>();

            if (playerRb != null)
            {
                playerRb.velocity = Vector3.zero;
                playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            }
        }
    }
}
