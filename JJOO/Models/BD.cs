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
            db.Execute(sql, new{pIdDeportista = IdDeportista});
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
    public static Deportista VerInfoDeportista(int IdDeportista){
        Deportista MiDeportista = null;
        using(SqlConnection db = new SqlConnection(_connectionString)){
            string sql = "SELECT * FORM Deportistas WHERE IdDeportista = @DeportistaVer";
            MiDeportista = db.QueryFirstOrDefault<Deportista>(sql, new{DeportistaVer = IdDeportista});
        }
        return MiDeportista;
    }
    public static List<Pais> ListarPaises(){
        List<Pais> ListaPaises = null;
        using(SqlConnection db = new SqlConnection(_connectionString)){
            string sql = "SELECT * FROM Paises";
            ListaPaises = db.Query<Pais>(sql).ToList();
        }
        return ListaPaises;
    }
    public static List<Deporte> ListarDeportes(){
        List<Deporte> ListaDeportes = null;
        using(SqlConnection db = new SqlConnection(_connectionString)){
            string sql = "SELECT * FROM Deportes";
            ListaDeportes = db.Query<Deporte>(sql).ToList();
        }
        return ListaDeportes;
    }
     public static List<Deportista> ListarDeportistasDeporte(int IdDeporte){
        List<Deportista> ListaDeportistas = null;
        using(SqlConnection db = new SqlConnection(_connectionString)){
            string sql = "SELECT * FORM Deportistas WHERE IdDeporte = @DeporteVer";
            ListaDeportistas = db.Query<Deportista>(sql, new {DeporteVer = IdDeporte}).ToList();
        }
        return ListaDeportistas;
    }
    public static List<Deportista> ListarDeportistasPais(int IdPais){
        List<Deportista> ListaDeportista = null;
        using(SqlConnection db = new SqlConnection(_connectionString)){
            string sql = "SELECT * FORM Deportistas WHERE IdPais = @PaisVer";
            ListaDeportista = db.Query<Deportista>(sql, new {PaisVer = IdPais}).ToList();
        }
        return ListaDeportista;
    }
}