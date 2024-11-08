using UnityEngine;

public class FloorSpawner : MonoBehaviour
{
    public Transform FloorPrefab; // ������ ������� ��� ������
    private float rotationAngle = 90f; // ���� �������� ��� ������� ������ �������
    public Transform spawnPoint; // ������, ������������ ��������� ����� ������
    private bool canSpawn = false; // ���� ��� ��������� ������

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
        // ��������, ���������� �� ������
        if (FloorPrefab == null)
        {
            Debug.LogWarning("������ FloorPrefab �� ����������!");
            return;
        }

        // ������� ��� � ������� spawnPoint � ������ ���������
        Instantiate(
            FloorPrefab,
            spawnPoint.position,
            Quaternion.Euler(0, rotationAngle, 0)
        );

        // ����������� ���� �������� �� 90 �������� ��� ���������� �������
        rotationAngle += 90f;

        // ���������� ���� ����� ������� �������
        if (rotationAngle >= 360f)
        {
            rotationAngle = 0f;
        }
    }
}
