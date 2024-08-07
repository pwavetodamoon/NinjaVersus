using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHPController : MonoBehaviour
{
    [SerializeField] private Health _characterHealth;
    [SerializeField] private Slider _sliderCurrentHealth;
    [SerializeField] private Slider _sliderHealthTrail;
    private Camera _mainCamera;
    private float _trailLerpSpeed = 2f; // Tốc độ của hiệu ứng trail

    private void Awake()
    {
        if (_characterHealth == null)
        {
            _characterHealth = GetComponent<Health>();
        }

        _sliderCurrentHealth.maxValue = _characterHealth.MaxHealth;
        _sliderHealthTrail.maxValue = _characterHealth.MaxHealth;
        _mainCamera = Camera.main; // Lấy camera chính
    }

    void Start()
    {
        _sliderCurrentHealth.value = _characterHealth.CurrentHealth;
        _sliderHealthTrail.value = _characterHealth.CurrentHealth;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateHealthSliders();
        FaceCamera(); // Cập nhật hướng của thanh máu để đối diện camera
    }

    private void UpdateHealthSliders()
    {
        if (_characterHealth.CurrentHealth <= 0)
        {
            Destroy(_sliderCurrentHealth.gameObject); // Xóa slider khi lượng máu <= 0
            Destroy(_sliderHealthTrail.gameObject); // Xóa luôn slider trail
        }
        else
        {
            // Cập nhật giá trị thanh máu hiện tại ngay lập tức
            _sliderCurrentHealth.value = _characterHealth.CurrentHealth;
            
            // Sử dụng lerp để tạo hiệu ứng trail mượt mà
            _sliderHealthTrail.value = Mathf.Lerp(_sliderHealthTrail.value, _characterHealth.CurrentHealth, Time.deltaTime * _trailLerpSpeed);
        }
    }

    private void FaceCamera()
    {
        // Đặt hướng của thanh máu để đối diện camera
        _sliderCurrentHealth.transform.LookAt(_mainCamera.transform);
        _sliderCurrentHealth.transform.Rotate(0, 180, 0); // Xoay 180 độ để đối diện camera
        
        _sliderHealthTrail.transform.LookAt(_mainCamera.transform);
        _sliderHealthTrail.transform.Rotate(0, 180, 0); // Xoay 180 độ để đối diện camera
    }
}
