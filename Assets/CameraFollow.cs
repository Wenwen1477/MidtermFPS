using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;   // ตัวแปรที่จะให้กล้องติดตาม (ตัวละคร)
    public Vector3 offset;     // ระยะห่างระหว่างกล้องกับตัวละคร

    void Start()
    {
        // ถ้ายังไม่ได้ตั้งค่า offset จะตั้งค่าเป็นค่าปกติ
        if (offset == Vector3.zero)
        {
            offset = new Vector3(0, 1.5f, -5);  // ตัวอย่างให้กล้องอยู่สูงขึ้นและห่างออกไป
        }
    }

    void LateUpdate()
    {
        // ให้กล้องติดตามตัวละครตามตำแหน่งและระยะห่าง
        transform.position = player.position + offset;

        // ให้กล้องหมุนตามการหมุนของตัวละคร
        transform.LookAt(player);
    }
}
