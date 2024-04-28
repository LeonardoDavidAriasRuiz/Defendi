using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class EnemyLogic : MonoBehaviour
{
    private AudioSource paperCut;
    public Sprite[] sprites;
    private SpriteRenderer spriteRenderer;
    public int life;
    int moveSpeed = 0;
    int direction = 3;

    // Inicializado con una vida inicial
    public void Initialize(int initialLife)
    {
        life = initialLife;
        
    }

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer == null)
        {
            Debug.LogError("SpriteRenderer component not found on the GameObject");
            return;
        }

        setSkin();
    }

    // Fincion para establecer el audio y disminucion de vida cuando es atacado
    public void GotAttacted(int dmg)
    {
        paperCut = GetComponent<AudioSource>();
        paperCut.Play();
        life -= dmg;
        setSkin();
    }

    // Funcion para cambiar la direccion del avion de papel
    void Update()
    {
        if (transform.position.x < -25 || transform.position.x > 29 || transform.position.y > 30 || transform.position.y < -25)
        {
            Destroy(gameObject);
        }

        if (direction == 1)
        {
            transform.position += (Vector3.up * moveSpeed) * Time.deltaTime;
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (direction == 2)
        {
            transform.position += (Vector3.right * moveSpeed) * Time.deltaTime;
            transform.rotation = Quaternion.Euler(0, 0, 270);
        }
        else if (direction == 3)
        {
            transform.position += (Vector3.down * moveSpeed) * Time.deltaTime;
            transform.rotation = Quaternion.Euler(0, 0, 180);
        }
        else if (direction == 4)
        {
            transform.position += (Vector3.left * moveSpeed) * Time.deltaTime;
            transform.rotation = Quaternion.Euler(0, 0, 90);
        }

        if (life <= 0)
        {
            Destroy();
        }
    }

    // Funcion para hacer girar hacia la izquiera
    public void TurnLeft()
    {
        direction = 4;
    }

    // Funcion para hacer girar hacia la derecha
    public void TurnRight()
    {
        direction = 2;
    }

    // Funcion para hacer girar hacia arriba
    public void TurnUp()
    {
        direction = 1;
    }

    // Funcion para hacer girar hacia abajo
    public void TurnDown()
    {
        direction = 3;
    }

    // Funcion para destruir el avion de papel
    public void Destroy()
    {
        Destroy(gameObject);
    }

    // Funcion para seleccionar la imagen dependiendo de la vida
    void setSkin()
    {
        switch (life)
        {
            case 1:
                spriteRenderer.sprite = sprites[life - 1];
                moveSpeed = 1;
                break;
            case 2:
                spriteRenderer.sprite = sprites[life - 1];
                moveSpeed = 2;
                break;
            case 3:
                spriteRenderer.sprite = sprites[life - 1];
                moveSpeed = 3;
                break;
            case 4:
                spriteRenderer.sprite = sprites[life - 1];
                moveSpeed = 4;
                break;
            case 5:
                spriteRenderer.sprite = sprites[life - 1];
                moveSpeed = 5;
                break;
            case 6:
                spriteRenderer.sprite = sprites[life - 1];
                moveSpeed = 6;
                break;
            case 7:
                spriteRenderer.sprite = sprites[life - 1];
                moveSpeed = 7;
                break;
            case 8:
                spriteRenderer.sprite = sprites[life - 1];
                moveSpeed = 8;
                break;
            case 9:
                spriteRenderer.sprite = sprites[life - 1];
                moveSpeed = 9;
                break;
            default:
                spriteRenderer.sprite = sprites[9 - 1];
                moveSpeed = 9;
                break;
        }
    }
}
