using Unity.VisualScripting;
using UnityEditor.EditorTools;
using UnityEngine;

public class ObjectHit : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        // 충돌한 물체가 Player 태그를 가지고 있으면,
        if (other.gameObject.tag == "Player")
        {
            // 컬러를 블랙으로 바꾸고 태그를 Hit 으로 바꾼다.
            GetComponent<MeshRenderer>().material.color = Color.black;
            gameObject.tag = "Hit";
        }
    }
}

