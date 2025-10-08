using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum CameraState
{
    MainMenu = 0,
    GamePlay = 1,
    Shop = 2
}
public class CameraFollow : Singleton<CameraFollow>
{
    [SerializeField] List<DataCamera> dataCameras;
    public Transform Target;
    public float speed = 20f;
    private DataCamera dataCamera;
    // Start is called before the first frame update
    void Start()
    {
        Target = FindObjectOfType<PlayerController>().transform;
        ChangeCamera(CameraState.MainMenu);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, Target.position + dataCamera.position, speed * Time.fixedDeltaTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(dataCamera.rotation), speed * Time.fixedDeltaTime);

    }
    public void ChangeCamera(CameraState cameraState)
    {
        dataCamera = dataCameras[(int)cameraState];
    }
    public void UpdateCamera()
    {
        dataCamera.position.y += 3f;
        dataCamera.position.z -= 3f;
    }

}
[System.Serializable]
public class DataCamera
{
    public CameraState name;
    public Vector3 position;
    public Vector3 rotation;
}


