using UnityEngine;

public class SCRIPT3 : MonoBehaviour
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
            m_objA.transform.position, //新增   第二个面的A点
            m_objC.transform.position, //新增   第二个面的C点
            m_objD.transform.position
        };

        int[] triangles = new int[] 
        {
            0, 1, 2,
            3, 4, 5  //修改  第二个面的序列发生了变化
        };

        Vector3[] normals = new Vector3[] //新增 法线序列 
        { 
            new Vector3(0,0,-1), //新增 第一个面A点的法线方向
            new Vector3(0,0,-1), //新增 第一个面B点的法线方向
            new Vector3(0,0,-1), //新增 第一个面C点的法线方向
            new Vector3(-1,0,0), //新增 第二个面A点的法线方向
            new Vector3(-1,0,0), //新增 第二个面C点的法线方向
            new Vector3(-1,0,0)  //新增 第二个面D点的法线方向
        };

        m_mesh.vertices = vertices;
        m_mesh.triangles = triangles;
        m_mesh.normals = normals; //新增 法线列表 放入mesh中

        m_meshFilter.mesh = m_mesh;
    }
}