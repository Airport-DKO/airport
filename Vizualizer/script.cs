using UnityEngine;
using System.Collections;
using System.IO;
using System.Collections.Generic;
using System.Threading;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Runtime.InteropServices;

public enum MoveObjectType
{
    None,
    Plane,
    FollowMeVan,
    ContainerLoader,
    BaggageTractor,
    CateringTruck,
    Deicer,
    PassengerStairs,
    PassengerBus,
    VipShuttle,
    SnowRemovalVehicle,
    Refueler
}
public enum Directions
{
    North,
    West,
    South,
    East
}
public struct Snow
{
    public GameObject go;
    public TilesPosition tp;
   
    public Snow(GameObject go, TilesPosition tp)
    {
        this.go = go;
        this.tp = tp;
    }

}
public struct TilesPosition
{
    public int posX;
    public int posY;

    public TilesPosition(int x, int y)
    {
        posX = x;
        posY = y;
    }
}
public class ServiceZone
{
    public TilesPosition tpos;
    public bool taken;

    public ServiceZone(TilesPosition tilePos)
    {
        tpos = tilePos;
        taken = false;
    }
}
public class Vehicle : MonoBehaviour
{
    public System.Guid guid;
    public MoveObjectType type;
    public string _name;
    public TilesPosition tilesPosition;
    public Vector2 actPosition;
    public Directions direction;
    public Vector2 actDestination;
    public TilesPosition tilesDestination;
    public TilesPosition prevTilesDestination;
    public int destinationx;
    public int destinationy;
    public float speed;
    public bool delete;




    public void InitialParameters(System.Guid guid, ref Vehicle vehicle, MoveObjectType type, TilesPosition destinationTile, Vector2 actPos, float speed, bool delete = false)
    {
        vehicle.type = type;
        vehicle.guid = guid;
        vehicle._name = type.ToString();
        vehicle.actDestination = vehicle.transform.position;
        vehicle.tilesDestination = destinationTile;
        vehicle.prevTilesDestination = destinationTile;
        vehicle.actPosition = vehicle.transform.position;
        vehicle.tilesPosition = destinationTile;
        destinationx = destinationTile.posX;
        destinationy = destinationTile.posY;
        vehicle.delete = false;
        this.speed = speed;

    }

    //public Vehicle(int id, string name, TilesPosition tilesPos, Vector2 actPosition, Directions direction, Vector2 actDestination = new Vector2(), TilesPosition tilesDirection = new TilesPosition())
    //{

    //    this.id = id;
    //    this.name = name;
    //    this.tilesPosition = tilesPos;
    //    this.actPosition = actPosition;
    //    this.direction = direction;
    //    this.actDestination = actPosition;
    //    this.tilesDirection = tilesPos;
    //}

    //public GameObject InstantiatePlane(KeyValuePair<float,float> coords)
    //{
    //    Vector3 posVector = new Vector3(coords.Key, coords.Value, 0);
    //    Object plane = Resources.Load("plane");
    //    Object obj =  Instantiate(plane, posVector, UnityEngine.Quaternion.identity);
    //    GameObject rb2D = obj as GameObject;
    //    return rb2D;

    //}
}
public class Tiles
{

    public TilesPosition tilesCustPos = new TilesPosition();
    public Vector2 tilesActPos;
    public float offset;
    public char symbol;
    public Tiles()
    { }
    public Tiles(TilesPosition tilePos, Vector2 pixelPos, float _offset, char symbol)
    {
        tilesCustPos = tilePos;
        tilesActPos = pixelPos;
        offset = _offset;
        this.symbol = symbol;
    }
    public Vector2 TileToPixel(Tiles tile)
    {
        return new Vector2(tile.tilesActPos.x, tile.tilesActPos.y);
    }
}


public class script : MonoBehaviour
{
    public bool listen = false;
    public int x;
    public int y;
    public TilesPosition tp = new TilesPosition();
    List<Vehicle> vehicleList = new List<Vehicle>();
    public int destinationX = 0;
    public int destinationY = 0;
    public Vector2 mapDimens;
    Tiles[,] tiles;
    List<string> messagesList = new List<string>();

    List<ServiceZone> serviceZoneList1 = new List<ServiceZone>();
    List<ServiceZone> serviceZoneList2 = new List<ServiceZone>();
    List<ServiceZone> serviceZoneList3 = new List<ServiceZone>();
    List<Snow> SnowList;

    TilesPosition servizeZoneCenter1;

    TilesPosition serviceZoneCenter2;

    TilesPosition serviceZoneCenter3;

