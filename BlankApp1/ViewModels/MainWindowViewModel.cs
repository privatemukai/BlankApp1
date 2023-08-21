using BlankApp1.Models;
using Prism.Mvvm;
using Reactive.Bindings;
using System.Threading;
using System;
using System.Windows;
using System.Threading.Tasks;
using BlankApp1.Converters;
using System.Collections.ObjectModel;
using BlankApp1.Commons;
using System.Windows.Documents;
using System.Collections.Generic;
using BlankApp1.Statics;
using Statics.BlankApp1;
using BlankApp1.Interfaces;

namespace BlankApp1.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        #region プロパティ

        public ReactiveProperty<DateTime> TargetDate { get; set; } = new ReactiveProperty<DateTime>(new DateTime(2023, 8, 1));
        public ReactiveProperty<string> Title { get; private set; } = new ReactiveProperty<string>("通貨変換アプリ");
        public ObservableCollection<ComboItem> CurrencyFromList { get; private set; }
        public ReactiveProperty<string> CurrencyFromValue { get; set; } = new ReactiveProperty<string>("");
        public ReactiveProperty<string> SelectedCurrencyFrom { get; set; } = new ReactiveProperty<string>("");
        public ObservableCollection<ComboItem> CurrencyToList { get; private set; }
        public ReactiveProperty<string> CurrencyToValue { get; set; } = new ReactiveProperty<string>("");
        public ReactiveProperty<string> SelectedCurrencyTo { get; set; } = new ReactiveProperty<string>("");
        public ReactiveProperty<string> UnitNameValue { get; set; } = new ReactiveProperty<string>("");
        public ReactiveProperty<MyTextData> MyTextData { get; } = new ReactiveProperty<MyTextData>();
        public ReactiveProperty<MyFunctionData> MyFunctionData { get; } = new ReactiveProperty<MyFunctionData>();
        public ReactiveProperty<MyFunctionContentData> MyFunctionContentData { get; } = new ReactiveProperty<MyFunctionContentData>();

        #endregion

        #region コマンド

        ReactiveCommand<string> FncCmd;

        #endregion

        #region パブリック変数

        public Window window;

        #endregion

        #region コンストラクタ

        public MainWindowViewModel()
        {
            CreateComboBox();
            CreateFunctions();
        }

        #endregion

        #region コントロール生成関連

        /// <summary>
        /// コンボボックスのItemsを生成
        /// </summary>
        private void CreateComboBox()
        {
            CurrencyFromList = new ObservableCollection<ComboItem>();
            CurrencyToList = new ObservableCollection<ComboItem>();
            var createItem = new CreateComboItem();
            CurrencyFromList.AddRange(createItem.CurrencyItems());
            CurrencyToList.AddRange(createItem.CurrencyItems());
        }

        /// <summary>
        /// 画面下部のボタンにイベントを付与
        /// </summary>
        private void CreateFunctions()
        {
            FncCmd = new ReactiveCommand<string>().WithSubscribe(p => FncExec(p));

            MyFunctionData.Value = new MyFunctionData(
                new FunctionProp() { FunctionCommand = FncCmd, FunctionVisibility = Visibility.Visible, FunctionIsEnabled = true },
                new FunctionProp() { FunctionCommand = null, FunctionVisibility = Visibility.Collapsed, FunctionIsEnabled = true },
                new FunctionProp() { FunctionCommand = null, FunctionVisibility = Visibility.Collapsed, FunctionIsEnabled = true },
                new FunctionProp() { FunctionCommand = null, FunctionVisibility = Visibility.Collapsed, FunctionIsEnabled = true },
                new FunctionProp() { FunctionCommand = null, FunctionVisibility = Visibility.Collapsed, FunctionIsEnabled = true },
                new FunctionProp() { FunctionCommand = null, FunctionVisibility = Visibility.Collapsed, FunctionIsEnabled = true },
                new FunctionProp() { FunctionCommand = null, FunctionVisibility = Visibility.Collapsed, FunctionIsEnabled = true },
                new FunctionProp() { FunctionCommand = null, FunctionVisibility = Visibility.Collapsed, FunctionIsEnabled = true },
                new FunctionProp() { FunctionCommand = null, FunctionVisibility = Visibility.Collapsed, FunctionIsEnabled = true },
                new FunctionProp() { FunctionCommand = null, FunctionVisibility = Visibility.Collapsed, FunctionIsEnabled = true },
                new FunctionProp() { FunctionCommand = null, FunctionVisibility = Visibility.Collapsed, FunctionIsEnabled = true },
                new FunctionProp() { FunctionCommand = null, FunctionVisibility = Visibility.Collapsed, FunctionIsEnabled = true },
                new FunctionProp() { FunctionCommand = FncCmd, FunctionVisibility = Visibility.Visible, FunctionIsEnabled = true }
            );

            MyFunctionContentData.Value = new MyFunctionContentData(
                new FunctionContentProp() { FunctionContent1 = "", FunctionContent2 = "終了" },
                new FunctionContentProp() { FunctionContent1 = "", FunctionContent2 = "" },
                new FunctionContentProp() { FunctionContent1 = "", FunctionContent2 = "" },
                new FunctionContentProp() { FunctionContent1 = "", FunctionContent2 = "" },
                new FunctionContentProp() { FunctionContent1 = "", FunctionContent2 = "" },
                new FunctionContentProp() { FunctionContent1 = "", FunctionContent2 = "" },
                new FunctionContentProp() { FunctionContent1 = "", FunctionContent2 = "" },
                new FunctionContentProp() { FunctionContent1 = "", FunctionContent2 = "" },
                new FunctionContentProp() { FunctionContent1 = "", FunctionContent2 = "" },
                new FunctionContentProp() { FunctionContent1 = "", FunctionContent2 = "" },
                new FunctionContentProp() { FunctionContent1 = "", FunctionContent2 = "" },
                new FunctionContentProp() { FunctionContent1 = "", FunctionContent2 = "" },
                new FunctionContentProp() { FunctionContent1 = "", FunctionContent2 = "変換" }
            );
        }

        #endregion

        #region ボタン押下イベント

        /// <summary>
        /// ボタン押下イベント
        /// </summary>
        /// <param name="parameter"></param>
        private void FncExec(string parameter)
        {
            switch (parameter.ToLower())
            {
                case "esc":
                    window.Close();
                    break;
                case "f12":
                    var rateTrancitions = new RateTrancitionList();
                    if (!InputCheck(rateTrancitions))
                    {
                        return;
                    }
                    Convert(rateTrancitions);
                    break;
            }            
        }

        #endregion

        #region 変換処理メインロジック

        /// <summary>
        /// 変換メイン処理
        /// </summary>
        private void Convert(RateTrancitionList rateTrancitions)
        {
            // 変換元のコンバータークラスを取得する。
            IConverterBase fromCnv = ConverterFactory.GetInstance(SelectedCurrencyFrom.Value);
            // 変換後のコンバータークラスを取得する。
            IConverterBase toCnv = ConverterFactory.GetInstance(SelectedCurrencyTo.Value);
            // 入力内容から変換元のレート情報を取得してコンバータークラスにセットする。
            fromCnv.SetRateTrancition(rateTrancitions.GetRateTrancition(SelectedCurrencyFrom.Value, TargetDate.Value));
            // 入力内容から変換後のレート情報を取得してコンバータークラスにセットする。
            toCnv.SetRateTrancition(rateTrancitions.GetRateTrancition(SelectedCurrencyTo.Value, TargetDate.Value));

            // 単位変換クラスのインスタンス生成（変換前後のコンバータークラスを渡す）
            var converter = new CurrencyConverter(fromCnv, toCnv);
            // 単位変換処理メソッドに変換元の数値を渡して変換後の金額を受け取る。
            var cnvresult = converter.Convert(double.Parse(CurrencyFromValue.Value));
            // 結果を画面に表示する。
            CurrencyToValue.Value = cnvresult.ToString("#,##0.00");
            UnitNameValue.Value = toCnv.UnitName;
        }

        #endregion

        #region 変換処理入力チェック

        /// <summary>
        /// 入力チェック
        /// </summary>
        /// <returns></returns>
        private bool InputCheck(RateTrancitionList rateTrancitions)
        {
            if (!rateTrancitions.RateTrancitionExists(SelectedCurrencyFrom.Value, TargetDate.Value) ||
                !rateTrancitions.RateTrancitionExists(SelectedCurrencyTo.Value, TargetDate.Value))
            {
                MessageBox.Show("選択した日付はデータが存在しません。");
                return false;
            }

            if (string.IsNullOrEmpty(SelectedCurrencyFrom.Value.TrimEnd()))
            {
                MessageBox.Show("変換元の通貨を選択してください。");
                return false;
            }

            if (string.IsNullOrEmpty(SelectedCurrencyTo.Value.TrimEnd()))
            {
                MessageBox.Show("変換後の通貨を選択してください。");
                return false;
            }

            if (SelectedCurrencyFrom.Value.TrimEnd() == SelectedCurrencyTo.Value.TrimEnd())
            {
                MessageBox.Show("変換元の通貨と変換後の通貨が同じです。");
                return false;
            }

            if (string.IsNullOrEmpty(CurrencyFromValue.Value.TrimEnd()))
            {
                MessageBox.Show("変換元の金額を入力してください。");
                return false;
            }
            double fromValue = double.NaN;
            if (!double.TryParse(CurrencyFromValue.Value, out fromValue))
            {
                MessageBox.Show("変換元の金額には数値を入力してください。");
                return false;
            }
            return true;
        }

        #endregion
    }
}
