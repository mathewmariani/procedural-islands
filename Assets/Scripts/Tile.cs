using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Tile {
	public const float tileSize = 0.0625f;

	#region Properties

	public int x {
		get;
		private set;
	}

	public int y {
		get;
		private set;
	}

	public int mask {
		get;
		set;
	}

	#endregion

	public Tile(int x, int y) {
		this.x = x;
		this.y = y;
	}
	
	public void GetTileData(ref MeshData mesh) {
		mesh.vertices.Add(new Vector3(x-0.5f, y+0.5f, 0f));
		mesh.vertices.Add(new Vector3(x+0.5f, y+0.5f, 0f));
		mesh.vertices.Add(new Vector3(x-0.5f, y-0.5f, 0f));
		mesh.vertices.Add(new Vector3(x+0.5f, y-0.5f, 0f));
		
		mesh.AddQuadTriangles();
		mesh.uv.AddRange(uv());
	}

	protected virtual void GetTexturePosition (out int x, out int y) {
		// if only all sprite sheets can be straigh lines :)
		x = mask;
		y = 0;
	}
	
	protected virtual Vector2[] uv() {
		int x, y;
		GetTexturePosition(out x, out y);
		
		Vector2[] uv = new Vector2[4];
		uv[0] = new Vector2(tileSize * x, 1);
		uv[1] = new Vector2(tileSize * x + tileSize, 1);
		uv[2] = new Vector2(tileSize * x, 0);
		uv[3] = new Vector2(tileSize * x + tileSize, 0);

		return uv;
	}
}
