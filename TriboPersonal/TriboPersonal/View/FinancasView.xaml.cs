using Microcharts;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TriboPersonal.FirebaseServices;
using TriboPersonal.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Entry = Microcharts.ChartEntry;


namespace TriboPersonal.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FinancasView : ContentPage
    {               

        public FinancasView()
        {
            InitializeComponent();           
        }       

        protected async override void OnAppearing()
        {
            UserServices userServices = new UserServices();
            float somaJaneiro = 0.00f;
            float somaFevereiro = 0.00f;
            float somaMarco = 0.00f;
            float somaAbril = 0.00f;
            float somaMaio = 0.00f;
            float somaJunho = 0.00f;
            float somaJulho = 0.00f;
            float somaAgosto = 0.00f;
            float somaSetembro = 0.00f;
            float somaOutubro = 0.00f;
            float somaNovembro = 0.00f;
            float somaDezembro = 0.00f;

            var lista = await userServices.RetornaAlunos();

            foreach (var valores in lista)
            {
                if(Convert.ToDateTime(valores.VencimentoEm).Month > 1 && Convert.ToDateTime(valores.CreatedAt).Month == 1)
                {
                    somaJaneiro = somaJaneiro + float.Parse(valores.ValorMensalidade);
                }

                if (Convert.ToDateTime(valores.VencimentoEm).Month > 2 && Convert.ToDateTime(valores.CreatedAt).Month <= 2)
                {
                    somaFevereiro = somaFevereiro + float.Parse(valores.ValorMensalidade);
                }

                if (Convert.ToDateTime(valores.VencimentoEm).Month > 3 && Convert.ToDateTime(valores.CreatedAt).Month <= 3)
                {
                    somaMarco = somaMarco + float.Parse(valores.ValorMensalidade);
                }

                if (Convert.ToDateTime(valores.VencimentoEm).Month > 4 && Convert.ToDateTime(valores.CreatedAt).Month <= 4)
                {
                    somaAbril = somaAbril + float.Parse(valores.ValorMensalidade);
                }

                if (Convert.ToDateTime(valores.VencimentoEm).Month > 5 && Convert.ToDateTime(valores.CreatedAt).Month <= 5)
                {
                    somaMaio = somaMaio + float.Parse(valores.ValorMensalidade);
                }

                if (Convert.ToDateTime(valores.VencimentoEm).Month > 6 && Convert.ToDateTime(valores.CreatedAt).Month <= 6)
                {
                    somaJunho = somaJunho + float.Parse(valores.ValorMensalidade);
                }

                if (Convert.ToDateTime(valores.VencimentoEm).Month > 7 && Convert.ToDateTime(valores.CreatedAt).Month <= 7)
                {
                    somaJulho = somaJulho + float.Parse(valores.ValorMensalidade);
                }

                if (Convert.ToDateTime(valores.VencimentoEm).Month > 8 && Convert.ToDateTime(valores.CreatedAt).Month <= 8)
                {
                    somaAgosto = somaAgosto + float.Parse(valores.ValorMensalidade);
                }

                if (Convert.ToDateTime(valores.VencimentoEm).Month > 9 && Convert.ToDateTime(valores.CreatedAt).Month <= 9)
                {
                    somaSetembro = somaSetembro + float.Parse(valores.ValorMensalidade);
                }

                if (Convert.ToDateTime(valores.VencimentoEm).Month > 10 && Convert.ToDateTime(valores.CreatedAt).Month <= 10)
                {
                    somaOutubro = somaOutubro + float.Parse(valores.ValorMensalidade);
                }

                if (Convert.ToDateTime(valores.VencimentoEm).Month > 11 && Convert.ToDateTime(valores.CreatedAt).Month <= 11)
                {
                    somaNovembro = somaNovembro + float.Parse(valores.ValorMensalidade);
                }

                if (Convert.ToDateTime(valores.VencimentoEm).Month > 12 && Convert.ToDateTime(valores.CreatedAt).Month <= 12)
                {
                    somaDezembro = somaDezembro + float.Parse(valores.ValorMensalidade);
                }

            }

            List<Entry> entries = new List<Entry>
                {
                    new Entry(somaJaneiro)
                    {
                        Color = SKColor.Parse("#8B405F"),
                        Label = "Janeiro",
                        ValueLabel = somaJaneiro.ToString()
                    },
                    new Entry(somaFevereiro)
                    {
                        Color = SKColor.Parse("#7CCFED"),
                        Label = "Fevereiro",
                        ValueLabel = somaFevereiro.ToString()
                    },
                    new Entry(somaMarco)
                    {
                        Color = SKColor.Parse("#6A8A9D"),
                        Label = "Março",
                        ValueLabel = somaMarco.ToString()
                    },
                    new Entry(somaAbril)
                    {
                        Color = SKColor.Parse("#315E75"),
                        Label = "Abril",
                        ValueLabel = somaAbril.ToString()
                    },
                    new Entry(somaMaio)
                    {
                        Color = SKColor.Parse("#BD382D"),
                        Label = "Maio",
                        ValueLabel = somaMaio.ToString()
                    },
                    new Entry(somaJunho)
                    {
                        Color = SKColor.Parse("#B40101"),
                        Label = "Junho",                        
                        ValueLabel = somaJunho.ToString()
                    },
                    new Entry(somaJulho)
                    {
                        Color = SKColor.Parse("#B40101"),
                        Label = "Julho",
                        ValueLabel = somaJulho.ToString()
                    },
                    new Entry(somaAgosto)
                    {
                        Color = SKColor.Parse("#B40101"),
                        Label = "Agosto",
                        ValueLabel = somaAgosto.ToString()
                    },
                    new Entry(somaSetembro)
                    {
                        Color = SKColor.Parse("#B40101"),
                        Label = "Setembro",
                        ValueLabel = somaSetembro.ToString()
                    },
                    new Entry(somaOutubro)
                    {
                        Color = SKColor.Parse("#B40101"),
                        Label = "Outubro",
                        ValueLabel = somaOutubro.ToString()
                    },
                    new Entry(somaNovembro)
                    {
                        Color = SKColor.Parse("#B40101"),
                        Label = "Novembro",
                        ValueLabel = somaNovembro.ToString()
                    },
                    new Entry(somaDezembro)
                    {
                        Color = SKColor.Parse("#B40101"),
                        Label = "Dezembro",
                        ValueLabel = somaDezembro.ToString()
                    }
                };
            

            if(DateTime.Today.Month == 1)
            {
                lblValor.Text = somaJaneiro.ToString();
            }

            if (DateTime.Today.Month == 2)
            {
                lblValor.Text = somaFevereiro.ToString();
            }

            if (DateTime.Today.Month == 3)
            {
                lblValor.Text = somaMarco.ToString();
            }

            if (DateTime.Today.Month == 4)
            {
                lblValor.Text = somaAbril.ToString();
            }

            if (DateTime.Today.Month == 5)
            {
                lblValor.Text = somaMaio.ToString();
            }

            if (DateTime.Today.Month == 6)
            {
                lblValor.Text = somaJunho.ToString();
            }

            if (DateTime.Today.Month == 7)
            {
                lblValor.Text = somaJulho.ToString();
            }

            if (DateTime.Today.Month == 8)
            {
                lblValor.Text = somaAgosto.ToString();
            }

            if (DateTime.Today.Month == 9)
            {
                lblValor.Text = somaSetembro.ToString();
            }

            if (DateTime.Today.Month == 10)
            {
                lblValor.Text = somaOutubro.ToString();
            }

            if (DateTime.Today.Month == 11)
            {
                lblValor.Text = somaNovembro.ToString();
            }

            if (DateTime.Today.Month == 12)
            {
                lblValor.Text = somaDezembro.ToString();
            }

            lblMesAtual.Text = DateTime.Today.ToString("MMMM").ToUpper();

            grafico.Chart = new LineChart() { Entries = entries };

        }

            
        }


    }