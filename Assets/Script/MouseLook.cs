using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 150f;
    public Transform playerBody;

    float xRotation = 0f;
    bool isLocked = true;

    void Start()
    {
        LockCursor(true);
    }

    void Update()
    {
        // Nhấn ESC để bật/tắt chuột
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isLocked = !isLocked;
            LockCursor(isLocked);
        }

        // Nếu đang mở chuột → không xoay
        if (!isLocked) return;

        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Xoay lên xuống
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // Xoay trái phải
        playerBody.Rotate(Vector3.up * mouseX);
    }

    void LockCursor(bool lockState)
    {
        if (lockState)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    // 🔥 Quan trọng: cho script khác kiểm tra
    public bool IsLocked()
    {
        return isLocked;
    }
}