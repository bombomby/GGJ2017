using UnityEngine;
using System.Collections;

/// <summary>
/// A simple procedural quad mesh, generated using the MeshBuilder class.
/// </summary>
public class WaveMeshGenerator: MonoBehaviour
{
	public EdgeCollider2D m_BakedEdgeCollider = null;
	public float m_minDepth = 50.0f;

	//Initialisation:
	private void Start()
	{
		//Create a new mesh builder:
		MeshBuilder meshBuilder = new MeshBuilder();

		for (int pointIdx = 0; pointIdx < m_BakedEdgeCollider.pointCount; ++pointIdx)
		{
			Vector2 edgePoint = m_BakedEdgeCollider.points[pointIdx];

			meshBuilder.Vertices.Add(new Vector3(edgePoint.x, m_minDepth, 0.0f));
			meshBuilder.Vertices.Add(new Vector3(edgePoint.x, edgePoint.y, 0.0f));
		}

		for (int pointIdx = 0; pointIdx < (m_BakedEdgeCollider.pointCount*2)-2; pointIdx+=2)
		{
			meshBuilder.AddTriangle(pointIdx, pointIdx + 1, pointIdx + 3);
			meshBuilder.AddTriangle(pointIdx, pointIdx + 3, pointIdx + 2);
		}

		//Create the mesh:
		Mesh mesh = meshBuilder.CreateMesh();

		//Look for a MeshFilter component attached to this GameObject:
		MeshFilter filter = GetComponent<MeshFilter>();

		//If the MeshFilter exists, attach the new mesh to it.
		//Assuming the GameObject also has a renderer attached, our new mesh will now be visible in the scene.
		if (filter != null)
		{
			filter.sharedMesh = mesh;
		}
	}
}