using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Entities;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MenuContoller : MonoBehaviour {
	private static MenuContoller instance;
    public static MenuContoller Instance { get { return instance;} }
	public Canvas menuCanvas;
	public Canvas presetsCanvas;
	public Button ExitBtn;
    public Button RestartBtn;

	public Button PresetsBtn;
	public TMP_Text GravMultText;
    public TMP_Text GravDivText;
    public TMP_Text TotalCountText;
    public TMP_Text SpawnRadiusText;
    public TMP_Text SpawnHeightText;
    public TMP_Text BoundrySpaceText;
    public TMP_Text MaxScaleText;
    public TMP_Text RangeMultText;
    public TMP_Text ScaleIncrementText;
	public TMP_Text GravFreqText;
	public TMP_Text ExplosionLifeTimeText;
	public TMP_Text ExplosionEndScaleText;
	public Slider GravMultSlider;
    public Slider GravDivSlider;
    public Slider TotalCountSlider;
    public Slider SpawnRadiusSlider;
    public Slider SpawnHeightSlider;
    public Slider BoundrySpaceSlider;
    public Slider MaxScaleSlider;
    public Slider RangeMultSlider;
    public Slider ScaleIncrementSlider;
	public Slider GravFreqSlider;
	public Slider ExplosionLifeTimeSlider;
	public Slider ExplosionEndScaleSlider;
	public Toggle BoundryBounceToggle;
    public Toggle AbsorbToggle;
	public Toggle ExplodeToggle;
	BoubleSystem bubSys;
    SpawnerRndAreaSystem spawnSys;

	private void Awake() {
		instance = this;
	}

	void Start() {
        StartCoroutine(StartInit());
		ExitBtn.onClick.AddListener(() => {
			GameManagerAuth.Instance.ExitGame();
		});

		RestartBtn.onClick.AddListener(() => {
			spawnSys.init = true;
		});
		PresetsBtn.onClick.AddListener(() => {
			menuCanvas.enabled = false;
			presetsCanvas.enabled = true;
		});

		GravMultSlider.onValueChanged.AddListener((value) => {
			int v = (int)(value * 50);
			bubSys.bd.gravityMult = v;
			GravMultText.text = v.ToString();
		});
		GravDivSlider.onValueChanged.AddListener((value) => {
			float v = value * 0.000001f;
			bubSys.bd.gravityDiv = v;
			GravDivText.text = v.ToString();
		});
		TotalCountSlider.onValueChanged.AddListener((value) => {
			spawnSys.sd.totalCount = (int)value * 100;
			TotalCountText.text = spawnSys.sd.totalCount.ToString();
		});
		SpawnRadiusSlider.onValueChanged.AddListener((value) => {
			spawnSys.sd.cylinderRadius = value * 50;
			SpawnRadiusText.text = spawnSys.sd.cylinderRadius.ToString();
		});
		SpawnHeightSlider.onValueChanged.AddListener((value) => {
			spawnSys.sd.cylinderHeight = value * 50;
			SpawnHeightText.text = spawnSys.sd.cylinderHeight.ToString();
		});
		BoundrySpaceSlider.onValueChanged.AddListener((value) => {
			bubSys.bd.boundryBuffer = (int)value * 10;
			BoundrySpaceText.text = bubSys.bd.boundryBuffer.ToString();
		});
		MaxScaleSlider.onValueChanged.AddListener((value) => {
			bubSys.bd.maxScale = value;
			MaxScaleText.text = bubSys.bd.maxScale.ToString();
		});
		RangeMultSlider.onValueChanged.AddListener((value) => {
			spawnSys.sd.rangeMult = value;
			spawnSys.sd.rangeMultChanged = true;
			RangeMultText.text = spawnSys.sd.rangeMult.ToString();
		});
		ScaleIncrementSlider.onValueChanged.AddListener((value) => {
			bubSys.bd.scaleInc = value * 0.01f;
			ScaleIncrementText.text = bubSys.bd.scaleInc.ToString();
		});
		GravFreqSlider.onValueChanged.AddListener((value) => {
			spawnSys.sd.gravUpdateDelay = value;
			GravFreqText.text = spawnSys.sd.gravUpdateDelay.ToString();
		});
		ExplosionLifeTimeSlider.onValueChanged.AddListener((value) => {
			spawnSys.sd.explosionLifeTime = value;
			ExplosionLifeTimeText.text = value.ToString();
		});
		ExplosionEndScaleSlider.onValueChanged.AddListener((value) => {
			spawnSys.sd.explosionEndScale = value;
			ExplosionEndScaleText.text = value.ToString();
		});
		BoundryBounceToggle.onValueChanged.AddListener((value) => { bubSys.bd.bounce = value; });
		AbsorbToggle.onValueChanged.AddListener((value) => { bubSys.bd.absorb = value; });
		ExplodeToggle.onValueChanged.AddListener((value) => { spawnSys.sd.explode = value; });
    }

    IEnumerator StartInit() {
        yield return null;
		bubSys = World.DefaultGameObjectInjectionWorld.GetOrCreateSystem<BoubleSystem>();
		spawnSys = World.DefaultGameObjectInjectionWorld.GetOrCreateSystem<SpawnerRndAreaSystem>();
		// var sp = bubSys.GetSingleton<SpawnerRndAreaComp>();
		Init();
	}

    public void Init(){
		GravMultText.text = bubSys.bd.gravityMult.ToString();
		GravDivText.text = bubSys.bd.gravityDiv.ToString();
		TotalCountText.text = spawnSys.sd.totalCount.ToString();
		SpawnHeightText.text = spawnSys.sd.cylinderRadius.ToString();
		SpawnRadiusText.text = spawnSys.sd.cylinderHeight.ToString();
		BoundrySpaceText.text = bubSys.bd.boundryBuffer.ToString();
		MaxScaleText.text = bubSys.bd.maxScale.ToString();
		RangeMultText.text = spawnSys.sd.rangeMult.ToString();
		ScaleIncrementText.text = bubSys.bd.scaleInc.ToString();
		GravFreqText.text = spawnSys.sd.gravUpdateDelay.ToString();
		ExplosionLifeTimeText.text = spawnSys.sd.explosionLifeTime.ToString();
		ExplosionEndScaleText.text = spawnSys.sd.explosionEndScale.ToString();
		AbsorbToggle.isOn = bubSys.bd.absorb;
		BoundryBounceToggle.isOn = bubSys.bd.bounce;
		ExplodeToggle.isOn = spawnSys.sd.explode;

		GravMultSlider.value = bubSys.bd.gravityMult / spawnSys.sd.defaultGrav;
		GravDivSlider.value = bubSys.bd.gravityDiv / 0.000001f;
		TotalCountSlider.value = spawnSys.sd.totalCount / 100;
		SpawnRadiusSlider.value = spawnSys.sd.cylinderRadius / 50;
		SpawnHeightSlider.value = spawnSys.sd.cylinderHeight / 50;
		BoundrySpaceSlider.value = bubSys.bd.boundryBuffer / 10;
		MaxScaleSlider.value = bubSys.bd.maxScale;
		RangeMultSlider.value = spawnSys.sd.rangeMult;
		ScaleIncrementSlider.value = bubSys.bd.scaleInc / 0.01f;
		GravFreqSlider.value = spawnSys.sd.gravUpdateDelay;
		ExplosionLifeTimeSlider.value = spawnSys.sd.explosionLifeTime;
		ExplosionEndScaleSlider.value = spawnSys.sd.explosionEndScale;
    }

}