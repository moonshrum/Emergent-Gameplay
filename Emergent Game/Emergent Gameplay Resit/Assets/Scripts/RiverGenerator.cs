using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiverGenerator : MonoBehaviour
{
    private enum Direction {Right, Down, Up, Left}
    private Direction CurrentDirection;
    private Vector3 InitialPosition;
    private GameObject _previousRiverPiece;

    public int RiverLength;
    public Transform River;
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
        SpawnRiver();
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
        riverStart.transform.position = InitialPosition;
        SpriteRenderer spriteRenderer = riverStart.GetComponent<SpriteRenderer>();
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
        //riverStart.transform.position = InitialPosition;
        riverStart.transform.parent = River;
        _previousRiverPiece = riverStart;
    }
    private void SpawnRiver()
    {
        int randomNumber = Random.Range(2, 6);
        for (int i = 0; i < randomNumber; i++)
        {
            if (CurrentDirection == Direction.Right || CurrentDirection == Direction.Left)
            {
                float posX = _previousRiverPiece.transform.position.x + (_previousRiverPiece.GetComponent<SpriteRenderer>().bounds.size.x / 2);
                float posY = _previousRiverPiece.transform.position.y;
                Vector3 pos = new Vector3(posX, posY);
                GameObject riverPiece = Instantiate(RiverPiecePrefab);
                riverPiece.transform.position = pos;
                riverPiece.GetComponent<SpriteRenderer>().sprite = HorizontalUp;
                riverPiece.transform.parent = River;
                _previousRiverPiece = riverPiece;
            } else if (CurrentDirection == Direction.Up || CurrentDirection == Direction.Down)
            {
                float posX = _previousRiverPiece.transform.position.x;
                float posY = _previousRiverPiece.transform.position.y + _previousRiverPiece.GetComponent<SpriteRenderer>().bounds.size.y;
                Vector3 pos = new Vector3(posX, posY);
                GameObject riverPiece = Instantiate(RiverPiecePrefab);
                riverPiece.transform.position = pos;
                riverPiece.GetComponent<SpriteRenderer>().sprite = VerticalRight;
                riverPiece.transform.parent = River;
                _previousRiverPiece = riverPiece;
            }
        }
        /*for (int i = 0; i < RiverLength; i++)
        {



            float posX = _previousRiverPiece.transform.position.x + RiverPiecePrefab.GetComponent<SpriteRenderer>().bounds.size.x;
            float posY = _previousRiverPiece.transform.position.y + RiverPiecePrefab.GetComponent<SpriteRenderer>().bounds.size.x
            Vector3 pos = new Vector3()
            GameObject riverPiece = Instantiate(RiverPiecePrefab, _previousRiverPiece.transform)
        }*/
    }
}
