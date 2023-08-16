using UnityEngine;

public class Mina : MonoBehaviour
{
    private AudioSource audioSource;
    [SerializeField] private MatchData data;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        if (data.isSound)
        {
            audioSource.enabled = true;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Fence"))
        {
            Debug.Log(collision.gameObject.name);
            collision.gameObject.SetActive(false);
        }
    }

}
