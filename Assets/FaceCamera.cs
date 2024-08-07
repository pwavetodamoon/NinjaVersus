using UnityEngine;

public class FaceCamera : MonoBehaviour
{
    [SerializeField] private Transform _uiTransform;
    private Camera mainCamera;
    

    void Start()
    {
        // Lấy camera chính
        mainCamera = Camera.main;
    }

    void Update()
    {
        // Kiểm tra nếu camera chính tồn tại
        if (mainCamera != null)
        {
            // Quay mặt đối tượng về phía camera
            _uiTransform.transform.LookAt(mainCamera.transform);
            
            // Giữ cho UI không bị lộn ngược
            _uiTransform.transform.rotation = Quaternion.LookRotation(  _uiTransform.transform.position - mainCamera.transform.position);
        }
    }
}
