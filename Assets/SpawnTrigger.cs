using UnityEngine;

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
                Debug.LogError("FloorSpawner не найден среди дочерних объектов родительского объекта!");
            }
        }
        else
        {
            Debug.LogError("Родительский объект не найден!");
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
