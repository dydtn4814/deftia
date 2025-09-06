using UnityEngine;

public class CameraLook : MonoBehaviour
{
    // 마우스 감도
    public float mouseSensitivity = 100f;

    // 플레이어 오브젝트의 Transform
    public Transform playerBody;

    // 카메라의 위아래 회전 각도를 저장할 변수
    private float xRotation = 0f;

    void Start()
    {
        // 게임 시작 시 마우스를 화면 중앙에 고정하고 보이지 않게 합니다.
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // 마우스의 X, Y 입력 값을 가져옵니다.
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // 위아래(Y축) 회전: 카메라만 회전시킵니다.
        xRotation -= mouseY;
        // 회전 각도를 -90도에서 90도 사이로 제한하여 고개가 꺾이는 것을 방지합니다.
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // 좌우(X축) 회전: 플레이어 전체를 회전시킵니다.
        playerBody.Rotate(Vector3.up * mouseX);
    }
}