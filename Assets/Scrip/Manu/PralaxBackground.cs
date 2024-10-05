using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PralaxBackground : MonoBehaviour
{
    public Material cloud;

    float offset1;
 

  
    void Update()
    {
        offset1 -= Time.deltaTime * 0.05f;

        cloud.mainTextureOffset = new Vector2 (offset1, 0);
    }
}
