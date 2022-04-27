using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TriboPersonal.FirebaseServices;
using TriboPersonal.Model;
using TriboPersonal.Services;
using Xamarin.Forms;

namespace TriboPersonal.ViewModel
{
    internal class CadastrarAlunoViewModel : BaseViewModel
    {
        private string _nomeAluno;
        private string _nomeUsuario;
        const string senhaPadrao = "1234";
        private object _rdButtonVezesPorSemana;
        const bool isProfessor = false;
        const bool isAtivo = true;
        private object _rdButtonPlano;
        private object _rdButtonPrazo;
        private DateTime VencimentoEm;
        private string _valorMensalidade;
        private string Mensal = "Mensal";
        private string Trimestral = "Trimestral";

        public Command CadastraAluno { get; set; }

        public string ValorMensalidade
        {
            get => _valorMensalidade;
            set
            {
                _valorMensalidade = value;
                OnPropertyChanged();
            }
        }

        public object PlanoButton
        {
            get => _rdButtonPlano;
            set
            {
                _rdButtonPlano = value;
                OnPropertyChanged();
            }
        }

        public object PrazoButton
        {
            get => _rdButtonPrazo;
            set
            {
                _rdButtonPrazo = value;
                OnPropertyChanged();
            }
        }

        public object QtdeVezesPorSemana
        {
            get => _rdButtonVezesPorSemana;
            set
            {
                _rdButtonVezesPorSemana = value;
                OnPropertyChanged();
            }
        }

        public string NomeAluno
        {
            get => _nomeAluno;
            set
            {
                _nomeAluno = value;
                OnPropertyChanged();
            }
        }

        public string NomeUsuario
        {
            get => _nomeUsuario;
            set
            {
                _nomeUsuario = value.ToLower();
                OnPropertyChanged();
            }
        }

        public CadastrarAlunoViewModel()
        {
            CadastraAluno = new Command(async () => await CadastrarAluno());
        }

        private async Task CadastrarAluno()
        {
            bool verificaConexao = Conectividade.VerificaConectividade();

            try
            {
                if (verificaConexao)
                {
                    if (string.IsNullOrEmpty(NomeAluno))
                    {
                        await Application.Current.MainPage.DisplayAlert("Erro", "Os Campos São Obrigatórios", "OK");
                    }
                    else
                    {
                        var tipoPlano = PlanoButton;
                        var userService = new UserServices();

                        if (PrazoButton.ToString() == Mensal)
                        {
                            VencimentoEm = DateTime.Now.AddDays(30);

                        }
                        else if (PrazoButton.ToString() == Trimestral)
                        {
                            VencimentoEm = DateTime.Now.AddDays(90);
                        }
                        else
                        {
                            VencimentoEm = DateTime.Now.AddDays(180);
                        }

                        var qtdeAlunos = userService.RetornaAlunos();

                        var novoUsuario = new Usuario()
                        {
                            NomeAluno = NomeAluno,
                            NomeUsuario = NomeUsuario,
                            IsAtivo = isAtivo,
                            CreatedAt = DateTime.Today.ToShortDateString(),
                            IsProfessor = isProfessor,
                            QtdeVezesSemana = QtdeVezesPorSemana,
                            PeriodoContrato = PrazoButton,
                            SenhaAluno = senhaPadrao,                            
                            TipoPlano = PlanoButton,
                            VencimentoEm = VencimentoEm.Date.ToShortDateString(),
                            ValorMensalidade = ValorMensalidade

                        };


                        bool confirmaCadastro = await userService.CadastraAluno(novoUsuario);

                        if (confirmaCadastro)
                        {
                            await Application.Current.MainPage.DisplayAlert("Sucesso", "Usuário Cadastrado Com Sucesso", "OK");

                        }
                        else
                        {
                            await Application.Current.MainPage.DisplayAlert("Info", "Usuário Já Cadastrado No Sistema", "OK");
                        }

                    }
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Erro", "Não Foi Possível Verificar Credenciais. Verifique Sua Conexão de Internet.", "OK");
                }

            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Erro", ex.Message, "OK");
            }

        }
    }
}
