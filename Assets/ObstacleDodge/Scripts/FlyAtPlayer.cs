using UnityEngine;

public class FlyAtPlayer : MonoBehaviour
{
    [SerializeField] float speed = 1f;
    [SerializeField] Transform player; // 오브젝트 선택
    Vector3 playerPosition;

    void Awake()
    {
        gameObject.SetActive(false);
    }
    
    void Start()
    {
        // 플레이어 포지션
        playerPosition = player.transform.position;
        DestroyWhenReached();
    }

    void Update()
    {
        MoveToPlayer();
        DestroyWhenReached();
    }

    void MoveToPlayer()
    {
        transform.position = Vector3.MoveTowards(transform.position, playerPosition, speed * Time.deltaTime);
    }
    
    void DestroyWhenReached()
    {
        if (transform.position == playerPosition)
        {
            Destroy(gameObject);
        }
    }
}
