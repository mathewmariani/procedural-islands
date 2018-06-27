using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[ExecuteInEditMode]
[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
public class Island : MonoBehaviour {
	private List<Tile> tiles;
	private MeshData mesh_data;

	[SerializeField]
	private int minQuads = 10;
	[SerializeField]
	private int maxQuads = 20;

	[SerializeField]
	private int maxTries = 10;
	private int tries;

	// Use this for initialization
	void Start () {
		Generate();
	}

	public void Generate() {
		tiles = new List<Tile>();

		// Procedural Generation
		while(true) {

			// Create Initial Tile
			CreateTile(0, 0);

			while(tiles.Count < Random.Range(minQuads, maxQuads)) {
				Tile t;
				if (tries >= maxTries) {
					t = tiles[Random.Range(0, tiles.Count)];
					Debug.Log("Hit max tries");
				} else {
					t = tiles[tiles.Count - 1];
				}

				int dir = Random.Range(0, 4);

				if (dir == 0) {
					if(GetTile(t.x, t.y+1) == null) {
						CreateTile(t.x, t.y+1);
					}
				} else if (dir == 1) {
					if(GetTile(t.x+1, t.y) == null) {
						CreateTile(t.x+1, t.y);
					}
				} else if (dir == 2) {
					if(GetTile(t.x, t.y-1) == null) {
						CreateTile(t.x, t.y-1);
					}
				} else if (dir == 3) {
					if(GetTile(t.x-1, t.y) == null) {
						CreateTile(t.x-1, t.y);
					}
				}

				tries++;
			}

			break;
		}

		CreateTileMask();
		RenderMesh();
	}

	private void CreateTile(int x, int y) {
		Tile t = new Tile(x, y);
		tiles.Add(t);

		tries = 0;
	}

	private Tile GetTile(int x, int y) {
		foreach(Tile t in tiles) {
			if(t.x == x && t.y == y)
				return t;
		}

		return null;
	}

	private void CreateTileMask() {
		foreach(Tile t in tiles) {
			if(GetTile(t.x, t.y+1) != null) {
				t.mask += 1;
			}
			if(GetTile(t.x+1, t.y) != null) {
				t.mask += 2;
			}
			if(GetTile(t.x, t.y-1) != null) {
				t.mask += 4;
			}
			if(GetTile(t.x-1, t.y) != null) {
				t.mask += 8;
			}
		}
	}

	private void RenderMesh() {
		mesh_data = new MeshData();
		foreach(Tile t in tiles) {
			t.GetTileData(ref mesh_data);
		}

		// Creae a new mesh, and populate with data
		Mesh mesh = new Mesh() {
			vertices = mesh_data.vertices.ToArray(),
			triangles = mesh_data.triangles.ToArray(),
			normals = mesh_data.normals.ToArray(),
			uv = mesh_data.uv.ToArray()
		};

		// Assing our mesh to Filter
		GetComponent<MeshFilter>().mesh = mesh;
	}

	void Update() {
		if (Input.GetKeyDown(KeyCode.R)) {
			Generate();
		}
	}
}
