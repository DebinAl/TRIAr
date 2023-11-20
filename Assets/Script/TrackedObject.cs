using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARTrackedImageManager))]
public class TrackedObject : MonoBehaviour
{
    //reference for the image manager
    private ARTrackedImageManager _trackedImageManager;

    //instantiate the image as an gameobject array
    public GameObject[] ArPrefabs;

    // dictionary of the prefabs array
    private readonly Dictionary<string, GameObject> _instantiadedPrefabs = new();

    private void Awake()
    {
        _trackedImageManager = GetComponent<ARTrackedImageManager>();
    }

    private void OnEnable()
    {//attach event handler
        _trackedImageManager.trackedImagesChanged += OnTrackedImagesChanged;
    }

    private void OnDisable()
    {//detach event handler
        _trackedImageManager.trackedImagesChanged -= OnTrackedImagesChanged;
    }

    //event handler
    private void OnTrackedImagesChanged(ARTrackedImagesChangedEventArgs eventArgs)
    { //loop through all images
        foreach (var trackedImage in eventArgs.added)
        {//get the name of the image
            var imageName = trackedImage.referenceImage.name;
            foreach (var curPrefab in ArPrefabs)
            {//add the tracked image to the prefabs list
                if (string.Compare(curPrefab.name, imageName, StringComparison.OrdinalIgnoreCase) == 0
                    && !_instantiadedPrefabs.ContainsKey(imageName))
                {
                    var newPrefab = Instantiate(curPrefab, trackedImage.transform);
                    _instantiadedPrefabs[imageName] = newPrefab;
                }
            }
        }

        foreach (var trackedImage in eventArgs.updated)
        {
            _instantiadedPrefabs[trackedImage.referenceImage.name]
                .SetActive(trackedImage.trackingState == TrackingState.Tracking);
        }

        foreach (var trackedImage in eventArgs.removed)
        {
            Destroy(_instantiadedPrefabs[trackedImage.referenceImage.name]);
            _instantiadedPrefabs.Remove(trackedImage.referenceImage.name);
        }
    }
}
