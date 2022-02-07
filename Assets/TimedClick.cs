using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedClick : MonoBehaviour
{
    public Tappable button;
    public GameObject pointer;
    public float timer;
    public float time;
    public float offset = 0;
    public float maxY = 1.5f;
    public float minY = 1.3f;

    // Start is called before the first frame update
    void Start()
    {
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        var t = ((time / timer) + offset) % 1;

        t = Mathf.InverseLerp(0.3f, 1f, t);

        t = Mathf.Sin(Mathf.PI * t);

        t = t * t * t;

        pointer.transform.localPosition = Vector3.Lerp(new Vector3(0, maxY, 0), new Vector3(0, minY, 0), t);

        Debug.Log(t);

        if (time >= timer)
        {
            button.NewClick();
            time = (time - timer);
        }
    }
}
