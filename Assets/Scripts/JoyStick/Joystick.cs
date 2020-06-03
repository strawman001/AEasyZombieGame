namespace zFrame.UI
{
    using UnityEngine;
    using UnityEngine.EventSystems;
    using UnityEngine.Events;
    using UnityEngine.UI;

    public class Joystick : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
    {
        public float maxRadius = 100; //Handle max raduis
        [EnumFlags]
        public Direction activatedAxis = (Direction)(-1); //choose the direction
        [SerializeField] bool dynamic = true; // dynamic handle
        [SerializeField] Transform handle; //
        [SerializeField] Transform backGround; //
        public JoystickEvent OnValueChanged = new JoystickEvent(); //Event： Draging joystick
        public JoystickEvent OnPointerDown = new JoystickEvent(); // Event： pointdown joystick
        public JoystickEvent OnPointerUp = new JoystickEvent(); //Event： pointup joystick
        public bool IsDraging { get { return fingerId != int.MinValue; } } //draging situation
        public bool DynamicJoystick //set whether dynamic
        {
            set
            {
                if (dynamic != value)
                {
                    dynamic = value;
                    ConfigJoystick();
                }
            }
            get
            {
                return dynamic;
            }
        }
        #region MonoBehaviour functions
        private void Awake() => backGroundOriginLocalPostion = backGround.localPosition;
        void Update()=>OnValueChanged.Invoke(handle.localPosition / maxRadius); 
        void OnDisable() => RestJoystick(); //Need to be reset if Disable 
        #endregion

        #region The implement of pointer event Interface
        void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
        {
            if (eventData.pointerId < -1 || IsDraging) return; //only respond one touch
            fingerId = eventData.pointerId;
            pointerDownPosition = eventData.position;
            if (dynamic)
            {
                pointerDownPosition[2] = eventData.pressEventCamera?.WorldToScreenPoint(backGround.position).z ?? backGround.position.z;
                backGround.position = eventData.pressEventCamera?.ScreenToWorldPoint(pointerDownPosition) ?? pointerDownPosition; ;
            }
            OnPointerDown.Invoke(eventData.position);
        }

        void IDragHandler.OnDrag(PointerEventData eventData)
        {
            if (fingerId != eventData.pointerId) return;
            Vector2 direction = eventData.position - (Vector2)pointerDownPosition; //get the vector od BackGround to Handle 
            float radius = Mathf.Clamp(Vector3.Magnitude(direction), 0, maxRadius); //get and sure the length of vector, to control the Handle's radius
            Vector2 localPosition = new Vector2()
            {
                x = (0 != (activatedAxis & Direction.Horizontal)) ? (direction.normalized * radius).x : 0, //Confirm whether to activate horizontal axis
                y = (0 != (activatedAxis & Direction.Vertical)) ? (direction.normalized * radius).y : 0       //Confirm whether to activate vertical axis
            };
            handle.localPosition = localPosition;      //refresh Handle situation
        }

        void IPointerUpHandler.OnPointerUp(PointerEventData eventData)
        {
            if (fingerId != eventData.pointerId) return;//only right point up will reset joystick
            RestJoystick();
            OnPointerUp.Invoke(eventData.position);
        }
        #endregion

        #region Assistant functions / fields / structures
        void RestJoystick()
        {
            backGround.localPosition = backGroundOriginLocalPostion;
            handle.localPosition = Vector3.zero;
            fingerId = int.MinValue; 
        }

        void ConfigJoystick() //setting dynamic/static joystick
        {
                if (!dynamic) backGroundOriginLocalPostion = backGround.localPosition;
                GetComponent<Image>().raycastTarget = dynamic;
                handle.GetComponent<Image>().raycastTarget = !dynamic;
        }

#if UNITY_EDITOR
        private void OnValidate()
        {
            if (!handle) handle = transform.Find("BackGround/Handle");
            if (!backGround) backGround = transform.Find("BackGround");
            ConfigJoystick();
        }
#endif
        private Vector3 backGroundOriginLocalPostion, pointerDownPosition;
        private int fingerId = int.MinValue; //set a number can not touch before
        [System.Serializable] public class JoystickEvent : UnityEvent<Vector2> { }
        [System.Flags]
        public enum Direction
        {
            Horizontal = 1 << 0,
            Vertical = 1 << 1
        }
        #endregion
    }
}
