using System.Collections.Generic;
using System;
using MySqlConnector;

namespace atividade_2_uc05.Models
{
    public class UsuarioRepository
    {
        private const string DadosConexao = "Database=Viagens_Destino_Certo;Data Source=localhost; User Id=root;";

        public void TestarConexao()
        {
            MySqlConnection Conexao = new MySqlConnection(DadosConexao);
            Conexao.Open();
            Console.WriteLine("Banco de dados funcionando");
            Conexao.Close();
        }


        public Usuario ValidarLogin(Usuario user)
        {
            MySqlConnection Conexao = new MySqlConnection(DadosConexao);
            Conexao.Open();

            String SqlConsultaLoginSenha = "select * from Usuario WHERE Login=@Login and Senha=@Senha";

            MySqlCommand Comando = new MySqlCommand(SqlConsultaLoginSenha, Conexao);

            Comando.Parameters.AddWithValue("@Login", user.Login);
            Comando.Parameters.AddWithValue("@Senha", user.Senha);

            MySqlDataReader Reader = Comando.ExecuteReader();

            Usuario userEncontrado = null;

            if (Reader.Read())
            {
                userEncontrado = new Usuario();

                userEncontrado.Id = Reader.GetInt32("Id");

                if (!Reader.IsDBNull(Reader.GetOrdinal("Nome")))
                    userEncontrado.Nome = Reader.GetString("Nome");

                if (!Reader.IsDBNull(Reader.GetOrdinal("Login")))
                    userEncontrado.Login = Reader.GetString("Login");

                if (!Reader.IsDBNull(Reader.GetOrdinal("Senha")))
                    userEncontrado.Senha = Reader.GetString("Senha");

                userEncontrado.DataNascimento = Reader.GetDateTime("DataNascimento");
            }

            Conexao.Close();

            return userEncontrado;

        }

        public void Inserir(Usuario user)
        {
            MySqlConnection Conexao = new MySqlConnection(DadosConexao);
            Conexao.Open();

            String SqlInclusao = "insert into Usuario (Nome,Login,Senha,DataNascimento) VALUES (@Nome,@Login,@Senha,@DataNascimento)";

            MySqlCommand Comando = new MySqlCommand(SqlInclusao, Conexao);

            Comando.Parameters.AddWithValue("@Nome", user.Nome);
            Comando.Parameters.AddWithValue("@Login", user.Login);
            Comando.Parameters.AddWithValue("@Senha", user.Senha);
            Comando.Parameters.AddWithValue("@DataNascimento", user.DataNascimento);

            Comando.ExecuteNonQuery();

            Conexao.Close();
        }

        public void Remover(Usuario user)
        {

            MySqlConnection Conexao = new MySqlConnection(DadosConexao);
            Conexao.Open();

            String SqlExclusao = "delete from Usuario WHERE Id=@Id";

            MySqlCommand Comando = new MySqlCommand(SqlExclusao, Conexao);

            Comando.Parameters.AddWithValue("@Id", user.Id);

            Comando.ExecuteNonQuery();

            Conexao.Close();
        }

        public void Atualizar(Usuario user)
        {
            MySqlConnection Conexao = new MySqlConnection(DadosConexao);
            Conexao.Open();

            String SqlAtalizacao = "update Usuario SET Nome=@Nome, Login=@Login, Senha=@Senha, DataNascimento=@DataNascimento WHERE Id=@Id";

            MySqlCommand Comando = new MySqlCommand(SqlAtalizacao, Conexao);

            Comando.Parameters.AddWithValue("@Id", user.Id);
            Comando.Parameters.AddWithValue("@Nome", user.Nome);
            Comando.Parameters.AddWithValue("@Login", user.Login);
            Comando.Parameters.AddWithValue("@Senha", user.Senha);
            Comando.Parameters.AddWithValue("@DataNascimento", user.DataNascimento);

            Comando.ExecuteNonQuery();

            Conexao.Close();
        }


        public List<Usuario> Listar()
        {
            MySqlConnection Conexao = new MySqlConnection(DadosConexao);
            Conexao.Open();

            String SqlConsulta = "select * from Usuario";

            MySqlCommand Comando = new MySqlCommand(SqlConsulta, Conexao);
            MySqlDataReader Reader = Comando.ExecuteReader();

            List<Usuario> Lista = new List<Usuario>();

            while (Reader.Read())
            {
                Usuario User = new Usuario();

                User.Id = Reader.GetInt32("Id");
                if (!Reader.IsDBNull(Reader.GetOrdinal("Nome")))
                    User.Nome = Reader.GetString("Nome");
                if (!Reader.IsDBNull(Reader.GetOrdinal("Login")))
                    User.Login = Reader.GetString("Login");
                if (!Reader.IsDBNull(Reader.GetOrdinal("Senha")))
                    User.Senha = Reader.GetString("Senha");
                User.DataNascimento = Reader.GetDateTime("DataNascimento");

                Lista.Add(User);
            }

            Conexao.Close();

            return Lista;

        }

        public Usuario BuscarPorId(int Id)
        {
            MySqlConnection Conexao = new MySqlConnection(DadosConexao);
            Conexao.Open();

            String SqlConsultaId = "select * from Usuario WHERE Id=@Id";

            MySqlCommand Comando = new MySqlCommand(SqlConsultaId, Conexao);

            Comando.Parameters.AddWithValue("@Id", Id);

            MySqlDataReader Reader = Comando.ExecuteReader();

            Usuario userEncontrado = new Usuario();

            if (Reader.Read())
            {
                userEncontrado.Id = Reader.GetInt32("Id");

                if (!Reader.IsDBNull(Reader.GetOrdinal("Nome")))
                    userEncontrado.Nome = Reader.GetString("Nome");

                if (!Reader.IsDBNull(Reader.GetOrdinal("Login")))
                    userEncontrado.Login = Reader.GetString("Login");

                if (!Reader.IsDBNull(Reader.GetOrdinal("Senha")))
                    userEncontrado.Senha = Reader.GetString("Senha");

                userEncontrado.DataNascimento = Reader.GetDateTime("DataNascimento");
            }

            Conexao.Close();

            return userEncontrado;

        }

    }
}