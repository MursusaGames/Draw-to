using UnityEngine;

public class Hand : MonoBehaviour
{
    [SerializeField] private float yStop;
    [SerializeField] private float speed;
    private bool go;
    private Vector3 startPos;
    private Vector3 pos;
    void Start()
    {
        go = true;
        startPos = gameObject.transform.localPosition;
    }

    void Update()
    {
        if (go)
        {
            pos = transform.localPosition;
            pos.y += Time.deltaTime*speed;
            transform.localPosition = pos;
            if(pos.y > yStop)
            {
                transform.localPosition = startPos;
            }
        }
        
    }
}
