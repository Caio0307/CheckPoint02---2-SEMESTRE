using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField]private GameObject target;
    [SerializeField] private float speedCamera;
    [SerializeField]private float Uplimit,DownLimit,LeftLimit,RightLimit;


    private void Awake()
    {
        target = GameObject.Find("Player");
    }


    private void Update()
    {

        if (target == null) return;

        Vector3 p = new Vector3(target.transform.position.x, target.transform.position.y,transform.position.z);


        p.x = Mathf.Clamp(p.x, LeftLimit, RightLimit);
        p.y = math.clamp(p.y, DownLimit, Uplimit);


        transform.position = Vector2.Lerp(transform.position, p, speedCamera * Time.deltaTime);







    }





}
