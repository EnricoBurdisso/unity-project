using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidProc : MonoBehaviour
{

     Vector3[] newVertices;
     Vector2[] newUV;
     int[] newTriangles;

     [SerializeField] int offset;

    void Start()
     {

       //noise = new Perlin();
       Mesh mesh = GetComponent<MeshFilter>().mesh;
       Vector3[] vertices = mesh.vertices;

       var i=0;

       while (i < vertices.Length) {
         var pos =vertices[i].normalized * 100;

        int smoothing = Random.Range(2, 35);

         var noise = Mathf.PerlinNoise((float) i / smoothing, (float)i / offset);


         //vertices[i] = vertices[i].normalized * (50 + noise.GetValue(pos.x, pos.y, pos.z));
         vertices[i] = vertices[i].normalized * (50 + noise);

         i++;
       }
       mesh.vertices = vertices;
       mesh.RecalculateNormals();
       mesh.RecalculateBounds();


     }

     void Update()
         {

         }
}
