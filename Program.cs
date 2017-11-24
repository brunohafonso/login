using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace login
{
    class Program
    {
        static void Main(string[] args)
        {
            MenuPrincipal();
        }

        public static void MenuPrincipal()
        {
            System.Console.WriteLine("--- facecodexp.com ---");
            System.Console.WriteLine("1 - Cadastrar usuario");
            System.Console.WriteLine("2 - Logar no Sistema");
            System.Console.WriteLine("3 - Deslogar do Sistema");
            System.Console.WriteLine("4 - finalizar programa");
            string opcao = Console.ReadLine();
            switch (opcao)
            {
                case "1":
                    MenuCadastrarUsuario();
                    break;
                case "2":

                    break;
                case "3":

                    break;
                case "4":
                    System.Environment.Exit(1);
                    break;
                default:
                    System.Console.WriteLine("A opcao digitada é invalida ou não existe");
                    MenuPrincipal();
                    break;
            }
        }

        public static void MenuCadastrarUsuario()
        {
            System.Console.WriteLine("    --- facecodexp.com ---");
            System.Console.WriteLine("---- Cadastrando usuario ----");
            System.Console.WriteLine("Digite o Login");
            string Login = Console.ReadLine();
            while (Login.Length < 1)
            {
                System.Console.WriteLine("Usuario invalido, digite novamente");
                Login = Console.ReadLine();
            }
            VerificarCadastro(Login);
            System.Console.WriteLine("Digite a senha");
            string senha = Console.ReadLine();
            while (senha.Length < 8)
            {
                System.Console.WriteLine("senha digitada invalida, digite uma senha com pelo menos 8 caracteres");
                senha = Console.ReadLine();
            }
            string senhaModificada = encripSenha(senha);
            Usuario usuario = new Usuario(Login, senhaModificada);
            usuario.Cadastrar();
            MenuPrincipal();
        }

        static string encripSenha(string senha)
        {
            // array de bytes
            byte[] senhaOriginal;
            byte[] senhaModificada;
            // padrão md5
            MD5 md5;
            //pegar os bytes de cada caracter da senha
            senhaOriginal = Encoding.Default.GetBytes(senha);
            //cria o padrão md5
            md5 = MD5.Create();
            //encripta os elementos do array de bytes
            senhaModificada = md5.ComputeHash(senhaOriginal);
            //retorn o array convertento para string
            return Convert.ToBase64String(senhaModificada);
        }

        static void VerificarCadastro(string Login)
        {
            string path = @"..\Login\CadUsuario.txt";
            if (File.Exists(path))
            {
                string[] linhas = File.ReadAllLines(path);
                string[] colunas;
                foreach (var linha in linhas)
                {
                    colunas = linha.Split(";");
                    if (colunas[0].ToUpper() == Login.ToUpper())
                    {
                        System.Console.WriteLine("Usuario ja cadastrado");
                        MenuCadastrarUsuario();
                        break;
                    }
                }
            }
        }

        static void GerarArqSup()
        {
            
            string path = @"..\Login\Superior.txt";
            StreamWriter arq = new StreamWriter(path, true);
            arq.WriteLine();
            arq.Write("teste");
        }

        static void GErarArqLog()
        {

        }
    }
}
