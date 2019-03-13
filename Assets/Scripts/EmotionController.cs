using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EmotionController : MonoBehaviour {

	[SerializeField] private Slider emotionMeter;

	private void SetLevel(int value) {
		emotionMeter.value = value;
	}

}