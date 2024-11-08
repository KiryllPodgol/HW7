using UnityEngine;

public class FloorSpawner : MonoBehaviour
{
    public Transform FloorPrefab; // Префаб объекта для спавна
    private float rotationAngle = 90f; // Угол поворота для каждого нового объекта
    public Transform spawnPoint; // Объект, определяющий начальную точку спавна
    private bool canSpawn = false; // Флаг для активации спавна

    void Update()
    {
        // Проверяем флаг и спавним пол
        if (canSpawn)
        {
            SpawnFloor();
            canSpawn = false; // Сбрасываем флаг, чтобы спавн был однократным
        }
    }

    public void EnableSpawning()
    {
        canSpawn = true; // Устанавливаем флаг, когда игрок пересекает триггер
    }

    private void SpawnFloor()
    {
        // Проверка, установлен ли префаб
        if (FloorPrefab == null)
        {
            Debug.LogWarning("Префаб FloorPrefab не установлен!");
            return;
        }

        // Создаем пол в позиции spawnPoint с нужным поворотом
        Instantiate(
            FloorPrefab,
            spawnPoint.position,
            Quaternion.Euler(0, rotationAngle, 0)
        );

        // Увеличиваем угол поворота на 90 градусов для следующего объекта
        rotationAngle += 90f;

        // Сбрасываем угол после полного оборота
        if (rotationAngle >= 360f)
        {
            rotationAngle = 0f;
        }
    }
}
