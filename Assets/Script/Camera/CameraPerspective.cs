using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPerspective : MonoBehaviour
{
    private const string TAG = "CameraPerspective";
    private Transform playerTran = null;
    private Camera myCamera;
    private Material transparentMat;
    private Material originMat;

    // Start is called before the first frame update
    void Start()
    {
        myCamera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerTran == null)
            playerTran = PlayerManager.Instance.PlayerGameObject.transform;

        RaycastHit[] hits;
        hits = Physics.RaycastAll(transform.position, playerTran.position - transform.position, 7.0f);

        if(hits.Length > 0)
        {
            for (int i = 0; i < hits.Length; i++)
            {
                RaycastHit hit = hits[i];

                Renderer rend = hit.transform.GetComponent<Renderer>();

                if (rend)
                {
                    // Change the material of all hit colliders
                    // to use a transparent shader.
                    rend.material.shader = Shader.Find("UI/Unlit/Transparent");
                    Color tempColor = rend.material.color;
                    tempColor.a = 0.3F;
                    rend.material.color = tempColor;
                }
            }
        }
        else
        {

        }
    }
}
