/*
using UnityEngine;
using UnityEngine.SceneManagement;
/*


    public Transform playerTransform;
    public float distance = 10.0f; // Adjust this value to control camera distance from player
    public float smoothSpeed = 0.1f; // Adjust this value for camera movement smoothness

    private void LateUpdate()
    {
        if (playerTransform != null)
        {
            // Calculate the target position behind the player based on the distance
            Vector3 targetPosition = playerTransform.position - playerTransform.forward * distance;
            targetPosition.z = targetPosition.z +10;
            targetPosition.x = targetPosition.x + 5;
            // Smoothly move the camera towards the target position
            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed);

            // Rotate the camera to match the player's rotation (without affecting its position)
            transform.rotation = Quaternion.Euler(0f, playerTransform.eulerAngles.y-90f, 0f);
        }
    }

 

*/

/*
public class CameraController : MonoBehaviour
{
    private Transform playerTransform;
    private Vector3 offset = new Vector3(8, 13, 1);
    private Vector3 secondOffset = new Vector3(8, 2, 0);
    private Quaternion defaultRotation;

    private void Start()
    {
        // Set the default rotation of the camera
        defaultRotation = Quaternion.Euler(0f, 267.576996f, 0f);
        transform.rotation = defaultRotation;
    }

    private void LateUpdate()
    {
        // Check if the playerTransform is assigned
        if (playerTransform != null)
        {
            
            Vector3 centerPosition = CalculateCenterPosition();
            Vector3 targetOffset = SceneManager.GetActiveScene().name == "Pyramiden" ?
                                    secondOffset : offset;

            
            Vector3 targetPosition = playerTransform.position + targetOffset;
            Vector3 direction = targetPosition - centerPosition;
            
            transform.position = SceneManager.GetActiveScene().name == "Pyramiden" ?
                                    (centerPosition + direction) : (centerPosition + direction) + new Vector3(0, -10f, 0);

            transform.rotation = Quaternion.Euler(0f, playerTransform.eulerAngles.y - 90f, 0f);
        }
    }

    
    private Vector3 CalculateCenterPosition()
    {
        Bounds bounds = new Bounds(Vector3.zero, Vector3.zero);
        foreach (Renderer renderer in FindObjectsOfType<Renderer>())
        {
            bounds.Encapsulate(renderer.bounds);
        }
        return bounds.center;
    }

    public void SetPlayer(GameObject player)
    {
        playerTransform = player.transform;
    }
}
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Transform playerTransform;
    [SerializeField] Vector3 offset;
    [SerializeField] float smoothSpeed = 12f;
    private void LateUpdate()
    {
        if (playerTransform != null)
        {
           
            Vector3 desiredPosition = playerTransform.position + playerTransform.rotation * offset;

      
            transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

            transform.LookAt(playerTransform);
        }
    }
    public void setPlayer(GameObject player)
    {

        playerTransform = player.transform;


    }
}