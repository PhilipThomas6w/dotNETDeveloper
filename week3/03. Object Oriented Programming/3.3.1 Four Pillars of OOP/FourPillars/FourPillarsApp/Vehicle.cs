namespace FourPillarsApp
{
    public class Vehicle
    {
        #region FIELDS

        private int _capacity;

        private int _numPassengers;

        #endregion

        #region PROPERTIES

        public int NumPassengers { get; set; }

        public int Position { get; set; }

        public int Speed { get; init; } = 10;

        #endregion

        #region METHODS

        public string Move()
        {

        }

        public string Move(int times)
        {

        }

        #endregion

        #region CONSTRUCTORS

         public Vehicle() { }

        public Vehicle(int capacity, int speed = 10) { } 

        #endregion

    }
}
