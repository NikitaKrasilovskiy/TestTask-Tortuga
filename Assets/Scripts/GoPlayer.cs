using UnityEngine;

public class GoPlayer : MonoBehaviour
{
    public GameObject player;
    void Start()
    { Instantiate(player, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity); }
}