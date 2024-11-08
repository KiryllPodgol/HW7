using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController characterController;
    public Transform cameraTransform; 
    public float speedWalk = 6.0f;
    public float gravity = -9.81f;
    private Vector3 velocity;

    void Start()
    {
        characterController = GetComponent<CharacterController>();

        
        if (cameraTransform == null)
        {
            cameraTransform = Camera.main.transform;
        }
    }

    void Update()
    {
        // Получаем ввод от пользователя
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        // Определяем направление движения относительно ориентации камеры
        Vector3 moveDirection = cameraTransform.right * x + cameraTransform.forward * z;
        moveDirection.y = 0; // Обнуляем влияние вертикальной оси
        moveDirection.Normalize(); // Нормализуем направление, чтобы исключить ускорение по диагонали

        // Двигаем персонажа
        characterController.Move(moveDirection * speedWalk * Time.deltaTime);

        // Применяем гравитацию
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
