using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoClick : MonoBehaviour
{
    public float time = 0;
    public float totalTime = 1f;

    public Tappable button;
    public GameObject pointer;

    public float minY = 0.5f;
    public float maxY = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        var t = ((time + 0.5f * totalTime) % totalTime) / totalTime;

        t = Mathf.Sin(t * Mathf.PI);

        pointer.transform.localPosition = Vector3.Lerp(new Vector3(0, maxY, 0), new Vector3(0, minY, 0), t);

        if (time >= totalTime)
        {
            button.NewClick();
            time = 0;
        }
    }
}
