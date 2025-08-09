using UnityEngine;

public class Scorer : MonoBehaviour
{
    public int hits = 0;
    
    private void OnCollisionEnter(Collision other)
    {
        // 충돌한 물체가 Hit이 아니면 카운트를 한다.
        if (other.gameObject.tag != "Hit")
        {
            hits++;
            Debug.Log("You've bumped into a thing this many times: " + hits);
        }

    }
}
