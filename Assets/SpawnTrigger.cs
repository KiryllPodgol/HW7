using UnityEngine;

public class SpawnTrigger : MonoBehaviour
{
    private FloorSpawner floorSpawner;

    private void Start()
    {
        // Автоматически находим FloorSpawner в сцене
        floorSpawner = FindObjectOfType<FloorSpawner>();

        if (floorSpawner == null)
        {
            Debug.LogError("FloorSpawner не найден в сцене! Пожалуйста, добавьте его.");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && floorSpawner != null)
        {
            floorSpawner.EnableSpawning();
        }
    }
}