using System.Collections.Generic;
using System;
using MySqlConnector;

namespace atividade_2_uc05.Models
{
    public class PacotesTuristicosRepository
    {

        private const string DadosConexao = "Database=Viagens_Destino_Certo;Data Source=localhost; User Id=root;";

        public void Inserir(PacotesTuristicos pac)
        {
            MySqlConnection Conexao = new MySqlConnection(DadosConexao);
            Conexao.Open();

            //String SqlInclusao = "insert into PacotesTuristicos (Nome,Origem,Destino,Atrativos,Saida,Retorno,Usuario) VALUES (@Nome,@Origem,@Destino,@Atrativos,@Saida,@Retorno,@Usuario)";

            String SqlInclusao = "insert into PacotesTuristicos (Nome,Origem,Destino,Atrativos,Saida,Retorno) VALUES (@Nome,@Origem,@Destino,@Atrativos,@Saida,@Retorno)";

            MySqlCommand Comando = new MySqlCommand(SqlInclusao, Conexao);

            Comando.Parameters.AddWithValue("@Nome", pac.Nome);
            Comando.Parameters.AddWithValue("@Origem", pac.Origem);
            Comando.Parameters.AddWithValue("@Destino", pac.Destino);
            Comando.Parameters.AddWithValue("@Atrativos", pac.Atrativos);
            Comando.Parameters.AddWithValue("@Saida", pac.Saida);
            Comando.Parameters.AddWithValue("@Retorno", pac.Retorno);
            Comando.Parameters.AddWithValue("@Usuario", pac.Usuario);

            Comando.ExecuteNonQuery();

            Conexao.Close();
        }

        public void Remover(PacotesTuristicos pac)
        {
            MySqlConnection Conexao = new MySqlConnection(DadosConexao);
            Conexao.Open();

            String SqlExclusao = "delete from PacotesTuristicos WHERE Id=@Id";

            MySqlCommand Comando = new MySqlCommand(SqlExclusao, Conexao);

            Comando.Parameters.AddWithValue("@Id", pac.Id);

            Comando.ExecuteNonQuery();

            Conexao.Close();
        }

        public void Atualizar(PacotesTuristicos pac)
        {
            MySqlConnection Conexao = new MySqlConnection(DadosConexao);
            Conexao.Open();

            //String SqlAtalizacao = "update PacotesTuristicos SET Nome=@Nome, Origem=@Origem, Destino=@Destino, Atrativos=@Atrativos Saida=@Saida Retorno=@Retorno Usuario=@Usuario WHERE Id=@Id";
            String SqlAtalizacao = "update PacotesTuristicos SET Nome=@Nome, Origem=@Origem, Destino=@Destino, Atrativos=@Atrativos, Saida=@Saida, Retorno=@Retorno WHERE Id=@Id";

            MySqlCommand Comando = new MySqlCommand(SqlAtalizacao, Conexao);

            Comando.Parameters.AddWithValue("@Id", pac.Id);
            Comando.Parameters.AddWithValue("@Nome", pac.Nome);
            Comando.Parameters.AddWithValue("@Origem", pac.Origem);
            Comando.Parameters.AddWithValue("@Destino", pac.Destino);
            Comando.Parameters.AddWithValue("@Atrativos", pac.Atrativos);
            Comando.Parameters.AddWithValue("@Saida", pac.Saida);
            Comando.Parameters.AddWithValue("@Retorno", pac.Retorno);
            //Comando.Parameters.AddWithValue("@Usuario", pac.Usuario);

            Comando.ExecuteNonQuery();

            Conexao.Close();
        }

        public List<PacotesTuristicos> Listar()
        {

            MySqlConnection Conexao = new MySqlConnection(DadosConexao);
            Conexao.Open();

            String SqlConsulta = "select * from PacotesTuristicos";

            MySqlCommand Comando = new MySqlCommand(SqlConsulta, Conexao);
            MySqlDataReader Reader = Comando.ExecuteReader();

            List<PacotesTuristicos> Lista = new List<PacotesTuristicos>();

            while (Reader.Read())
            {
                PacotesTuristicos pac = new PacotesTuristicos();

                if (!Reader.IsDBNull(Reader.GetOrdinal("Id")))
                    pac.Id = Reader.GetInt32("Id");
                if (!Reader.IsDBNull(Reader.GetOrdinal("Nome")))
                    pac.Nome = Reader.GetString("Nome");

                if (!Reader.IsDBNull(Reader.GetOrdinal("Origem")))
                    pac.Origem = Reader.GetString("Origem");

                if (!Reader.IsDBNull(Reader.GetOrdinal("Destino")))
                    pac.Destino = Reader.GetString("Destino");

                if (!Reader.IsDBNull(Reader.GetOrdinal("Atrativos")))
                    pac.Atrativos = Reader.GetString("Atrativos");

                if (!Reader.IsDBNull(Reader.GetOrdinal("Saida")))
                    pac.Saida = Reader.GetDateTime("Saida");

                if (!Reader.IsDBNull(Reader.GetOrdinal("Retorno")))
                    pac.Retorno = Reader.GetDateTime("Retorno");

                if (!Reader.IsDBNull(Reader.GetOrdinal("Usuario")))
                    pac.Usuario = Reader.GetInt32("Usuario");

                Lista.Add(pac);
            }

            Conexao.Close();

            return Lista;
        }

        public PacotesTuristicos BuscarPorId(int Id)
        {

            MySqlConnection Conexao = new MySqlConnection(DadosConexao);
            Conexao.Open();

            String SqlConsultaId = "select * from PacotesTuristicos WHERE Id=@Id";

            MySqlCommand Comando = new MySqlCommand(SqlConsultaId, Conexao);

            Comando.Parameters.AddWithValue("@Id", Id);

            MySqlDataReader Reader = Comando.ExecuteReader();

            PacotesTuristicos userEncontrado = new PacotesTuristicos();

            if (Reader.Read())
            {
                if (!Reader.IsDBNull(Reader.GetOrdinal("Id")))
                    userEncontrado.Id = Reader.GetInt32("Id");

                if (!Reader.IsDBNull(Reader.GetOrdinal("Nome")))
                    userEncontrado.Nome = Reader.GetString("Nome");

                if (!Reader.IsDBNull(Reader.GetOrdinal("Origem")))
                    userEncontrado.Origem = Reader.GetString("Origem");

                if (!Reader.IsDBNull(Reader.GetOrdinal("Destino")))
                    userEncontrado.Destino = Reader.GetString("Destino");

                if (!Reader.IsDBNull(Reader.GetOrdinal("Atrativos")))
                    userEncontrado.Atrativos = Reader.GetString("Atrativos");

                if (!Reader.IsDBNull(Reader.GetOrdinal("Saida")))
                    userEncontrado.Saida = Reader.GetDateTime("Saida");

                if (!Reader.IsDBNull(Reader.GetOrdinal("Retorno")))
                    userEncontrado.Retorno = Reader.GetDateTime("Retorno");

                //if (!Reader.IsDBNull(Reader.GetOrdinal("Usuario")))
                //    userEncontrado.Usuario = Reader.GetInt32("Usuario");
            }

            Conexao.Close();

            return userEncontrado;
        }
    }
}