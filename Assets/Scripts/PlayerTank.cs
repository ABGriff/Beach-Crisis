using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerTank : MonoBehaviour {

	public float moveSpeed = 20.0f;  // units per second
	public float rotateSpeed = 3.0f;

	public int health = 100;
	private int maxHealth;
	
	private Transform _transform;
	private Rigidbody _rigidbody;

	public GameObject turret;
	public GameObject bullet;
	public GameObject bulletSpawnPoint;
    public Image healthbar;

    public float turretRotSpeed = 3.0f;
    public float originalSize;
    public float originalHeight;
    public float newSize;

    public Mask ammoMask;
    



    //Bullet shooting rate
    public float shootRate = 1.5f;
	protected float elapsedTime;

	public int ammo = 5;
	private const int maxAmmo = 20;

	private int score = 0;
    public Text ScoreText;



    // Use this for initialization
    void Start () {
       originalSize = healthbar.rectTransform.rect.width;
        originalHeight = healthbar.rectTransform.rect.height;

        

        _transform = transform;
		_rigidbody = GetComponent<Rigidbody>();

		maxHealth = health;

		elapsedTime = shootRate; // allow first press to fire
		rotateSpeed = rotateSpeed * 180 / Mathf.PI; // convert from rad to deg for rot function
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		// check for input
		float rot = _transform.localEulerAngles.y + rotateSpeed * Time.deltaTime * Input.GetAxis("Horizontal");
		Vector3 fwd = _transform.forward * moveSpeed * Time.deltaTime * Input.GetAxis("Vertical");

		// Tank Chassis is rigidbody, use MoveRotation and MovePosition
		_rigidbody.MoveRotation(Quaternion.AngleAxis(rot, Vector3.up));
		_rigidbody.MovePosition(_rigidbody.position + fwd);

		if (turret) {
			Plane playerPlane = new Plane(Vector3.up, _transform.position + new Vector3(0, 0, 0));
			
			// Generate a ray from the cursor position
			Ray RayCast = Camera.main.ScreenPointToRay(Input.mousePosition);
			
			// Determine the point where the cursor ray intersects the plane.
			float HitDist = 0;
			
			// If the ray is parallel to the plane, Raycast will return false.
			if (playerPlane.Raycast(RayCast, out HitDist))
			{
				// Get the point along the ray that hits the calculated distance.
				Vector3 RayHitPoint = RayCast.GetPoint(HitDist);
				
				Quaternion targetRotation = Quaternion.LookRotation(RayHitPoint - _transform.position);
				turret.transform.rotation = Quaternion.Slerp(turret.transform.rotation, targetRotation, Time.deltaTime * turretRotSpeed);
			}
		}

		if(Input.GetButton("Fire1"))
		{
			if (elapsedTime >= shootRate)
			{
				//Reset the time
				elapsedTime = 0.0f;

				if (ammo > 0) {
                    //Also Instantiate over the PhotonNetwork
                    UpdateScore(100);
					if ((bulletSpawnPoint) & (bullet)) {
						Instantiate(bullet, bulletSpawnPoint.transform.position, bulletSpawnPoint.transform.rotation);
						ammo--;
                        UpdateAmmoCount();
                    }
				}
			}
		}

		// Update the time
		elapsedTime += Time.deltaTime;
	}

	// Apply Damage if hit by bullet
	public void ApplyDamage(int damage ) {
		health -= damage;
        newSize = maxHealth + health;
        healthbar.rectTransform.sizeDelta = new Vector2(newSize, originalHeight);
       
      

    }

	// Increment ammo
	public void ApplyAmmoPickup() {
		ammo = ammo + 5;
		if (ammo > maxAmmo) ammo = maxAmmo;
        UpdateAmmoCount();
    }

	// Increment score
	public void UpdateScore(int addScore) {
		score = score + addScore;
        string scoreString = score.ToString();
        // update the GUI score here
        ScoreText.text = "Score: " + scoreString;
       
        
       
	}

    public void UpdateAmmoCount()
    {
        if (ammoMask)
        {
            RectTransform rectTransform = ammoMask.GetComponent<RectTransform>();
            rectTransform.sizeDelta = new Vector2(13f * ammo, rectTransform.sizeDelta.y);
        }
    }


}
