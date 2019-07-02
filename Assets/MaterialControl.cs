using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialControl : MonoBehaviour
{
    private Material m_material;

    // 加载脚本实例时调用 Awake
    private void Awake()
    {
        m_material = GetComponent<MeshRenderer>().material;
        gameObject.transform.DOScale(new Vector3(0.2f, 0.2f, 0.2f), 0.5f);
        m_material.DOFade(1.0f, 0.5f).OnComplete(() =>
        {
            gameObject.transform.DOScale(new Vector3(0.1f, 0.1f, 0.1f), 0.5f);
            m_material.DOFade(0.2f, 0.5f);
        });
    }
}
