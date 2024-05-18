using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

namespace Azirel
{
	public class PortalTraversalController : MonoBehaviour
	{
		[SerializeField] private LayerMask collidersMask;
		[SerializeField] private UnityEvent OnTraversed;

		private HashSet<Collider> inMomentTrack = new();
		private List<Collider> traversalTrack = new();

		public void OnTriggerEnter(Collider other)
		{
			if (((1 << other.gameObject.layer) & collidersMask.value) != 0)
			{
				traversalTrack.Add(other);
				inMomentTrack.Add(other);
			}
		}

		public void OnTriggerExit(Collider other)
		{
			if (((1 << other.gameObject.layer) & collidersMask.value) != 0)
			{
				traversalTrack.Add(other);
				inMomentTrack.Remove(other);
				if (!inMomentTrack.Any())
				{
					if (traversalTrack.First() != traversalTrack.Last())
						OnTraversed?.Invoke();
					traversalTrack.Clear();
				}
			}
		}
	}
}
