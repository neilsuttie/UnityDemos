using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    [SerializeField]
    Text _text;

    private float time;

	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;

        string timeText = time.ToString().Substring(0, 4);

        _text.text = timeText;
    }

    public void ResetTimer()
    {
         time = 0.0f;
    }

    public float getTime()
    {
        return time;
    }
}
