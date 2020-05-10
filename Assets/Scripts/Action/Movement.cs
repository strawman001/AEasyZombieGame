namespace zFrame.Example
{
    using UnityEngine;
    using zFrame.UI;
    public class Movement : MonoBehaviour
    {
        [SerializeField] Joystick joystick;
        public float speed = 5;
        CharacterController controller;
        void Start()
        {
            controller = GetComponent<CharacterController>();

            joystick.OnValueChanged.AddListener(v =>
            {
                if (v.magnitude != 0)
                {
                    Vector3 direction = new Vector3(v.x, 0, v.y);
                    controller.Move(direction * speed * Time.deltaTime);
                    transform.rotation = Quaternion.LookRotation(new Vector3(v.x, 0, v.y));
                }
            });
        }
    }
}
