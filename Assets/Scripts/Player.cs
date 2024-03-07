using UnityEngine;

public class Player : MonoBehaviour
{
    Health health;
    public Weapon weapon;
    public LayerMask weaponLayer;
    public GameObject equipText;
    public Transform hand;
    public HUD hud;


    void Start()
    {
        health = GetComponent<Health>();
    }


    void Update()
    {
        var cam = Camera.main.transform;
        var collided = Physics.Raycast(cam.position, cam.forward, out var hit, 2f, weaponLayer);
        equipText.SetActive(collided && !weapon);

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (weapon == null && collided)
            {
                weapon = hit.transform.GetComponent<Weapon>();
                Grab(weapon);
            }
            else
            {
                Drop();
            }
        }


        if (weapon == null) return;

        // manual mode
        if (!weapon.isAutoFire && Input.GetKeyDown(KeyCode.Mouse0))
        {
            weapon.Shoot();
        }

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            weapon.onRightClick.Invoke();
        }

        // auto mode
        if (weapon.isAutoFire && Input.GetKey(KeyCode.Mouse0))
        {
            weapon.Shoot();
        }

        if (Input.GetKeyDown(KeyCode.R) && weapon.ammo < weapon.maxAmmo)
        {
            weapon.Reload();
        }
    }


    public void Grab(Weapon newWeapon)
    {
        weapon = newWeapon;
        weapon.GetComponent<Rigidbody>().isKinematic = true;
        weapon.GetComponent<BoxCollider>().enabled = false;
        weapon.transform.position = hand.position;
        weapon.transform.rotation = hand.rotation;
        weapon.transform.parent = hand;

        hud.weapon = weapon;
        hud.UpdateUI();
        weapon.onShoot.AddListener(hud.UpdateUI);
        weapon.onReload.AddListener(hud.UpdateUI);

        print("weapong grabbed");
    }


    public void Drop()
    {
        if (weapon == null) return;

        var rb = weapon.GetComponent<Rigidbody>();
        rb.isKinematic = false;
        weapon.GetComponent<BoxCollider>().enabled = true;

        rb.velocity = transform.forward * 5f;

        weapon.transform.parent = null;

        hud.weapon = weapon;
        hud.UpdateUI();
        weapon.onShoot.RemoveListener(hud.UpdateUI);
        weapon.onReload.RemoveListener(hud.UpdateUI);
        weapon = null;
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            health.Damage(10);
        }
    }
}
