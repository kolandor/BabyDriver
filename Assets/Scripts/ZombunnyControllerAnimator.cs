using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombunnyControllerAnimator : MonoBehaviour
{
    private Animator _animator;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_animator != null)
        {
            
            if (Input.GetMouseButtonDown(0))///вернёт true если нажатая нажата переданная кнопка мыши (левая)
            {
                _animator.SetBool("IdleBool", true);///устанавливаем значение состояния ожидания (анимация простоя)
            }
            else if (Input.GetMouseButtonDown(1))///вернёт true если нажатая нажата переданная кнопка мыши (правая)
            {
                _animator.SetBool("IdleBool", false);///устанавливаем значение состояния ожидания (анимация ходьбы)
            }
            else if (Input.GetKeyDown(KeyCode.Space))///вернёт true если нажатая нажата переданная кнопка мыши (правая)
            {
                _animator.SetInteger("Life", 0);///устанавливаем значение жизней на 0 (анимация смерти)
            }
        }
    }
}
