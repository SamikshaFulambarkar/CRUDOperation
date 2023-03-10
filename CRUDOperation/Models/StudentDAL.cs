using System.Data.SqlClient;
using NuGet.Protocol.Plugins;
namespace CRUDOperation.Models
{
    public class StudentDAL
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        private readonly IConfiguration configuration;

        public StudentDAL(IConfiguration configuration)
        {
            this.configuration = configuration;
            con = new SqlConnection(this.configuration.GetConnectionString("MyDbConnection"));
        }
        public List<Student> List()
        {
            List<Student> stlist = new List<Student>();
            string str = "select * from table_Student where isactive=1";
            cmd = new SqlCommand(str, con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Student st = new Student();
                    st.Id = Convert.ToInt32(dr["id"]);
                    st.Name = dr["name"].ToString();
                    st.CourseName = dr["course_name"].ToString();
                    st.EmailId = dr["emailid"].ToString();
                    st.PhoneNumber = dr["mobileno"].ToString();
                    st.GraduationDegreeName = dr["graduation_degree_name"].ToString();
                    st.DOJ_Class = Convert.ToDateTime(dr["doj_class"]);
                    stlist.Add(st);
                }
            }
            con.Close();
            return stlist;
        }
        public Student GetStudentById(int id)
        {
            Student st = new Student();
            string str = "select * from table_Student where id=@id";
            cmd = new SqlCommand(str, con);
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    st.Id = Convert.ToInt32(dr["id"]);
                    st.Name = dr["name"].ToString();
                    st.CourseName = dr["course_name"].ToString();
                    st.EmailId = dr["emailid"].ToString();
                    st.PhoneNumber = dr["mobileno"].ToString();
                    st.GraduationDegreeName = dr["graduation_degree_name"].ToString();
                    st.DOJ_Class = Convert.ToDateTime(dr["doj_class"]);
                }
            }
            con.Close();
            return st;
        }
        public int AddStudent(Student st)
        {
            int result = 0;
            st.IsActive = 1;
            string qry = "insert into table_Student values(@name,@course_name,@emailid,@mobileno," +
                "@graduation_degree_name,cast(@doj_class as date),@isactive)";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@name", st.Name);
            cmd.Parameters.AddWithValue("@course_name", st.CourseName);
            cmd.Parameters.AddWithValue("@emailid", st.EmailId);
            cmd.Parameters.AddWithValue("@mobileno", st.PhoneNumber);
            cmd.Parameters.AddWithValue("@graduation_degree_name", st.GraduationDegreeName);
            cmd.Parameters.AddWithValue("@doj_class", st.DOJ_Class);
            cmd.Parameters.AddWithValue("@isactive", st.IsActive);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;

        }
        public int UpdateStudent(Student st)
        {
            int result = 0;
            st.IsActive = 1;
            string qry = "update table_Student set Name=@name,CourseName=@course_name,EmailId=@emailid," +
            "PhoneNumber=@mobileno,GraduationDegreeName=@graduation_degree_name,DOJ_Class=cast(@doj_class as date),isactive=@IsActive where Id=@id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@name", st.Name);
            cmd.Parameters.AddWithValue("@course_name", st.CourseName);
            cmd.Parameters.AddWithValue("@emailid", st.EmailId);
            cmd.Parameters.AddWithValue("@mobileno", st.PhoneNumber);
            cmd.Parameters.AddWithValue("@graduation_degree_name", st.GraduationDegreeName);
            cmd.Parameters.AddWithValue("@doj_class", st.DOJ_Class);
            cmd.Parameters.AddWithValue("@id", st.Id);
            cmd.Parameters.AddWithValue("@isactive", st.IsActive);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
        public int DeleteStudent(int id)
        {
            int result = 0;
            string qry = "update table_Student set isactive=0 where id=@id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
    }
}

