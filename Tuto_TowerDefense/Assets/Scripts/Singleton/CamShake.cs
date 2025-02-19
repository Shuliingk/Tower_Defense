using System;
using System.Collections;
using UnityEngine;

public class CamShake : MonoBehaviour
{
    private static CamShake instance;

    public static CamShake Instance
    {
        get
        {
            return instance;
        }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    bool shakingCam;
	[SerializeField] Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void Shake(float duration, float amount, float intensity)
	{
		if (!shakingCam)
        {
			try
            {
				StartCoroutine(ShakeCam(duration, amount, intensity));
			}
			catch(Exception e)
            {
				print(e.Message);
            }
		}
			
	}

	IEnumerator ShakeCam(float dur, float amount, float intensity)
	{
		float t = dur;
		Vector3 originalPos = Camera.main.transform.localPosition;
		Vector3 targetPos = Vector3.zero;
		shakingCam = true;
        animator.enabled = false;

        while (t > 0.0f)
		{
			if (targetPos == Vector3.zero)
			{
				targetPos = originalPos + (UnityEngine.Random.insideUnitSphere * amount);
			}

			Camera.main.transform.localPosition = Vector3.Lerp(Camera.main.transform.localPosition, targetPos, intensity * Time.deltaTime);

			if (Vector3.Distance(Camera.main.transform.localPosition, targetPos) < 0.02f)
			{
				targetPos = Vector3.zero;
			}

			t -= Time.deltaTime;
			yield return null;
		}

		Camera.main.transform.localPosition = originalPos;
		shakingCam = false;
        animator.enabled = true;
    }

}
