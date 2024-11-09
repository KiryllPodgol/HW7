using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController characterController;
    public Transform cameraTransform;
    public float speedWalk = 6.0f;
    public float gravity = -9.81f;
    public Light flashlight; // ������ �� �������
    private Vector3 velocity;

    void Start()
    {
        characterController = GetComponent<CharacterController>();


        if (cameraTransform == null)
        {
            cameraTransform = Camera.main.transform;
        }

        // ���������, �������� �� �������
        if (flashlight == null)
        {
            Debug.LogError("Flashlight is not assigned! Please assign a flashlight in the inspector.");
        }
        else
        {
            flashlight.enabled = false; // �������� � ������������ ��������
        }
    }


    void Update()
    {
        // ���������� ��������� �� ������� F
        if (Input.GetKeyDown(KeyCode.F) && flashlight != null)
        {
            flashlight.enabled = !flashlight.enabled; // ����������� ��������� ��������
        }
        // �������� ���� �� ������������
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        // ���������� ����������� �������� ������������ ���������� ������
        Vector3 moveDirection = cameraTransform.right * x + cameraTransform.forward * z;
        moveDirection.y = 0; // �������� ������� ������������ ���
        moveDirection.Normalize(); // ����������� �����������, ����� ��������� ��������� �� ���������

        // ������� ���������
        characterController.Move(moveDirection * speedWalk * Time.deltaTime);

        // ��������� ����������
        if (!characterController.isGrounded)
        {
            velocity.y += gravity * Time.deltaTime;
        }
        else if (velocity.y < 0)
        {
            velocity.y = -2f;
        }
        characterController.Move(velocity * Time.deltaTime);
    }
}

