using Unity.Mathematics;
using UnityEngine;

public class CameraMovement : MonoBehaviour{
    [SerializeField] private float speed;
    private float currentPosX;
    private Vector3 velocity = Vector3.zero;
    private float smooth = 5.0f;
    private Quaternion targetRotation;

    [SerializeField] private Transform player;

    // Update is called once per frame
    private void Update(){
        transform.position = new Vector3(player.position.x, transform.position.y, transform.position.z);
    }

    public void rotateCamera(){
        Debug.Log(this.transform.rotation);

        transform.Rotate(0f, 90f, 0f);
    }   
}
