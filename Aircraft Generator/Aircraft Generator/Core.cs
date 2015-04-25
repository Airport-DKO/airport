using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Aircraft_Generator.Commons;
using Aircraft_Generator.DeicerVs;
using Aircraft_Generator.FollowMeWs;
using Aircraft_Generator.GmcVs;
using Aircraft_Generator.GscWs2;
using Aircraft_Generator.InformationPanelWS;
using Aircraft_Generator.MetrologicalService;
using Aircraft_Generator.PassengersWs;
using Aircraft_Generator.TowerService;
using Aircraft_Generator.WeatherWs;
using MapObject = Aircraft_Generator.GmcVs.MapObject;
using MoveObjectType = Aircraft_Generator.GmcVs.MoveObjectType;

namespace Aircraft_Generator
{
    public class Core
    {
        #region Singleton_realization

        private static readonly Lazy<Core> _instance =
            new Lazy<Core>(() => new Core());

        public static Core Instance
        {
            get { return _instance.Value; }
        }

        #endregion

        private readonly List<Plane> _createdPlanes;
        private readonly FollowMe _followMe;
        private readonly GMC _gmc;
        private readonly GSC _gsc;
        private readonly MetrologService _metrolog;
        private readonly WebServiceInformationPanel _panel;
        private readonly WebServicePassengersGenerator _passengersGenerator;

        private readonly SynchronizedCollection<CancellationTokenSource> _tokens;
        private readonly Tower _tower;
        private readonly WebServiceWeather _weather;

        private CancellationTokenSource _token;

        private Core()
        {
            _createdPlanes = new List<Plane>();
            _tower = new Tower();
            _gmc = new GMC();
            _gsc = new GSC();
            _panel = new WebServiceInformationPanel();
            _metrolog = new MetrologService();
            _followMe = new FollowMe();
            _passengersGenerator = new WebServicePassengersGenerator();
            _weather = new WebServiceWeather();
            _tokens = new SynchronizedCollection<CancellationTokenSource>();
            Rabbit.Instance.MessageReceived += CancelTasks;
            _token = new CancellationTokenSource();
        }

        public List<Plane> Planes
        {
            get { return _createdPlanes; }
        }

        public bool CreateNewPlane(String name, PlaneType type, int fuelNeed,
            int currentStandartPassengers, int currentVipPassengers, bool hasArrivalPassengers, int currentBaggage)
        {
            if (type == PlaneType.Jet)
            {
                hasArrivalPassengers = false;
            }
            else
            {
                if (currentStandartPassengers > 0 || currentVipPassengers > 0)
                {
                    hasArrivalPassengers = true;
                }
                else
                {
                    hasArrivalPassengers = false;
                }
            }
            var plane = new Plane(name, PlaneState.Arrival, type, fuelNeed, currentStandartPassengers,
                currentVipPassengers, currentBaggage, 0, hasArrivalPassengers);
            _createdPlanes.Add(plane);
            Debug.WriteLine("Самолет {0} создан! Тип: {1}. Топливо {2}, Пассажиры: {3} Вип: {4} Баггаж: {5}", name, type,
                fuelNeed, currentStandartPassengers, currentVipPassengers, currentBaggage);
            Logger.SendMessage(1, "AircraftGenerator",
                String.Format("Самолет {0} создан! Тип: {1}. Топливо {2}, Пассажиры: {3} Вип: {4} Баггаж: {5}", name,
                    type,
                    fuelNeed, currentStandartPassengers, currentVipPassengers, currentBaggage),
                _metrolog.GetCurrentTime());
            DashboardSender.Total();
            return true;
        }

        public void BindPlaneToFlight(Guid planeId, Guid flightId)
        {
            Plane plane = Planes.First(p => p.Id == planeId);
            DashboardSender.Arrival();
            plane.Flight = _panel.RegisterPlaneToFlight(planeId, flightId);
            var task = new Task(() => PlaneLanding(plane, _token.Token), _token.Token);
            Debug.WriteLine("Plane {0} binded to {1}", planeId, flightId);
            Logger.SendMessage(1, "AircraftGenerator",
                String.Format("Самолет {0} закреплен на рейс {1}", planeId, flightId),
                _metrolog.GetCurrentTime());
            task.Start();
        }

        public bool LoadStandartPassangers(MapObject serviceZone, List<Guid> passengersGuids)
        {
            Plane plane = Planes.FirstOrDefault(p => p.ServiceZone.Number == serviceZone.Number);
            if (plane == null)
            {
                return true;
            }
            plane.CurrentStandartPassengers += passengersGuids.Count;
            _passengersGenerator.onPlane(passengersGuids.ToArray());
            return true;
        }

