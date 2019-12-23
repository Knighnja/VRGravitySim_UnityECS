using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class ChildRenamer : MonoBehaviour {
	public string customName = "";
	public bool renChildWChildren = false;

	public void RenameChildren() {
		int count = 0;
		if (customName == "") {
			for (int i = 0; i < transform.childCount; i++) {
				if (transform.GetChild(i).childCount == 0 || renChildWChildren)
					transform.GetChild(i).name = name + "_" + count++;
			}
		} else {
			for (int i = 0; i < transform.childCount; i++) {
				if (transform.GetChild(i).childCount == 0 || renChildWChildren)
					transform.GetChild(i).name = customName + count++;
			}
		}
		Debug.Log("Renamed " + count + " children.");
	}

	public void RemoveStage() {
		string[] delimiter = { "_s" };
		for (int i = 0; i < transform.childCount; i++) {
			transform.GetChild(i).name = transform.GetChild(i).name.Split(delimiter, System.StringSplitOptions.None) [0];
		}
	}

	public Object[] SelectSubChildren(int[] childrenNums) {
		List<GameObject> selchildren = new List<GameObject>();
		for (int i = 0; i < transform.childCount; i++) {
			for (int g = 0; g < childrenNums.Length; g++) {
				var child = transform.GetChild(i);
				if (child.childCount >= childrenNums[g] + 1) {
					selchildren.Add(child.GetChild(childrenNums[g]).gameObject);
				}
			}
		}
		return selchildren.ToArray();
	}
}

#if UNITY_EDITOR
[CustomEditor(typeof(ChildRenamer))]
public class ChildRenamerEditor : Editor {
	string subChildNum = "0";
	public override void OnInspectorGUI() {
		DrawDefaultInspector();

		ChildRenamer myScript = (ChildRenamer) target;
		if (GUILayout.Button("Rename Children")) {
			myScript.RenameChildren();
		}

		if (GUILayout.Button("Remove stageInfo from child name")) {
			myScript.RemoveStage();
		}

		GUILayout.BeginHorizontal();

		subChildNum = EditorGUILayout.TextField(subChildNum, GUILayout.Width(60));
		if (GUILayout.Button("SelectSubChild:")) {
			List<int> nums = new List<int>();
			foreach (var item in subChildNum.Replace(" ", "").Split(',')) {
				int n;
				if (int.TryParse(item, out n)) {
					nums.Add(n);
				}
			}
			Selection.objects = myScript.SelectSubChildren(nums.ToArray());
			Debug.Log("Selected: " + Selection.objects.Length);
		}
		GUILayout.EndHorizontal();
	}
}
#endif