using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CameraControl3 : MonoBehaviour
{
    public Camera MainCamera;
    public GameObject MapButton;
    public GameObject Names;
    public GameObject Name;
    public float CamMoveSpeed = 2;
    public float CamSize = 540;
    float size;
    public float CamSizeSpeed = 2;
    bool canMove;
    public Vector3 Targetposition;
    GameObject Target;
    void Start()
    {
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
            Target.GetComponent<Image>().enabled = true;
        }
        canMove = true;
        Names.SetActive(false);
        MapButton.SetActive(true);
        Name.SetActive(true);
        switch(obj)
        {
            case "Province 1":
                Name.GetComponent<TMP_Text>().text = "Зерокотто\n";
                break;
            case "Province 2":
                Name.GetComponent<TMP_Text>().text = "Андройдзидзю\n";
                break;
            case "Province 3":
                Name.GetComponent<TMP_Text>().text = "Напитонэ\n";
                break;
            case "Province 4":
                Name.GetComponent<TMP_Text>().text = "Реляохоки\n";
                break;
            case "Province 5":
                Name.GetComponent<TMP_Text>().text = "Чатаботто\n";
                break;
            case "Province 6":
                Name.GetComponent<TMP_Text>().text = "Играхаги\n";
                break;
            case "Province 7":
                Name.GetComponent<TMP_Text>().text = "Джаваскрипту\n";
                break;
        }
        Target = GameObject.Find(obj);        
        Target.GetComponent<Image>().enabled = false;
        Target.GetComponent<Province>().ActiveTasks();
        CamSize = 170;
        Targetposition.y = Target.transform.position.y;
        Targetposition.x = Target.transform.position.x;
    }
    public void ResetTarget()
    {
        if (Target != null)
        {
            Target.GetComponent<Province>().UnActiveTasks();
            Target.GetComponent<Image>().enabled = true;
        }
        Names.SetActive(true);
        MapButton.SetActive(false);
        Name.SetActive(false);
        canMove = true;
        CamSize = 540;
        Targetposition.y = 540;
        Targetposition.x = 960;
    }
}
