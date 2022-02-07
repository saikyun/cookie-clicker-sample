using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Tappable : MonoBehaviour
{
    public float animationTime = 1;
    public float totalAnimationTime = 1;

    public GameObject sphere;

    public Vector3 startScale = new Vector3(2.75f, 0.65f, 2.75f);

    public GameObject rim;

    private Vector3 startPos;
    public Vector3 relEndPos;

    // Start is called before the first frame update
    void Start()
    {
        startPos = gameObject.transform.position;
    }

    void NewClick()
    {
        GameState.instance.clicks++;
        GameState.instance.hud.Q<Label>("clicks-label").text = "" + GameState.instance.clicks;

        animationTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        var scaleRim = 0.1f;

        if (animationTime <= totalAnimationTime)
        {
            var p = animationTime / totalAnimationTime;

            var p2 = p < 0.5 ? 8 * p * p * p * p : 1 - (Mathf.Pow(-2 * p + 2, 4) / 2);

            //var scaleFactor = (0.5f * p < 0.5 ? (8 * p * p * p * p)
            //                          : (1 - Mathf.Pow(-2 * p + 2, 4)));

            var moveFactor =   p2 < 0.25 ? 4 * p2
                             : p2 < 0.5 ? (1 - (4 * (p2 - 0.25f)))
                             : 0;

            var scaleFactor =   p2 < 0.5 ? 0
                              : p2 < 0.75 ? 4 * (p2 - 0.5f)
                              : (1 - (4 * (p2 - 0.75f)));

            sphere.transform.position = new Vector3(Mathf.Lerp(-1.5f, 1.5f, p2),
                sphere.transform.position.y,
                sphere.transform.position.z);

            GameState.instance.hud.Q<Label>("p-label").text = p.ToString("#.##");

            // scaleFactor = Mathf.Sin(scaleFactor * scaleFactor);

            var newScale = 1 + scaleFactor * scaleRim;
            rim.transform.localScale = new Vector3(startScale.x * newScale, startScale.y, startScale.z * newScale);
            transform.position = Vector3.Lerp(startPos, startPos + relEndPos, moveFactor);
            animationTime += Time.deltaTime;
        }

        if (Input.GetMouseButtonDown(0))
        {
            NewClick();
        }

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                NewClick();
            }
        }
    }
}
