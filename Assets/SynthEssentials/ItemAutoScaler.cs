using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAutoScaler : MonoBehaviour {

	private float scale = 0f;
    public float targetScale = 1;

	private Transform myTransform;
	public new Transform transform {
        get {
            if(myTransform == null) myTransform = base.transform;
            return myTransform;
        }
    }
    

    void Start()
    {
        // Spawn the sphere
		transform.localScale = new Vector3(scale, scale, scale);
    }

    void Update()
    {
        // We need to constantly scale up the sphere until it is back to its normal size
		if (scale < targetScale)
		{
			// Set the scale of the sphere
			transform.localScale = new Vector3(scale, scale, scale);

			// Increase the scale for the next update
			scale += Time.deltaTime;
		}
    }
}
