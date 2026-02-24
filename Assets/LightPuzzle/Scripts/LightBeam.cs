using System.Collections.Generic;
using System.Linq;
using LightPuzzle.Tiles;
using UnityEngine;

namespace LightPuzzle
{
	[RequireComponent(typeof(LineRenderer))]
	public class LightBeam : MonoBehaviour
	{
		[SerializeField] private new LineRenderer renderer;
		[SerializeField] private float maxBeamDistance = 10f;
		[SerializeField] private ContactFilter2D filter;

		public void Emit(Vector3 start, Vector3 direction, GameObject emittingObject)
		{
			List<Vector3> points = EmitRecurse(start, direction, this.maxBeamDistance, this.filter, emittingObject);

			points.Insert(0, start);
			this.renderer.positionCount = points.Count;
			this.renderer.SetPositions(points.ToArray());
		}

		private static List<Vector3> EmitRecurse(Vector3 start, Vector3 direction, float maxDistance,
			ContactFilter2D mask, GameObject emittingObject)
		{
			List<Vector3> points = new();
			List<RaycastHit2D> hits = new();

			if (!(Physics2D.Raycast(start, direction, mask, hits, maxDistance) > 0 &&
			      hits.Count(h => h.transform.gameObject != emittingObject) > 0))
			{
				return points;
			}

			RaycastHit2D hit = hits.First(h => h.transform.gameObject != emittingObject);
			points.Add(hit.transform.position);
			
			Tile tile = hit.transform.GetComponentInParent<Tile>();
			if (tile == null || !tile.IsBeamModifier())
			{
				return points;
			}
			
			points.AddRange(
				EmitRecurse(
					hit.transform.position,
					Vector2.Reflect(direction, hit.normal),
					maxDistance,
					mask,
					hit.transform.gameObject
				)
			);

			return points;
		}
	}
}