using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiverGenerator : MonoBehaviour
{
    private enum Direction {Right, Down, Up, Left}
    private Direction CurrentDirection;
    private Vector3 InitialPosition;

    public GameObject RiverPiecePrefab;
    public Sprite StartLeft;
    public Sprite StartRight;
    public Sprite StartDown;
    public Sprite StartUp;
    public Sprite VerticalLeft;
    public Sprite VerticalRight;
    public Sprite HorizontalUp;
    public Sprite HorizontalDown;
    public Sprite LeftToUp;
    public Sprite UpToRight;
    public Sprite RightToDown;
    public Sprite DownToLeft;

    private void Start()
    {
        GenerateRiver();
    }
    public void GenerateRiver()
    {
        CurrentDirection = GetInitialDirection();
        InitialPosition = GetInitialPosition();
        SpawnRiverStart();


    }

    private Direction GetInitialDirection()
    {
        Direction direction = Direction.Right;
        int randomDirection = Random.Range(0, 4);

        if (randomDirection == 0)
        {
            direction = Direction.Right;
        }
        else if (randomDirection == 1)
        {
            direction = Direction.Down;
        }
        else if (randomDirection == 2)
        {
            direction = Direction.Up;
        }
        else if (randomDirection == 3)
        {
            direction = Direction.Left;
        }
        return direction;
    }
    private Vector3 GetInitialPosition()
    {
        Vector3 initialPos = Vector3.zero;
        int posX = Random.Range(-95, 95);
        float posY = Random.Range(-65, 25);
        initialPos = new Vector3(posX, posY);
        return initialPos;
    }
    private void SpawnRiverStart()
    {
        GameObject riverStart = Instantiate(RiverPiecePrefab);
        SpriteRenderer spriteRenderer = riverStart.GetComponent<SpriteRenderer>();
        Debug.Log(CurrentDirection);
        Debug.Log(InitialPosition);
        switch (CurrentDirection)
        {
            case Direction.Right:
                spriteRenderer.sprite = StartRight;
                break;
            case Direction.Left:
                spriteRenderer.sprite = StartLeft;
                break;
            case Direction.Up:
                spriteRenderer.sprite = StartUp;
                break;
            case Direction.Down:
                spriteRenderer.sprite = StartDown;
                break;
        }
        riverStart.transform.position = InitialPosition;
    }
}
