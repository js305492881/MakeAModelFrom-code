using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCRIPT4 : MonoBehaviour
{
    public MeshFilter m_meshFilter;
    public Mesh m_mesh;
    public GameObject m_objA;
    public GameObject m_objB;
    public GameObject m_objC;
    public GameObject m_objD;

    // 加载脚本实例时调用 Awake
    private void Awake()
    {
        m_meshFilter = GetComponent<MeshFilter>();
        m_mesh = new Mesh();
        Vector3[] vertices = new Vector3[]
        {
            m_objA.transform.position,
            m_objB.transform.position,
            m_objC.transform.position,
            m_objA.transform.position,
            m_objC.transform.position,
            m_objD.transform.position,
        };

        int[] triangles = new int[] {
            0, 1, 2,
            3, 4, 5
        };

        Vector3[] normals = new Vector3[] {
            new Vector3(0,0,-1),
            new Vector3(0,0,-1),
            new Vector3(0,0,-1),
            new Vector3(-1,0,0),
            new Vector3(-1,0,0),
            new Vector3(-1,0,0),
        };

        Vector2[] uv = new Vector2[] {
            new Vector2(0,1),
            new Vector2(1,1),
            new Vector2(0,0),
            new Vector2(0,0),
            new Vector2(0,0),
            new Vector2(0,0),
        };

        m_mesh.vertices = vertices;//把点放到mesh中
        m_mesh.triangles = triangles;//画模型,每三个为一组,为一个面
        m_mesh.normals = normals;//法线   法线的向量和 vertices 一一对应
        m_mesh.uv = uv;

        m_meshFilter.mesh = m_mesh;
    }
}