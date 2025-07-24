using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    public Transform playerBody; // Player để xoay trái phải

    float xRotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // Ẩn và khóa chuột trong màn hình
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY; // Đảo chiều vì di chuột lên thì camera phải ngẩng lên
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // Giới hạn góc nhìn

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f); // Xoay camera
        playerBody.Rotate(Vector3.up * mouseX); // Xoay thân player
    }
}
