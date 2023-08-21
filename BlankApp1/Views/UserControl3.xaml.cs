using BlankApp1.Models;
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

namespace BlankApp1.Views
{
    /// <summary>
    /// UserControl3.xaml の相互作用ロジック
    /// </summary>
    public partial class UserControl3 : UserControl
    {
        public UserControl3()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty FunctionValueProperty =
            DependencyProperty.Register(
                nameof(FunctionValue),
                typeof(MyFunctionData),
                typeof(UserControl3), new PropertyMetadata(null));

        public MyFunctionData FunctionValue
        {
            get => (MyFunctionData)GetValue(FunctionValueProperty);
            set => SetValue(FunctionValueProperty, value);
        }

        public static readonly DependencyProperty FunctionContentValueProperty =
            DependencyProperty.Register(
                nameof(FunctionContentValue),
                typeof(MyFunctionContentData),
                typeof(UserControl3), new PropertyMetadata(null));

        public MyFunctionContentData FunctionContentValue
        {
            get => (MyFunctionContentData)GetValue(FunctionContentValueProperty);
            set => SetValue(FunctionContentValueProperty, value);
        }
    }
}
