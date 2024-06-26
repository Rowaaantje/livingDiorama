using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARTrackedImageManager))]
public class PlaceDiorama : MonoBehaviour
{
	private ARTrackedImageManager _trackedImagesManager;
	public GameObject[] ArPrefabs;
	private readonly Dictionary<string, GameObject> _instantiatedPrefabs = new Dictionary<string, GameObject>();

	void Awake()
	{
		_trackedImagesManager = GetComponent<ARTrackedImageManager>();
	}

	void OnEnable()
	{
		_trackedImagesManager.trackedImagesChanged += OnTrackedImagesChanged;
	}

	void OnDisable()
	{
		_trackedImagesManager.trackedImagesChanged -= OnTrackedImagesChanged;
	}

	private void OnTrackedImagesChanged(ARTrackedImagesChangedEventArgs eventArgs)
	{
		foreach (var trackedImage in eventArgs.updated)
		{
			var imageName = trackedImage.referenceImage.name;
			bool shouldInstantiateNewPrefab = false;

			foreach (var curPrefab in ArPrefabs)
			{
				if (curPrefab.name.Equals(imageName, StringComparison.OrdinalIgnoreCase))
				{
					if (!_instantiatedPrefabs.ContainsKey(imageName))
					{
						shouldInstantiateNewPrefab = true;
						var newPrefab = Instantiate(curPrefab, trackedImage.transform);
						_instantiatedPrefabs[imageName] = newPrefab;
						break; // Exit the loop once a matching prefab is instantiated
					}
					else
					{
						if (_instantiatedPrefabs[imageName].gameObject.activeSelf == false && trackedImage.trackingState == TrackingState.Tracking)
						{
							_instantiatedPrefabs[imageName].SetActive(true);
						}
					}
				}
			}

			if (shouldInstantiateNewPrefab)
			{
				// This block is redundant since the instantiation happens inside the loop above
				// var newPrefab = Instantiate(curPrefab, trackedImage.transform);
				// _instantiatedPrefabs[imageName] = newPrefab;
			}
		}

		// Update active state based on tracking
		foreach (var trackedImage in eventArgs.updated)
		{
			_instantiatedPrefabs[trackedImage.referenceImage.name].SetActive(trackedImage.trackingState == TrackingState.Tracking);
		}

		// Handle removal of tracked images
		foreach (var trackedImage in eventArgs.removed)
		{
			Destroy(_instantiatedPrefabs[trackedImage.referenceImage.name]);
			_instantiatedPrefabs.Remove(trackedImage.referenceImage.name);
		}
	}
}
