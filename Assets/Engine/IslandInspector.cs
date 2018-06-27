#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Island))]
public class IslandInspector : Editor {
	public override void OnInspectorGUI () {
		base.OnInspectorGUI ();		
		if(GUILayout.Button("Generate")) {
			Island t = (Island)target;
			t.Generate();
		}
	}
}
#endif