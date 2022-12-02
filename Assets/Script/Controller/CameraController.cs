using UnityEngine;
using System.Collections;
using TMPro;

public class CameraController : MonoBehaviour
{ 
    public float offsetX = -5;  //The offset of the camera to centrate the player in the X axis
    public float offsetY = 0;   //The offset of the camera to centrate the player in the Y axis
    public float offsetZ = 0;   //The offset of the camera to centrate the player in the Z axis
    public float maximumDistance = 2;  //The maximum distance permited to the camera to be far from the player, its used to     make a smooth movement
    public float playerVelocity = 10;  //The velocity of your player, used to determine que speed of the camera
    public TextMeshProUGUI xValueText;
    public TextMeshProUGUI yValueText;
    public TextMeshProUGUI zValueText;

    private GameObject player;
    private float movementX;
    private float movementY;
    private float movementZ;

    private void Start()
    {
        player = PlayerManager.Instance.PlayerGameObject;    
    }

    // Update is called once per frame
    void Update()
    {
        xValueText.text = offsetX.ToString();
        yValueText.text = offsetY.ToString();
        zValueText.text = offsetZ.ToString();
        movementX = ((player.transform.position.x + offsetX - this.transform.position.x)) / maximumDistance;
        movementY = ((player.transform.position.y + offsetY - this.transform.position.y)) / maximumDistance;
        movementZ = ((player.transform.position.z + offsetZ - this.transform.position.z)) / maximumDistance;
        this.transform.position += new Vector3((movementX * playerVelocity * Time.deltaTime), (movementY * playerVelocity * Time.deltaTime), (movementZ * playerVelocity * Time.deltaTime));
    }

    public void PlusOffsetX()
    {
        offsetX += 0.1f; 
    }

    public void MinusOffsetX()
    {
        offsetX -= 0.1f;
    }

    public void PlusOffsetY()
    {
        offsetY += 0.1f;
    }

    public void MinusOffsetY()
    {
        offsetY -= 0.1f;
    }

    public void PlusOffsetZ()
    {
        offsetZ += 0.1f;
    }

    public void MinusOffsetZ()
    {
        offsetZ -= 0.1f;
    }
}