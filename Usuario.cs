using System.IO;

namespace login
{
    public class Usuario
    {
        private string Login { get; set; }

        private string Senha { get; set; }

        public Usuario()
        {

        }
        public Usuario(string Login, string Senha)
        {
            this.Login = Login;
            this.Senha = Senha;
        }

        public void Cadastrar()
        {
            string path = @"..\Login\CadUsuario.txt";
            StreamWriter arq = new StreamWriter(path, true);
            arq.WriteLine();
            arq.Write("{0};", Login);
            arq.Write("{0};", Senha);
            arq.Close();
            System.Console.WriteLine("\nusuario cadastrado com sucesso");
        }

        public delegate void EventoUsuario();

        public event EventoUsuario acao_usuario;
    }
}