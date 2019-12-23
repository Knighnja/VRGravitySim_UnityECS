using UnityEngine;
using System.Collections;

// Evenly spaces children that are between the first and last child in the editor.
[ExecuteInEditMode]
public class ChildSpacer : MonoBehaviour {
#if UNITY_EDITOR
	private Vector3 firstObjPos, lastObjPos, offset, currentOffset;

	public bool doSpacing = false;

	//public string newName = "Child_";
	//public bool renameChildren = false;

	// so it can be disabled
	void Start(){}

	// this will evenly space children between the position of the first and last child 
	void Update () {
		if(doSpacing){
			firstObjPos = transform.GetChild(0).localPosition;
			lastObjPos = transform.GetChild(transform.childCount-1).localPosition;
			offset = (firstObjPos - lastObjPos) / (transform.childCount-1);
			for(int i = 1; i < transform.childCount-1; i++){
				currentOffset = firstObjPos - (i * offset);
				if (transform.GetChild(i).localPosition != currentOffset)
					transform.GetChild(i).localPosition = currentOffset;
			}
		}

		/*if(renameChildren){
			renameChildren = false;
			for (int i = 0; i < transform.childCount; i++) {
				transform.GetChild(i).name = newName + i;
			}
		}*/
	}
#endif
}
