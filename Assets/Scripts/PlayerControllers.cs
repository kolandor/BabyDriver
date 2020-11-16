using UnityEngine;
using System.Collections;

public class PlayerControllers : MonoBehaviour {

    public float speed = 6.0F;
    public float jumpValue = 8.0F;
    public float gravity = 20.0F;

    /// <summary>
    /// Изначальный вектор который мы используем 
    /// для формирования направления движения объекта персонажа
    /// (Он и есть напрвление)
    /// </summary>
    private Vector3 moveDirection = Vector3.zero;
    void Update()
    {
        /// Получаем компонент CharacterController, который прикреплен к текущему GameObject
        CharacterController controller = GetComponent<CharacterController>();
        if (controller.isGrounded)///Проверяем или объект стоит на земле
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            //Debug.Log("Input.GetAxis = " + moveDirection);
            /// Преобразование кординат текущего объекта из локальных в  world space
            /// Суть:
            /// Допустим Vector3.forward, это направление вперёд (увеличение Z), но если наш объект 
            /// повернут на 90* вправо По логике объект двигаясь вперед должен двигаться вправо 
            /// относительно мира, но если мы используем Vector3.forward для его передвижения 
            /// вперед, то объект начнет двигаться влево. Всё потому, что Vector3.forward просто 
            /// увеличивает координату Z, а для нашего объекта движение вперед это увеличение X 
            /// TransformDirection(Vector3.forward) преобразует вектор таким образом, что направление 
            /// станет верным по отношению объекта к мировым координатам, следовательно вектор Vector3.forward 
            /// изменит своё направление применив на Vector3.forward ротацию объекта
            moveDirection = transform.TransformDirection(moveDirection);

            //Таким образом все направления умножаются на скорость
            moveDirection *= speed;
            if (Input.GetButton("Jump"))///Проверка на нажатие кнопки прыжка
            {
                /// Тут выставляется высота Y вектора, не положение объекта
                moveDirection.y = jumpValue;
            }

        }
        /// Отнимаем гравитацию 
        //Debug.Log("moveDirection.y = " + moveDirection.y + " / gravity * Time.deltaTime = " + gravity * Time.deltaTime);
        moveDirection.y -= gravity * Time.deltaTime;

        ///применение результатов
        ///Этот метод начнёт передвижение объекта согласно ранее свормированному вектору
        controller.Move(moveDirection * Time.deltaTime);
    }


}
