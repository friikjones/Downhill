using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class SegmentGen : MonoBehaviour
{
    //Path Gen
    public float sizeZ, sizeX, offX, offY;
    public float angleY, angleX;
    public GameObject startPoint, endPoint;

    //Mesh Gen
    Mesh mesh;
    Vector3[] vertices;
    int[] trianglesRoad, trianglesHill;

    void Start()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;

        SelfOrientate();
        CreateShape();
        UpdateMesh();
        UpdateCollider();
    }

    public GameObject CreateAnchor()
    {
        float diffY = (Mathf.Tan(angleX * 0.0174533f) * sizeZ);
        endPoint = new GameObject("endPoint");
        endPoint.transform.parent = this.transform;
        endPoint.transform.localPosition = new Vector3(0, diffY, sizeZ);
        endPoint.transform.Rotate(Vector3.up * angleY);
        return endPoint;
    }

    void SelfOrientate()
    {
        this.transform.position = startPoint.transform.position;
        this.transform.rotation = startPoint.transform.rotation;
    }

    void CreateShape()
    {
        float diffZ = (Mathf.Tan(angleY * 0.0174533f) * sizeX / 2);
        float diffOffZ = (Mathf.Tan(angleY * 0.0174533f) * (sizeX / 2 + offX));
        float diffY = (Mathf.Tan(angleX * 0.0174533f) * sizeZ);
        //local coordinates
        vertices = new Vector3[]{
            new Vector3 (-sizeX/2,0,0),
            new Vector3 (-sizeX/2,diffY,sizeZ+diffZ),
            new Vector3 (sizeX/2,0,0),
            new Vector3 (sizeX/2,diffY,sizeZ-diffZ),
            new Vector3 (-(sizeX/2)-offX,-offY,0),
            new Vector3 (-(sizeX/2)-offX,-offY+diffY,sizeZ+diffOffZ),
            new Vector3 ((sizeX/2)+offX,-offY,0),
            new Vector3 ((sizeX/2)+offX,-offY+diffY,sizeZ-diffOffZ),
        };

        trianglesRoad = new int[]{
            0,1,2,
            1,3,2
        };

        trianglesHill = new int[]{
            0,4,1,
            4,5,1,
            2,3,6,
            6,3,7
        };
    }

    void UpdateMesh()
    {
        mesh.Clear();

        mesh.subMeshCount = 2;
        mesh.vertices = vertices;
        // mesh.triangles = triangles;
        mesh.SetTriangles(trianglesRoad, 0);
        mesh.SetTriangles(trianglesHill, 1);

        mesh.RecalculateNormals();
    }

    void UpdateCollider()
    {
        transform.GetComponent<MeshCollider>().sharedMesh = mesh;
    }


}
