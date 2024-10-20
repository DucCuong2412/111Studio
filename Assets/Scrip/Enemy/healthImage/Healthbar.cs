using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    private Image _image;
    [SerializeField] private float _timetoDrain = 0.25f;
    float _taget;

    private Coroutine _coroutine;
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



    IEnumerator DrainhealthBar()
    {
        float Fillamount = _image.fillAmount;

        float eslapedTime = 0f;
        while (eslapedTime < _timetoDrain)
        {
            eslapedTime += Time.deltaTime;

            _image.fillAmount = Mathf.Lerp(eslapedTime, _taget, (eslapedTime/_timetoDrain));
            yield return null;
        }
    }
}
