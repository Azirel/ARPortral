using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

namespace Azirel
{
	[RequireComponent(typeof(ARRaycastManager))]
	public class PlaceOnPlane : MonoBehaviour
	{
		[SerializeField] private GameObject portalGO;
		private ARRaycastManager raycastManager;
		private List<ARRaycastHit> hits = new();

		protected void Awake() => raycastManager = GetComponent<ARRaycastManager>();

		private bool TryGetTouchPosition(out Vector2 touchPosition)
		{
			if (Input.touchCount > 0)
			{
				touchPosition = Input.GetTouch(0).position;
				return true;
			}

			touchPosition = default;
			return false;
		}

		private void Update()
		{
			if (!TryGetTouchPosition(out var touchPosition))
				return;

			if (raycastManager.Raycast(touchPosition, hits, TrackableType.PlaneWithinPolygon))
			{
				var hitPose = hits[0].pose;
				portalGO.SetActive(true);
				portalGO.transform.SetPositionAndRotation(hitPose.position, hitPose.rotation);
			}
		}
	}
}