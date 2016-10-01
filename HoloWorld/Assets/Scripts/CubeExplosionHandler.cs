using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class CubeExplosionHandler : MonoBehaviour {

    public AudioClip explosionSound;
    public GameObject explosion;
    private AudioSource source;

	void Start () {
        source = gameObject.GetComponent<AudioSource>();
        if (source != null && explosionSound!=null)
        {
            source.clip = explosionSound;
        }
	}


    public void Explode()
    {
        var explosionGameObject = (GameObject)Instantiate(explosion, gameObject.transform.position, gameObject.transform.rotation);
        explosionGameObject.GetComponent<ParticleSystem>().Play();

        if (source == null || source.clip == null) //No AudioSource
        {
            Destroy(gameObject);
        }
        else //Has AudioSource
        {
            GetComponent<Renderer>().enabled = false;   //Hide GameObject
            source.Play();                              //Play Sound
            Destroy(gameObject, explosionSound.length); //Destroy Gameobject
        }
    }
}
