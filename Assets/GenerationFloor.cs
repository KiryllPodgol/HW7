using UnityEngine;

public class FloorSpawner : MonoBehaviour
{
    public Transform FloorPrefab; // ������ ������� ��� ������
    private bool canSpawn = false; // ���� ��� ��������� ������
    public GameObject spawnPoint; // ����� ������ � �������� ���������
    private static int floorCounter = 1; 

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
        GameObject newFloor = Instantiate(FloorPrefab, spawnPoint.transform.position, spawnPoint.transform.rotation).gameObject;

        // ������ ��� ������ ������� �� ������ �������� �������� floorCounter
        newFloor.name = "���� " + floorCounter;

        // ����������� ������� ������ ��� ���������� ������
        floorCounter++;
    }
}
