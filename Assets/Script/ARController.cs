using UnityEngine;
using UnityEngine.XR.ARFoundation;
using System.Collections.Generic;

public class ARController : MonoBehaviour
{
    public ARPlaneManager arPlaneManager;
    public GameObject fishPrefab; // Dra in din fisk-prefab h�r
    public float fishSpawnDepth = 0.3f; // Avst�nd under vattenytan
    public int fishCount = 5; // Antal fiskar per yta

    void OnEnable()
    {
        arPlaneManager.planesChanged += OnPlanesChanged;
    }

    void OnDisable()
    {
        arPlaneManager.planesChanged -= OnPlanesChanged;
    }

    void OnPlanesChanged(ARPlanesChangedEventArgs args)
    {
        foreach (ARPlane plane in args.added) // N�r en ny yta uppt�cks
        {
            SpawnFishUnderPlane(plane);
        }
    }

    void SpawnFishUnderPlane(ARPlane plane)
    {
        for (int i = 0; i < fishCount; i++)
        {
            Vector3 spawnPosition = plane.center;
            spawnPosition.y -= fishSpawnDepth; // Placera under ytan

            GameObject fish = Instantiate(fishPrefab, spawnPosition, Quaternion.identity);
            fish.transform.SetParent(plane.transform); // F�st p� ARPlanet
            
        }
    }
}



