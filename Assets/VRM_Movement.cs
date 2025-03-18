using UnityEngine;

public class VRM_Movement : MonoBehaviour
{
    public Animator animator;
    public float moveSpeed = 3.0f;

    void Start()
    {
        if (animator == null)
        {
            animator = GetComponent<Animator>();
        }
    }

    void Update()
    {
        float move = Input.GetAxis("Vertical"); // กด W/S หรือลูกศรขึ้นลง
        animator.SetFloat("Speed", Mathf.Abs(move));

        transform.Translate(Vector3.forward * move * moveSpeed * Time.deltaTime);
    }
}
