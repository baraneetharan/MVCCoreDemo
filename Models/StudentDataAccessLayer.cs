using MySql.Data.MySqlClient;
using System.Data;

namespace MVCCoreDemo.Models
{
    public class StudentDataAccessLayer
    {
         string connectionString = "server=127.0.0.1;uid=root;pwd=Kgisl@12345;database=mvccoredemo";

        // To View all Student details
        public IEnumerable<Student> GetAllStudent()
        {
            List<Student> studList = new List<Student>();

            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                MySqlCommand cmd = new MySqlCommand("spGetAllStudent", con);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Student stud = new Student
                    {
                        StudId = Convert.ToInt32(rdr["StudID"]),
                        Name = rdr["Name"].ToString(),
                        Gender = rdr["Gender"].ToString(),
                        Department = rdr["Department"].ToString(),
                        City = rdr["City"].ToString()
                    };

                    studList.Add(stud);
                }
                con.Close();
            }
            return studList;
        }
        

       public void AddStudent(Student student)
{
    using (MySqlConnection con = new MySqlConnection(connectionString))
    {
        MySqlCommand cmd = new MySqlCommand("spAddStudent", con);
        cmd.CommandType = CommandType.StoredProcedure;

        // Match the parameter names exactly as they are defined in the stored procedure
        cmd.Parameters.AddWithValue("Name", student.Name);
        cmd.Parameters.AddWithValue("City", student.City);
        cmd.Parameters.AddWithValue("Department", student.Department);
        cmd.Parameters.AddWithValue("Gender", student.Gender);

        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();
    }
}


        // To Update the records of an individual student
       public void UpdateStudent(Student student)
{
    try
    {
        using (MySqlConnection con = new MySqlConnection(connectionString))
        {
            MySqlCommand cmd = new MySqlCommand("spUpdateStudent", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("StudId", student.StudId);
            cmd.Parameters.AddWithValue("Name", student.Name);
            cmd.Parameters.AddWithValue("City", student.City);
            cmd.Parameters.AddWithValue("Department", student.Department);
            cmd.Parameters.AddWithValue("Gender", student.Gender);

            con.Open();
            cmd.ExecuteNonQuery();
        }
    }
    catch (Exception ex)
    {
        // Log or handle the exception as needed
        Console.WriteLine("An error occurred: " + ex.Message);
    }
}



        // Get the details of an individual student
     public Student GetStudentData(int id)
{
    Student student = null;

    using (MySqlConnection con = new MySqlConnection(connectionString))
    {
        string sqlQuery = "SELECT * FROM tblStudent WHERE StudID = @StudId";
        MySqlCommand cmd = new MySqlCommand(sqlQuery, con);
        cmd.Parameters.AddWithValue("@StudId", id);

        con.Open();
        MySqlDataReader rdr = cmd.ExecuteReader();

        if (rdr.Read())
        {
            student = new Student
            {
                StudId = Convert.ToInt32(rdr["StudID"]),
                Name = rdr["Name"].ToString(),
                Gender = rdr["Gender"].ToString(),
                Department = rdr["Department"].ToString(),
                City = rdr["City"].ToString()
            };
        }
        con.Close();
    }
    return student;
}



        // To Delete the record of a particular student
       public void DeleteStudent(int? id)
{
    using (MySqlConnection con = new MySqlConnection(connectionString))
    {
        MySqlCommand cmd = new MySqlCommand("spDeleteStudent", con);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("StudId", id);

        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();
    }
}

    }
}