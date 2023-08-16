using UnityEngine;

public class Car : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float rotSpeed = 1;
    [SerializeField] private float board;
    [SerializeField] private MatchData data;
    public bool ufo;
    private Vector3 pos;
    private Vector3 rot;

    private void Start()
    {
        if(data.currentSkin == 2)
        {
            ufo = true;
        }
    }
    void Update()
    {
        pos = transform.localPosition;
        pos.x -= speed * Time.deltaTime;
        transform.localPosition = pos;
        if(pos.x < -board)
        {
            pos.x = board;
            transform.localPosition = pos;
        }
        if (ufo)
        {
            transform.Rotate(Vector3.forward, rotSpeed*Time.deltaTime);
        }
    }
}
