/*using UnityEngine;
using UnityEngine.XR.ARFoundation;
using System.Collections.Generic;

public class ARController : MonoBehaviour
{
    public ARPlaneManager arPlaneManager;
    public GameObject fishPrefab; // Dra in din fisk-prefab här
    public float fishSpawnDepth = 0.3f; // Avstånd under vattenytan
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
        foreach (ARPlane plane in args.added) // När en ny yta upptäcks
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
            fish.transform.SetParent(plane.transform); // Fäst på ARPlanet
        }
    }
}
*/


using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ARController : MonoBehaviour
{
    public DrivingSurfaceManager drivingSurfaceManager; // Hämtar ytan
    public GameObject waterPrefab; // Prefab för vatten
    private GameObject waterInstance;
    private Transform mainPlane;

    void Start()
    {
        if (drivingSurfaceManager == null)
        {
            Debug.LogError("DrivingSurfaceManager är inte tilldelad i ARController!");
            return;
        }
    }

    void Update()
    {
        // Hämta den "Locked Plane" som DrivingSurfaceManager använder
        if (drivingSurfaceManager.LockedPlane != null)
        {
            Transform lockedTransform = drivingSurfaceManager.LockedPlane.transform;

            if (waterInstance == null)
            {
                // Skapa vatten vid den låsta ytan
                mainPlane = lockedTransform;
                waterInstance = Instantiate(waterPrefab, mainPlane.position, Quaternion.identity);
                waterInstance.transform.SetParent(mainPlane);

                Debug.Log("Vatten skapat och kopplat till huvudytan.");
            }
            else
            {
                // Uppdatera vattnets position och storlek om AR-yta förändras
                waterInstance.transform.position = mainPlane.position;
                AdjustWaterSize();
            }
        }
        else
        {
            Debug.Log("Ingen låst yta hittades, vattnet kommer inte att skapas än.");
        }
    }

    void AdjustWaterSize()
    {
        if (drivingSurfaceManager.LockedPlane != null && waterInstance != null)
        {
            ARPlane plane = drivingSurfaceManager.LockedPlane.GetComponent<ARPlane>();
            if (plane != null)
            {
                // Justera vattnets storlek till AR-ytans storlek
                waterInstance.transform.localScale = new Vector3(plane.size.x, 1, plane.size.y);
                Debug.Log($"Vatten uppdaterat till storlek: {plane.size.x} x {plane.size.y}");
            }
        }
    }
}
