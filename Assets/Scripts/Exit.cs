using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Exit : MonoBehaviour
{
    [SerializeField] ParticleSystem ext;
    [SerializeField] GameObject exitExplode;
    [SerializeField] AudioClip exit;
    AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            audioSource.PlayOneShot(exit, 1f);
            ext.Play();
            StartCoroutine(WaitAndLoadScene());
        }
    }

    private IEnumerator WaitAndLoadScene()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
