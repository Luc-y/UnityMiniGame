using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{

    [SerializeField] float levelLoadDelay = 2f;
    [SerializeField] AudioClip successSFX;
    [SerializeField] AudioClip crashSFX;
    [SerializeField] ParticleSystem successParticles;
    [SerializeField] private ParticleSystem crashParticles;
    
    AudioSource audioSource;
    
    bool isControllable = true;
    bool isCollidable = true;
    
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        RespondToDebugKeys();
    }

    private void RespondToDebugKeys()
    {
        if (Keyboard.current.lKey.wasPressedThisFrame)
        {
            LoadNextLevel();
        }
        else if (Keyboard.current.cKey.wasPressedThisFrame)
        {
            isCollidable = !isCollidable; // false로 변경 = 콜리젼 온/오프
            Debug.Log("c Key was Pressed");
        }
    }
    
    private void OnCollisionEnter(Collision other)
    {

        if (!isControllable || !isCollidable)
        {
            return; // 아무것도 하지 않는다.
        }
            
        switch (other.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("Everything is looking good");
                break;
            case "Finished":
                StartSuccessSequence();
                break;
            default:
                StartCrashSequence();
                break;
        }
    }

    private void StartSuccessSequence()
    {
        isControllable = false;
        audioSource.Stop(); // 모든 효과음을 중지하고
        audioSource.PlayOneShot(successSFX); // successSFX 효과를 출력한다.
        successParticles.Play();
        GetComponent<Movement>().enabled = false; // Movement.cs도 같은 오브젝트 안의 스크립트이기 때문에 호출 가능
        Invoke("LoadNextLevel", levelLoadDelay);
    }

    private void StartCrashSequence()
    {
        isControllable = false;
        audioSource.Stop();
        audioSource.PlayOneShot(crashSFX);
        crashParticles.Play();
        GetComponent<Movement>().enabled = false; // Movement.cs도 같은 오브젝트 안의 스크립트이기 때문에 호출 가능
        Invoke("ReloadLevel", levelLoadDelay);
    }

    private void ReloadLevel()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene);
    }

    private void LoadNextLevel()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        int nextScene = currentScene + 1;
        
        if (nextScene == SceneManager.sceneCountInBuildSettings)
        {
            nextScene = 0;
        }
        SceneManager.LoadScene(nextScene);
 

    }

    private void ActionFriendly()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }
}
