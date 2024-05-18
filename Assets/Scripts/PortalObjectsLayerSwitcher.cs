using System.Collections.Generic;
using UnityEngine;

namespace Azirel
{
	public class PortalObjectsLayerSwitcher : MonoBehaviour
	{
		[SerializeField] private List<GameObject> insidePortalObjects = new List<GameObject>();
		[SerializeField] private int layerWhenInside;
		[SerializeField] private int layerWhenOutside;

		private bool isInPortal = false;

		private void ToggleSceneState()
		{
			isInPortal = !isInPortal;
			ChangeInsidePortalObjectsLayer(isInPortal);
		}

		private void ChangeInsidePortalObjectsLayer(bool isInPortal)
		{
			foreach (var portalObject in insidePortalObjects)
			{
				portalObject.layer = isInPortal ? layerWhenInside : layerWhenOutside;
			}
		}
	}
}
