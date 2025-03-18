using System.Collections;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float vRotationSpeed = 10f;
    private bool isUp = true;
    private Vector3 incr = new Vector3(0, 0.05f, 0);
    public float time = 0.2f;

    public GameObject onCollectEffect;
    public AudioClip onCollectAudio;

    void Start()
    {
        StartCoroutine(UpDown());
    }

    IEnumerator UpDown()
    {
        for(; ; )
        {
            if (isUp)
            {
                transform.position = transform.position - incr;
                isUp = false;
            }
            else
            {
                transform.position = transform.position + incr;
                isUp = true;
            }
            yield return new WaitForSeconds(time);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        //start a coroutine, stop himself if the gameobject is disable ou stop, or if stopcoroutine(object) is called
        
        transform.Rotate(0, vRotationSpeed, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        // add sound on collect
        AudioSource.PlayClipAtPoint(onCollectAudio, transform.position);
        
        //Destroy the considered collectible
        Destroy(gameObject);

        //add the sfx effect
        Instantiate(onCollectEffect, transform.position, transform.rotation);
        // Destroy(onCollectEffect); //(est ce nécessaire ?)
    }
}
