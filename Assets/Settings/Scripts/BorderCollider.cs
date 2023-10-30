using System;
using UnityEngine;

public class BorderCollider : MonoBehaviour{
    [SerializeField] private CameraMovement cam;

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Player") {
            int index = this.getIndex(other);

            float otherPosition = other.transform.position[index];
            float thisPosition = transform.position[index];

            this.cam.rotateCamera();
            other.gameObject.GetComponent<PlayerMovement>().rotatePlayer();
        }
    }

    private int getIndex(Collider other){
        string[] axles = { "x", "y", "z" };
        string axis = other.gameObject.GetComponent<PlayerMovement>().getCurrentMovementAxis();

        return Array.IndexOf(axles, axis);
    }
}