        public bool LoadVipPassangers(MapObject serviceZone, List<Guid> passengersGuids)
        {
            Plane plane = Planes.FirstOrDefault(p => p.ServiceZone.Number == serviceZone.Number);
            if (plane == null)
            {
                return true;
            }
            plane.CurrentVipPassengers += passengersGuids.Count;
            _passengersGenerator.onPlane(passengersGuids.ToArray());
            return true;
        }

        public bool UnloadStandartPassangers(MapObject serviceZone, int countOfPassengers)
        {
            Plane plane = Planes.FirstOrDefault(p => p.ServiceZone.Number == serviceZone.Number);
            if (plane == null)
            {
                return true;
            }
            if (countOfPassengers >= plane.CurrentStandartPassengers)
            {
                countOfPassengers = plane.CurrentStandartPassengers;
            }
            plane.CurrentStandartPassengers -= countOfPassengers;
            return true;
        }

        public bool UnloadVipPassangers(MapObject serviceZone, int countOfPassengers)
        {
            Plane plane = Planes.FirstOrDefault(p => p.ServiceZone.Number == serviceZone.Number);
            if (plane == null)
            {
                return true;
            }
            if (countOfPassengers >= plane.CurrentVipPassengers)
            {
                countOfPassengers = plane.CurrentVipPassengers;
            }
            plane.CurrentVipPassengers -= countOfPassengers;
            return true;
        }

        public bool LoadBaggage(MapObject serviseZone, int weightOfBaggage)
        {
            Plane plane = Planes.FirstOrDefault(p => p.ServiceZone.Number == serviseZone.Number);
            if (plane == null)
            {
                return true;
            }
            plane.CurrentBaggage += weightOfBaggage;
            return true;
        }

        public bool UnloadBaggage(MapObject serviseZone, int weightOfBaggage)
        {
            Plane plane = Planes.FirstOrDefault(p => p.ServiceZone.Number == serviseZone.Number);
            if (plane == null)
            {
                return true;
            }
            if (weightOfBaggage >= plane.CurrentBaggage)
            {
                weightOfBaggage = plane.CurrentBaggage;
            }
            plane.CurrentBaggage -= weightOfBaggage;
            return true;
        }

        public bool FollowMe(Guid planeId)
        {
            PlaneTaxingToServiceZone(planeId);

            Debug.WriteLine("Самолет {0} вызван машиной Follow Me", planeId);
            Logger.SendMessage(0, "AircraftGenerator", String.Format("К самолету {0} приехал Follow me", planeId),
                _metrolog.GetCurrentTime());
            return true;
        }

        public bool DoStep(Guid planeId, CoordinateTuple step)
        {
            Plane plane = Planes.First(p => p.Id == planeId);
            MoveObjectType type = plane.Type == PlaneType.Jet ? MoveObjectType.Jet : MoveObjectType.Plane;
            while (true)
            {
                bool result = _gmc.Step(step, type, planeId, 1000*Rabbit.Instance.CurrentCoef);
                if (result)
                {
                    break;
                }
                if (_token.IsCancellationRequested)
                    return false;
                Sleep(1000);
            }
            return true;
        }

        public bool FollowMeComplete(Guid planeId)
        {
            PlaneIsReadyToService(planeId);
            Debug.WriteLine("Самолет {0} доехал до сервис зоны", planeId);
            Logger.SendMessage(1, "AircraftGenerator", String.Format("Самолет {0} готов к обслуживанию", planeId),
                _metrolog.GetCurrentTime());
            return true;
        }

        public bool Douched(MapObject serviceZone)
        {
            Plane plane = Planes.First(
                p =>
                    p.ServiceZone.MapObjectType == serviceZone.MapObjectType &&
                    p.ServiceZone.Number == serviceZone.Number);
            _panel.ReadyToTakeOff(plane.Flight.number);
            Debug.WriteLine("Самолет {0} облит реагентом", plane.Name);
            Logger.SendMessage(1, "AircraftGenerator", String.Format("Самолет {0} облит антиобледенителем", plane.Name),
                _metrolog.GetCurrentTime());
            MoveToRunway(plane, false);
            return true;
        }

