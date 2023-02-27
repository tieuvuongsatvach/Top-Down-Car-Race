using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Racetrack : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    private Vector2 offset;
    private Renderer rend;
    private int score;

    private void Awake()
    {
        rend = GetComponent<Renderer>();
    }

    void Start()
    {

    }

    void Update()
    {
        if (!GameController.gc.Gameover())
        {
            offset = new Vector2(0, Time.time * speed);
            rend.material.mainTextureOffset = offset;
        }
    }
}
