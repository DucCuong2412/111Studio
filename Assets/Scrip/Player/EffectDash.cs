using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectDash : MonoBehaviour
{
    public GameObject Effect;
    public void Dash()
    {
        
       GameObject effect = Instantiate(Effect,transform.position,transform.rotation);
        Destroy(effect,0.3f);
    }
}