        private void MoveToRunway(Plane plane, bool isFirstCall)
        {
            if (isFirstCall)
            {
                while (true)
                {
                    // Проверяем время вылета
                    if (_panel.IsFlightSoon(plane.Flight.number))
                    {
                        break;
                    }
                    Sleep(10000);
                    Debug.WriteLine("Самолет {0} время вылета еще не настало", plane.Name);
                }

                while (true)
                {
                    double windInCity;
                    try
                    {
                        windInCity = _weather.GetTempFromCity(plane.Flight.city.ToString());
                    }
                    catch (Exception)
                    {
                        windInCity = 0;
                    }
                    if (windInCity < 30)
                    {
                        Debug.WriteLine("Самолет {0} погода в пункте назначения хорошая", plane.Name);
                        Logger.SendMessage(1, "AircraftGenerator",
                            String.Format("Самолет {0} погода в пункте назначения хорошая", plane.Name),
                            _metrolog.GetCurrentTime());
                        break;
                    }
                    Debug.WriteLine("Самолет {0} не вылетает из за сильного ветра в пункте назначения", plane.Name);
                    Logger.SendMessage(1, "AircraftGenerator",
                        String.Format("Самолет {0} не вылетает из за сильного ветра в пункте назначения", plane.Name),
                        _metrolog.GetCurrentTime());
                    Sleep(100000); // оч долго
                }
                plane.State = PlaneState.TaxingToRunway;
                DashboardSender.Taxing();


                while (true)
                {
// Проверяем свободна ли полоса
                    if (_gmc.CheckRunwayAwailability(plane.Id,
                        plane.Type == PlaneType.Jet ? MoveObjectType.Jet : MoveObjectType.Plane, false))
                    {
                        Logger.SendMessage(1, "AircraftGenerator",
                            String.Format("Самолет {0} освободил площадку обслуживания", plane.Name),
                            _metrolog.GetCurrentTime());
                        break;
                    }
                    Sleep(40000);
                    Debug.WriteLine("Самолет {0} - полоса занята", plane.Name);
                }


                double temperature;
                try
                {
                    temperature = _weather.GetTemperature(false);
                }
                catch (Exception)
                {
                    temperature = 10;
                }
                bool tempResult = (temperature <= 4 && temperature >= 0) ? true : false;
                if (tempResult) // Weather check
                {
                    var d = new Deicer();
                    d.DouchePlane(plane.ServiceZone);
                    Logger.SendMessage(0, "AircraftGenerator",
                        String.Format("Самолет {0} отправил заявку антиобледенителю", plane.Name),
                        _metrolog.GetCurrentTime());
                    Debug.WriteLine("Самолет {0} отправил заявку антиобледенителю", plane.Name);
                    return;
                }
                Logger.SendMessage(0, "AircraftGenerator",
                    String.Format("Самолету {0} антиобледенитель не требуется", plane.Name),
                    _metrolog.GetCurrentTime());
                Debug.WriteLine("Самолету {0} антиобледенитель не требуется", plane.Name);
            }
            MapObject runway = _gmc.GetRunway();
            CoordinateTuple[] route;
            while (true)
            {
                // Получаем маршрут до полосы
                route = _gmc.GetRoute(plane.ServiceZone, runway);
                if (route.Count() >= 0)
                {
                    break;
                }
                Sleep(30000);
            }

            _panel.ReadyToTakeOff(plane.Flight.number);

            while (true)
            {
                // Проверяем время вылета
                if (_panel.IsFlightRightNow(plane.Flight.number))
                {
                    break;
                }
                Sleep(10000);
                Debug.WriteLine("Самолет {0} время вылета еще не настало", plane.Name);
            }

            var coordinateTuple = new CoordinateTuple();
            foreach (CoordinateTuple coordinate in route)
            {
// Едем до полосы
                bool result;

                while (true)
                {
                    var time = 7000 * Rabbit.Instance.CurrentCoef;
                    if (plane.Type == PlaneType.Jet)
                    {
                        result = _gmc.Step(coordinate, MoveObjectType.Jet, plane.Id, time);
                    }
                    else
                    {
                        result = _gmc.Step(coordinate, MoveObjectType.Plane, plane.Id, time);
                    }
                    if (result)
                    {
                        coordinateTuple = coordinate;
                        break;
                    }
                    Sleep(Convert.ToInt32(time));
                }
                var localtime = 7000 * Rabbit.Instance.CurrentCoef;
                Sleep(Convert.ToInt32(localtime));
            }


            Debug.WriteLine("Самолет {0} вылетел", plane.Name);
            Logger.SendMessage(1, "AircraftGenerator",
                String.Format("Самолет {0} вылетел", plane.Name),
                _metrolog.GetCurrentTime());
            plane.State = PlaneState.Departed;
            DashboardSender.Departure();
            Sleep(30000); // Ждем 30 секунд и освобождаем полосу
            _gsc.SetFreePlace(plane.Id); // Сообщаем УНО что освобождаем площадку
            _gmc.RunwayRelease(coordinateTuple.X, coordinateTuple.Y);
            Logger.SendMessage(1, "AircraftGenerator",
                String.Format("Самолет {0} освободил взлетную полосу", plane.Name),
                _metrolog.GetCurrentTime());
            Debug.WriteLine("Самолет {0} освободил взлетную полосу", plane.Name);
        }

