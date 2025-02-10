using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Exit : MonoBehaviour
{
    [SerializeField] ParticleSystem ext;
    [SerializeField] float waitTime = 3f;
    [SerializeField] Animator transition;
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
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
