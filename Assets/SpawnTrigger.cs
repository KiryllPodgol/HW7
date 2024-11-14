using UnityEngine;
using System.Collections;

public class SpawnTrigger : MonoBehaviour
{
    private FloorSpawner floorSpawner;

    private void Start()
    {
        Transform parentObject = transform.parent;

        if (parentObject != null)
        {
            floorSpawner = parentObject.GetComponentInChildren<FloorSpawner>();

            if (floorSpawner == null)
            {
                Debug.LogError("FloorSpawner �� ������ ����� �������� �������� ������������� �������!");
            }
        }
        else
        {
            Debug.LogError("������������ ������ �� ������!");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && floorSpawner != null)
        {
            floorSpawner.EnableSpawning();
            Debug.Log("����� �����������. ����������� �������� ����� 1 �������."); // ���������� ����������

            // ��������� �������� ��� ����������� ��������
            StartCoroutine(RemoveTriggerAfterDelay(1f));
        }
    }

    private IEnumerator RemoveTriggerAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

   
        gameObject.SetActive(false);
    }
}