using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARRaycastManager))]
public class PlaceOnPlane : MonoBehaviour
{
	[SerializeField]
	[Tooltip("Instantiates this prefab on a plane at the touch location.")]
	private GameObject portalGO;
	private ARRaycastManager raycastManager;
	private List<ARRaycastHit> hits = new();

	protected void Awake() => raycastManager = GetComponent<ARRaycastManager>();

	protected bool TryGetTouchPosition(out Vector2 touchPosition)
	{
		if (Input.touchCount > 0)
		{
			touchPosition = Input.GetTouch(0).position;
			return true;
		}

		touchPosition = default;
		return false;
	}

	protected void Update()
	{
		if (!TryGetTouchPosition(out var touchPosition))
			return;

		if (raycastManager.Raycast(touchPosition, hits, TrackableType.PlaneWithinPolygon))
		{
			Debug.Log("Touch screen");
			var hitPose = hits[0].pose;
			portalGO.SetActive(true);
			portalGO.transform.SetPositionAndRotation(hitPose.position, hitPose.rotation);
		}
	}
}
