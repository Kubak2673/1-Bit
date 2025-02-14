using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;

public class PlayerSwitch : MonoBehaviour
{
    // Movement
    [SerializeField] MonoBehaviour player1Movement;
    [SerializeField] MonoBehaviour player2Movement;
    [SerializeField] MonoBehaviour player1Position;
    [SerializeField] MonoBehaviour player2Position;
    // Colliders
    [SerializeField] BoxCollider2D boxCollider1;
    [SerializeField] BoxCollider2D boxCollider2;
    [SerializeField] TilemapCollider2D tilemapCollider1;
    [SerializeField] TilemapCollider2D tilemapCollider2;
    [SerializeField] CapsuleCollider2D cCollider1;
    [SerializeField] CapsuleCollider2D cCollider2;
    // Walls & Grounds
    [SerializeField] GameObject GroundWandB;
    [SerializeField] GameObject GroundBandW;
    [SerializeField] GameObject Walls1;
    [SerializeField] GameObject Walls2;
    // Audio
    [SerializeField] AudioClip switchon;
    AudioSource audioSource;
    // BGS
    [SerializeField] Tilemap BG1;
    [SerializeField] Tilemap BG2;
    // Death
    [SerializeField] GameObject Death1;
    [SerializeField] GameObject Death2;
    // Platforms
    [SerializeField] Tilemap Platforms1;
    [SerializeField] Tilemap Platforms2;
    // Player Sprites
    [SerializeField] SpriteRenderer player1;
    [SerializeField] SpriteRenderer player2;
    [SerializeField] Sprite phase;
    [SerializeField] Sprite normal;
    private void Start() {
        audioSource = GetComponent<AudioSource>();
    }
    void OnInteract(InputValue value)
    {
        if (value.isPressed)
        {
            if(tilemapCollider1.enabled == true)
            {
                if (cCollider1.IsTouchingLayers(LayerMask.GetMask("Interact")) || cCollider2.IsTouchingLayers(LayerMask.GetMask("Interact")) || boxCollider1.IsTouchingLayers(LayerMask.GetMask("Interact")) || boxCollider2.IsTouchingLayers(LayerMask.GetMask("Interact")))
                {
                    return;
                }
                else {
                    SwitchPlayer1();
                }
            }
            else
            {
                if (cCollider1.IsTouchingLayers(LayerMask.GetMask("Interact")) || cCollider2.IsTouchingLayers(LayerMask.GetMask("Interact")) || boxCollider1.IsTouchingLayers(LayerMask.GetMask("Interact")) || boxCollider2.IsTouchingLayers(LayerMask.GetMask("Interact")))
                {
                    return;
                }
                else {
                    SwitchPlayer2();
                }
            }
        }
    }
    void SwitchPlayer1()
    {
        audioSource.PlayOneShot(switchon, 1f);
        player2Movement.enabled = true;
        player1Movement.enabled = false;
        player2Position.enabled = false;
        player1Position.enabled = true;
        tilemapCollider1.enabled = false;
        tilemapCollider2.enabled = true;
        BG1.color = Color.white;
        BG2.color = Color.black;
        Walls1.SetActive(false);
        Walls2.SetActive(true);
        Platforms1.color = Color.black;
        Platforms2.color = Color.white;
        player1.sprite = phase;
        player2.sprite = normal;
        GroundWandB.SetActive(false);
        GroundBandW.SetActive(true);
        Death1.SetActive(true);
        Death2.SetActive(false);
    }
    void SwitchPlayer2()
    {
        audioSource.PlayOneShot(switchon, 1f);
        player2Movement.enabled = false;
        player1Movement.enabled = true;
        player2Position.enabled = true;
        player1Position.enabled = false;        
        tilemapCollider1.enabled = true;
        tilemapCollider2.enabled = false;
        BG1.color = Color.black;
        BG2.color = Color.white;
        Walls1.SetActive(true);
        Walls2.SetActive(false);
        Platforms1.color = Color.white;
        Platforms2.color = Color.black;
        player1.sprite = normal;
        player2.sprite = phase;
        GroundWandB.SetActive(true);
        GroundBandW.SetActive(false);
        Death1.SetActive(false);
        Death2.SetActive(true);
    }
}
