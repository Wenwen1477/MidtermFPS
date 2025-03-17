using UnityEngine;

public class FirstPersonCamera : MonoBehaviour
{
    public Transform player;           // ตัวแปรที่เก็บตัวละคร
    public float mouseSensitivity = 2.0f;  // ความไวของเมาส์
    public float verticalLookLimit = 80f;  // จำกัดมุมมองขึ้น/ลง

    private float xRotation = 0f;     // มุมการหมุนกล้องในแนว X (มุมขึ้น/ลง)

    void Update()
    {
        // รับค่าการเคลื่อนที่ของเมาส์
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        // หมุนกล้องตามแนวนอน (ซ้าย/ขวา)
        transform.Rotate(Vector3.up * mouseX);

        // คำนวณการหมุนในแนวตั้ง (ขึ้น/ลง) และจำกัดมุมมอง
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -verticalLookLimit, verticalLookLimit);  // จำกัดไม่ให้มุมเกิน 80 องศา

        // หมุนกล้องในแนวตั้ง (มุมมองขึ้น/ลง)
        Camera.main.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }
}
