using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomCursor : MonoBehaviour
{
    public Sprite[] frames;
    public float frameRate = 0.1f;
    [SerializeField] private UnityEngine.UI.Image image;
    private int index = 0;
    private float timer = 0f;

    void Awake()
    {
        image = GetComponent<UnityEngine.UI.Image>();
        Cursor.visible = false;
    }
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= frameRate)
        {
            timer = 0;
            index = (index + 1) % frames.Length;
            image.sprite = frames[index];
        }
        transform.position = Input.mousePosition;
    }
}
