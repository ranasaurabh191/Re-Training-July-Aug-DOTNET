using System;
using System.Collections.Generics;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MetroSmartCard.Services
{
    public class MetroCardManager : IMetroOperations
    {
        private readonly Dictionary<int, Commuter> commuters;
        private readonly Dictionary<int, Station> stations;
        private readonly Dictionary<int, Journey> activeJourneys;

        private readonly Dictionary<int, List<double>> fareHistory;

        private readonly Dictionary<int, Dictionary<string, int>> routeHistory;

        private readonly Dictionary<int, Dictionary<long, double>> dailyFare;

        private readonly List<JourneyRecord> journeyRecords;

        private readonly double baseFare;
        private readonly double perKmRate;
        private readonly double maxDailyCap;

        public MetroCardManager(List<Station> stationList, double baseFare, double perKmRate, double maxDailyCap)
        {
            commuters = new Dictionary<int, Commuter>();

            stations = stationList.ToDictionary(x => x.StationId);

            activeJourneys = new Dictionary<int, Journey>();

            fareHistory = new Dictionary<int, List<double>>();

            routeHistory = new Dictionary<int, Dictionary<string, int>>();

            dailyFare = new Dictionary<int, Dictionary<long, double>>();

            journeyRecords = new List<JourneyRecord>();

            this.baseFare = baseFare; 
            this.perKmRate = perKmRate;
            this.maxDailyCap = maxDailyCap;
        }

        public void IssueCard(int cardNumber,
                              string commuterName,
                              string commuterType)
        {
            if (commuters.ContainsKey(cardNumber))
                return;

            commuters[cardNumber] = new Commuter
            {
                CardNumber = cardNumber,
                CommuterName = commuterName,
                CommuterType = commuterType,
                TravelSummary = new TravelSummary()
            };

            fareHistory[cardNumber] = new List<double>();

            routeHistory[cardNumber] = new Dictionary<string, int>();

            dailyFare[cardNumber] = new Dictionary<long, double>();
        }

        public bool TapIn(int cardNumber,
                          int stationId,
                          long epochTime)
        {
            if (!commuters.ContainsKey(cardNumber))
                return false;

            if (!stations.ContainsKey(stationId))
                return false;

            if (activeJourneys.ContainsKey(cardNumber))
                return false;

            activeJourneys[cardNumber] = new Journey
            {
                EntryStationId = stationId,
                EntryTime = epochTime
            };

            commuters[cardNumber].TravelSummary.LastEntryStation = stationId;
            commuters[cardNumber].TravelSummary.LastEntryTime = epochTime;

            return true;
        }

        private double GetDiscount(string type)
        {
            switch (type.ToUpper())
            {
                case "SENIOR":
                    return 0.50;

                case "STUDENT":
                    return 0.25;

                case "CHILD":
                    return 0.75;

                default:
                    return 0;
            }
        }

        private long GetDateKey(long epoch)
        {
            return epoch / 86400000;
        }

        private double CalculateDistance(Station s1,
                                         Station s2)
        {
            double lat1 = Math.PI * s1.Latitude / 180.0;
            double lon1 = Math.PI * s1.Longitude / 180.0;

            double lat2 = Math.PI * s2.Latitude / 180.0;
            double lon2 = Math.PI * s2.Longitude / 180.0;

            double dlat = lat2 - lat1;
            double dlon = lon2 - lon1;

            double a =
                Math.Pow(Math.Sin(dlat / 2), 2) +
                Math.Cos(lat1) *
                Math.Cos(lat2) *
                Math.Pow(Math.Sin(dlon / 2), 2);

            double c = 2 * Math.Asin(Math.Sqrt(a));

            return 6371 * c;
        }
    }
}