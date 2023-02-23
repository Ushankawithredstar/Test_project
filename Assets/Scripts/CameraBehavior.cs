using UnityEngine;

public class CameraBehavior : MonoBehaviour
{

    private Transform Player;
    private Vector3 TempPos;

    [SerializeField]
    private float minX;
    [SerializeField]
    private float maxX;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        TempPos = transform.position;
        TempPos.x = Player.position.x;

        if (TempPos.x < minX) //fixes the camera position near the level borders
        {
            TempPos.x = minX;
        }

        if (TempPos.x > maxX)
        {
            TempPos.x = maxX;
        }
        transform.position = TempPos;
    }

}
