namespace maui464;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
	}
	MainViewModel _vm;

	protected override void OnAppearing()
	{
		base.OnAppearing();
		_vm = new MainViewModel();
		this.BindingContext = _vm;
	}

	public void OnInputClicked(object sender, EventArgs e)
	{
		_vm.Result = $"{_vm.Name} ({_vm.Age}) in {_vm.Address}";
		// ここにキーボードを消す処理が必要
	}
}

public class MainViewModel : Prism.Mvvm.BindableBase
{
	public string Name { get; set; } = "";
	public int Age { get; set; } = 0;
	public string Address { get; set; } = "";

	public string _result = "";
	public string Result
	{
		get => _result;
		set => SetProperty(ref _result, value, nameof(Result));
	}
}

