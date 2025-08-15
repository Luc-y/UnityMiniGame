using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    
    private void OnCollisionEnter(Collision other)
    {
        switch (other.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("Everything is looking good");
                break;
            case "Fuel":
                Debug.Log("Why did you pick me up, I'm not in this game");
                break;
            case "Finished":
                Debug.Log("You're all done, Welcome to our country");
                break;
            default:
                Debug.Log("You crashed dummy");
                break;
        }
    }

    private void ActionList()
    {
        
    }
    
    private void ActionFriendly()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }

    private void ActionFuel()
    {
        
    }

    private void ActionFinished()
    {
        
    }
    
}
