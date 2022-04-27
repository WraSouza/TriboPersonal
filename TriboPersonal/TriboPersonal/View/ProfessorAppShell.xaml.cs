using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TriboPersonal.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfessorAppShell : Shell
    {
        public ProfessorAppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(FinancasView), typeof(FinancasView));
            Routing.RegisterRoute(nameof(CadastrarAlunoView), typeof(CadastrarAlunoView));
        }
    }
}