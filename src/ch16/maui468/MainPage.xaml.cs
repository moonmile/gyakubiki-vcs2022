namespace maui468;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
        this.Loaded += MainPage_Loaded;
	}

    private List<Data> _Items;

    private void MainPage_Loaded(object sender, EventArgs e)
    {
        _Items = new List<Data>();
        _Items.Add(new Data { Id = 1, Name = "ブラームス：間奏曲２番" });
        _Items.Add(new Data { Id = 2, Name = "バッハ：リュート組曲　第４番" });
        _Items.Add(new Data { Id = 3, Name = "タンスマン：カヴァティーナ組曲より" });
        _Items.Add(new Data { Id = 4, Name = "レノックス・バークリー：ギターのためのソナチネより" });
        _Items.Add(new Data { Id = 5, Name = "ヴィラ・ロボス：12の練習曲より" });
        _Items.Add(new Data { Id = 6, Name = "ドビュッシー：月の光～ベルガマスク組曲より" });
        this.cv.ItemsSource = _Items;
    }

    private void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var item = this.cv.SelectedItem as Data;
        this.DisplayAlert("選択", item.Name, "OK");
    }
}
public class Data
{
    public int Id { get; set; }
    public string Name { get; set; }
}

