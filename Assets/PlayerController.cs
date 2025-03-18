using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    public float speed = 0f;

    void Update()
    {
        float move = Input.GetAxis("Vertical"); // กด W หรือ S
        speed = Mathf.Abs(move) * 3f; // ปรับค่า Speed

        animator.SetFloat("Speed", speed);
    }
}
