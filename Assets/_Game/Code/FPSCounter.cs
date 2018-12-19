using UnityEngine;
using TMPro;

public class FPSCounter : MonoBehaviour
{
	public TextMeshProUGUI fpsCounter;

	private int framesRendered;
	private float frameTime;

	private float reportingPeriod = 1f;
	private float lastReport = 0f;

	private void Update()
	{
		framesRendered++;

		if(Time.unscaledTime > lastReport + reportingPeriod)
		{
			lastReport = Time.unscaledTime;
			frameTime = 1000 / (float) framesRendered;

			//TODO String concatenation every frame! This sucks!
			fpsCounter.text = framesRendered.ToString() + " FPS - " + frameTime.ToString("N2") + " ms";

			framesRendered = 0;
		}
	}
}