    TilesPosition vehicleSpawnPoint;

    TilesPosition vehicleRemovePoint;

    TilesPosition planeSpawnPoint;

    TilesPosition planeRemovePoint;

    TilesPosition serviceZoneEnter1;
    TilesPosition serviceZoneEnter2;
    TilesPosition serviceZoneEnter3;




    static readonly object _lockObject = new object();

    //перевод тектовика в массив чаровC:\Users\Nikita\Documents\Airport\Assets\
    public char[,] mapTranslator(ref int rowSize, ref int columnSize)
    {
        string map;
        TcpClient client = new TcpClient("airport-dko-1.cloudapp.net", 9050);

        //var res = client.BeginConnect()
        var stream = client.GetStream();
        var buf = new byte[64];
        map = "200";
        buf = Encoding.ASCII.GetBytes(map);
        stream.Write(buf, 0, map.Length);
        buf = new byte[50000];
        stream.Read(buf, 0, 50000);
        map = Encoding.ASCII.GetString(buf);
        map = map.Trim('\0');
        stream.Close();
        client.Close();

        //TextAsset textAsset = (TextAsset)Resources.Load("change");
        //map = textAsset.text;
        //string map = updatePosition();
        string tempString = map.Replace("\n", "");
        int total = tempString.Length;
        int m = columnSize = map.IndexOf("\n");
        int n = rowSize = total / m;

        char[,] mapArray = new char[n, m];
        int count = 0;
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {

                mapArray[i, j] = tempString[count];
                count++;
            }
        }
        return mapArray;
    }

    public Vector2 DrawGrass()
    {
        //char map
        int rows = 0;
        int columns = 0;
        var map = mapTranslator(ref rows, ref columns);

        Object grass = Resources.Load("grass");
        Object asphalt = Resources.Load("asphalt");
        Object runway = Resources.Load("runway");

        Object side = Resources.Load("side");
        Object garage = Resources.Load("garage");
        Object airport = Resources.Load("airport");
        Object serviceZone = Resources.Load("service");

        float tileX = 0;
        float tileY = 0;
        tiles = new Tiles[rows, columns];
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {

                tiles[i, j] = new Tiles(new TilesPosition(i, j), new Vector2(tileX, tileY), 12, map[i, j]);

                tileX += 12f;
            }
            tileX = 0;
            tileY -= 12f;
        }

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                if (tiles[i, j].symbol == '+')
                {
                    Instantiate(runway, new Vector3(tiles[i, j].tilesActPos.x, tiles[i, j].tilesActPos.y), UnityEngine.Quaternion.identity);
                }
                else if (tiles[i, j].symbol == '.' || tiles[i, j].symbol == '-' || tiles[i, j].symbol == '|')
                {
                    Instantiate(asphalt, new Vector3(tiles[i, j].tilesActPos.x, tiles[i, j].tilesActPos.y), UnityEngine.Quaternion.identity);
                }
                else if (tiles[i, j].symbol == ' ')
                {
                    Instantiate(grass, new Vector3(tiles[i, j].tilesActPos.x, tiles[i, j].tilesActPos.y), UnityEngine.Quaternion.identity);
                }
                else if (tiles[i, j].symbol == '=')
                {
                    Instantiate(side, new Vector3(tiles[i, j].tilesActPos.x, tiles[i, j].tilesActPos.y), UnityEngine.Quaternion.identity);
                }
                else if (tiles[i, j].symbol == 'x')
                {
                    Instantiate(serviceZone, new Vector3(tiles[i, j].tilesActPos.x, tiles[i, j].tilesActPos.y), UnityEngine.Quaternion.identity);
                }
                else if (tiles[i, j].symbol == '#')
                {
                    Instantiate(airport, new Vector3(tiles[i, j].tilesActPos.x, tiles[i, j].tilesActPos.y), UnityEngine.Quaternion.identity);
                }
                else if (tiles[i, j].symbol == 'b')
                {
                    Instantiate(garage, new Vector3(tiles[i, j].tilesActPos.x, tiles[i, j].tilesActPos.y), UnityEngine.Quaternion.identity);
                }
                //arrival
                else if (tiles[i, j].symbol == '1')
                {
                    planeSpawnPoint = new TilesPosition(i, j);

                    Instantiate(runway, new Vector3(tiles[i, j].tilesActPos.x, tiles[i, j].tilesActPos.y), UnityEngine.Quaternion.identity);
                }
                //departure
                else if (tiles[i, j].symbol == '7')
                {
                    planeRemovePoint = new TilesPosition(i, j);

                    Instantiate(runway, new Vector3(tiles[i, j].tilesActPos.x, tiles[i, j].tilesActPos.y), UnityEngine.Quaternion.identity);
                }
                //spawn
                else if (tiles[i, j].symbol == '2')
                {
                    vehicleSpawnPoint = new TilesPosition(i, j);

                    Instantiate(garage, new Vector3(tiles[i, j].tilesActPos.x, tiles[i, j].tilesActPos.y), UnityEngine.Quaternion.identity);
                }
                //remove
                else if (tiles[i, j].symbol == '3')
                {

                    vehicleRemovePoint = new TilesPosition(i, j);

                    Instantiate(garage, new Vector3(tiles[i, j].tilesActPos.x, tiles[i, j].tilesActPos.y), UnityEngine.Quaternion.identity);
                }
                else if (tiles[i, j].symbol == '8')
                {
                    serviceZoneEnter2 = new TilesPosition(i, j);

                    Instantiate(serviceZone, new Vector3(tiles[i, j].tilesActPos.x, tiles[i, j].tilesActPos.y), UnityEngine.Quaternion.identity);
                }
                else if (tiles[i, j].symbol == '9')
                {
                    serviceZoneCenter2 = new TilesPosition(i, j);

                    Instantiate(serviceZone, new Vector3(tiles[i, j].tilesActPos.x, tiles[i, j].tilesActPos.y), UnityEngine.Quaternion.identity);
                }
                else if (tiles[i, j].symbol == 'm')
                {
                    serviceZoneEnter3 = new TilesPosition(i, j);

                    Instantiate(serviceZone, new Vector3(tiles[i, j].tilesActPos.x, tiles[i, j].tilesActPos.y), UnityEngine.Quaternion.identity);
                }
                else if (tiles[i, j].symbol == 'n')
                {
                    serviceZoneCenter3 = new TilesPosition(i, j);

                    Instantiate(serviceZone, new Vector3(tiles[i, j].tilesActPos.x, tiles[i, j].tilesActPos.y), UnityEngine.Quaternion.identity);
                }
                else if (tiles[i, j].symbol == '4')
                {
                    serviceZoneEnter1 = new TilesPosition(i, j);

                    Instantiate(serviceZone, new Vector3(tiles[i, j].tilesActPos.x, tiles[i, j].tilesActPos.y), UnityEngine.Quaternion.identity);
                }
                else if (tiles[i, j].symbol == '5')
                {
                    servizeZoneCenter1 = new TilesPosition(i, j);

                    Instantiate(serviceZone, new Vector3(tiles[i, j].tilesActPos.x, tiles[i, j].tilesActPos.y), UnityEngine.Quaternion.identity);
                }


            }
        }
        return (new Vector2(rows, columns));
    }

    public TilesPosition PositionToTile(Vector3 vector)
    {

        for (int i = 0; i < mapDimens.x; i++)
        {
            for (int j = 0; j < mapDimens.y; j++)
            {
                if (tiles[i, j].tilesActPos == (Vector2)vector)
                {
                    return tiles[i, j].tilesCustPos;
                }
            }
        }
        return new TilesPosition(0, 0);
    }
    public Vector2 TileToPosition(TilesPosition tile)
    {
        int vectorX = tile.posX;
        int vectorY = tile.posY;
        Vector2 newVector = tiles[vectorX, vectorY].tilesActPos;
        return newVector;
    }

    public void AddToList(int count, Vehicle v0 = null, Vehicle v1 = null, Vehicle v2 = null, Vehicle v3 = null, Vehicle v4 = null, Vehicle v5 = null, Vehicle v6 = null, Vehicle v7 = null, Vehicle v8 = null, Vehicle v9 = null)
    {
        for (int i = 0; i < count; i++)
        {
            vehicleList.Add(v0);
            vehicleList.Add(v1);
            vehicleList.Add(v2);
            vehicleList.Add(v3);
            vehicleList.Add(v4);
            vehicleList.Add(v5);
            vehicleList.Add(v6);
            vehicleList.Add(v7);
            vehicleList.Add(v8);
            vehicleList.Add(v9);
        }
    }
    //void CreateObjects()

    //{
    //    Vehicle plane = new Vehicle((int)MoveObjectType.Plane, "Plane", new TilesPosition(0, 0), new Vector2(tiles[0, 0].posX, tiles[0, 0].posY), Directions.North);
    //    Vehicle followMeVan = new Vehicle((int)MoveObjectType.FollowMeVan, "FollowMeVan", new TilesPosition(0, 1), new Vector2(tiles[0, 1].posX, tiles[0, 1].posY), Directions.North);
    //    Vehicle containerLoader = new Vehicle((int)MoveObjectType.ContainerLoader, "ContainerLoader", new TilesPosition(0, 2), new Vector2(tiles[0, 2].posX, tiles[0, 2].posY), Directions.North);
    //    Vehicle BaggageTractor = new Vehicle((int)MoveObjectType.BaggageTractor, "BaggageTractor", new TilesPosition(0, 3), new Vector2(tiles[0, 3].posX, tiles[0, 3].posY), Directions.North);
    //    Vehicle CateringTruck = new Vehicle((int)MoveObjectType.CateringTruck, "CateringTruck", new TilesPosition(0, 4), new Vector2(tiles[0, 4].posX, tiles[0, 4].posY), Directions.North);
    //    Vehicle deicer = new Vehicle((int)MoveObjectType.Deicer, "Deicer", new TilesPosition(0, 5), new Vector2(tiles[0, 5].posX, tiles[0, 5].posY), Directions.North);
    //    Vehicle passengerStairs = new Vehicle((int)MoveObjectType.PassengerStairs, "PassengerStairs", new TilesPosition(0, 6), new Vector2(tiles[0, 6].posX, tiles[0, 6].posY), Directions.North);
    //    Vehicle passengerBus = new Vehicle((int)MoveObjectType.PassengerBus, "PassengerBus", new TilesPosition(0, 7), new Vector2(tiles[0, 7].posX, tiles[0, 7].posY), Directions.North);
    //    Vehicle vipShuttle = new Vehicle((int)MoveObjectType.VipShuttle, "VipShuttle", new TilesPosition(0, 8), new Vector2(tiles[0, 8].posX, tiles[0, 8].posY), Directions.North);
    //    Vehicle snowRemovalMachine = new Vehicle((int)MoveObjectType.SnowRemovalVehicle, "SnowRemovalVehicle", new TilesPosition(0, 9), new Vector2(tiles[0, 9].posX, tiles[0, 9].posY), Directions.North);
    //    AddToList(plane, followMeVan, containerLoader, BaggageTractor, CateringTruck, deicer, passengerStairs, passengerBus, vipShuttle, snowRemovalMachine);
    //}

    void Start()
    {
        //DEBUG ONLY

        //randomList.Add("BaggageTractor;03342-Ef44-fsdv3;19;2;1;");
        //randomList.Add("VipShuttle;13342-Eg44-fsdv3;10;7;1;");
        //randomList.Add("PassengerBus;23343-Ef44-fsdv3;4;17;1;");
        //randomList.Add("Plane;33342-Ef46-fsdv3;19;2;1;");
        mapDimens = DrawGrass();

        addToServiceZone(servizeZoneCenter1, serviceZoneList1);
        addToServiceZone(serviceZoneCenter2, serviceZoneList2);
        addToServiceZone(serviceZoneCenter3, serviceZoneList3);

        Thread updateThread = new Thread(MoveFeed);
        updateThread.Start();
        //Vehicle plane = ((GameObject)(Instantiate(Resources.Load("plane"), TileToPosition(new TilesPosition(0, 1)), UnityEngine.Quaternion.identity))).AddComponent<Vehicle>();
        //plane.InitialParameters(2, ref plane, MoveObjectType.Plane, PositionToTile(plane.transform.position), plane.actPosition, 0.2f);
        //vehicleList.Add(plane);

        //Vehicle bus = ((GameObject)(Instantiate(Resources.Load("bus"), TileToPosition(new TilesPosition(5, 5)), UnityEngine.Quaternion.identity))).AddComponent<Vehicle>();
        //bus.InitialParameters(4, ref bus, MoveObjectType.PassengerBus, PositionToTile(bus.transform.position), bus.actPosition, 0.3f);
        //vehicleList.Add(bus); 
        //Vehicle vip = ((GameObject)(Instantiate(Resources.Load("vip"), TileToPosition(new TilesPosition(8, 15)), UnityEngine.Quaternion.identity))).AddComponent<Vehicle>();
        //vip.InitialParameters(8, ref vip, MoveObjectType.VipShuttle, PositionToTile(vip.transform.position), vip.actPosition, 0.7f);
        //vehicleList.Add(vip);





    }
    void MoveFeed()
    {



        string s;
        TcpClient new_client = new TcpClient("airport-dko-1.cloudapp.net", 9050);

        var inputStream = new_client.GetStream();
        var buf = new byte[1000];
        s = "201";
        buf = Encoding.ASCII.GetBytes(s);
        inputStream.Write(buf, 0, s.Length);

        while (true)
        {
            buf = new byte[1000];
            inputStream.Read(buf, 0, 1000);
            s = Encoding.ASCII.GetString(buf);
            s = s.Trim('\0');
            s = s.TrimEnd();
            lock (_lockObject)
            {
                messagesList.Add(s);
            }

        }


    }


    // Update is called once per frame

    void Update()
    {

        lock (_lockObject)
        {
            List<string>.Enumerator instEnum = messagesList.GetEnumerator();
            InstantaiteObject(instEnum);
        }
        bool empty = true;
        foreach (var item in vehicleList)
        {
            if (item.delete == true)
            {
                Destroy(item.gameObject);
                vehicleList.Remove(item);
            }
            else
            {
                empty = false;
            }
        }
        if (empty == true)
        {
            vehicleList.Clear();
        }
        List<Vehicle>.Enumerator listEnum = vehicleList.GetEnumerator();

        MoveObject(listEnum);


    }
    
    void MoveObject(IEnumerator<Vehicle> enumerator)
    {



        TilesPosition defaultPos2 = new TilesPosition(15, 16);
        Vector2 planeLeave = TileToPosition(defaultPos2);
        TilesPosition defaultPos3 = new TilesPosition(0, 0);
        Vector2 serviceZone = TileToPosition(defaultPos3);
        TilesPosition planeActRemove = new TilesPosition(0, 0);
        Vector2 planeRemove = TileToPosition(planeActRemove);

        while (enumerator.MoveNext())
        {

            Quaternion defaultRotation = new Quaternion();
            //enumerator.Current.actDestination = TileToPosition(enumerator.Current.tilesDestination);
            //if (destinationX!=0 && destinationY!=0)
            //{
            enumerator.Current.actDestination = TileToPosition(enumerator.Current.tilesDestination);
            //}
            //if (enumerator.Current.type==MoveObjectType.Plane && (enumerator.Current.actPosition == TileToPosition(planeRemovePoint)))
            //{
            //    transform.localScale += new Vector3(0.3F, 0.3F, 0);
            //}


            //LEFT
            if (enumerator.Current.actDestination.x - enumerator.Current.actPosition.x < 0)
            {
                enumerator.Current.actPosition.x -= enumerator.Current.speed;
                if (enumerator.Current.actDestination.x - enumerator.Current.actPosition.x >= 0)
                {
                    enumerator.Current.actPosition = new Vector2(enumerator.Current.actDestination.x, enumerator.Current.actPosition.y);
                    enumerator.Current.tilesPosition = enumerator.Current.tilesDestination;
                }

                else
                {
                    if (enumerator.Current.direction != Directions.West)
                    {
                        enumerator.Current.direction = Directions.West;
                        enumerator.Current.transform.rotation = defaultRotation;
                        enumerator.Current.transform.Rotate(Vector3.forward * +90);

                    }
                    enumerator.Current.transform.position = enumerator.Current.actPosition;

                }

            }
            //RIGHT
            else if (enumerator.Current.actDestination.x - enumerator.Current.actPosition.x > 0)
            {

                enumerator.Current.actPosition.x += enumerator.Current.speed;

                if (enumerator.Current.actDestination.x - enumerator.Current.actPosition.x <= 0)
                {
                    enumerator.Current.actPosition = new Vector2(enumerator.Current.actDestination.x, enumerator.Current.actPosition.y);
                    enumerator.Current.tilesPosition = enumerator.Current.tilesDestination;
                }
                else
                {

                    if (enumerator.Current.direction != Directions.East)
                    {
                        enumerator.Current.direction = Directions.East;
                        enumerator.Current.transform.rotation = defaultRotation;
                        enumerator.Current.transform.Rotate(Vector3.forward * -90);
                    }
                    enumerator.Current.transform.position = enumerator.Current.actPosition;
                }

            }

            else
            {


                //DOWN
                if (enumerator.Current.actDestination.y - enumerator.Current.actPosition.y < 0)
                {
                    enumerator.Current.actPosition.y -= enumerator.Current.speed;
                    if (enumerator.Current.actDestination.y - enumerator.Current.actPosition.y >= 0)
                    {
                        enumerator.Current.actPosition = new Vector2(enumerator.Current.actPosition.x, enumerator.Current.actDestination.y);
                        enumerator.Current.tilesPosition = enumerator.Current.tilesDestination;
                    }


                    else
                    {
                        if (enumerator.Current.direction != Directions.South)
                        {
                            enumerator.Current.direction = Directions.South;
                            enumerator.Current.transform.rotation = defaultRotation;
                            enumerator.Current.transform.Rotate(Vector3.forward * -180);

                        }
                        enumerator.Current.transform.position = enumerator.Current.actPosition;

                    }

                }
                //UP
                else if (enumerator.Current.actDestination.y - enumerator.Current.actPosition.y > 0)
                {
                    enumerator.Current.actPosition.y += enumerator.Current.speed;
                    if (enumerator.Current.actDestination.y - enumerator.Current.actPosition.y <= 0)
                    {
                        enumerator.Current.actPosition = new Vector2(enumerator.Current.actPosition.x, enumerator.Current.actDestination.y);
                        enumerator.Current.tilesPosition = enumerator.Current.tilesDestination;
                    }
                    else
                    {

                        if (enumerator.Current.direction != Directions.North)
                        {
                            enumerator.Current.direction = Directions.North;
                            enumerator.Current.transform.rotation = defaultRotation;
                        }

                        enumerator.Current.transform.position = enumerator.Current.actPosition;
                    }

                }

            }

            if (enumerator.Current.type == MoveObjectType.Plane && (enumerator.Current.actPosition == TileToPosition(planeRemovePoint)))
            {

                //enumerator.Current.tilesDestination = planeActRemove;
                enumerator.Current.delete = true;
                return;

            }
          
            if (enumerator.Current.type == MoveObjectType.SnowRemovalVehicle)
            {
                foreach (var item in SnowList)
                {
                    if (item.tp.posX==enumerator.Current.tilesDestination.posX  && item.tp.posY == enumerator.Current.tilesDestination.posY)
                    {
                        Destroy(item.go.gameObject);
                        SnowList.Remove(item);
                    }
                }
                
               

            }
            if (enumerator.Current.actPosition == TileToPosition(vehicleRemovePoint))
            {
                enumerator.Current.delete = true;
                return;
            }
           


                //ZONE1
                if (enumerator.Current.tilesDestination.posX == serviceZoneEnter1.posX  && enumerator.Current.tilesDestination.posY == serviceZoneEnter1.posY)
            {
                if (enumerator.Current.type==MoveObjectType.Plane)
                {
                    enumerator.Current.tilesDestination = servizeZoneCenter1;
                    enumerator.Current.actDestination = TileToPosition(enumerator.Current.tilesDestination);
                   
                }
                else
                {
                    foreach (var zone in serviceZoneList1)
                    {
                        if (!zone.taken)
                        {
                            zone.taken = true;
                            enumerator.Current.tilesDestination = zone.tpos;
                            enumerator.Current.actDestination = TileToPosition(enumerator.Current.tilesDestination);
                            
                            return;

                        }
                    }
                }
                

            }
            //ZONE2
            if (enumerator.Current.tilesDestination.posX == serviceZoneEnter2.posX && enumerator.Current.tilesDestination.posY == serviceZoneEnter2.posY)
            {
                if (enumerator.Current.type == MoveObjectType.Plane)
                {
                    enumerator.Current.tilesDestination = serviceZoneCenter2;
                    enumerator.Current.actDestination = TileToPosition(enumerator.Current.tilesDestination);
                    
                }
                else
                {
                    foreach (var zone in serviceZoneList2)
                    {
                        if (!zone.taken)
                        {
                            zone.taken = true;
                            enumerator.Current.tilesDestination = zone.tpos;
                            enumerator.Current.actDestination = TileToPosition(enumerator.Current.tilesDestination);
                            
                            return;

                        }
                    }
                }
                

            }
            //ZONE3
            if (enumerator.Current.tilesDestination.posX == serviceZoneEnter3.posX && enumerator.Current.tilesDestination.posY == serviceZoneEnter3.posY)
            {
                if (enumerator.Current.type==MoveObjectType.Plane)
                {
                    enumerator.Current.tilesDestination = serviceZoneCenter3;
                    enumerator.Current.actDestination = TileToPosition(enumerator.Current.tilesDestination);
                    
                }
                else
                {
                    foreach (var zone in serviceZoneList3)
                    {
                        if (!zone.taken)
                        {
                            zone.taken = true;
                            enumerator.Current.tilesDestination = zone.tpos;
                            enumerator.Current.actDestination = TileToPosition(enumerator.Current.tilesDestination);
                           
                            return;

                        }
                    }
                }
               

            }

        }
    }



    void addToServiceZone(TilesPosition serviceZone, List<ServiceZone> serviceZoneList)
    {


        int i = serviceZone.posX;
        int j = serviceZone.posY;

        serviceZoneList.Add(new ServiceZone(new TilesPosition(i - 2, j - 1)));

        serviceZoneList.Add(new ServiceZone(new TilesPosition(i - 2, j)));
        serviceZoneList.Add(new ServiceZone(new TilesPosition(i - 2, j + 1)));
        serviceZoneList.Add(new ServiceZone(new TilesPosition(i - 2, j + 2)));
        serviceZoneList.Add(new ServiceZone(new TilesPosition(i - 1, j + 2)));
        serviceZoneList.Add(new ServiceZone(new TilesPosition(i, j + 2)));
        serviceZoneList.Add(new ServiceZone(new TilesPosition(i + 1, j + 2)));
        serviceZoneList.Add(new ServiceZone(new TilesPosition(i + 2, j + 2)));
        serviceZoneList.Add(new ServiceZone(new TilesPosition(i + 2, j + 1)));
        serviceZoneList.Add(new ServiceZone(new TilesPosition(i + 2, j)));
        serviceZoneList.Add(new ServiceZone(new TilesPosition(i + 2, j - 1)));



    }
    void InstantaiteObject(IEnumerator<string> instanEnumerator)
    {

        lock (_lockObject)
        {
            while (instanEnumerator.MoveNext())
            {
                string moveObjectType = string.Empty;
                System.Guid newGuid = new System.Guid();
                int speed = 0;
                float realSpeed;
                TilesPosition dest = new TilesPosition();

                string s = instanEnumerator.Current;
                if (string.IsNullOrEmpty(s))
                {
                    return;
                }

                s = s.Replace(" ", "");

                string[] stringArray;
                stringArray = s.Split('.');

                for (int item = 0; item < stringArray.Length-1; item++)
                {


                    string[] objectProps = stringArray[item].Split(';');
                    if (objectProps[0] == "1")
                    {


                        continue;
                    }
                    if (objectProps[0] == "Reset")
                    {

                        messagesList.Clear();
                        foreach (var item1 in vehicleList)
                        {
                            item1.delete = true;
                        }
                        //messagesList.Clear();
                        return;
                    }
                    if (objectProps[0] == "LetSnow")
                    {

                       
                        foreach (var item2 in tiles)
                        {
                            if (item2.symbol == '.' || item2.symbol == '=' || item2.symbol == '+')
                            {
                                Object obj = Resources.Load("snow");
                                GameObject snow = Instantiate(obj, item2.tilesActPos, Quaternion.identity) as GameObject;
                                TilesPosition tilePos = PositionToTile((Vector3)item2.tilesActPos);
                                
                                Snow snowy = new Snow(snow, tilePos);
                                SnowList.Add(snowy);
                            }
                        }
                        messagesList.Clear();
                        return;
                    }


                    moveObjectType = objectProps[0];
                    newGuid = new System.Guid(objectProps[1]);
                    dest.posX = System.Convert.ToInt32(objectProps[3]);



                    dest.posY = System.Convert.ToInt32(objectProps[2]);



                    speed = System.Convert.ToInt32(objectProps[4]);




                    int indexOfVehicle = vehicleList.FindIndex(item1 => item1.guid == newGuid);

                    if (indexOfVehicle >= 0)
                    {
                        //CHANGE VALUE
                        vehicleList[indexOfVehicle].tilesDestination.posX = dest.posX;
                        //CHANGE VALUE
                        vehicleList[indexOfVehicle].tilesDestination.posY = dest.posY;
                    }
                    else
                    {

                        if (moveObjectType == MoveObjectType.Plane.ToString())
                        {
                            Vehicle plane = ((GameObject)(Instantiate(Resources.Load("plane"), TileToPosition(planeSpawnPoint), UnityEngine.Quaternion.identity))).AddComponent<Vehicle>();
                            plane.InitialParameters(newGuid, ref plane, MoveObjectType.Plane, dest, plane.actPosition, 3f);
                            vehicleList.Add(plane);
                        }
                        if (moveObjectType == MoveObjectType.VipShuttle.ToString())
                        {
                            Vehicle vip = ((GameObject)(Instantiate(Resources.Load("vip"), TileToPosition(vehicleSpawnPoint), UnityEngine.Quaternion.identity))).AddComponent<Vehicle>();
                            vip.InitialParameters(newGuid, ref vip, MoveObjectType.VipShuttle, dest, vip.actPosition, 3f);
                            vehicleList.Add(vip);
                        }
                        if (moveObjectType == MoveObjectType.PassengerBus.ToString())
                        {
                            Vehicle bus = ((GameObject)(Instantiate(Resources.Load("bus"), TileToPosition(vehicleSpawnPoint), UnityEngine.Quaternion.identity))).AddComponent<Vehicle>();
                            bus.InitialParameters(newGuid, ref bus, MoveObjectType.PassengerBus, dest, bus.actPosition, 3f);
                            vehicleList.Add(bus);
                        }
                        if (moveObjectType == MoveObjectType.Deicer.ToString())
                        {
                            Vehicle deicer = ((GameObject)(Instantiate(Resources.Load("deicer"), TileToPosition(vehicleSpawnPoint), UnityEngine.Quaternion.identity))).AddComponent<Vehicle>();
                            deicer.InitialParameters(newGuid, ref deicer, MoveObjectType.Deicer, dest, deicer.actPosition, 3f);
                            vehicleList.Add(deicer);
                        }
                        if (moveObjectType == MoveObjectType.PassengerStairs.ToString())
                        {
                            Vehicle ladder = ((GameObject)(Instantiate(Resources.Load("ladder"), TileToPosition(vehicleSpawnPoint), UnityEngine.Quaternion.identity))).AddComponent<Vehicle>();
                            ladder.InitialParameters(newGuid, ref ladder, MoveObjectType.PassengerStairs, dest, ladder.actPosition,3f);
                            vehicleList.Add(ladder);
                        }
                        if (moveObjectType == MoveObjectType.SnowRemovalVehicle.ToString())
                        {
                            Vehicle plower = ((GameObject)(Instantiate(Resources.Load("plower"), TileToPosition(vehicleSpawnPoint), UnityEngine.Quaternion.identity))).AddComponent<Vehicle>();
                            plower.InitialParameters(newGuid, ref plower, MoveObjectType.SnowRemovalVehicle, dest, plower.actPosition, 3f);
                            vehicleList.Add(plower);
                        }
                        if (moveObjectType == MoveObjectType.CateringTruck.ToString())
                        {
                            Vehicle catering = ((GameObject)(Instantiate(Resources.Load("catering"), TileToPosition(vehicleSpawnPoint), UnityEngine.Quaternion.identity))).AddComponent<Vehicle>();
                            catering.InitialParameters(newGuid, ref catering, MoveObjectType.CateringTruck, dest, catering.actPosition, 3f);
                            vehicleList.Add(catering);
                        }
                        if (moveObjectType == MoveObjectType.Refueler.ToString())
                        {
                            Vehicle fuel = ((GameObject)(Instantiate(Resources.Load("fuel"), TileToPosition(vehicleSpawnPoint), UnityEngine.Quaternion.identity))).AddComponent<Vehicle>();
                            fuel.InitialParameters(newGuid, ref fuel, MoveObjectType.Refueler, dest, fuel.actPosition, 3f);
                            vehicleList.Add(fuel);
                        }
                        if (moveObjectType == MoveObjectType.BaggageTractor.ToString())
                        {
                            Vehicle baggage = ((GameObject)(Instantiate(Resources.Load("baggage"), TileToPosition(vehicleSpawnPoint), UnityEngine.Quaternion.identity))).AddComponent<Vehicle>();
                            baggage.InitialParameters(newGuid, ref baggage, MoveObjectType.BaggageTractor, dest, baggage.actPosition, 3f);
                            vehicleList.Add(baggage);
                        }
                        if (moveObjectType == MoveObjectType.FollowMeVan.ToString())
                        {
                            Vehicle flwme = ((GameObject)(Instantiate(Resources.Load("flwme"), TileToPosition(vehicleSpawnPoint), UnityEngine.Quaternion.identity))).AddComponent<Vehicle>();
                            flwme.InitialParameters(newGuid, ref flwme, MoveObjectType.FollowMeVan, dest, flwme.actPosition, 3f);
                            vehicleList.Add(flwme);
                        }
                        if (moveObjectType == MoveObjectType.ContainerLoader.ToString())
                        {
                            Vehicle loader = ((GameObject)(Instantiate(Resources.Load("loader"), TileToPosition(vehicleSpawnPoint), UnityEngine.Quaternion.identity))).AddComponent<Vehicle>();
                            loader.InitialParameters(newGuid, ref loader, MoveObjectType.ContainerLoader, dest, loader.actPosition, 3f);
                            vehicleList.Add(loader);
                        }
                    }
                }

            }

        }
        messagesList.Clear();

    }
}