        private void Sleep(int time)
        {
            while (true)
            {
                int sleepTime = Convert.ToInt32(time*Rabbit.Instance.CurrentCoef);
                var tokenSource = new CancellationTokenSource();
                _tokens.Add(tokenSource);
                bool cancelled = tokenSource.Token.WaitHandle.WaitOne(sleepTime);
                _tokens.Remove(tokenSource);
                if (cancelled)
                {
                    continue;
                }
                break;
            }
        }


        private void PlaneLanding(Plane plane, CancellationToken token)
        {
            try
            {
                while (!CheckTime(plane.Flight.arrivalTime))
                {
                    if (token.IsCancellationRequested)
                    {
                        return;
                    }
                    Sleep(10000);
                }
                Debug.WriteLine("Самолет {0} готов приземляться по времени", plane.Name);
                while (true)
                {
                    if (token.IsCancellationRequested)
                    {
                        return;
                    }
                    bool landingRequest = _tower.LandingRequest(plane.Id,
                        plane.Type == PlaneType.Jet
                            ? TowerService.MoveObjectType.Jet
                            : TowerService.MoveObjectType.Plane);
                    if (!landingRequest)
                    {
                        Sleep(10000);
                        Debug.WriteLine("Самолет {0} - полоса занята", plane.Name);
                    }
                    else
                    {
                        break;
                    }
                }
                Debug.WriteLine("Самолет {0} получил разрешение на посадку ", plane.Name);

                MapObject runway = _gmc.GetRunway();
                plane.State = PlaneState.Landing;
                DashboardSender.Landing();
                plane.ServiceZone = _gmc.GetPlaneServiceZone(plane.Id);
                _followMe.LeadPlane(runway, plane.ServiceZone, plane.Id);
                Debug.WriteLine("Самолет {0} Приземлился!", plane.Name);
                Logger.SendMessage(1, "AircraftGenerator", String.Format("Самолет {0} приземлился!", plane.Name),
                    _metrolog.GetCurrentTime());
            }
            catch (OperationCanceledException)
            {
            }
        }

        private void CancelTasks(object sender, MetrologicalEventArgs e)
        {
            for (int i = 0; i < _tokens.Count; i++)
            {
                _tokens[i].Cancel();
            }
        }

        private void PlaneTaxingToServiceZone(Guid planeGuid)
        {
            Plane plane = _createdPlanes.First(p => p.Id == planeGuid);
            plane.State = PlaneState.TaxingToServiceArea;

            new Task(() =>
            {
                Sleep(20000);
                _gmc.RunwayRelease(0, 0);
            }).Start();
            Debug.WriteLine("Самолет {0} поехал до сервиз зоны и освободил взлетную полосу", plane.Name);
        }

        private void PlaneIsReadyToService(Guid planeGuid)
        {
            Plane plane = _createdPlanes.First(p => p.Id == planeGuid);
            plane.State = PlaneState.OnService;
            DashboardSender.OnService();
            _gsc.SetNeeds(plane.Id, plane.Flight, plane.HasArrivalPassengers, plane.CurrentStandartPassengers,
                plane.CurrentVipPassengers, plane.CurrentBaggage, plane.FuelNeed);
            Logger.SendMessage(0, "AircraftGenerator",
                String.Format("Самолет {0} отправил в УНО запрос на обслуживание", plane.Name),
                _metrolog.GetCurrentTime());
            Debug.WriteLine("Самолет {0} доехал до СЗ и отправил в УНО запрос", plane.Name);
        }

        private bool CheckTime(DateTime time)
        {
            DateTime currentAirportTime = _metrolog.GetCurrentTime();
            if (currentAirportTime >= time)
            {
                return true;
            }
            return false;
        }


        public void ServiceComplete(Guid planeId)
        {
            Plane plane = Planes.First(p => p.Id == planeId);
            Debug.WriteLine("Самолет {0} получил информацию от УНО о том, что он обслужен", plane.Name);
            Logger.SendMessage(0, "AircraftGenerator",
                String.Format("Самолет {0} получил информацию от УНО о том, что он обслужен", plane.Name),
                _metrolog.GetCurrentTime());
            while (!_panel.IsFlightSoon(plane.Flight.number))
            {
                Logger.SendMessage(0, "AircraftGenerator",
                    String.Format("Самолет {0} еще не готов к вылету по расписанию", plane.Name),
                    _metrolog.GetCurrentTime());
                Debug.WriteLine("Самолет {0} еще не готов к вылету по расписанию", plane.Name);
                Sleep(50000);
            }
            Logger.SendMessage(0, "AircraftGenerator",
                String.Format("Самолет {0} по расписанию скоро вылетит", plane.Name),
                _metrolog.GetCurrentTime());
            Debug.WriteLine("Самолет {0} по расписанию скоро вылетит", plane.Name);
            MoveToRunway(plane, true);
        }

        public void Reset()
        {
            Planes.Clear();
            _token.Cancel(true);
            _token = new CancellationTokenSource();
        }
    }
}