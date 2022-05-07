using UnityEngine;
using UnityEngine.UI;
public class ChasingObstacle : MonoBehaviour
{

    public Transform Player;
    public int MoveSpeed = 1;
    //public int MaxDist = 10;
    //public int MinDist = 5;

    void Update()
    {
        //transform.LookAt(Player, Vector3.forward);

       var step = MoveSpeed * Time.deltaTime; // calculate distance to move
       transform.position = Vector3.MoveTowards(transform.position, Player.position, step);

        
    }
}