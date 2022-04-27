using Firebase.Database;
using Firebase.Database.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TriboPersonal.Model;

namespace TriboPersonal.FirebaseServices
{
    internal class UserServices
    {
        FirebaseClient firebase;

        public UserServices()
        {
            firebase = new FirebaseClient("https://tribopersonalacademia-default-rtdb.firebaseio.com/");
        }

        public async Task<bool> LoginUser(string nomeUsuario, string passwd)
        {
           
            var user = (await firebase.Child("Usuario")
                .OnceAsync<Usuario>())
                .Where(u => u.Object.NomeUsuario == nomeUsuario)
                .Where(u => u.Object.SenhaAluno == passwd)
                .FirstOrDefault();


            return (user != null);
        }

        public async Task<bool> GetUserStatus(string nomeUsuario)
        {
            var user = (await firebase.Child("Usuario")
               .OnceAsync<Usuario>())
               .Where(u => u.Object.NomeUsuario == nomeUsuario)
               .FirstOrDefault();

            return user.Object.IsAtivo;
        }

        public async Task<bool> IsUSerExists(string nomeUsuario)
        {
            var user = (await firebase.Child("Usuario")
                .OnceAsync<Usuario>())
                .Where(u => u.Object.NomeUsuario == nomeUsuario)
                .FirstOrDefault();

            return (user != null);
        }

        public async Task<bool> CadastraAluno(Usuario usuario)
        {
            if (await IsUSerExists(usuario.NomeUsuario) == false)
            {
                await firebase.Child("Usuario")
                    .PostAsync(new Usuario()
                    {
                        NomeUsuario = usuario.NomeUsuario,
                        NomeAluno = usuario.NomeAluno,
                        SenhaAluno = usuario.SenhaAluno,
                        IsAtivo = usuario.IsAtivo,
                        IsProfessor = usuario.IsProfessor,
                        QtdeVezesSemana = usuario.QtdeVezesSemana,
                        PeriodoContrato = usuario.PeriodoContrato,
                        TipoPlano = usuario.TipoPlano,
                        CreatedAt = usuario.CreatedAt,
                        VencimentoEm = usuario.VencimentoEm,
                        ValorMensalidade = usuario.ValorMensalidade
                    });

                return true;
            }
            else
            {
                return false;
            }

        }

        public async Task<bool> GetUserProfile(string nomeUsuario)
        {
            var user = (await firebase.Child("Usuario")
               .OnceAsync<Usuario>())
               .Where(u => u.Object.NomeUsuario == nomeUsuario)
               .FirstOrDefault();

            return user.Object.IsProfessor;
        }

        public async Task<string> GetUserSenha(string nomeUsuario)
        {
            var user = (await firebase.Child("Usuario")
               .OnceAsync<Usuario>())
               .Where(u => u.Object.NomeUsuario == nomeUsuario)
               .FirstOrDefault();

            return user.Object.SenhaAluno;
        }

        public async Task<List<Usuario>> RetornaUsuarios()
        {
            return (await firebase.Child("Usuario")
                .OnceAsync<Usuario>()).Select(item => new Usuario
                {
                    NomeAluno = item.Object.NomeAluno,
                    IsProfessor = item.Object.IsProfessor,
                    TipoPlano = item.Object.TipoPlano,
                    VencimentoEm = item.Object.VencimentoEm,
                    ValorMensalidade = item.Object.ValorMensalidade,
                    PeriodoContrato = item.Object.PeriodoContrato,
                    CreatedAt = item.Object.CreatedAt

                }).ToList();
        }

        public async Task<List<Usuario>> RetornaAlunos()
        {
            var alunos = await RetornaUsuarios();
            await firebase
                .Child("Usuario")
                .OnceAsync<Usuario>();

            return alunos.Where(a => a.IsProfessor == false).ToList();
        }
    }
}
