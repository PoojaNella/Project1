
using Microsoft.Data.SqlClient;
using System.Data;

namespace WebApplication1.Models
{
    public class CustomerModel
    {

        public DataSet getCustomers()
        {
            string conenctionString = "Data Source=DESKTOP-KLB699B\\SQLEXPRESS;Database=northwind;Trusted_Connection=true;MultipleActiveResultSets = true;TrustServerCertificate=true";
            SqlConnection conn = new SqlConnection(conenctionString);
            SqlCommand cmd = new SqlCommand("Select * from customers");
            cmd.CommandType = CommandType.Text; 
            cmd.Connection = conn;
            conn.Open();

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            conn.Close();
            //checking git
            return ds;

        }
    }
}
