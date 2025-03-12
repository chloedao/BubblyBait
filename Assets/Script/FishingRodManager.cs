using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class FishingRodManager : MonoBehaviour
{
    public ARTrackedImageManager imageManager;
    public GameObject fishingRodPrefab;
    public float trackingThreshold = 0.1f; // Allowable wiggle room for tracking

    private GameObject fishingRodInstance;
    private Dictionary<string, Transform> trackedMarkers = new Dictionary<string, Transform>();

    private void Update()
    {
        foreach (var trackedImage in imageManager.trackables)
        {
            if (trackedImage.trackingState == TrackingState.Tracking)
            {
                if (!trackedMarkers.ContainsKey(trackedImage.referenceImage.name))
                {
                    trackedMarkers[trackedImage.referenceImage.name] = trackedImage.transform;
                    Debug.Log($"Tracked new marker: {trackedImage.referenceImage.name}");
                }
            }
            else
            {
                Debug.Log($"Marker {trackedImage.referenceImage.name} is not tracking.");
            }
        }

        if (trackedMarkers.Count >= 1) // Ensure at least one marker is detected
        {
            Debug.Log("Updating fishing rod transform.");
            UpdateFishingRodTransform();
        }
        else
        {
            Debug.Log("Not enough markers to update fishing rod transform.");
        }
    }

    private void UpdateFishingRodTransform()
    {
        List<Transform> markers = new List<Transform>(trackedMarkers.Values);

        if (markers.Count >= 1)
        {
            Vector3 position = markers[0].position;
            Quaternion rotation = markers[0].rotation;

            // Check if the position is within the tracking threshold
            if (fishingRodInstance == null)
            {
                fishingRodInstance = Instantiate(fishingRodPrefab, position, rotation);
                Debug.Log("Fishing rod instance created.");
            }
            else
            {
                Vector3 currentPosition = fishingRodInstance.transform.position;
                if (Vector3.Distance(currentPosition, position) <= trackingThreshold)
                {
                    fishingRodInstance.transform.position = position;
                    fishingRodInstance.transform.rotation = rotation;
                    Debug.Log("Fishing rod instance updated.");
                }
                else
                {
                    Debug.Log("Position change exceeds tracking threshold.");
                }
            }
        }
        else
        {
            Debug.Log("Not enough markers to update fishing rod transform.");
        }
    }
}

