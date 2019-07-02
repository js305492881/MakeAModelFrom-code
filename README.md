# MakeAModelFrom-code
通过代码制作模型的一个demo  
在SCRIPT6中的代码可以当做是一个模板  
private Vector3 Faxian(Vector3 a, Vector3 b, Vector3 c, int index = 0)  
private void AddCorss(ref Dictionary<int, Vector3> _dic_v3Normal, List<Vector3> _list_v3Vertices, int a, int b, int c)  
protected void DrawModel(ref List<int> _list_nTriangles, ref Dictionary<int, Vector3> _dic_v3Normal, List<Vector3> _list_v3Vertices, int a, int b, int c, int d)  
这三个是一起的  但是只使用DrawModel就可以,其他的函数是辅助这个函数的  
![如图](https://github.com/js305492881/MakeAModelFrom-code/blob/master/Assets/Image/说明.png)  
  
基础知识简介  
  
首先引入的是三个类型  
Mesh 网格:模型的网格，建模就是建网格。  
Mesh Filter 网格过滤器:  内包含一个Mesh组件，可以根据MeshFilter获得模型网格的组件，也可以为MeshFilter设置Mesh内容。  
Mesh Renderer 网格渲染器: 是用于把网格渲染出来的组件。MeshFilter的作用就是把Mesh扔给MeshRender将模型或者说是几何体绘制显示出来。  
![如图](https://github.com/js305492881/MakeAModelFrom-code/blob/master/Assets/Image/说明2.png)
  
Mesh 网格属性:  
顶点坐标（vertex）顶点坐标数组存放Mesh的每个顶点的空间坐标，假设某mesh有n个顶点，则顶点坐标的的size为n  

法线（normal）法线数组存放mesh每个顶点的法线，大小与顶点坐标对应，normal[i]对应顶点vertex[i]的法线  

纹理坐标（uv）它定义了图片上每个点的位置的信息. 这些点与3D模型是相互联系的, 以决定表面纹理贴图的位置. UV就是将图像上每一个点精确对应到模型物体的表面. uv[i]对应vertex[i]  

三角形序列（triangle）每个mesh都由若干个三角形组成，而三角形的三个点就是顶点坐标里的点，三角形的数组的size = 三角形个数 * 3.  
三角形的顶点顺序必须是顺时针，顺时针表示正面，逆时针表示背面，而unity3d在渲染时默认只渲染正面，背面是看不见的。(也就是左手定责)  


工程简介  
工程共有六个场景从1到6难度由浅到深 场景中会有四个点 A红 B绿 C蓝 D黄  
一场景:ABC制作为一个面  
![如图](https://github.com/js305492881/MakeAModelFrom-code/blob/master/Assets/Image/说明3.png)
二场景:ABC和ACD制作两个面  
![如图](https://github.com/js305492881/MakeAModelFrom-code/blob/master/Assets/Image/说明4.png)
三场景:加入法线,让模型看上去有棱角感  
![如图](https://github.com/js305492881/MakeAModelFrom-code/blob/master/Assets/Image/说明5.png)
四场景:ABC面加入UV  
![如图](https://github.com/js305492881/MakeAModelFrom-code/blob/master/Assets/Image/说明6.png)
五场景:ACD面加入UV  
![如图](https://github.com/js305492881/MakeAModelFrom-code/blob/master/Assets/Image/说明7.png)
六场景:动态制作一个圆柱体,整个过程是动态的,方便大家观察  
![如图](https://github.com/js305492881/MakeAModelFrom-code/blob/master/Assets/Image/说明8.png)