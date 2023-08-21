using Reactive.Bindings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace BlankApp1.Models
{
    public class ButtonProp
    {
        public string ButtonContent { get; set; }
        public ReactiveCommand ButtonCommand { get; set; }
    }

    public class FunctionProp
    {
        public ReactiveCommand<string> FunctionCommand { get; set; }
        public Visibility FunctionVisibility { get; set; }
        public bool FunctionIsEnabled { get; set; }
       
    }

    public class FunctionContentProp
    {
        public string FunctionContent1 { get; set; }
        public string FunctionContent2 { get; set; }
    }

    public record MyTextData(string Id, int Count, double? Point, string Content);
    public record MyButtonData(ButtonProp Button1, ButtonProp Button2);
    public record MyFunctionData(FunctionProp Escape, 
                                 FunctionProp Function1, FunctionProp Function2, FunctionProp Function3, 
                                 FunctionProp Function4, FunctionProp Function5, FunctionProp Function6, 
                                 FunctionProp Function7, FunctionProp Function8, FunctionProp Function9, 
                                 FunctionProp Function10, FunctionProp Function11, FunctionProp Function12);

    public record MyFunctionContentData(FunctionContentProp Escape,
                                        FunctionContentProp Function1, FunctionContentProp Function2, FunctionContentProp Function3,
                                        FunctionContentProp Function4, FunctionContentProp Function5, FunctionContentProp Function6,
                                        FunctionContentProp Function7, FunctionContentProp Function8, FunctionContentProp Function9,
                                        FunctionContentProp Function10, FunctionContentProp Function11, FunctionContentProp Function12);
}
