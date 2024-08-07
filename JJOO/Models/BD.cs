using System.Data.SqlClient;
using Dapper;

class BD{
    private static string _connectionString = @"Server = localhost; DataBase = JJOO; Trusted_Connection=True";
    public static void AgregarDeportista(Deportista Dep){
        using(SqlConnection db = new SqlConnection(_connectionString)){
            string sql = "INSERT INTO Deportistas (Apellido, Nombre, FechaNacimiento, Foto, IdPais, IdDeporte) VALUES (@pApellido, @pNombre, @pFechaNacimiento, @pFoto, @pIdPais, @pIdDeporte)";
            db.Execute(sql, new{pApellido = Dep.Apellido, pNombre = Dep.Nombre, pFechaNacimiento = Dep.FechaNacimiento, pFoto = Dep.Foto, pIdPais = Dep.IdPais, pIdDeporte = Dep.IdDeporte});
        }
    }
    public static void EliminarDeportista(int IdDeportista){
        using(SqlConnection db = new SqlConnection(_connectionString)){
            string sql = "DELETE FROM Deportistas WHERE IdDeportista = @pIdDeportista";
            db.Execute(sql, new{IdDeportista = pIdDeportista});
        }
    }
    public static Deporte VerInfoDeporte(int IdDeporte){
        Deporte MiDeporte = null;
        using(SqlConnection db = new SqlConnection(_connectionString)){
            string sql = "SELECT * FORM Deportes WHERE IdDeporte = @pIdDeporte";
            MiDeporte = db.QueryFirstOrDefault(sql, new{DeporteVer = IdDeporte});
        }
        return MiDeporte;
    }
    public static Pais VerInfoPais(int IdPais){
        Pais MiPais = null;
        using(SqlConnection db = new SqlConnection(_connectionString)){
            string sql = "SELECT * FORM Paises WHERE IdPais = @PaisVer";
            MiPais = db.QueryFirstOrDefault<Pais>(sql, new{PaisVer = IdPais});
        }
        return MiPais;
    }
    public static List<Pais> ListarPaises(){
        List<Pais> ListaPaises = null;
        using(SqlConnection db = new SqlConnection(_connectionString)){
            string sql = "SELECT * FROM Paises";
            ListaPaises = db.Query<Pais>(sql).ToList();
        }
        return ListaPaises;
    }
    /* public static List<string> ListarDeportistasDeporte(int IdDeporte){
        List<string> ListaDeportistas = null;
        using(SqlConnection db = new SqlConnection(_connectionString)){
            string sql = "SELECT * FORM Paises WHERE IdPais = @PaisVer";
            ListaPaises = db.Query<Pais>(sql).ToList();
        }
        return ListaDeportistas;
    }
    public static List<string> ListarDeportistasPais(int IdPais){
        List<string> ListaPaises = null;
        using(SqlConnection db = new SqlConnection(_connectionString)){
            string sql = "SELECT * FORM Paises WHERE IdPais = @PaisVer";
            ListaPaises = db.Query<Pais>(sql).ToList();
        }
        return ListaPaises;
    }*/
}