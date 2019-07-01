﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCRIPT1 : MonoBehaviour
{
    public MeshFilter m_meshFilter;
    public Mesh m_mesh;
    public GameObject m_objA;
    public GameObject m_objB;
    public GameObject m_objC;

    // 加载脚本实例时调用 Awake
    private void Awake()
    {
        m_meshFilter = GetComponent<MeshFilter>();
        m_mesh = new Mesh();
        Vector3[] v_vertices = new Vector3[]
        {
            m_objA.transform.position,
            m_objB.transform.position,
            m_objC.transform.position
        };

        int[] triangles = new int[] { 0, 1, 2 };


        m_mesh.vertices = v_vertices;//把点放到mesh中
        m_mesh.triangles = triangles;//画模型,每三个为一组,为一个面

        m_meshFilter.mesh = m_mesh;
    }

}
