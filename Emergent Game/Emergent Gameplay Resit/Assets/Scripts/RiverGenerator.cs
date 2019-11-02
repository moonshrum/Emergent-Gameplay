using System.Collections.Generic;
using UnityEngine;

public class RiverGenerator : MonoBehaviour
{
    private enum Direction { Right, Down, Up, Left }
    private enum Side { LeftIsh, RightIsh, UpIsh, DownIsh };
    private Direction _currentDirection;
    private Direction _previousDirection;
    private Direction _prohibitedDIrection;
    private Side _currentSide;
    private Side _previousSide;
    private Vector3 InitialPosition;
    private GameObject _previousRiverPiece;
    private int _negativeX = -143;
    private int _positiveX = 128;
    private int _negativeY = -32;
    private int _positiveY = 56;
    private float _distanceBetweenTiles = 1f;

    public int RiverLength;
    public int MinNumberOfSections;
    public int MaxNumberOfSections;
    public int MinNumberOfPiecesPerSection;
    public int MaxNumberOfPiecesPerSection;
    public Transform River;
    public GameObject RiverPiecePrefab;
    public Sprite StartLeftDownish;
    public Sprite StartLeftUpish;
    public Sprite StartRightDownish;
    public Sprite StartRightUpish;
    public Sprite StartDownLeftish;
    public Sprite StartDownRightish;
    public Sprite StartUpLeftish;
    public Sprite StartUpRightish;
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
        while (EnvironementGenerator.Instance.PlacedRiverPieces.Count < RiverLength)
        {
            GenerateRiver();
        }
    }
    public void GenerateRiver()
    {
        //_currentDirection = Direction.Right;
        InitialPosition = GetInitialPosition();
        _currentDirection = GetInitialDirection();
        if (_currentDirection == Direction.Up || _currentDirection == Direction.Down)
        {
            _currentSide = Side.LeftIsh;
        }
        else if (_currentDirection == Direction.Left || _currentDirection == Direction.Right)
        {
            _currentSide = Side.DownIsh;
        }
        SpawnRiverStart();
        SpawnRiver();
    }
    private Direction GetInitialDirection()
    {
        Direction direction = Direction.Right;
        int randomDirection = Random.Range(0, 2);
        int centerX = Mathf.Abs(_positiveX) - Mathf.Abs(_negativeX);
        int centerY = Mathf.Abs(_positiveY) - Mathf.Abs(_negativeY);
        if (randomDirection == 0)
        {
            if (InitialPosition.x >= centerX)
            {
                direction = Direction.Left;
            }
            else if (InitialPosition.x <= centerX)
            {
                direction = Direction.Right;
            }
        }
        else if (randomDirection == 1)
        {
            if (InitialPosition.y >= centerY)
            {
                direction = Direction.Down;
            }
            else if (InitialPosition.y <= centerY)
            {
                direction = Direction.Up;
            }
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
        tempList.Remove(_prohibitedDIrection);

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
    private Direction GetNewDirection(bool hitEdge, Vector3 pos)
    {
        Direction _direction = Direction.Right;
        if (hitEdge)
        {
            int randomDirection = Random.Range(0, 2);
            int centerX = Mathf.Abs(_positiveX) - Mathf.Abs(_negativeX);
            int centerY = Mathf.Abs(_positiveY) - Mathf.Abs(_negativeY);
            if (pos.x >= centerX)
            {
                _direction = Direction.Up;
            }
            else if (InitialPosition.x <= centerX)
            {
                _direction = Direction.Down;
            }
        }
        _previousDirection = _currentDirection;
        Direction direction = _previousDirection;
        List<Direction> tempList = new List<Direction>();
        tempList.Add(Direction.Right);
        tempList.Add(Direction.Left);
        tempList.Add(Direction.Up);
        tempList.Add(Direction.Down);
        tempList.Remove(_previousDirection);
        tempList.Remove(_prohibitedDIrection);
        tempList.Remove(_direction);

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
        int posX = Random.Range(_negativeX + Mathf.Abs(_negativeX / 2), _positiveX - Mathf.Abs(_positiveX / 2));
        int posY = Random.Range(_negativeY + Mathf.Abs(_negativeY / 2), _positiveY - Mathf.Abs(_positiveY / 2));
        initialPos = new Vector3(posX, posY);
        return initialPos;
    }
    private void SpawnRiverStart()
    {
        GameObject riverStart = Instantiate(RiverPiecePrefab);
        riverStart.transform.position = InitialPosition;
        SpriteRenderer spriteRenderer = riverStart.GetComponent<SpriteRenderer>();
        switch (_currentDirection)
        {
            case Direction.Right:
                spriteRenderer.sprite = StartRightDownish;
                break;
            case Direction.Left:
                spriteRenderer.sprite = StartLeftDownish;
                break;
            case Direction.Up:
                spriteRenderer.sprite = StartUpLeftish;
                break;
            case Direction.Down:
                spriteRenderer.sprite = StartDownLeftish;
                break;
        }
        riverStart.transform.parent = River;
        _previousRiverPiece = riverStart;
        EnvironementGenerator.Instance.PlacedRiverPieces.Add(riverStart);
    }
    private void SpawnRiverEnd(bool reachedEnd)
    {
        Sprite spriteToUse = null;
        Direction directionToUse;
        if (!reachedEnd)
        {
            directionToUse = _currentDirection;
        } else
        {
            directionToUse = _previousDirection;
        }
        if (directionToUse == Direction.Right)
        {
            if (_currentSide == Side.DownIsh)
            {
                spriteToUse = StartLeftDownish;
            }
            else if (_currentSide == Side.UpIsh)
            {
                spriteToUse = StartLeftUpish;
            }
        }
        else if (directionToUse == Direction.Left)
        {
            if (_currentSide == Side.DownIsh)
            {
                spriteToUse = StartRightDownish;
            }
            else if (_currentSide == Side.UpIsh)
            {
                spriteToUse = StartRightUpish;
            }
        }
        else if (directionToUse == Direction.Up)
        {
            if (_currentSide == Side.LeftIsh)
            {
                spriteToUse = StartDownLeftish;
            }
            else if (_currentSide == Side.RightIsh)
            {
                spriteToUse = StartDownRightish;
            }
        }
        else if (directionToUse == Direction.Down)
        {
            if (_currentSide == Side.LeftIsh)
            {
                spriteToUse = StartUpLeftish;
            }
            else if (_currentSide == Side.RightIsh)
            {
                spriteToUse = StartUpRightish;
            }
        }
        _previousRiverPiece.GetComponent<SpriteRenderer>().sprite = spriteToUse;
    }
    private void SpawnRiverCorner()
    {
        Sprite spriteToUse = null;
        if ((_previousDirection == Direction.Right && _currentDirection == Direction.Down) || (_previousDirection == Direction.Up && _currentDirection == Direction.Left))
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
        if (_previousDirection == Direction.Right)
        {
            if (_currentDirection == Direction.Up)
            {
                if (_previousSide == Side.UpIsh)
                {
                    float posX = _previousRiverPiece.transform.position.x;
                    float posY = _previousRiverPiece.transform.position.y + _previousRiverPiece.GetComponent<SpriteRenderer>().size.y / 2;
                    Vector3 newPos = new Vector3(posX, posY);
                    _previousRiverPiece.transform.position = newPos;
                }
                else
                {
                    RegularyPositionCornerPiece();
                }
            }
            else if (_currentDirection == Direction.Down)
            {
                if (_previousSide == Side.DownIsh)
                {
                    float posX = _previousRiverPiece.transform.position.x;
                    float posY = _previousRiverPiece.transform.position.y - _previousRiverPiece.GetComponent<SpriteRenderer>().size.y / 2;
                    Vector3 newPos = new Vector3(posX, posY);
                    _previousRiverPiece.transform.position = newPos;
                }
                else
                {
                    RegularyPositionCornerPiece();
                }
            }
            _currentSide = Side.RightIsh;
        }
        if (_previousDirection == Direction.Up)
        {
            if (_currentDirection == Direction.Right)
            {
                if (_previousSide == Side.RightIsh)
                {
                    float posX = _previousRiverPiece.transform.position.x + _previousRiverPiece.GetComponent<SpriteRenderer>().size.x / 2;
                    float posY = _previousRiverPiece.transform.position.y;
                    Vector3 newPos = new Vector3(posX, posY);
                    _previousRiverPiece.transform.position = newPos;
                }
                else
                {
                    RegularyPositionCornerPiece();
                }
            }
            else if (_currentDirection == Direction.Left)
            {
                if (_previousSide == Side.LeftIsh)
                {
                    float posX = _previousRiverPiece.transform.position.x - _previousRiverPiece.GetComponent<SpriteRenderer>().size.x / 2;
                    float posY = _previousRiverPiece.transform.position.y;
                    Vector3 newPos = new Vector3(posX, posY);
                    _previousRiverPiece.transform.position = newPos;
                }
                else
                {
                    RegularyPositionCornerPiece();
                }
            }
            _currentSide = Side.UpIsh;
        }
        if (_previousDirection == Direction.Left)
        {
            if (_currentDirection == Direction.Down)
            {
                if (_previousSide == Side.DownIsh)
                {
                    float posX = _previousRiverPiece.transform.position.x;
                    float posY = _previousRiverPiece.transform.position.y - _previousRiverPiece.GetComponent<SpriteRenderer>().size.x / 2;
                    Vector3 newPos = new Vector3(posX, posY);
                    _previousRiverPiece.transform.position = newPos;
                }
                else
                {
                    RegularyPositionCornerPiece();
                }
            }
            else if (_currentDirection == Direction.Up)
            {
                if (_previousSide == Side.UpIsh)
                {
                    float posX = _previousRiverPiece.transform.position.x;
                    float posY = _previousRiverPiece.transform.position.y + _previousRiverPiece.GetComponent<SpriteRenderer>().size.x / 2;
                    Vector3 newPos = new Vector3(posX, posY);
                    _previousRiverPiece.transform.position = newPos;
                }
                else
                {
                    RegularyPositionCornerPiece();
                }
            }
            _currentSide = Side.LeftIsh;
        }
        if (_previousDirection == Direction.Down)
        {
            if (_currentDirection == Direction.Left)
            {
                if (_previousSide == Side.LeftIsh)
                {
                    float posX = _previousRiverPiece.transform.position.x - _previousRiverPiece.GetComponent<SpriteRenderer>().size.x / 2;
                    float posY = _previousRiverPiece.transform.position.y;
                    Vector3 newPos = new Vector3(posX, posY);
                    _previousRiverPiece.transform.position = newPos;
                }
                else
                {
                    RegularyPositionCornerPiece();
                }
            }
            else if (_currentDirection == Direction.Right)
            {
                if (_previousSide == Side.RightIsh)
                {
                    float posX = _previousRiverPiece.transform.position.x + _previousRiverPiece.GetComponent<SpriteRenderer>().size.x / 2;
                    float posY = _previousRiverPiece.transform.position.y;
                    Vector3 newPos = new Vector3(posX, posY);
                    _previousRiverPiece.transform.position = newPos;
                }
                else
                {
                    RegularyPositionCornerPiece();
                }
            }
            _currentSide = Side.DownIsh;
        }
    }
    private void RegularyPositionCornerPiece()
    {
        float posX = _previousRiverPiece.transform.position.x;
        float posY = _previousRiverPiece.transform.position.y;
        Vector3 newPos = new Vector3(posX, posY);
        _previousRiverPiece.transform.position = newPos;
    }
    private void SpawnRiver()
    {
        int amountOfTurns = Random.Range(MinNumberOfSections, MaxNumberOfSections);
        for (int i = 0; i < amountOfTurns - 1; i++)
        {
            int sectionLength = Random.Range(MinNumberOfPiecesPerSection, MaxNumberOfPiecesPerSection);
            for (int j = 0; j < sectionLength; j++)
            {
                GameObject riverPiece = Instantiate(RiverPiecePrefab);
                if (_currentDirection == Direction.Right)
                {
                    float posX = _previousRiverPiece.transform.position.x + _previousRiverPiece.GetComponent<SpriteRenderer>().size.x - _distanceBetweenTiles;
                    float posY = _previousRiverPiece.transform.position.y;
                    if ((posX < _negativeX || posX > _positiveX) || (posY < _negativeY || posY > _positiveY))
                    {
                        _prohibitedDIrection = _currentDirection;
                        GetNewDirection();
                        Destroy(riverPiece);
                        Debug.Log("bb" + _previousDirection + _currentDirection + _previousRiverPiece.name);
                        continue;
                    }
                    Vector3 pos = new Vector3(posX, posY);
                    riverPiece.transform.position = pos;
                    if (i == 0 && j == 0)
                    {
                        riverPiece.GetComponent<SpriteRenderer>().sprite = HorizontalDown;
                        _previousSide = Side.DownIsh;
                        _currentSide = Side.DownIsh;
                    }
                    else if (j != 0 || i != 0)
                    {
                        if (_currentSide == Side.UpIsh)
                        {
                            riverPiece.GetComponent<SpriteRenderer>().sprite = HorizontalUp;
                            _previousSide = _currentSide;
                            _currentSide = Side.UpIsh;
                        }
                        else if (_currentSide == Side.DownIsh)
                        {
                            riverPiece.GetComponent<SpriteRenderer>().sprite = HorizontalDown;
                            _previousSide = _currentSide;
                            _currentSide = Side.DownIsh;
                        }
                    }
                    riverPiece.transform.parent = River;
                    riverPiece.transform.name = i + " + " + j;
                    _previousRiverPiece = riverPiece;
                }
                else if (_currentDirection == Direction.Left)
                {
                    float posX = _previousRiverPiece.transform.position.x - _previousRiverPiece.GetComponent<SpriteRenderer>().size.x + _distanceBetweenTiles;
                    float posY = _previousRiverPiece.transform.position.y;
                    if ((posX < _negativeX || posX > _positiveX) || (posY < _negativeY || posY > _positiveY))
                    {
                        _prohibitedDIrection = _currentDirection;
                        GetNewDirection();
                        Destroy(riverPiece);
                        continue;
                    }
                    Vector3 pos = new Vector3(posX, posY);
                    riverPiece.transform.position = pos;
                    if (i == 0 && j == 0)
                    {
                        riverPiece.GetComponent<SpriteRenderer>().sprite = HorizontalDown;
                        _previousSide = Side.DownIsh;
                        _currentSide = Side.DownIsh;
                    }
                    else if (j != 0 || i != 0)
                    {
                        if (_currentSide == Side.UpIsh)
                        {
                            riverPiece.GetComponent<SpriteRenderer>().sprite = HorizontalUp;
                            _previousSide = _currentSide;
                            _currentSide = Side.UpIsh;
                        }
                        else if (_currentSide == Side.DownIsh)
                        {
                            riverPiece.GetComponent<SpriteRenderer>().sprite = HorizontalDown;
                            _previousSide = _currentSide;
                            _currentSide = Side.DownIsh;
                        }
                    }
                    riverPiece.transform.parent = River;
                    riverPiece.transform.name = i + " + " + j;
                    _previousRiverPiece = riverPiece;
                }
                else if (_currentDirection == Direction.Down)
                {
                    float posX = _previousRiverPiece.transform.position.x;
                    float posY = _previousRiverPiece.transform.position.y - _previousRiverPiece.GetComponent<SpriteRenderer>().size.y + _distanceBetweenTiles;
                    if ((posX < _negativeX || posX > _positiveX) || (posY < _negativeY || posY > _positiveY))
                    {
                        _prohibitedDIrection = _currentDirection;
                        GetNewDirection();
                        Destroy(riverPiece);
                        continue;
                    }
                    Vector3 pos = new Vector3(posX, posY);
                    riverPiece.transform.position = pos;
                    if (i == 0 && j == 0)
                    {
                        riverPiece.GetComponent<SpriteRenderer>().sprite = VerticalLeft;
                        _previousSide = Side.LeftIsh;
                        _currentSide = Side.LeftIsh;
                    }
                    else if (j != 0 || i != 0)
                    {
                        if (_currentSide == Side.RightIsh)
                        {
                            riverPiece.GetComponent<SpriteRenderer>().sprite = VerticalRight;
                            _previousSide = _currentSide;
                            _currentSide = Side.RightIsh;
                        }
                        else if (_currentSide == Side.LeftIsh)
                        {
                            riverPiece.GetComponent<SpriteRenderer>().sprite = VerticalLeft;
                            _previousSide = _currentSide;
                            _currentSide = Side.LeftIsh;
                        }
                    }
                    riverPiece.transform.parent = River;
                    riverPiece.transform.name = i + " + " + j;
                    _previousRiverPiece = riverPiece;
                }
                else if (_currentDirection == Direction.Up)
                {
                    float posX = _previousRiverPiece.transform.position.x;
                    float posY = _previousRiverPiece.transform.position.y + _previousRiverPiece.GetComponent<SpriteRenderer>().size.y - _distanceBetweenTiles;
                    if ((posX < _negativeX || posX > _positiveX) || (posY < _negativeY || posY > _positiveY))
                    {
                        _prohibitedDIrection = _currentDirection;
                        GetNewDirection();
                        Destroy(riverPiece);
                        continue;
                    }
                    Vector3 pos = new Vector3(posX, posY);
                    riverPiece.transform.position = pos;
                    if (i == 0 && j == 0)
                    {
                        riverPiece.GetComponent<SpriteRenderer>().sprite = VerticalLeft;
                        _previousSide = Side.LeftIsh;
                        _currentSide = Side.LeftIsh;
                    }
                    else if (j != 0 || i != 0)
                    {
                        if (_currentSide == Side.RightIsh)
                        {
                            riverPiece.GetComponent<SpriteRenderer>().sprite = VerticalRight;
                            _previousSide = _currentSide;
                            _currentSide = Side.RightIsh;
                        }
                        else if (_currentSide == Side.LeftIsh)
                        {
                            riverPiece.GetComponent<SpriteRenderer>().sprite = VerticalLeft;
                            _previousSide = _currentSide;
                            _currentSide = Side.LeftIsh;
                        }
                    }
                    riverPiece.transform.parent = River;
                    riverPiece.transform.name = i + " + " + j;
                    _previousRiverPiece = riverPiece;
                }
                EnvironementGenerator.Instance.PlacedRiverPieces.Add(riverPiece);
            }
            if (i == amountOfTurns - 1)
                Debug.Log("aaa");
            if (i < amountOfTurns)
            {
                _currentDirection = GetNewDirection();
            }
            SpawnRiverCorner();
        }
        SpawnRiverEnd(true);
    }
}
