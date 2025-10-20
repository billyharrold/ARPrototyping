using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ImageTracker : MonoBehaviour
{

    [SerializeField] private ARTrackedImageManager trackedImageManager;
    //public GameObject[] ArPrefabs;

    [SerializeField] private List<GameObject> ARObjects;

    private readonly Dictionary<string, GameObject> spawnedObjects = new();

    private void OnEnable()
    {
        
        trackedImageManager.trackablesChanged.AddListener(OnTrackedImagesChanged);
    }

    private void OnDisable()
    {
        trackedImageManager.trackablesChanged.RemoveListener(OnTrackedImagesChanged);
    }

    private void Start()
    {
        
        foreach (var prefab in ARObjects)
        {
            GameObject newObject = Instantiate(prefab, Vector3.zero, Quaternion.identity);
            newObject.name = prefab.name;
            newObject.SetActive(false);
            spawnedObjects.Add(prefab.name, newObject);
        }
    }

    private void OnTrackedImagesChanged(ARTrackablesChangedEventArgs<ARTrackedImage> eventArgs)
    {
        // Handle added tracked images
        foreach (var trackedImage in eventArgs.added)
            UpdateTracking(trackedImage);

        // Handle updated tracked images (e.g., moved or re-tracked)
        foreach (var trackedImage in eventArgs.updated)
            UpdateTracking(trackedImage);

        // Handle removed tracked images
        foreach (var trackedImagePair in eventArgs.removed)
        {
            ARTrackedImage trackedImage = trackedImagePair.Value;
            string imageName = trackedImage.referenceImage.name;
            if (spawnedObjects.TryGetValue(imageName, out var obj))
                obj.SetActive(false);
        }
    }

    private void UpdateTracking(ARTrackedImage trackedImage)
    {
        string imageName = trackedImage.referenceImage.name;

        if (!spawnedObjects.TryGetValue(imageName, out var obj))
            return;

        if (trackedImage.trackingState == TrackingState.Tracking)
        {
            obj.SetActive(true);
            obj.transform.SetPositionAndRotation(
                trackedImage.transform.position,
                trackedImage.transform.rotation
            );
        }
        else
        {
            obj.SetActive(false);
        }
    }

}
