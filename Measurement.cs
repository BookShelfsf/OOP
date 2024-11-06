namespace BMIMonitor.ValueTypes
{
    public struct Measurement
    {
        public double BMI { get; }

        public Measurement(double weight, double height)
        {
            BMI = weight / (height * height);
        }
    }
}
