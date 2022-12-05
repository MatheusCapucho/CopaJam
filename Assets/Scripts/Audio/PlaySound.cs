using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{

    [SerializeField]
    private string soundName;

    private void Start()
    {
        if (soundName == "")
            Destroy(this);

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            AudioManager.instance.PlaySound(soundName);
            //Destroy(this, 0.1f);
        }
    }

    public void PlaySoundByName(string name)
    {
        AudioManager.instance.PlaySound(name);
    } 

}
