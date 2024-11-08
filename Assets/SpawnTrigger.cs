using UnityEngine;

public class SpawnTrigger : MonoBehaviour
{
    private FloorSpawner floorSpawner;

    private void Start()
    {
        // ������������� ������� FloorSpawner � �����
        floorSpawner = FindObjectOfType<FloorSpawner>();

        if (floorSpawner == null)
        {
            Debug.LogError("FloorSpawner �� ������ � �����! ����������, �������� ���.");
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