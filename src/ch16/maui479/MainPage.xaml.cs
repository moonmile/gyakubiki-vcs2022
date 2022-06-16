namespace maui479;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
	}



	private void OnClicked(object sender, EventArgs e)
	{
		Accelerometer.ReadingChanged += Accelerometer_ReadingChanged;
		Accelerometer.Start(new SensorSpeed());
	}
    private void Accelerometer_ReadingChanged(object sender, AccelerometerChangedEventArgs e)
    {
		float x = e.Reading.Acceleration.X;
		float y = e.Reading.Acceleration.Y;
		float z = e.Reading.Acceleration.Z;

		this.labelX.Text = $"X: {x:0.000}";
		this.labelY.Text = $"Y: {y:0.000}";
		this.labelZ.Text = $"Z: {z:0.000}";

	}
}

