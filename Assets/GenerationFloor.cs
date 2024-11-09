using UnityEngine;

public class FloorSpawner : MonoBehaviour
{
    public Transform FloorPrefab; // Префаб объекта для спавна
    private bool canSpawn = false; // Флаг для активации спавна
    public GameObject spawnPoint; // Точка спавна с заданным поворотом

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
        // Создаем пол в позиции и с поворотом точки спавна
        Instantiate(FloorPrefab, spawnPoint.transform.position, spawnPoint.transform.rotation);
    }
}
