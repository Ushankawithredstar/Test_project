using UnityEngine;

public class AnimationEnd : MonoBehaviour
{

    private float delay = 0f;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length + delay); 
    }
}