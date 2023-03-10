using System.Data.SqlClient;
using NuGet.Protocol.Plugins;
namespace CRUDOperation.Models
{
    public class EmployeeCrud
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        private readonly IConfiguration configuration;

        public EmployeeCrud(IConfiguration configuration)
        {
            this.configuration = configuration;
            con = new SqlConnection(this.configuration.GetConnectionString("MyDbConnection"));
        }
        public List<Employee> List()
        {
            List<Employee> emplist = new List<Employee>();
            string str = "select * from table_Employee where isactive=1";
            cmd = new SqlCommand(str, con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Employee emp = new Employee();
                    emp.Id = Convert.ToInt32(dr["id"]);
                    emp.Name = dr["name"].ToString();
                    emp.EmailId = dr["emailid"].ToString();
                    emp.CreatePassword = dr["createpassword"].ToString();
                    emp.PhoneNumber = dr["mobileno"].ToString();
                    emp.Age = Convert.ToInt32(dr["age"]);
                    emp.DOJ = Convert.ToDateTime(dr["doj"]);
                    emplist.Add(emp);
                }
            }
            con.Close();
            return emplist;
        }
        public Employee GetEmployeeById(int id)
        {
            Employee emp = new Employee();
            string str = "select * from table_Employee where id=@id";
            cmd = new SqlCommand(str, con);
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {

                    emp.Id = Convert.ToInt32(dr["id"]);
                    emp.Name = dr["name"].ToString();
                    emp.EmailId = dr["emailid"].ToString();
                    emp.CreatePassword = dr["createpassword"].ToString();
                    emp.PhoneNumber = dr["mobileno"].ToString();
                    emp.Age = Convert.ToInt32(dr["age"]);
                    emp.DOJ = Convert.ToDateTime(dr["doj"]);
                }
            }
            con.Close();
            return emp;
        }
        public int AddEmployee(Employee emp)
        {
            int result = 0;
            emp.IsActive = 1;
            string qry = "insert into table_Employee values(@name,@emailid,@createpassword,@mobileno,@age,cast(@doj as date),@isactive)";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@name", emp.Name);
            cmd.Parameters.AddWithValue("@emailid", emp.EmailId);
            cmd.Parameters.AddWithValue("@createpassword", emp.CreatePassword);
            cmd.Parameters.AddWithValue("@mobileno", emp.PhoneNumber);
            cmd.Parameters.AddWithValue("@age", emp.Age);
            cmd.Parameters.AddWithValue("@doj", emp.DOJ);
            cmd.Parameters.AddWithValue("@isactive", emp.IsActive);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;

        }
        public int UpdateEmployee(Employee emp)
        {
            int result = 0;
            emp.IsActive = 1;
            string qry = "update table_Employee set name=@name,email=@emailid,createpassword=@createpassword,PhoneNumber=@mobileno,age=@age,doj=cast(@doj as date),isactive=@IsActive where id=@id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@name", emp.Name);
            cmd.Parameters.AddWithValue("@emailid", emp.EmailId);
            cmd.Parameters.AddWithValue("@createpassword", emp.CreatePassword);
            cmd.Parameters.AddWithValue("@mobileno", emp.PhoneNumber);
            cmd.Parameters.AddWithValue("@age", emp.Age);
            cmd.Parameters.AddWithValue("@doj", emp.DOJ);
            cmd.Parameters.AddWithValue("@id", emp.Id);
            cmd.Parameters.AddWithValue("@isactive", emp.IsActive);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;

        }
        public int DeleteEmployee(int id)
        {
            int result = 0;
            string qry = "update table_Employee set isactive=0 where id=@id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
    }
}
