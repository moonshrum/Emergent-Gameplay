using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiverGenerator : MonoBehaviour
{
    private enum Direction {Right, Down, Up, Left}
    //private readonly List<Direction> _directions = new List<Direction>();
    private Direction _currentDirection;
    private Direction _previousDirection;
    private Vector3 InitialPosition;
    private GameObject _previousRiverPiece;
    private GameObject _agent;

    public int RiverLength;
    public GameObject AgentPrefab;
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
        _currentDirection = GetInitialDirection();
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
    private Direction GetNewDirection()
    {
        _previousDirection = _currentDirection;
        Direction direction = _previousDirection;
        List<Direction> tempList = new List<Direction>();
        tempList.Add(Direction.Right);
        tempList.Add(Direction.Left);
        tempList.Add(Direction.Up);
        tempList.Add(Direction.Down);
        tempList.Remove(_previousDirection);
        if (_previousDirection == Direction.Down)
        {
            tempList.Remove(Direction.Up);
        }
        else if (_previousDirection == Direction.Up)
        {
            tempList.Remove(Direction.Down);
        }
        else if (_previousDirection == Direction.Left)
        {
            tempList.Remove(Direction.Right);
        }
        else if (_previousDirection == Direction.Right)
        {
            tempList.Remove(Direction.Left);
        }
        int randomIndex = Random.Range(0, tempList.Count);
        //Debug.Log(tempList.Count);
        direction = tempList[randomIndex];
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
        _agent = Instantiate(AgentPrefab);
        _agent.transform.position = InitialPosition;
        riverStart.transform.position = InitialPosition;
        SpriteRenderer spriteRenderer = riverStart.GetComponent<SpriteRenderer>();
        switch (_currentDirection)
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
        riverStart.transform.parent = River;
        _previousRiverPiece = riverStart;
    }
    private void SpawnRiverCorner()
    {
        Sprite spriteToUse = null;
        if ((_previousDirection == Direction.Right && _currentDirection== Direction.Down) || (_previousDirection == Direction.Up && _currentDirection == Direction.Left))
        {
            spriteToUse = UpToRight;
        }
        if ((_previousDirection == Direction.Left && _currentDirection == Direction.Up) || (_previousDirection == Direction.Down && _currentDirection == Direction.Right))
        {
            spriteToUse = DownToLeft;
        }
        if ((_previousDirection == Direction.Down && _currentDirection == Direction.Left) || (_previousDirection == Direction.Right && _currentDirection == Direction.Up))
        {
            spriteToUse = RightToDown;
        }
        if ((_previousDirection == Direction.Up && _currentDirection == Direction.Right) || (_previousDirection == Direction.Left && _currentDirection == Direction.Down))
        {
            spriteToUse = LeftToUp;
        }
        _previousRiverPiece.GetComponent<SpriteRenderer>().sprite = spriteToUse;
    }
    private void SpawnRiver()
    {
        int amountOfTurns = Random.Range(5, 11);
        for (int i = 0; i < amountOfTurns - 1; i++)
        {
            int sectionLength = Random.Range(5, 10);
            for (int j = 0; j < sectionLength; j++)
            {
                if (_currentDirection == Direction.Right)
                {
                    float posX = _previousRiverPiece.transform.position.x + _previousRiverPiece.GetComponent<SpriteRenderer>().bounds.size.x;
                    float posY = _previousRiverPiece.transform.position.y;
                    Vector3 pos = new Vector3(posX, posY);

                    // Sending agent to check whether a tile can be placed
                    _agent.transform.position = pos;
                    if (_agent.GetComponent<RiverAgent>().CollidingWith == null)
                    {
                        //Debug.Log("sukaaaa");
                    }

                    GameObject riverPiece = Instantiate(RiverPiecePrefab);
                    riverPiece.transform.position = pos;
                    riverPiece.GetComponent<SpriteRenderer>().sprite = HorizontalUp;
                    riverPiece.transform.parent = River;
                    _previousRiverPiece = riverPiece;
                }
                else if (_currentDirection == Direction.Left)
                {
                    float posX = _previousRiverPiece.transform.position.x - _previousRiverPiece.GetComponent<SpriteRenderer>().bounds.size.x;
                    float posY = _previousRiverPiece.transform.position.y;
                    Vector3 pos = new Vector3(posX, posY);
                    GameObject riverPiece = Instantiate(RiverPiecePrefab);
                    riverPiece.transform.position = pos;
                    riverPiece.GetComponent<SpriteRenderer>().sprite = HorizontalUp;
                    riverPiece.transform.parent = River;
                    _previousRiverPiece = riverPiece;
                }
                else if (_currentDirection == Direction.Down)
                {
                    float posX = _previousRiverPiece.transform.position.x;
                    float posY = _previousRiverPiece.transform.position.y - _previousRiverPiece.GetComponent<SpriteRenderer>().bounds.size.y;
                    Vector3 pos = new Vector3(posX, posY);
                    GameObject riverPiece = Instantiate(RiverPiecePrefab);
                    riverPiece.transform.position = pos;
                    riverPiece.GetComponent<SpriteRenderer>().sprite = VerticalRight;
                    riverPiece.transform.parent = River;
                    _previousRiverPiece = riverPiece;
                }
                else if (_currentDirection == Direction.Up)
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
            _currentDirection = GetNewDirection();
            SpawnRiverCorner();
        }
    }
}
