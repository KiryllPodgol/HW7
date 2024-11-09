using UnityEngine;

public class FloorSpawner : MonoBehaviour
{
    public Transform FloorPrefab; // ������ ������� ��� ������
    private bool canSpawn = false; // ���� ��� ��������� ������
    public GameObject spawnPoint; // ����� ������ � �������� ���������

    void Update()
    {
        // ��������� ���� � ������� ���
        if (canSpawn)
        {
            SpawnFloor();
            canSpawn = false; // ���������� ����, ����� ����� ��� �����������
        }
    }

    public void EnableSpawning()
    {
        canSpawn = true; // ������������� ����, ����� ����� ���������� �������
    }

    private void SpawnFloor()
    {
        // ������� ��� � ������� � � ��������� ����� ������
        Instantiate(FloorPrefab, spawnPoint.transform.position, spawnPoint.transform.rotation);
    }
}
