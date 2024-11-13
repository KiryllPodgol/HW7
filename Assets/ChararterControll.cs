using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlayerMovement : MonoBehaviour
{
    public CharacterController characterController;
    public Transform cameraTransform;
    public float speedWalk = 6.0f;
    public float gravity = -9.81f;
    public Light flashlight;

    [Header("Audio Settings")]
    public AudioSource source;
    public AudioClip clip; // ��������� ��� �����

    private Vector3 velocity;

    private Vector3 previousPosition;

    void Start()
    {
        characterController = GetComponent<CharacterController>();


        if (cameraTransform == null)
        {
            cameraTransform = Camera.main.transform;
        }

        if (flashlight == null)
        {
            Debug.LogError("Flashlight is not assigned! Please assign a flashlight in the inspector.");
        }
        else
        {
            flashlight.enabled = false;
        }

        if (source == null)
        {
            Debug.LogError("Step AudioSource is not assigned! Please assign an AudioSource in the inspector.");
        }

        if (clip == null)
        {
            Debug.LogError("Step AudioClip is not assigned! Please assign an AudioClip in the inspector.");
        }
        else
        {
            source.clip = clip; // ������������� ���� � �������� �����
            source.loop = true; // ���� ����� �����������
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && flashlight != null)
        {
            flashlight.enabled = !flashlight.enabled;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        // ���������� ����������� �������� ������������ ���������� ������
        Vector3 moveDirection = cameraTransform.right * x + cameraTransform.forward * z;
        moveDirection.y = 0;
        moveDirection.Normalize();

        // ����������� �������� ������� ��������
        //Debug.Log("Magnitude of moveDirection: " + moveDirection.magnitude);

        // ��������, �������� �� ��������, � ������������ ����� �����
        if (moveDirection.magnitude > 0 && characterController.isGrounded)
        {
            // ������� ���������
            characterController.Move(moveDirection * speedWalk * Time.deltaTime);
        }

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

        // ����������� �������� ������������ �����������
        float actualSpeed = 0;
        if (previousPosition != null)
        {
            Vector3 movementVector = transform.position - previousPosition;
            actualSpeed = movementVector.magnitude / Time.deltaTime;
            Debug.Log("Position: prev = " + previousPosition + ", new = " + transform.position + "; Movement vector: " + movementVector + "; delta time: " + Time.deltaTime + "; Actual speed: " + actualSpeed);
        }

        // ������������� ����, ���� �������� ����� ��������
        if (actualSpeed > speedWalk * 0.01)
        {
            if (!source.isPlaying)
            {
                source.Play();
            }
        }
        else
        {
            if (source.isPlaying)
            {
                source.Stop();
            }
        }

        previousPosition = transform.position;
    }
}
