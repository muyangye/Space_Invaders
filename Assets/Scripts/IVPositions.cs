using UnityEngine;
using System.Collections;

public class IVPositions : MonoBehaviour
{
    // Define invaders
    public Invader bottom;
    public Invader middle;
    public Invader top;

    // Define rows and columns of Invaders
    int rows = 5;
    int cols = 11;

    // Define Invaders direction and movement speed
    public Vector3 direction = new Vector3(1.0f, 0f, 0f);
    public float speed = 0.2f;
    private float baseMoveCooldown = 1.0f;

    // Essentially these 2 floats are always the same, but for clarity name 2 variables
    private float moveCooldown = 1.0f;
    private float invaderAnimTime = 1.0f;

    private int originalChildCount = 54;

    // Define GameManager
    public GameManager gameManager;

    // Define Active State
    public bool active = true;

    public float positionDrop = 0.0f;

    // Add base score of 1000 after completing a level
    private int scoreForLevelComplete = 1000;

    // Add more score upon completing a level since levels get gradually harder
    private int scoreBoosterForLevelComplete = 0;

    void Start()
    {
        // Create the matrix of Invaders
        SpawnInvaders();
        // StartCoroutine("UpdatePosition");
    }

    void SpawnInvaders()
    {
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                Vector3 position = new Vector3(0.0f, row * 0.56f - positionDrop, 0.0f);
                position.x += col * 0.56f;
                Invader invader;
                if (row == 0 || row == 1)
                {
                    invader = Instantiate(bottom, transform);
                }
                else if (row == 2 || row == 3)
                {
                    invader = Instantiate(middle, transform);
                }
                else
                {
                    invader = Instantiate(top, transform);
                }
                invader.transform.localPosition = position - new Vector3(2.8f, 0.0f, 0.0f);
            }
        }
    }

    // Check to see if invaders hit the edge and if so, move them down
    void Update()
    {
        moveCooldown -= Time.deltaTime;
        if (moveCooldown <= 0.0f)
        {
            transform.position += direction * speed;
            foreach (Transform invader in transform)
            {
                if (invader.position.x <= -5.2f || invader.position.x >= 5.1f)
                {
                    MoveDownAndChangeDirection(invader.position.x);
                    break;
                }
                else if (invader.position.y <= -3f)
                {
                    gameManager.life = 0;
                    gameManager.UpdateLife();
                }
            }
            moveCooldown = baseMoveCooldown;
        }

        if (transform.childCount < originalChildCount / 2)
        {
            // At most 16x faster
            baseMoveCooldown = Mathf.Max(0.0625f, baseMoveCooldown - 0.25f);
            invaderAnimTime = Mathf.Max(0.0625f, invaderAnimTime - 0.25f);
            // Update each individual invader's sprite animation frequency
            foreach (Transform invaderTransform in transform)
            {
                invaderTransform.gameObject.GetComponent<Invader>().invaderMoveFrequency =
                    invaderAnimTime;
            }
            originalChildCount /= 2;
        }
        if (transform.childCount == 0)
        {
            if (gameManager.life < 3)
            {
                gameManager.life += 1;
                gameManager.UpdateLifeIcon();
            }
            StartCoroutine("Reset");
            SpawnInvaders();
        }
    }

    void MoveDownAndChangeDirection(float x)
    {
        direction *= -1;
        transform.position += new Vector3(0f, -0.24f, 0f);
    }

    IEnumerator Reset()
    {
        positionDrop += 0.4f;
        gameManager.score += scoreForLevelComplete + scoreBoosterForLevelComplete;
        scoreBoosterForLevelComplete += 500;
        transform.position = Vector3.zero;
        transform.localPosition = Vector3.zero;
        baseMoveCooldown = 1.0f;
        invaderAnimTime = 1.0f;
        originalChildCount = 54;
        yield return new WaitForSeconds(1f);
    }
}
