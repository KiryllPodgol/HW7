using UnityEngine;

public class FloorSpawner : MonoBehaviour
{
    public Transform FloorPrefab; // Префаб объекта для спавна
    private bool canSpawn = false; // Флаг для активации спавна
    public GameObject spawnPoint; // Точка спавна с заданным поворотом
    private static int floorCounter = 1; 

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
        GameObject newFloor = Instantiate(FloorPrefab, spawnPoint.transform.position, spawnPoint.transform.rotation).gameObject;

        // Задаем имя новому объекту на основе текущего значения floorCounter
        newFloor.name = "Этаж " + floorCounter;

        // Увеличиваем счётчик этажей для следующего спавна
        floorCounter++;
    }
}
