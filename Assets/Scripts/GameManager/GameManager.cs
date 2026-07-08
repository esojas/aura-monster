using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Transform mainGamePosition;
    [SerializeField] private Transform sideGamePosition;

    private MusicEvent musicEvent;

    private bool GameStateChange = false;

    private void OnEnable()
    {
        musicEvent.GameStateChangeEvent += HandleGameState;
    }

    private void OnDisable()
    {
        musicEvent.GameStateChangeEvent -= HandleGameState;
    }

    private void HandleGameState(bool state)
    {
        GameStateChange = state;
        HandlePlayerPos(GameStateChange);
    }

    private void HandlePlayerPos(bool sideState)
    {
        Vector3 targetPos = sideState ? mainGamePosition.position : sideGamePosition.position;

        CharacterController controller = player.GetComponent<CharacterController>();
        if (controller != null)
        {
            controller.enabled = false;
            player.transform.position = targetPos;
            controller.enabled = true;
        }
        else
        {
            player.transform.position = targetPos;
        }
    }

    private void Awake()
    {
        musicEvent = GetComponent<MusicEvent>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player.transform.position = mainGamePosition.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
