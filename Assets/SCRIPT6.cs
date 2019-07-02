using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCRIPT6 : MonoBehaviour
{
    public GameObject m_objLocation;
    public MeshFilter m_meshFilter;
    public Mesh m_mesh;

    [Header("内圆半径")]
    public float m_fInnerRadius = 1.0f;
    [Header("外圆半径")]
    public float m_fOuterRadius = 1.5f;
    [Header("圆柱体半高")]
    public float m_fHalfHeight = 1.0f;

    [Header("内圆")]
    public List<Vector3> m_list_v3InnerRadius;
    [Header("外圆")]
    public List<Vector3> m_list_v3OuterRadius;

    public List<Vector3> m_list_v3Vertices;
    public List<int> m_list_nTriangles;
    public Dictionary<int, Vector3> m_dic_v3Normal = new Dictionary<int, Vector3>();
    public List<Vector3> m_list_v3Normal;



    // 加载脚本实例时调用 Awake
    private void Awake()
    {
        m_meshFilter = GetComponent<MeshFilter>();
        m_mesh = new Mesh();
    }

    // 仅在首次调用 Update 方法之前调用 Start
    private IEnumerator Start()
    {
        int v_nBegin = 0;
        int v_nA;
        int v_nB;
        int v_nC;
        int v_nD;

        int v_nPolygon = 12;
        float v_fAngle = 360f / v_nPolygon;//圆形的一个边的所占的角度
        for (int i = 0; i < v_nPolygon; i++)
        {
            //内圆
            m_list_v3InnerRadius.Add(new Vector3(Mathf.Cos(v_fAngle * (i + 1) * Mathf.PI / 180) * m_fInnerRadius, 0, Mathf.Sin(v_fAngle * (i + 1) * Mathf.PI / 180) * m_fInnerRadius));

            //外圆
            m_list_v3OuterRadius.Add(new Vector3(Mathf.Cos(v_fAngle * (i + 1) * Mathf.PI / 180) * m_fOuterRadius, 0, Mathf.Sin(v_fAngle * (i + 1) * Mathf.PI / 180) * m_fOuterRadius));
        }

        //设置上半部分的内圆和外圆
        v_nBegin = m_list_v3Vertices.Count;
        for (int i = 0; i < v_nPolygon; i++)
        {
            m_list_v3Vertices.Add(m_list_v3InnerRadius[i] + new Vector3(0, m_fHalfHeight, 0));
            GameObject v_obj = Instantiate(m_objLocation, gameObject.transform);
            v_obj.transform.position = m_list_v3Vertices[m_list_v3Vertices.Count - 1];
            yield return new WaitForSeconds(1.0f);
        }

        for (int i = v_nBegin; i < v_nBegin + v_nPolygon; i++)
        {
            m_list_v3Vertices.Add(m_list_v3OuterRadius[i] + new Vector3(0, m_fHalfHeight, 0));
            GameObject v_obj = Instantiate(m_objLocation, gameObject.transform);
            v_obj.transform.position = m_list_v3Vertices[m_list_v3Vertices.Count - 1];
            yield return new WaitForSeconds(1.0f);
        }

        for (int i = v_nBegin; i < v_nBegin + v_nPolygon; i++)
        {
            v_nA = i;
            v_nB = i == v_nPolygon - 1 ? 0 : i + 1;
            v_nC = i + v_nPolygon;
            v_nD = i == v_nPolygon - 1 ? v_nPolygon : i + 1 + v_nPolygon;
            DrawModel(ref m_list_nTriangles, ref m_dic_v3Normal, m_list_v3Vertices, v_nA, v_nB, v_nC, v_nD);
            Draw();
            yield return new WaitForSeconds(1.0f);
        }


        //设置下半部分的内圆和外圆
        v_nBegin = m_list_v3Vertices.Count;
        for (int i = 0; i < v_nPolygon; i++)
        {
            m_list_v3Vertices.Add(m_list_v3InnerRadius[i] - new Vector3(0, m_fHalfHeight, 0));
            GameObject v_obj = Instantiate(m_objLocation, gameObject.transform);
            v_obj.transform.position = m_list_v3Vertices[m_list_v3Vertices.Count - 1];
            yield return new WaitForSeconds(1.0f);
        }
        for (int i = 0; i < v_nPolygon; i++)
        {
            m_list_v3Vertices.Add(m_list_v3OuterRadius[i] - new Vector3(0, m_fHalfHeight, 0));
            GameObject v_obj = Instantiate(m_objLocation, gameObject.transform);
            v_obj.transform.position = m_list_v3Vertices[m_list_v3Vertices.Count - 1];
            yield return new WaitForSeconds(1.0f);
        }

        for (int i = v_nBegin; i < v_nBegin + v_nPolygon; i++)
        {
            v_nA = i;
            v_nB = i + v_nPolygon;
            v_nC = i == v_nBegin + v_nPolygon - 1 ? v_nBegin : i + 1;
            v_nD = i == v_nBegin + v_nPolygon - 1 ? v_nBegin + v_nPolygon : i + 1 + v_nPolygon;
            DrawModel(ref m_list_nTriangles, ref m_dic_v3Normal, m_list_v3Vertices, v_nA, v_nB, v_nC, v_nD);
            Draw();
            yield return new WaitForSeconds(1.0f);
        }


        //设置内圆
        v_nBegin = m_list_v3Vertices.Count;
        for (int i = 0; i < v_nPolygon; i++)
        {
            m_list_v3Vertices.Add(m_list_v3InnerRadius[i] + new Vector3(0, m_fHalfHeight, 0));
            GameObject v_obj = Instantiate(m_objLocation, gameObject.transform);
            v_obj.transform.position = m_list_v3Vertices[m_list_v3Vertices.Count - 1];
            yield return new WaitForSeconds(1.0f);

            m_list_v3Vertices.Add(m_list_v3InnerRadius[i] - new Vector3(0, m_fHalfHeight, 0));
            v_obj = Instantiate(m_objLocation, gameObject.transform);
            v_obj.transform.position = m_list_v3Vertices[m_list_v3Vertices.Count - 1];
            yield return new WaitForSeconds(1.0f);

            m_list_v3Vertices.Add(m_list_v3InnerRadius[i] + new Vector3(0, m_fHalfHeight, 0));
            v_obj = Instantiate(m_objLocation, gameObject.transform);
            v_obj.transform.position = m_list_v3Vertices[m_list_v3Vertices.Count - 1];
            yield return new WaitForSeconds(1.0f);

            m_list_v3Vertices.Add(m_list_v3InnerRadius[i] - new Vector3(0, m_fHalfHeight, 0));
            v_obj = Instantiate(m_objLocation, gameObject.transform);
            v_obj.transform.position = m_list_v3Vertices[m_list_v3Vertices.Count - 1];
            yield return new WaitForSeconds(1.0f);
        }

        for (int i = v_nBegin; i < v_nBegin + v_nPolygon * 4; i += 4)
        {
            v_nA = i + 2;
            v_nB = i + 3;
            v_nC = i == v_nBegin + v_nPolygon * 4 - 4 ? v_nBegin : i + 4;
            v_nD = i == v_nBegin + v_nPolygon * 4 - 4 ? v_nBegin + 1 : i + 5;
            DrawModel(ref m_list_nTriangles, ref m_dic_v3Normal, m_list_v3Vertices, v_nA, v_nB, v_nC, v_nD);
            Draw();
            yield return new WaitForSeconds(1.0f);
        }


        //设置外圆
        v_nBegin = m_list_v3Vertices.Count;
        for (int i = 0; i < v_nPolygon; i++)
        {
            m_list_v3Vertices.Add(m_list_v3OuterRadius[i] + new Vector3(0, m_fHalfHeight, 0));
            GameObject v_obj = Instantiate(m_objLocation, gameObject.transform);
            v_obj.transform.position = m_list_v3Vertices[m_list_v3Vertices.Count - 1];
            yield return new WaitForSeconds(1.0f);

            m_list_v3Vertices.Add(m_list_v3OuterRadius[i] - new Vector3(0, m_fHalfHeight, 0));
            v_obj = Instantiate(m_objLocation, gameObject.transform);
            v_obj.transform.position = m_list_v3Vertices[m_list_v3Vertices.Count - 1];
            yield return new WaitForSeconds(1.0f);

            m_list_v3Vertices.Add(m_list_v3OuterRadius[i] + new Vector3(0, m_fHalfHeight, 0));
            v_obj = Instantiate(m_objLocation, gameObject.transform);
            v_obj.transform.position = m_list_v3Vertices[m_list_v3Vertices.Count - 1];
            yield return new WaitForSeconds(1.0f);

            m_list_v3Vertices.Add(m_list_v3OuterRadius[i] - new Vector3(0, m_fHalfHeight, 0));
            v_obj = Instantiate(m_objLocation, gameObject.transform);
            v_obj.transform.position = m_list_v3Vertices[m_list_v3Vertices.Count - 1];
            yield return new WaitForSeconds(1.0f);
        }

        for (int i = v_nBegin; i < v_nBegin + v_nPolygon * 4; i += 4)
        {
            v_nA = i + 2;
            v_nB = i == v_nBegin + v_nPolygon * 4 - 4 ? v_nBegin : i + 4;
            v_nC = i + 3;
            v_nD = i == v_nBegin + v_nPolygon * 4 - 4 ? v_nBegin + 1 : i + 5;
            DrawModel(ref m_list_nTriangles, ref m_dic_v3Normal, m_list_v3Vertices, v_nA, v_nB, v_nC, v_nD);
            Draw();
            yield return new WaitForSeconds(1.0f);
        }

        Draw();
        yield return null;
    }

    private void Draw()
    {
        //模型的绘制
        m_mesh = new Mesh
        {
            vertices = m_list_v3Vertices.ToArray()//把点放到mesh中
        };

        m_list_v3Normal.Clear();
        for (int i = 0; i < m_list_v3Vertices.Count; i++)
        {
            if (m_dic_v3Normal.ContainsKey(i))
            {
                m_list_v3Normal.Add(m_dic_v3Normal[i]);
            }
            else
            {
                m_list_v3Normal.Add(Vector3.zero);
            }
        }

        m_mesh.triangles = m_list_nTriangles.ToArray();//画模型,每三个为一组,为一个面
        m_mesh.normals = m_list_v3Normal.ToArray();//法线   法线的向量和 vertices 一一对应
        //Debug.Log(m_list_v3Vertices.Count + "_" + m_list_v3Normal.Count);

        m_meshFilter.mesh = m_mesh;
    }




    /// <summary>
    /// 得到三角形ABC 某点的 右手定则的  法线方向
    /// </summary>
    /// <param name="a"> A点的坐标 </param>
    /// <param name="b"> B点的坐标 </param>
    /// <param name="c"> C点的坐标 </param>
    /// <param name="index"> 0:A点  1:B点  2:C点 </param>
    /// <returns></returns>
    private Vector3 Faxian(Vector3 a, Vector3 b, Vector3 c, int index = 0)
    {
        a *= 100;
        b *= 100;
        c *= 100;

        Vector3 left = b - a;
        Vector3 right = c - a;
        if (index != 0 && index == 1)
        {
            left = c - b;
            right = a - b;
        }

        if (index != 0 && index == 2)
        {
            left = a - c;
            right = b - c;
        }
        return Vector3.Cross(left, right);
    }

    /// <summary>
    /// 添加法线
    /// </summary>
    /// <param name="_dic_v3Normal"> 法线的字典  为什么用字典的主要就是为了排除重复的点 方便找到某些点没有给出来 </param>
    /// <param name="_list_v3Vertices"> 图形的点的list  </param>
    /// <param name="a"> 要算法线的一个三角面的三个点A </param>
    /// <param name="b"> 要算法线的一个三角面的三个点B </param>
    /// <param name="c"> 要算法线的一个三角面的三个点C </param>
    private void AddCorss(ref Dictionary<int, Vector3> _dic_v3Normal, List<Vector3> _list_v3Vertices, int a, int b, int c)
    {
        Vector3 v_v2FaA = Faxian(_list_v3Vertices[a], _list_v3Vertices[b], _list_v3Vertices[c], 0);
        if (_dic_v3Normal.ContainsKey(a))
        {
            if (v_v2FaA != Vector3.zero)
            {
                _dic_v3Normal[a] = v_v2FaA;
            }
        }
        else
        {
            _dic_v3Normal.Add(a, v_v2FaA);
        }

        Vector3 v_v2FaB = Faxian(_list_v3Vertices[a], _list_v3Vertices[b], _list_v3Vertices[c], 1);
        if (_dic_v3Normal.ContainsKey(b))
        {
            if (v_v2FaB != Vector3.zero)
            {
                _dic_v3Normal[b] = v_v2FaB;
            }
        }
        else
        {
            _dic_v3Normal.Add(b, v_v2FaB);
        }

        Vector3 v_v2FaC = Faxian(_list_v3Vertices[a], _list_v3Vertices[b], _list_v3Vertices[c], 2);
        if (_dic_v3Normal.ContainsKey(c))
        {
            if (v_v2FaC != Vector3.zero)
            {
                _dic_v3Normal[c] = v_v2FaC;
            }
        }
        else
        {
            _dic_v3Normal.Add(c, v_v2FaC);
        }
    }

    /// <summary>
    /// 画一个四角面 面的方向也是右手定则
    /// </summary>
    /// <param name="_list_nPanel"> 法线的返回集合 面的一个list 三个索引为一个面的 右手定则 </param>
    /// <param name="_dic_v3normal"> 法线的字典集合 </param>
    /// <param name="_list_v3Vertices"> 模型上所有的点的面 </param>
    /// <param name="a"> 两个三角面的四个顶点A </param>
    /// <param name="b"> 两个三角面的四个顶点B </param>
    /// <param name="c"> 两个三角面的四个顶点C </param>
    /// <param name="d"> 两个三角面的四个顶点D </param>
    protected void DrawModel(ref List<int> _list_nTriangles, ref Dictionary<int, Vector3> _dic_v3Normal, List<Vector3> _list_v3Vertices, int a, int b, int c, int d)
    {
        _list_nTriangles.Add(a);
        _list_nTriangles.Add(b);
        _list_nTriangles.Add(c);
        AddCorss(ref _dic_v3Normal, _list_v3Vertices, a, b, c);

        _list_nTriangles.Add(c);
        _list_nTriangles.Add(b);
        _list_nTriangles.Add(d);
        AddCorss(ref _dic_v3Normal, _list_v3Vertices, c, b, d);
    }
}
