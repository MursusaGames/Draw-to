using UnityEngine;
using System.Collections.Generic;

public class Man : MonoBehaviour
{
    [SerializeField] private GameObject shield;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private MatchData data;
    [SerializeField] private LevelController levelController;
    [SerializeField] private GameObject explosionStick;
    [SerializeField] private GameObject explosionZombee;
    [SerializeField] private GameObject visual;
    [SerializeField] private ParticleSystem hearts;
    [SerializeField] private BoxCollider2D touchColider;
    [SerializeField] private CircleCollider2D gameColider;
    [SerializeField] private List<Animator> minaAnim;
    private float timeToPoint;
    private float pointsCount;
    private int count = 0;
    private float timeCount;
    private LineRenderer _line;
    private bool go;
    private bool step;
    private Vector3 pos;
    private bool stopGame;
    public bool isFlip;
    private bool isShield;
    public void Go(LineRenderer line, AudioClip clip)
    {
        touchColider.enabled = false;
        gameColider.enabled = true;
        if (data.isSound)
        {
            audioSource.clip = clip;
            audioSource.Play();
        }        
        _line = line;
        pointsCount = line.positionCount;        
        timeToPoint = data.timeToFinish / pointsCount;        
        timeCount = timeToPoint;
        go = true;
    }   
    public void HideVisual()
    {
        audioSource.Stop();
        visual.SetActive(false);
        hearts.Stop();
    }
    private void Update()
    {
        if (stopGame) return;
        if(go)
        {
            timeCount -= Time.deltaTime;
            if(timeCount <= 0)
            {
                go = false;
                step = true;
            } 
        }
        if (step)
        {
            count++;
            var previousX = transform.localPosition.x;
            gameObject.transform.position = _line.GetPosition(count);            
            pos = gameObject.transform.localPosition;
            pos.z = 0;
            if (!isFlip)
            {
                if (pos.x < previousX)
                {
                    isFlip = true;
                    var scal = transform.localScale;
                    scal.x *= - 1;
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
            
            gameObject.transform.localPosition = pos;
            step = false;
            timeCount = timeToPoint;
            if (count + 1 != pointsCount)
            {
                go = true;
            }
            else
            {
                audioSource.Stop();
                levelController.Win();
            }
                
        }
    }
    public void StopGame()
    {
        stopGame = true;
    }

    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (stopGame) return;
        if (collision.gameObject.CompareTag("Shield"))
        {
            isShield = true;
            shield.SetActive(true);
            collision.gameObject.SetActive(false);
        }
        if (collision.gameObject.CompareTag("Woman"))
        {
            audioSource.Stop();
            levelController.Fight(transform.position);
        }
        if (collision.gameObject.CompareTag("Man"))
        {
            audioSource.Stop();
            levelController.Fight(transform.position);
        }
        if (collision.gameObject.CompareTag("Fence"))
        {
            if (isShield)
            {
                shield.SetActive(false);
                collision.gameObject.SetActive(false);
                isShield = false;
            }
            else
            {
                audioSource.Stop();
                Boom();
            }
            
        }
        if (collision.gameObject.CompareTag("Mina"))
        {
            if (isShield)
            {
                shield.SetActive(false);
                foreach (var mAnim in minaAnim)
                {
                    mAnim.SetBool("boom", true);
                }                    
                isShield = false;
            }
            else
            {
                audioSource.Stop();
                foreach (var mAnim in minaAnim)
                {
                    mAnim.SetBool("boom", true);
                }
                Boom();
            }

        }
        if (collision.gameObject.CompareTag("Key"))
        {
            levelController.GetKey();
            collision.gameObject.SetActive(false);
        }
    }

    public void Boom()
    {
        StopGame();
        HideVisual();
        if(data.currentSkin == 0)
        {
            explosionStick.SetActive(true);
            explosionStick.GetComponent<ParticleSystem>().Play();
        }
        else if(data.currentSkin == 1)
        {
            explosionZombee.SetActive(true);
        }        
        levelController.Boom(true);
    }
}
