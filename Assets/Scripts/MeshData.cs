using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MeshData {
	private List<Vector3> _vertices;
	private List<Vector3> _normals;
	private List<int> _triangles;
	private List<Vector2> _uv;
	
	#region Properties
	
	public List<Vector3> vertices {
		get { return _vertices; }
	}
	
	public List<Vector3> normals {
		get { return _normals; }
	}
	
	public List<int> triangles {
		get { return _triangles; }
	}
	
	public List<Vector2> uv {
		get { return _uv; }
	}
	
	#endregion
	
	public MeshData() {
		_vertices = new List<Vector3>();
		_normals = new List<Vector3>();
		_triangles = new List<int>();
		_uv = new List<Vector2>();
	}
	
	public void AddQuadTriangles() {
		_triangles.Add(vertices.Count - 4);
		_triangles.Add(vertices.Count - 1);
		_triangles.Add(vertices.Count - 2);
		
		_triangles.Add(vertices.Count - 4);
		_triangles.Add(vertices.Count - 3);
		_triangles.Add(vertices.Count - 1);
	}
}