using UnityEngine;

public class SCRIPT2 : MonoBehaviour
{
    public MeshFilter m_meshFilter;
    public Mesh m_mesh;
    public GameObject m_objA;
    public GameObject m_objB;
    public GameObject m_objC;
    public GameObject m_objD; //新增 D点

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
            m_objD.transform.position //新增 D点坐标加入到 顶点序列 中
        };

        int[] triangles = new int[] 
        {
            0, 1, 2, //第一个三角面 A->B->C->A
            0, 2, 3  //第二个三角面A->C->D->A
        };
        
        m_mesh.vertices = vertices;
        m_mesh.triangles = triangles;

        m_meshFilter.mesh = m_mesh;
    }
}