using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using Utilities;

[RequireComponent(typeof(BoxCollider))]
[RequireComponent(typeof(Rigidbody))]

public class DragObjects : MonoBehaviour
{
    [Tooltip("The Yellow area LayerMask, used for the Distance Traveled statistic")]
    public LayerMask YellowZoneLayer;

    [Tooltip("The Green area LayerMask, used for the Distance Traveled statistic")]
    public LayerMask GreenZoneLayer;

    [Tooltip("The Blue area LayerMask, used for the Distance Traveled statistic")]
    public LayerMask BlueZoneLayer;

    [Tooltip("The Red area LayerMask, used for the Distance Traveled statistic")]
    public LayerMask RedZoneLayer;

    private LayerMask _contactLayer;
    private Statistics _stats;

    private int _fingerID = -1;
    private Rigidbody _rb;
    private bool isTouching = false;
    private Vector2 _currentPosition;
    private List<Vector2> _positions = new List<Vector2>();

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        //Stats are not used in the tutorial
        if (!SceneManager.GetActiveScene().Equals(SceneManager.GetSceneByName(Scenes.Tutorial.ToString())))
            _stats = GameObject.Find("Stats").GetComponent<Statistics>();

        //cache the correct layer to use on UpdateLayer
        switch (tag)
        {
            case "YellowObject": _contactLayer = YellowZoneLayer; break;
            case "GreenObject": _contactLayer = GreenZoneLayer; break;
            case "BlueObject": _contactLayer = BlueZoneLayer; break;
            case "RedObject": _contactLayer = RedZoneLayer; break;
            default: Debug.Log("Layer of " + name + " not found."); break;
        }
    }

    private void Update()
    {
        _currentPosition = new Vector2(transform.position.x,transform.position.y);
        if (!isTouching)
        {
            MultiTouch();
        }
        else
        {
            ResetPosition();
        }
        _positions.Add(_currentPosition);
        KeepInside();
        CheckLayerCollision();
    }

    private void MultiTouch()
    {
        Touch[] myTouches = Input.touches;

        for (int i = 0; i < Input.touchCount; i++)
        {
            Touch touch = myTouches[i];
            switch (touch.phase)
            {        
                case TouchPhase.Began:
                    RaycastHit hit;
                    Ray ray = Camera.main.ScreenPointToRay(touch.position);
                    if (Physics.Raycast(ray, out hit))
                    {
                        if (hit.collider.gameObject == this.gameObject)
                        {
                            _fingerID = touch.fingerId;
                        }
                    }
                    break;

                case TouchPhase.Moved:
                    if (_fingerID == touch.fingerId)
                    {
                        Vector2 worldPosition = Camera.main.ScreenToWorldPoint(touch.position);
                        transform.position = worldPosition;
                    }
                    break;

                case TouchPhase.Ended:
                    if (_fingerID == touch.fingerId)
                    {
                        _fingerID = -1;
                    }
                    break;
            }
        }
    }

    //private void OnMouseDrag()
    //{
    //    Vector2 mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
    //    Vector2 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
    //    transform.position = objPosition;
    //}

    public void OnCollisionEnter(UnityEngine.Collision collision)
    {
        if ((tag == "YellowObject"  || tag == "RedObject"  || tag == "BlueObject"  || tag == "GreenObject") && collision.gameObject.tag == "Wall")
        {
            isTouching = true;
            _fingerID = -1;
        }
    }

    private void ResetPosition()
    {
        if (isTouching)
        {
            //gameObject.transform.position = startPosition;
            var oneback = new Vector2(0,0);
            if (_positions.Count > 0)
            {
                oneback = _positions[_positions.Count - 2];  
            }
            else
            {
                return;
            }
            gameObject.transform.position = oneback;
            gameObject.SetActive(false);
            isTouching = false;
            gameObject.SetActive(true);
        }
    }

    private void CheckLayerCollision()
    {
        //raycast to find the layer
        if (Physics.Raycast(transform.position + Vector3.back * 1, transform.forward, out RaycastHit hit, Mathf.Infinity, _contactLayer))
        {
            string area = tag.ToString().Substring(0, tag.Length - 6);
            float dist = Vector2.Distance(_positions[_positions.Count-1], _positions[_positions.Count - 2]);

            _stats.IncrementDistance(area, dist);
        }
        else
        {
            Debug.DrawRay(transform.position + Vector3.back * 1, transform.forward, Color.red);
        }
    }

    private void KeepInside()
    {
        if (_rb.position.x < -8.5f)
            _rb.position = new Vector2(-8.5f, _rb.position.y);
        if (_rb.position.x > 8.5f)
            _rb.position = new Vector2(8.5f, _rb.position.y);
        if (_rb.position.y < -4.5f)
            _rb.position = new Vector2(_rb.position.x, -4.5f);
        if (_rb.position.y > 4.5f)
            _rb.position = new Vector2(_rb.position.x, 4.5f);
    }

}