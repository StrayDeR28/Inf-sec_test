using UnityEngine;
using UnityEngine.UI;

public class CameraControl3 : MonoBehaviour
{
    public Camera MainCamera;
    public float CamMoveSpeed = 2;
    public float CamSize = 540;
    float size;
    public float CamSizeSpeed = 2;
    bool canMove;
    bool onStartPos;
    public Vector3 Targetposition;
    GameObject Target;
    void Start()
    {
        onStartPos = true;
        canMove = false;
        Targetposition.y = 540;
        Targetposition.x = 960;
        Targetposition.z = -10;
    }

    void Update()
    {   
        if (Input.GetKeyDown(KeyCode.Tab) && Target != null) ResetTarget();
        if (Targetposition.x == Mathf.Round(MainCamera.transform.position.x) && Targetposition.y == Mathf.Round(MainCamera.transform.position.y)
                                                                             && CamSize == Mathf.Round(MainCamera.orthographicSize))
        {
            canMove = false;
            MainCamera.transform.position = Targetposition;
            MainCamera.orthographicSize = CamSize;
            if (!onStartPos) 
            {
                Target.GetComponent<Province>().ActiveTasks();
            }
        }
        if (canMove)
        {
            float moveInterpolation = CamMoveSpeed * Time.deltaTime;
            float sizeInterpolation = CamSizeSpeed * Time.deltaTime;
            
            Vector3 position = MainCamera.transform.position;
            position.y = Mathf.Lerp(MainCamera.transform.position.y, Targetposition.y, moveInterpolation);
            position.x = Mathf.Lerp(MainCamera.transform.position.x, Targetposition.x, moveInterpolation);
            size = Mathf.Lerp(MainCamera.orthographicSize, CamSize, sizeInterpolation);

            MainCamera.transform.position = position;
            MainCamera.orthographicSize = size;
        }
    }
    public void SetTarget(string obj)
    {
        if (Target != null)
        {
            Target.GetComponent<Province>().UnActiveTasks();
            Target.GetComponent<Button>().interactable = true;
        }
        onStartPos = false;
        canMove = true;
        Target = GameObject.Find(obj);        
        Target.GetComponent<Button>().interactable = false;
        Target.GetComponent<Province>().ActiveTasks();
        CamSize = 150;
        Targetposition.y = Target.transform.position.y;
        Targetposition.x = Target.transform.position.x;
    }
    public void ResetTarget()
    {
        if (Target != null)
        {
            Target.GetComponent<Province>().UnActiveTasks();
            Target.GetComponent<Button>().interactable = true;
        }
        onStartPos = true;
        canMove = true;
        CamSize = 540;
        Targetposition.y = 540;
        Targetposition.x = 960;
    }
}
