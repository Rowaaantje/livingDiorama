using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]

public class WaterManager : MonoBehaviour
{
    private MeshFilter meshFilter;

	private void Awake()
	{
		meshFilter = GetComponent<MeshFilter>();
	}

	private void Update()
	{
		Vector3[] vertices = meshFilter.mesh.vertices;
		for (int i = 0; i < vertices.Length; i++)
		{
			// Calculate wave height using Gerstner wave formula
			float waveHeight = WaveManager.instance.CalculateWaveHeight(vertices[i]);
			vertices[i].y = waveHeight;
		}

		meshFilter.mesh.vertices = vertices;
		meshFilter.mesh.RecalculateNormals();
	}

}
