using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {
	
	public GameObject shortRangeParticleSystem;
	public GameObject longRangeParticleSystem;
	public GameObject calumityParticleSystem;
	public GameObject player;
	PlayerController playerController;
	
	// Use this for initialization
	void Start () {
		playerController = player.GetComponent<PlayerController>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	
	void FixedUpdate() {
		if (Utilities.state == Utilities.stateMainGame) {
			shortRangeParticleSystem.transform.position = player.transform.position;
			if (Utilities.isShortRangeAttacking == true) {
				shortRangeParticleSystem.particleSystem.enableEmission = true;
				playerController.walkSpeed = 0.2f;
				playerController.runSpeed = 0.2f;
				playerController.trotSpeed = 0.2f;
				if ((int)Time.time - (int)Utilities.attackTimeShort > 3) {
					playerController.walkSpeed = 5.0f;
					playerController.runSpeed = 10.0f;
					playerController.trotSpeed = 6.0f;
					Utilities.isShortRangeAttacking = false;
					shortRangeParticleSystem.particleSystem.enableEmission = false;
				}
			}
			
			if (Utilities.isLongRangeAttacking == true) {
				longRangeParticleSystem.particleSystem.enableEmission = true;
				if (Vector3.Distance(longRangeParticleSystem.transform.position, player.transform.position) <= 1) {
					playerController.walkSpeed = 0.2f;
					playerController.runSpeed = 0.2f;
					playerController.trotSpeed = 0.2f;
				}
				if ((int)Time.time - (int)Utilities.attackTimeLong > 5) {
					playerController.walkSpeed = 5.0f;
					playerController.runSpeed = 10.0f;
					playerController.trotSpeed = 6.0f;	
					Utilities.isLongRangeAttacking = false;
					longRangeParticleSystem.particleSystem.enableEmission = false;
				}
			}
		}
	}
}