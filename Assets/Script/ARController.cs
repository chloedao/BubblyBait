/*using UnityEngine;
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
*/


using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ARController : MonoBehaviour
{
    public DrivingSurfaceManager drivingSurfaceManager; // H�mtar ytan
    public GameObject waterPrefab; // Prefab f�r vatten
    private GameObject waterInstance;
    private Transform mainPlane;

    void Start()
    {
        if (drivingSurfaceManager == null)
        {
            Debug.LogError("DrivingSurfaceManager �r inte tilldelad i ARController!");
            return;
        }
    }

    void Update()
    {
        // H�mta den "Locked Plane" som DrivingSurfaceManager anv�nder
        if (drivingSurfaceManager.LockedPlane != null)
        {
            Transform lockedTransform = drivingSurfaceManager.LockedPlane.transform;

            if (waterInstance == null)
            {
                // Skapa vatten vid den l�sta ytan
                mainPlane = lockedTransform;
                waterInstance = Instantiate(waterPrefab, mainPlane.position, Quaternion.identity);
                waterInstance.transform.SetParent(mainPlane);

                Debug.Log("Vatten skapat och kopplat till huvudytan.");
            }
            else
            {
                // Uppdatera vattnets position och storlek om AR-yta f�r�ndras
                waterInstance.transform.position = mainPlane.position;
                AdjustWaterSize();
            }
        }
        else
        {
            Debug.Log("Ingen l�st yta hittades, vattnet kommer inte att skapas �n.");
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
