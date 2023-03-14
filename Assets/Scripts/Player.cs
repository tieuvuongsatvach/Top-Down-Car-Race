using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float carSpeed = 10f;
    [SerializeField] private GameObject effect;
    [SerializeField] private AudioClip explo;
    [SerializeField] private AudioSource auSource;

    private Vector3 carPos;
    private float maxCarPos = 3.8f;

    void Awake()
    {

        carPos = transform.position;
    }

    void Update()
    {
        carPos.x += Input.GetAxis("Horizontal") * carSpeed * Time.deltaTime;
        carPos.x = Mathf.Clamp(carPos.x, -maxCarPos, maxCarPos);
        transform.position = carPos;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            auSource.PlayOneShot(explo);
            Destroy(gameObject);
            Instantiate(effect, transform.position, Quaternion.identity);
            GameController.gc.SetGameoverState(true);
        }
    }
}
