using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using Newtonsoft.Json;
using Unity.Entities;
using TMPro;
public class PresetsMenu : MonoBehaviour
{
	private static PresetsMenu instance;
    public static PresetsMenu Instance { get { return instance; } }
	public struct SaveData {
		public SpawnerRndAreaSystem.SpawnerData spawnerData;
		public BoubleSystem.BoubleData boubleData;
	}
	public Canvas presetCanvas;
	public Canvas menuCanvas;
	public Button backBtn;
	public TMP_Text StatusText;

	public Transform presetParent;
	Button[] saveBtns;
	Button[] loadBtns;
	SpawnerRndAreaSystem spsys;
	BoubleSystem bubsys;
    void BackToMain(){
        presetCanvas.enabled = false;
		menuCanvas.enabled = true;
    }
	// Start is called before the first frame update
	void Start()
    {
		instance = this;
		bubsys = World.DefaultGameObjectInjectionWorld.GetOrCreateSystem<BoubleSystem>();
		spsys = World.DefaultGameObjectInjectionWorld.GetOrCreateSystem<SpawnerRndAreaSystem>();

		saveBtns = new Button[presetParent.childCount];
		loadBtns = new Button[presetParent.childCount];

		backBtn.onClick.AddListener(() => {
			BackToMain();
		});

		string dir = Application.dataPath + "/Saves";

		if(Directory.Exists(dir) == false)
			Directory.CreateDirectory(dir);

		for (int i = 0; i < presetParent.childCount; i++)
        {
			Transform preset = presetParent.GetChild(i);
			int ind = i; // cannot use i in a lambda expression
			string filename = dir + "/" + i + ".json";
			// Debug.Log(filename);
			saveBtns[i] = preset.GetChild(0).GetComponent<Button>();
			loadBtns[i] = preset.GetChild(1).GetComponent<Button>();
			preset.GetChild(2).GetComponent<TMP_Text>().text = "Preset " + i;

			if (File.Exists(filename) == false) {
				loadBtns[i].interactable = false;
			}

			saveBtns[i].onClick.AddListener(() => {
				var f = File.CreateText(filename);
				f.Write(JsonConvert.SerializeObject(new SaveData { spawnerData = spsys.sd, boubleData = bubsys.bd }, Formatting.Indented));
				f.Close();
                if(File.Exists(filename)){
    				loadBtns[ind].interactable = true;
					StatusText.text = "Preset " + ind + " Saved";
				} else {
					StatusText.text = "Coundn't Save! " + ind;
				}
			});

			loadBtns[i].onClick.AddListener(() => {
				string json = File.ReadAllText(filename);
				SaveData savedData = JsonConvert.DeserializeObject<SaveData>(json);
				bubsys.bd = savedData.boubleData;
				spsys.sd = savedData.spawnerData;
				MenuContoller.Instance.Init();
				StatusText.text = "Preset " + ind + " Loaded";
				// BackToMain();
			});
		}
	}
}
