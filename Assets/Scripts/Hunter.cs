using UnityEngine;

public class Hunter : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private MatchData data;
    [SerializeField] private Animator osaAnim;
    private Vector3 pos;
    [SerializeField] private float boardX = 425f;
    private bool goLeft;
    private bool goRight;

    private void Start()
    {
        goLeft = true;
        if(data.currentSkin == 0)
        {
            osaAnim.enabled = true;
        }
        else
        {
            osaAnim.enabled = false;
        }
    }
    void Update()
    {
        if (goLeft)
        {
            pos = transform.localPosition;
            pos.x -= speed * Time.deltaTime;
            transform.localPosition = pos;
            if(pos.x < -boardX)
            {
                goLeft = false;
                goRight = true;
                var scal = transform.localScale;
                scal.x *= -1;
                transform.localScale = scal;
            }
        }
        if (goRight)
        {
            pos = transform.localPosition;
            pos.x += speed * Time.deltaTime;
            transform.localPosition = pos;
            if (pos.x > boardX)
            {
                goLeft = true;
                goRight = false;
                var scal = transform.localScale;
                scal.x *= -1;
                transform.localScale = scal;
            }
        }
    }    
}
