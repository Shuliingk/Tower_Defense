using UnityEngine;

public class GrassAnim : MonoBehaviour
{
    public Vector3 amount;
    public float time;
    float randomTime;

    void Start()
    {
        randomTime = Random.Range(time - 0.5f, time + 0.5f);

        Invoke("StartTween", randomTime / 2);
    }

    public void StartTween()
    {
        iTween.PunchScale(gameObject, iTween.Hash(
            "amount", amount,
            "time", randomTime,
            "looptype", iTween.LoopType.loop
        ));
    }
}
