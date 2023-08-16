using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chucha : MonoBehaviour
{
    [SerializeField] private float speed;
    private float timeToGo = 2f;
    private bool isGo;
    private bool isFlip;
    public Vector3 target;
    public void Go()
    {
        var point = new Vector3(Random.Range(-400f,400f), Random.Range(-400f, 400f),0);
        target = point - transform.localPosition;
        timeToGo = 2f;
        isGo = true;

    }
    
    void Update()
    {
        if (isGo)
        {
            timeToGo -= Time.deltaTime;
            if (timeToGo <= 0)
            {
                isGo = false;
                Go();
                return;
            }
            var previousX = transform.localPosition.x;
            var pos = transform.localPosition;
            pos = Vector3.Lerp(transform.localPosition, target, speed);
            transform.localPosition = pos;
            if (!isFlip)
            {
                if (pos.x < previousX)
                {
                    isFlip = true;
                    var scal = transform.localScale;
                    scal.x *= -1;
                    transform.localScale = scal;
                }
            }
            else
            {
                if (pos.x > previousX)
                {
                    isFlip = false;
                    var scal = transform.localScale;
                    scal.x *= -1;
                    transform.localScale = scal;
                }
            }
        }
    }
}
