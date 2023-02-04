using Mirror;
using NaughtyAttributes;
using UnityEditor;
using UnityEngine;

namespace Modules.Mirror.Runtime
{
    public class PlayerControllerNet : NetworkBehaviour
    {
        private Material _cachedMaterial;
        [SyncVar(hook = nameof(ChangeColor))] public Color _playerColor = Color.red;

        [ReadOnly] public Rigidbody2D _rigid;
        public float speed = 5f;
        private float acceleration = 12f;
        private float stopSpeed = 0.5f;
        public float maxSpeed = 10f;
        public bool doingTask = false;
        public GameObject CameraTarget;
    
        private Vector2 mov;
        private GameLogic _gameLogic;
    
        public override void OnStartServer()
        {
            base.OnStartServer();
            _playerColor = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
        }

        public override void OnStartClient()
        {
            base.OnStartClient();
            OnStart();
        }
    
        public void OnStart()
        {
            _rigid = GetComponent<Rigidbody2D>();
            name = !isLocalPlayer ? "network player" : "LOCAL PLAYER";
            if (isLocalPlayer)
            {
                // Camera.main.gameObject.GetComponent<CameraController>().target = CameraTarget;
                _gameLogic = GameObject.Find("GameLogic").GetComponent<GameLogic>();
                _gameLogic.localPlayer = this;
                //_gameLogic.GetComponent<NetworkIdentity>().AssignClientAuthority(GetComponent<NetworkIdentity>().connectionToClient); doesnt work cauz not instatiated 
            }
        }

        public void ChangeColor(Color oldColor, Color newColor)
        {
            if (_cachedMaterial == null)
                _cachedMaterial = GetComponent<SpriteRenderer>().material;
            _cachedMaterial.color = newColor;
        }

        private void FixedUpdate()
        {
            if (!isLocalPlayer) return;
            if (doingTask) return;
            NormalMovement();
        }
    
        void NormalMovement()
        {
            Vector3 input = Vector3.zero;
            input.x = Input.GetAxisRaw("Horizontal");
            input.y = Input.GetAxisRaw("Vertical");

            Vector3 direction = input.normalized;
            CameraTarget.transform.localPosition = direction * (transform.localScale.x * 70f); // Update Camera Target
        
            Vector3 movement = direction * speed * Time.fixedDeltaTime;

        
            _rigid.MovePosition(transform.position + movement);
        }

        public void DoingTask()
        {
            CameraTarget.transform.localPosition = Vector3.zero;
            doingTask = true;
        }
        void SlipperyMovement()
        {
            mov = Vector2.zero;

            mov.x += Input.GetAxisRaw("Horizontal") < 0 ? -1 : 0;
            mov.x += Input.GetAxisRaw("Horizontal") > 0 ? 1 : 0;
            mov.y += Input.GetAxisRaw("Vertical") < 0 ? -1 : 0;
            mov.y += Input.GetAxisRaw("Vertical") > 0 ? 1 : 0;

            if (mov == Vector2.zero && (Mathf.Abs(_rigid.velocity.x) > 0.00f
                                        || Mathf.Abs(_rigid.velocity.y) > 0.00f))
                _rigid.velocity *= stopSpeed;

            _rigid.AddForce(mov.normalized * acceleration);
            if (_rigid.velocity.magnitude > maxSpeed)
                _rigid.velocity = _rigid.velocity.normalized * maxSpeed;
        }

        private void OnDestroy()
        {
            Destroy(_cachedMaterial);
        }

        public void OnTriggerEnter2D(Collider2D other)
        {
        }
    }


#if UNITY_EDITOR
    [CustomEditor(typeof(PlayerControllerNet))]
    public class PlayerControllerNetEditor : Editor
    {
        private Vector2Int position;
        private int size;
        public override void OnInspectorGUI()
        {
            //var targ = target as PlayerControllerBallocamp;
            base.OnInspectorGUI();
        
            /*if (GUILayout.Button("Maj Color"))
         {
             targ.ChangeColor(Color.black, targ._playerColor);
         }*/
        }
    }
#endif
}