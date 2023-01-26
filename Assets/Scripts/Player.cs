using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public bool isStart = false;
    private Creator playerCreator;
    private GameManager gm;
    [SerializeField] private LayerMask Wall;
    private float minXBound = -4.75f;
    private float maxXBound = 4.75f;
    public float speed = 8f;

    private void Awake()
    {
        playerCreator = GameObject.FindGameObjectWithTag("base").GetComponent<Creator>();
        gm = GameObject.FindGameObjectWithTag("manager").GetComponent<GameManager>();
    }

    private void Update()
    {
        if (playerCreator.totalSize <= 0)
        {
            isStart = false;
            gm.restartPanel.SetActive(true);
            
        }

        if (gm.isRestart)
        {
            gm.startPanel.SetActive(false);
        }
        if (isStart)
        {
            if (Input.GetMouseButton(0))
            {
                Move();
            }

            transform.position = new Vector3(Mathf.Clamp(transform.position.x, minXBound, maxXBound), transform.position.y, transform.position.z);
        }
        
    }

    private void FixedUpdate()
    {
        if (isStart){ 
        transform.Translate(Vector3.forward * speed * Time.fixedDeltaTime);
        }    
    }

    public void Move()
    {
        float swipeSpeed = 10f;
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.transform.localPosition.z;

        Ray ray = Camera.main.ScreenPointToRay(mousePos);

        if (Physics.Raycast(ray, out RaycastHit hit, 50))
        {
            Vector3 hitPoint = hit.point;
            hitPoint.y = transform.position.y;
            hitPoint.z = transform.position.z;

            transform.position = Vector3.MoveTowards(transform.position, hitPoint, Time.deltaTime * swipeSpeed);
        }
    }
        /* TOUCH ÝLE HAREKET 
        transform.Translate(Vector3.left * Time.deltaTime * main_speed);
        if (Input.touchCount > 0)
        {
            theTouch = Input.GetTouch(0);

            if (theTouch.phase == TouchPhase.Moved)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + theTouch.deltaPosition.x * speed);
            }
        }
}*/

}
