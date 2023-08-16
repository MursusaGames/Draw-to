using UnityEngine;

public class Will : MonoBehaviour
{
    [SerializeField] private MatchData data;
    [SerializeField] private float speed;
    public bool demo;
    private bool isRotate;
    void OnEnable()
    {
        if (demo)
        {
            isRotate = true;
            return;
        }
            if (data.currentSkin > 0)
        {
            gameObject.SetActive(false);
        }
        else
        {
            isRotate = true;
        }
    }

    
    void Update()
    {
        if (isRotate)
        {
            gameObject.transform.Rotate(Vector3.forward, speed * Time.deltaTime);
        }
        
    }
}
