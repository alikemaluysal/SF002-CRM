using Dapper;
using Dapper.Contrib.Extensions;
using System.Data.SqlClient;

namespace Company.Crm.SqlServer
{
    public class DbConnection
    {
        private readonly SqlConnection _connection;

        public DbConnection()
        {
            // Connection
            // https://www.connectionstrings.com/
            _connection = new SqlConnection();
            _connection.ConnectionString = "Server=(localdb)\\MsSqlLocalDb;Database=SF2_CRM;Trusted_Connection=True;";
            _connection.Open();
        }

        #region Dapper

        public List<Employee> GetAllEmployessDapper()
        {
            var employees = _connection.Query<Employee>(@"
                SELECT * FROM Employees
            ");

            return employees.ToList();
        }

        //Dapper.Contrib paketi CRUD işlemleri otomatik uygulamayı sağlar.
        public List<Employee> GetAllEmployessDapper2()
        {
            var employees = _connection.GetAll<Employee>();

            return employees.ToList();
        }

        #endregion

        #region SqlClient

        public List<string> GetAllEmployess()
        {
            var employees = new List<string>();

            // Command
            var cmd = new SqlCommand("SELECT Name, Surname FROM Employees", _connection);
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    employees.Add(reader[0] + " " + reader["Surname"]);
                }
            }

            return employees;
        }

        public bool CreateEmployee(string name, string surname)
        {
            // Command
            var cmd = new SqlCommand("INSERT INTO Employees (Name, Surname) VALUES (@Name, @Surname)", _connection);
            cmd.Parameters.AddWithValue("Name", name);
            cmd.Parameters.AddWithValue("Surname", surname);
            int affected = cmd.ExecuteNonQuery();

            return affected > 0;
        }

        public bool UpdateEmployee(string id, string name, string surname)
        {
            // Command
            var cmd = new SqlCommand("UPDATE Employees SET Name=@Name, Surname=@Surname WHERE Id=@Id", _connection);
            cmd.Parameters.AddWithValue("Id", id);
            cmd.Parameters.AddWithValue("Name", name);
            cmd.Parameters.AddWithValue("Surname", surname);
            int affected = cmd.ExecuteNonQuery();

            return affected > 0;
        }

        public bool DeleteEmployee(string id)
        {
            // Command
            var cmd = new SqlCommand("DELETE FROM Employees WHERE Id=@Id", _connection);
            cmd.Parameters.AddWithValue("Id", id);
            int affected = cmd.ExecuteNonQuery();

            return affected > 0;
        }

        public int CountEmployee()
        {
            var cmd = new SqlCommand("SELECT COUNT(1) Employees", _connection);
            int count = (int)cmd.ExecuteScalar();
            return count;
        }

        #endregion
    }

    public class Employee
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        [Write(false)]
        [Computed]
        public int Age => DateTime.Now.Year - BirthDate.Year;


        public DateTime BirthDate { get; set; }
    }
}