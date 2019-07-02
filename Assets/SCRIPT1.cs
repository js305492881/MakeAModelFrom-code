using UnityEngine;

public class SCRIPT1 : MonoBehaviour
{
    public MeshFilter m_meshFilter; //meshfilter组件
    public Mesh m_mesh;
    public GameObject m_objA; //A点
    public GameObject m_objB; //B点
    public GameObject m_objC; //C点

    // 加载脚本实例时调用 Awake
    private void Awake()
    {
        m_meshFilter = GetComponent<MeshFilter>(); //得到meshfilter组件
        m_mesh = new Mesh(); //new 一个mesh

        Vector3[] vertices = new Vector3[] //顶点列表的变量
        {
            m_objA.transform.position, //加入A点坐标
            m_objB.transform.position, //加入B点坐标
            m_objC.transform.position  //加入C点坐标
        };

        int[] triangles = new int[] { 0, 1, 2 }; //按照A->B->C->A的顺序连接 放入三角序列中
        
        m_mesh.vertices = vertices; //把顶点列表 放到mesh中
        m_mesh.triangles = triangles; //把三角序列 放到mesh中

        m_meshFilter.mesh = m_mesh;   //把mesh放到meshfilter中   meshfilter会把它抛给renderer
    }
}
