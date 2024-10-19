using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    private Image _image;

    
    void Start()
    {
        _image = GetComponent<Image>();
    }

   
    void Update()
    {
        
    }

    public void Updatehealthbar(float MaxHealth, float CurrentHealth)
    {
        _image.fillAmount = CurrentHealth / MaxHealth;
    }
}
