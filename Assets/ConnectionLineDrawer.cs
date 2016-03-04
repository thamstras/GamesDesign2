using UnityEngine;
using System.Collections.Generic;

public class ConnectionLineDrawer : MonoBehaviour {

    public Transform[] waypoints;

    public Sprite offSprite;

    public Sprite onSprite;

    private List<SpriteRenderer> stamps;

    private bool on = false;

	// Use this for initialization
	void Start () {

        //waypoints = transform.GetComponentsInChildren<Transform>();
        var stampsize = offSprite.bounds.extents.x * 2;
        stamps = new List<SpriteRenderer>();

        for (int w = 0; w < waypoints.Length - 1; w++)
        {
            Transform start = waypoints[w];
            Transform end = waypoints[w+1];
            var vector = end.position - start.position;
            var distance = vector.magnitude;
            var direction = vector.normalized;
            var nStamps = distance / stampsize;
            var singleStep = vector / nStamps;
            for (int i = 0; i < nStamps; i++)
            {
                var stampPos = start.position + (singleStep * i);
                GameObject stamp = new GameObject();
                stamp.transform.SetParent(this.transform);
                SpriteRenderer ren = stamp.AddComponent<SpriteRenderer>();
                ren.sprite = this.offSprite;
                stamp.transform.position = stampPos;
                stamp.transform.LookAt(end);
                stamp.transform.Rotate(new Vector3(90, 0, 0));
                stamps.Add(stamp.GetComponent<SpriteRenderer>());
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void toggle()
    {
        on = !on;
        Sprite sprite;
        if (on)
        {
            sprite = onSprite;
        }
        else
        {
            sprite = offSprite;
        }

        foreach (SpriteRenderer ren in stamps)
        {
            ren.sprite = sprite;
        }
    }
}
