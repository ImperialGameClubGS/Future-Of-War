using AssemblyCSharp.Assets.Scripts.Player;
using System.Collections;
using UnityEngine;

public class RayShooter : MonoBehaviour
{
    public int Damage = 10;
    public float floatInfrontOfWall;
    public bool IsDialog;
    private PlayerUI _playerUI => transform.GetComponent<PlayerUI>();
    [SerializeField] private Transform _bulletHole;
    [SerializeField] private Shotgun _shotgun;

    private Camera _camera;

    void Start()
    {
        _camera = GetComponent<Camera>();
        
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            
            switch (WeaponSwitcher.gunName)
            {
                case "Shotgun":
                    _shotgun.Shoot();
                    break;
                default:
                    Debug.Log("Don't have weapon");
                    break;
            }
        }

    }

    private void Shooting()
    {
        if (!IsDialog)
        {
            if (_playerUI.Bullets > 0)
            {
                if (_playerUI.GameIsOver == false)
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        _playerUI.SetBullets(_playerUI.Bullets--);
                        Vector3 point = new Vector3(_camera.pixelWidth / 2, _camera.pixelHeight / 2, 0);
                        Ray ray = _camera.ScreenPointToRay(point);
                        RaycastHit hit;

                        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
                        {
                            GameObject hitObject = hit.transform.gameObject;
                            IHittable target = hitObject.GetComponent<IHittable>();
                            if (target != null)
                            {
                                target.HitObject(Damage);
                                //StartCoroutine(HitLocation(hitObject, hit.point)); // Добавить анимацию и префаб попадания во врага
                            }
                            else
                            {
                                Instantiate(_bulletHole, hit.point + hit.normal * floatInfrontOfWall, Quaternion.LookRotation(hit.normal)); // Добавить анимацию и префаб попадания в неживую поверхность
                            }
                        }
                    }
                }
            }
        }
    }

}
