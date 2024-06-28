using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
	public static WaveManager instance;

	// Wave parameters
	public float amplitude = 1f;
	public float wavelength = 20f;
	public float speed = 1f;
	public Vector3 direction = new Vector3(1, 0, 0); // Direction of the wave
	public float steepness = 1f; // Steepness of the wave

	private void Awake()
	{
		if (instance == null)
		{
			instance = this;
		}
		else if (instance != this)
		{
			Debug.Log("Instance already exists, destroying object!");
			Destroy(this);
		}
	}

	private void Update()
	{
		// No changes needed here, just ensure the instance management is correct.
	}

	// Method to calculate wave height using the Gerstner wave formula
	public float CalculateWaveHeight(Vector3 position)
	{
		float steepness = this.steepness;
		float wavelength = this.wavelength;
		float directionX = this.direction.x;
		float directionZ = this.direction.z;
		float speed = this.speed;

		float k = 2 * Mathf.PI / wavelength;
		float c = Mathf.Sqrt(9.81f / k); // Gravity constant
		Vector3 d = new Vector3(directionX, 0, directionZ).normalized;

		// Define offset within the method
		float offset = Time.time * speed;

		// Perform the dot product between the direction vector and the position vector
		float dotProduct = Vector3.Dot(d, position);

		// Extract the x and z components from the dot product result for the sine function
		float f = k * (dotProduct - c * offset);

		return steepness * Mathf.Sin(f);
	}
}
