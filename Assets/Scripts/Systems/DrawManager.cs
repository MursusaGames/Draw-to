using UnityEngine;

public class DrawManager : MonoBehaviour
{
    [SerializeField] private TouchDetector touchDetector;
    private Camera _cam;
    [SerializeField] private Line _linePrefabM;
    [SerializeField] private Line _linePrefabW;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private Transform linesParent;
    public bool isDraw;
    public const float RESOLUTION = .1f;
    public Vector2 mousePos;
    public Line _currentLine;
    public Line mansLine;
    public Line mans2Line;
    public Line womansLine;
    void Awake()
    {
        _cam = Camera.main;
    }
    public void PlaySound()
    {
        //audioSource.Play();
        audioSource.volume = 0.2f;
    }
    public void StopSound()
    {
        audioSource.volume = 0f;
    }
    public void RemoveLine()
    {
        Destroy(_currentLine.gameObject);
    }
    public void RemoveAllLine(int count)
    {
        if(count == 3&& mans2Line != null)
        {
            Destroy(mans2Line.gameObject);
        }
        else if(count == 2 && womansLine != null)
        {
            Destroy(womansLine.gameObject);
        }
        if(mansLine != null) 
            Destroy(mansLine.gameObject);
        
    }
    public void RemoveManLine()
    {
        Destroy(mansLine.gameObject);        
    }
    public void RemoveWomanLine()
    {
        Destroy(womansLine.gameObject);
    }
    void Update()
    {
        if (!isDraw) return;
        mousePos = _cam.ScreenToWorldPoint(Input.mousePosition);
        
        
        if (Input.GetMouseButtonDown(0)&&touchDetector.currentGO == touchDetector.man)
        {
            _currentLine = Instantiate(_linePrefabM, new Vector3(mousePos.x,mousePos.y, 1), Quaternion.identity,linesParent);
            mansLine = _currentLine;
        }
            
        if (Input.GetMouseButtonDown(0) && touchDetector.currentGO == touchDetector.woman)
        {
            _currentLine = Instantiate(_linePrefabW, mousePos, Quaternion.identity,linesParent);
            womansLine = _currentLine;
        }
        if (Input.GetMouseButtonDown(0) && touchDetector.currentGO == touchDetector.man2)
        {
            _currentLine = Instantiate(_linePrefabM, mousePos, Quaternion.identity,linesParent);
            mans2Line = _currentLine;
        }

        if (Input.GetMouseButton(0)) _currentLine.SetPosition(mousePos);

    }
}
