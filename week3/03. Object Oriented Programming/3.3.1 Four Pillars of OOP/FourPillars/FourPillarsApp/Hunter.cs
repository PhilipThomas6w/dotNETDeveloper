namespace FourPillarsApp
{
    public class Hunter : Person
    {
        private string _camera = "";


        public Hunter(string fName, string lName, string camera = "") : base(fName, lName)
        {
            _camera = camera;
        }

        public string Shoot()
        {
            return $"{GetFullName()} takes a photograph with their {_camera} camera.";
        }

        public override string ToString()
        {
            return $"{base.ToString()} _camera: {_camera}";
        }




    }
}
