using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    private Camera cam;
    [SerializeField]
    private float distance = 3f;
    [SerializeField]
    private float distanceEnemy = 24f;
    [SerializeField]
    private LayerMask layerMask;
    private PlayerUI playerUI;
    private InputManager inputManager;
    public Transform target;
    //public Transform[] enemies;

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<PlayerLook>().cam;
        playerUI = GetComponent<PlayerUI>();
        inputManager = GetComponent<InputManager>();

    }

    // Update is called once per frame
    void Update()
    {
        playerUI.UpdateText(string.Empty);
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * distance);
        RaycastHit hitInfo; //store collision information
        if ( Physics.Raycast(ray, out hitInfo, distance, layerMask) )
        {
            if(hitInfo.collider.GetComponent<Interactable>() != null)
            {
                Interactable interactable = hitInfo.collider.GetComponent<Interactable>();
                playerUI.UpdateText(interactable.promptMesssage);
                if (inputManager.onFoot.Interact.triggered)
                {
                    interactable.BaseInteract();
                }
            }
        }
        //Ray viewRay = cam.ViewportPointToRay(cam.WorldToViewportPoint(target.position));
        Ray viewRay = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        if (Physics.Raycast(viewRay, out hitInfo, distanceEnemy))
        {
            if (hitInfo.collider.GetComponent<EnemyMovement>() != null)
            {
                EnemyMovement enemyMovement = hitInfo.collider.GetComponent<EnemyMovement>();
                enemyMovement.sightedEnemy();
            }
        }
    }
}
