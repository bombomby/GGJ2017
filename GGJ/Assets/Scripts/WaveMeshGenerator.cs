using UnityEngine;
using System.Collections;

/// <summary>
/// A simple procedural quad mesh, generated using the MeshBuilder class.
/// </summary>
public class WaveMeshGenerator: MonoBehaviour
{
	public WaveGenerator m_waveGenerator;
	public float m_minDepth = -50.0f;

    public Vector2 UVScale = new Vector2(1, 1);

	//Initialisation:
	private void Update()
	{
		//Create a new mesh builder:
		MeshBuilder meshBuilder = new MeshBuilder();

		for (int pointIdx = 0; pointIdx < m_waveGenerator.Points.Count; ++pointIdx)
		{
			Vector2 edgePoint = m_waveGenerator.Points[pointIdx];

			meshBuilder.Vertices.Add(new Vector3(edgePoint.x, m_minDepth, 0.0f));
			meshBuilder.Vertices.Add(new Vector3(edgePoint.x, edgePoint.y, 0.0f));

			meshBuilder.UVs.Add(new Vector2(pointIdx * UVScale.x, 0.0f));
            meshBuilder.UVs.Add(new Vector2(pointIdx * UVScale.x, /*(edgePoint.y - m_minDepth)*/ 1.0f * UVScale.y));

            meshBuilder.Normals.Add(Vector3.back);
            meshBuilder.Normals.Add(Vector3.back);
        }

		for (int pointIdx = 0; pointIdx < (m_waveGenerator.Points.Count*2)-2; pointIdx+=2)
		{
			meshBuilder.AddTriangle(pointIdx, pointIdx + 3, pointIdx + 1);
			meshBuilder.AddTriangle(pointIdx, pointIdx + 2, pointIdx + 3);
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
