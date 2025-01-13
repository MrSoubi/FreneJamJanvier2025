using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SpawnManager : MonoBehaviour
{
    [Header("Spawn Settings")]
    public GameObject objectToSpawn; // Le prefab à spawner
    public int maxSpawnCount = 10; // Nombre maximal de GameObjects instanciés
    public float spawnDelay = 1f; // Délai entre chaque spawn

    private int currentSpawnCount = 0;
    private bool canSpawn = false; // État du spawn
    private Coroutine spawnCoroutine;

    private void Start()
    {
        // Désactiver les spawns au début
        canSpawn = false;
    }

    // Called from its child TriggerZone(Activation)
    public void ActivateSpawn()
    {
        canSpawn = true;
        if (spawnCoroutine == null)
        {
            spawnCoroutine = StartCoroutine(SpawnObjects());
        }
    }

    // Called from its child TriggerZone(Deactivation)
    public void DeactivateSpawn()
    {
        canSpawn = false;
        if (spawnCoroutine != null)
        {
            StopCoroutine(spawnCoroutine);
            spawnCoroutine = null;
        }
    }

    private IEnumerator SpawnObjects()
    {
        while (canSpawn)
        {
            if (currentSpawnCount < maxSpawnCount)
            {
                GameObject spawnedObject = Instantiate(objectToSpawn, transform.position, Quaternion.identity);
                spawnedObject.AddComponent<SpawnedObjectTracker>().OnObjectDestroyed = HandleObjectDestroyed;
                currentSpawnCount++;
            }
            yield return new WaitForSeconds(spawnDelay);
        }

        // Arrête la coroutine si canSpawn est désactivé
        spawnCoroutine = null;
    }

    private void HandleObjectDestroyed()
    {
        currentSpawnCount--;
        if (canSpawn && spawnCoroutine == null)
        {
            spawnCoroutine = StartCoroutine(SpawnObjects());
        }
    }
}