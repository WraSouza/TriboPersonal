using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TriboPersonal.ViewModel
{
    internal class ProfessorMainViewModel : BaseViewModel
    {
        public Command OpenFinancas { get; set; }
        public Command OpenCadastroAluno { get; set; }

        public ProfessorMainViewModel()
        {
            OpenFinancas = new Command(async () => await OpenFinancasView());
            OpenCadastroAluno = new Command(async () => await OpenCadastrarAlunoView());
        }

        private async Task OpenCadastrarAlunoView()
        {
            var route = $"{nameof(View.CadastrarAlunoView)}";
            await Shell.Current.GoToAsync(route);
        }

        private async Task OpenFinancasView()
        {
            var route = $"{nameof(View.FinancasView)}";
            await Shell.Current.GoToAsync(route);
        }
    }
}
