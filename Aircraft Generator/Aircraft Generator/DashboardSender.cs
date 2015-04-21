namespace Aircraft_Generator
{
    public static class DashboardSender
    {
        private static int _total;
        private static int _landing;
        private static int _arrival;
        private static int _onService;
        private static int _taxing;
        private static int _departure;

        static DashboardSender()
        {
            _total = 0;
            _landing = 0;
            _arrival = 0;
            _onService = 0;
            _taxing = 0;
            _departure = 0;
        }

        public static void Total()
        {
            _total++;
            Dashboard.SendMessage(1,_total);
        }
        public static void Landing()
        {
            _landing++;
            Dashboard.SendMessage(2, _landing);
        }

        public static void Arrival()
        {
            _arrival++;
            Dashboard.SendMessage(3, _arrival);
        }

        public static void OnService()
        {
            _onService++;
            Dashboard.SendMessage(4,_onService);
        }

        public static void Taxing()
        {
            _taxing++;
            Dashboard.SendMessage(5,_taxing);
        }

        public static void Departure()
        {
            _departure++;
            Dashboard.SendMessage(6,_departure);
        }
    }
}