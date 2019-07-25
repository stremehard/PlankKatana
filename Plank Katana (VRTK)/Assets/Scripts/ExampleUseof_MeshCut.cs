using UnityEngine;
using System.Collections;

public class ExampleUseof_MeshCut : MonoBehaviour {

	public Material capMaterial;
    public AudioSource cutSound;
    private int userScore;
    public AudioClip[] clips;

	// Use this for initialization
	void Start () {
        
	}
	
	void Update()
    {
			RaycastHit hit;

			if(Physics.Raycast(transform.position, transform.forward, out hit, 0.75f))
			
			{

				GameObject victim = hit.collider.gameObject;

				if(victim.tag == "Cuttable") 
				{
                    GameObject[] pieces = BLINDED_AM_ME.MeshCut.Cut(victim, transform.position, transform.right, capMaterial);
                    cutSound.clip = clips[Random.Range(0,3)];
                    cutSound.Play();
                    victim.tag = "Cut";
                    userScore++;
					if(!pieces[1].GetComponent<Rigidbody>())
					{
						pieces[1].AddComponent<Rigidbody>();
						for(int i = 0; i < pieces.Length; i++) {
							Destroy(pieces[i], 2);
						}
					}

				}

				
			}

	}

    public int GetScore()
    {
        return userScore;
    }


	void OnDrawGizmosSelected() {

		Gizmos.color = Color.green;

		Gizmos.DrawLine(transform.position, transform.position + transform.forward * 0.75f);
		Gizmos.DrawLine(transform.position + transform.up * 0.5f, transform.position + transform.up * 0.5f + transform.forward * 0.75f);
		Gizmos.DrawLine(transform.position + -transform.up * 0.5f, transform.position + -transform.up * 0.5f + transform.forward * 0.75f);

		Gizmos.DrawLine(transform.position, transform.position + transform.up * 0.5f);
		Gizmos.DrawLine(transform.position,  transform.position + -transform.up * 0.5f);

	}

}
