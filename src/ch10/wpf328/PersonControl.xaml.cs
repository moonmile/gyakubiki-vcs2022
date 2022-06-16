using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace wpf328
{
    /// <summary>
    /// PersonControl.xaml の相互作用ロジック
    /// </summary>
    public partial class PersonControl : UserControl
    {
        public PersonControl()
        {
            InitializeComponent();

            this.textName.TextChanged += (_, _) => { _person.Name = this.textName.Text; };
            this.textAge.TextChanged += (_, _) => { _person.Age = int.Parse(this.textAge.Text); };
            this.textAddress.TextChanged += (_, _) => { _person.Address = this.textAddress.Text; };
        }

        /// <summary>
        /// 依存プロパティの定義
        /// </summary>
        public static readonly DependencyProperty ItemProperty =
            DependencyProperty.Register(
                "Item",
                typeof(Person),
                typeof(PersonControl),
                new FrameworkPropertyMetadata(
                    null,
                    FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
                    new PropertyChangedCallback((o, e) =>
                    {
                        var uc = o as PersonControl;
                        if (uc != null)
                        {
                            if (e.NewValue != null)
                            {
                                var pa = e.NewValue as Person;
                                if ( pa != null )
                                {
                                    uc._person = pa;
                                    uc.textId.Text = pa.Id.ToString();
                                    uc.textName.Text = pa.Name;
                                    uc.textAge.Text = pa.Age.ToString();
                                    uc.textAddress.Text = pa.Address;
                                }
                            }
                        }
                    })));

        private Person _person = new Person();
        public Person Item
        {
            get => _person;
            set => SetValue(ItemProperty, value);
        }
    }
}
