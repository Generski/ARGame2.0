using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerlinNoiseLava : MonoBehaviour
{
    public float scale;
    public float waveSpeed;
    public float waveHeight;

    // Size of the plane
    public int xSize = 10;
    public int zSize = 10;

    private void Update()
    {
        CreateShape();
        CalcNoise();
    }

    void CreateShape()
    {
        MeshFilter mf = GetComponent<MeshFilter>();
        Mesh mesh = new Mesh();
        mf.mesh = mesh;

        // Defining the vertices array
        Vector3[] vertices = new Vector3[(xSize + 1) * (zSize + 1)];

        // Generating the vertices using a forloop
        int i = 0;
        for(int z = 0; z <= zSize; z++)
        {
            for (int x = 0; x <= xSize; x++)
            {
                vertices[i] = new Vector3(x - xSize/2, 0, z - zSize/2);
                i++;
            }
        }

        // Defining triangles array
        int[] triangles = new int[xSize * zSize * 6];

        // Ints to store the current row and column
        int vert = 0;
        int tris = 0;

        // Generating the triangles and incrementing on the rows where they are generated
        for (int z = 0; z < zSize; z++)
        {
            for (int x = 0; x < xSize; x++)
            {
                // tris increments the rows
                // verts increments the columns
                triangles[0 + tris] = vert + 0;
                triangles[1 + tris] = vert + xSize + 1;
                triangles[2 + tris] = vert + 1;

                triangles[3 + tris] = vert + 1;
                triangles[4 + tris] = vert + xSize + 1;
                triangles[5 + tris] = vert + xSize + 2;

                vert++;

                // tris increased by 6 because one square is made out of 2 triangles using 6 vertices
                tris += 6;
            }

            // Go up to the next row
            vert++;
        }

        mesh.vertices = vertices;
        mesh.triangles = triangles;
    }

    void CalcNoise()
    {
        MeshFilter mF = GetComponent<MeshFilter>();

        Vector3[] verts = mF.mesh.vertices;

        for (int i = 0; i < verts.Length; i++)
        {
            float pX = (verts[i].x * scale) + (Time.time * waveSpeed);
            float pZ = (verts[i].z * scale) + (Time.time * waveSpeed);

            verts[i].y = Mathf.PerlinNoise(pX, pZ) * waveHeight;
        }

        mF.mesh.vertices = verts;

        mF.mesh.RecalculateNormals();

        mF.mesh.RecalculateBounds();
    }
}
