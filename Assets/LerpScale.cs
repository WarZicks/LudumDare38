using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpScale : MonoBehaviour
{
    public float speed, scaleSpeed;
    public float actualScaleX, actualScaleY, actualScaleZ;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

            scaleSpeed += Time.deltaTime * speed;
            actualScaleX = Mathf.Lerp(0, 0.04420807f, scaleSpeed);
            actualScaleY = Mathf.Lerp(0, 0.08623946f, scaleSpeed);
            actualScaleZ = Mathf.Lerp(0, 0.08623946f, scaleSpeed);
            transform.localScale = new Vector3(actualScaleX, actualScaleY, actualScaleZ);
    }
}
