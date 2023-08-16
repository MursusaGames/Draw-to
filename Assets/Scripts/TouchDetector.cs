using UnityEngine;

public class TouchDetector : MonoBehaviour
{
    public GameObject man;
    [SerializeField] private GameObject manT;
    public GameObject man2;
    [SerializeField] private GameObject manT2;
    public GameObject woman;
    [SerializeField] private GameObject womanT;
    public GameObject woman2;
    [SerializeField] private GameObject womanT2;
    [SerializeField] private DrawManager drawManager;
    [SerializeField] private LevelController levelController;
    [SerializeField] private FueMan fueMan;
    [SerializeField] private FueWoman fueWoman;
    [SerializeField] private MatchData data;
    public GameObject currentGO;
    public bool isMan;
    public bool isMan2;
    public bool isWoman;
    public bool stopPlay;
    public bool beMan2;
    public bool beWoman2;
    public bool noSound;
    public bool checkStop;
    private Vector2 oldPos = Vector2.zero;
    private Vector2 currentPos = Vector2.one;
    private float stopTime = 0.5f;
    public bool IsTouchingMouse(GameObject g)
    {
        Vector2 point = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        return g.GetComponent<Collider2D>().OverlapPoint(point);
    }
    void CheckGO()
    {
        if (IsTouchingMouse(man)&&!isMan)
        {
            currentGO = man;
            drawManager.mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);            
            drawManager.isDraw = true;
            if (data.isSound)
            {
                drawManager.PlaySound();
            }         
            
        }
        else if (levelController.thisUserNumber > 1 && !isWoman && IsTouchingMouse(woman))
        {
            currentGO = woman;
            drawManager.mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);            
            drawManager.isDraw = true;
            if (data.isSound)
            {
                drawManager.PlaySound();
            }              
            
        }

        if (beMan2)
        {
            if (IsTouchingMouse(man2) && !isMan2)
            {
                currentGO = man2;
                drawManager.mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                
                drawManager.isDraw = true;
                if (data.isSound)
                {
                    drawManager.PlaySound();
                }                
            }
        }
        checkStop = true;
    }
    void CheckT()
    {
        if (beMan2)
        {
            if (currentGO == man)
            {
                if (IsTouchingMouse(manT) || IsTouchingMouse(manT2))
                {
                    drawManager.isDraw = false;
                    isMan = true;
                    if (fueMan != null)
                        fueMan.StopFue();
                    drawManager.mansLine = drawManager._currentLine;
                }

                else
                {
                    drawManager.RemoveLine();
                    drawManager.isDraw = false;
                }
                currentGO = null;
            }
            else if (currentGO == woman)
            {
                if (IsTouchingMouse(womanT))
                {
                    drawManager.isDraw = false;
                    isWoman = true;
                    if (fueWoman != null)
                        fueWoman.StopFue();
                    drawManager.womansLine = drawManager._currentLine;
                }

                else
                {
                    drawManager.RemoveLine();
                    drawManager.isDraw = false;
                }
                currentGO = null;
            }
            else if (currentGO == man2)
            {
                if (IsTouchingMouse(manT) || IsTouchingMouse(manT2))
                {
                    drawManager.isDraw = false;
                    isMan2 = true;
                    if (fueMan != null)
                        fueMan.StopFue();
                    drawManager.mans2Line = drawManager._currentLine;
                }

                else
                {
                    drawManager.RemoveLine();
                    drawManager.isDraw = false;
                }
                currentGO = null;
            }
            if (isMan && isWoman && isMan2)
            {
                levelController.Go(3);
            }
        }
        else
        {
            if (currentGO == man)
            {
                if (IsTouchingMouse(manT))
                {
                    drawManager.isDraw = false;
                    isMan = true;
                    if (fueMan != null)
                        fueMan.StopFue();
                    drawManager.mansLine = drawManager._currentLine;
                    if (levelController.thisUserNumber == 1)
                    {
                        stopPlay = true;
                        levelController.Go(1);
                    }
                }

                else
                {
                    drawManager.RemoveLine();
                    drawManager.isDraw = false;
                }
                currentGO = null;
            }

            if (currentGO != null && currentGO == woman)
            {
                if (IsTouchingMouse(womanT))
                {
                    drawManager.isDraw = false;
                    isWoman = true;
                    if (fueWoman != null)
                        fueWoman.StopFue();
                    drawManager.womansLine = drawManager._currentLine;
                }

                else
                {
                    drawManager.RemoveLine();
                    drawManager.isDraw = false;
                }
                currentGO = null;
            }
            if (isMan && isWoman)
            {
                stopPlay = true;
                levelController.Go(2);
            }
            
        }
        
        if (data.isSound)
            drawManager.StopSound();
        checkStop = false;
    }
    private void CheckStop()
    {
        currentPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);        
        if (currentPos == oldPos)
        {
            stopTime-=Time.deltaTime;
            if(stopTime <= 0)
            {
                noSound = true;
            }            
        }
        else
        {
            stopTime = 0.5f;
            noSound = false;
        }
        
        if (data.isSound && !noSound)
        {
            drawManager.PlaySound();
        }

        if (noSound)
        {
            drawManager.StopSound();
        }
        oldPos = drawManager.mousePos;
    }
    
    private void Update()
    {
        if (stopPlay) return;
        if (checkStop)
        {
            CheckStop();
        }
        if (Input.GetMouseButtonDown(0))
        {
            CheckGO();
        }
        if (Input.GetMouseButtonUp(0))
        {
            CheckT();
        }
    }
}
