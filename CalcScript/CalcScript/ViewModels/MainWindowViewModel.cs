using CalcScript.Mvvm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.Scripting;

namespace CalcScript
{
    public class MainWindowViewModel : BindableBase
    {
        private ScriptingHost scriptingHost = new ScriptingHost();

        private string _codeText;
        public string CodeText
        {
            get { return _codeText; }
            set { SetProperty(ref _codeText, value); }
        }

        private string _result;
        public string Result
        {
            get { return _result; }
            set { SetProperty(ref _result, value); }
        }

        public DelegateCommand CalculateCommand { get; }

        public MainWindowViewModel()
        {
            CalculateCommand = new DelegateCommand(async _ => await Calculate(), _ => !string.IsNullOrWhiteSpace(CodeText));
        }

        private async Task Calculate()
        {
            
            try
            {
                var script = CSharpScript.Create(CodeText, ScriptOptions.Default
                    .WithReferences(typeof(object).Assembly,typeof(Enumerable).Assembly)
                    .WithImports(
                        "System",
                        "System.Collections.Generic",
                        "System.Linq"),
                    typeof(ScriptingHost));
                var context = await script.RunAsync(scriptingHost);
                Result = context.ReturnValue.ToString();
            }catch(CompilationErrorException e)
            {
                Result = e.ToString();
            }
        }
    }
}
