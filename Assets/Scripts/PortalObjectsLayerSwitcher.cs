using System.Collections.Generic;
using UnityEngine;

namespace Azirel
{
	public class PortalObjectsLayerSwitcher : MonoBehaviour
	{
		public LayerMask LayerMask;
		public List<GameObject> insidePortalObjects = new List<GameObject>();
		public int layerWhenInside;
		public int layerWhenOutside;

		private bool isInPortal = false;

		[ContextMenu(nameof(ToggleSceneState))]
		public void ToggleSceneState()
		{
			isInPortal = !isInPortal;
			ChangeInsidePortalObjectsLayer(isInPortal);
		}

		public void ChangeInsidePortalObjectsLayer(bool isInPortal)
		{
			foreach (var portalObject in insidePortalObjects)
			{
				portalObject.layer = isInPortal ? layerWhenInside : layerWhenOutside;
			}
		}
	}
}
