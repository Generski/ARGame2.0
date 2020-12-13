using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolcanoAnim : MonoBehaviour
{
    public float scale = 1f;
    public float speed = 1f;
    private bool recalculateNormals = false;

    private Vector3[] baseVertices;
    private Vector3[] veritces;

    private void Update()
    {
        CalcNoise();
    }

    void CalcNoise()
    {
        Mesh mesh = GetComponent<MeshFilter>().mesh;

        if (baseVertices == null)
            baseVertices = mesh.vertices;

        veritces = new Vector3[baseVertices.Length];

        float timeX = Time.time * speed + 2.5564f;
        float timeY = Time.time * speed + 1.21688f;
        float timeZ = Time.time * speed + 0.1365143f;

        for (int i = 0; i < veritces.Length; i++)
        {
            Vector3 vertex = baseVertices[i];
            vertex.x += Mathf.PerlinNoise(timeX + vertex.x, timeX + vertex.y) * scale;
            vertex.y += Mathf.PerlinNoise(timeY + vertex.x, timeY + vertex.y) * scale;
            vertex.z += Mathf.PerlinNoise(timeZ + vertex.x, timeZ + vertex.y) * scale;
            veritces[i] = vertex;
        }

        mesh.vertices = veritces;

        if (recalculateNormals)
        {
            mesh.RecalculateNormals();
            mesh.RecalculateBounds();
        }
    }
}
