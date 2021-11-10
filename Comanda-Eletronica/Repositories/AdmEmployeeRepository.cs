using Comanda_Eletronica.Data;
using Comanda_Eletronica.Entities;
using Comanda_Eletronica.Entities.Enums;
using Comanda_Eletronica.Models;
using Comanda_Eletronica.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Comanda_Eletronica.Repositories
{
    public class AdmEmployeeRepository : IAdmEmployeeRepository
    {
        private ComandaEletronicaContext Context;
        public AdmEmployeeRepository(ComandaEletronicaContext context)
        {
            Context = context;
        }
        public void CriaFuncionario(FuncionarioRequest funcionarioRequest)
        {
            string user = null;

            if (funcionarioRequest.Nome.Trim().IndexOf(" ") > -1)
            {
                user = funcionarioRequest.Nome.Trim().Replace(" ", ".");
            }

            var usuarioExistente = Context.Funcionario.Where(p => p.usuario.Contains(user)).OrderBy(p => p.usuario).ToList();

            if (usuarioExistente.Count() > 0)
            {
                string usuarioLista = null;
                string usuarioApoio = user;
                for (int i = 0; i < usuarioExistente.Count(); i++)
                {
                    usuarioLista = usuarioExistente[i].usuario.ToString();
                    if (usuarioLista.Equals(usuarioApoio))
                    {
                        usuarioApoio = (user + (i + 1)).ToString();
                    }
                }
                user = usuarioApoio;
            }

            var funcionario = new Funcionario()
            {
                nome = funcionarioRequest.Nome,
                usuario = user,
                email = funcionarioRequest.Email,
                senha = GeraSenha(),
                status = Enum.Parse<Status>("Ativo")
        };
            Context.Funcionario.Add(funcionario);
            Context.SaveChanges();

            EnviarEmail(funcionario.senha, funcionario.email, funcionario.nome);
        }

        public void RemoveFuncionario(FuncionarioRequest funcionarioRequest)
        {
            var funcionario = Context.Funcionario.Find(funcionarioRequest.IdFuncionario);

                funcionario.status = Enum.Parse<Status>("Inativo");

            Context.SaveChanges();
        }

        public void AlteraFuncionario(FuncionarioRequest funcionarioRequest)
        {
            var funcionario = Context.Funcionario.Find(funcionarioRequest.IdFuncionario);

            if (!string.IsNullOrEmpty(funcionarioRequest.Nome))
            {
                funcionario.nome = funcionarioRequest.Nome;
            }

            if (!string.IsNullOrEmpty(funcionarioRequest.Usuario))
            {
                funcionario.usuario = funcionarioRequest.Usuario;
            }

            if (!string.IsNullOrEmpty(funcionarioRequest.IdModulo))
            {
                funcionario.id_modulo_fk = Enum.Parse<Modulo>(funcionarioRequest.IdModulo);
            }

            if (!string.IsNullOrEmpty(funcionarioRequest.Senha))
            {
                funcionario.senha = funcionarioRequest.Senha;
            }

            if (!string.IsNullOrEmpty(funcionarioRequest.Email))
            {
                funcionario.email = funcionarioRequest.Email;
            }

            if (!string.IsNullOrEmpty(funcionarioRequest.Status))
            {
                funcionario.status = Enum.Parse<Status>("Ativo");
            }

            Context.SaveChanges();
        }

        public void ResetSenha(FuncionarioRequest funcionarioRequest)
        {
            var funcionario = Context.Funcionario.Find(funcionarioRequest.IdFuncionario);
            {
                funcionario.senha = GeraSenha();
            }

            if (!string.IsNullOrEmpty(funcionarioRequest.Nome))
            {
                funcionario.nome = funcionarioRequest.Nome;
            }

            if (!string.IsNullOrEmpty(funcionarioRequest.Usuario))
            {
                funcionario.usuario = funcionarioRequest.Usuario;
            }

            if (!string.IsNullOrEmpty(funcionarioRequest.IdModulo))
            {
                funcionario.id_modulo_fk = Enum.Parse<Modulo>(funcionarioRequest.IdModulo);
            }

            Context.SaveChanges();

            EnviarEmail(funcionario.senha, funcionario.email, funcionario.nome);
        }

        public List<Funcionario> BuscaFuncionarios()
        {
            return Context.Funcionario.Where(f => f.status.Equals(Status.Ativo)).ToList();
        }

        public string GeraSenha()
        {
            var characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var Charsarr = new char[8];
            var random = new Random();

            for (int i = 0; i < Charsarr.Length; i++)
            {
                Charsarr[i] = characters[random.Next(characters.Length)];
            }

            var resultString = new String(Charsarr);
            return resultString;
        }

        protected void EnviarEmail(string senha, string email, string nome)
        {
            System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient()
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                Credentials = new System.Net.NetworkCredential("dark.group.ope2@gmail.com", "ImpactaOPE2*")
            };

            MailMessage mail = new MailMessage()
            {
                Sender = new System.Net.Mail.MailAddress("soares.bianca.sv@gmail.com", "Comanda Eletronica APP"),
                From = new MailAddress("soares.bianca.sv@gmail.com", "Comanda Eletronica APP"),
                Subject = "Senha",
                Body = nome + ",  \r\n \r\n Sua senha para acessar o APP Comanda Eletronica é: <b>" + senha,
                IsBodyHtml = true,
                Priority = MailPriority.High
            };

            mail.To.Add(new MailAddress(email, nome));

            client.Send(mail);
        }
    }
}