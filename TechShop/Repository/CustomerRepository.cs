using System.Data.SqlClient;
using System.Net;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using TechShop.Model;
using TechShop.Utility;

namespace TechShop.Repository
{
    internal class CustomerRepository : ICustomerRepository
    {
        SqlConnection sqlConnection = null;
        SqlCommand cmd = null;
        public CustomerRepository()
        {
            //sqlConnection = new SqlConnection("Server=EDITH;Database=TechShop;Trusted_Connection=True");
            sqlConnection = new SqlConnection(DbConnUtil.GetConnectionString());
            cmd = new SqlCommand();
        }
        public List<Customers> GetCustomerDetails()
        {
            List<Customers> Lcustomer = new List<Customers>();
            cmd.CommandText = "select * from Customers";
            cmd.Connection = sqlConnection;
            sqlConnection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Customers customer = new Customers();
                customer.CustomerID = (int)reader["CustomerId"];
                customer.FirstName = (string)reader["FirstName"];
                customer.LastName = (string)reader["LastName"];
                customer.Email = (string)reader["email"];
                customer.Phone = (string)reader["phone"];
                customer.Address = (string)reader["Address"];

                Lcustomer.Add(customer);
            }
            sqlConnection.Close();
            return Lcustomer;
            

        }
        public int UpdateCustomerInfo(int id, string email, string phone, string address)
        {
            cmd.CommandText = "Update Customers set email=@email,phone=@phone,Address=@address where CustomerId=@id";
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@phone", phone);
            cmd.Parameters.AddWithValue("@address", address);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Connection = sqlConnection;
            sqlConnection.Open();
            int status = cmd.ExecuteNonQuery();
            sqlConnection.Close();
            return status;

        }

        public int CalculateTotalOrders(int customerid)
        {
            cmd.CommandText = "select count(*) as TotalORders from Orders where CustomerId=@id;";
            cmd.Parameters.AddWithValue("@id", customerid);
            
            cmd.Connection = sqlConnection;
            sqlConnection.Open();
            object result = cmd.ExecuteScalar();
            cmd.Parameters.Clear();
            int totalOrders = 0;
            if (result != null)
            {
                totalOrders = Convert.ToInt32(result);
            }
            sqlConnection.Close();

            return totalOrders;

        }

        public bool isEmailUnique(string email)
        {
            int flag = 0;
            List<string> list = new List<string>();
            cmd.CommandText = "select Email from Customers";
            cmd.Connection = sqlConnection;
            sqlConnection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(reader.GetString(0));

            }
            sqlConnection.Close();
            foreach (string item in list)
            {
                if (email.Contains(item))
                {
                    flag = 1;
                }
            }
            if (flag == 1)
            {
                return true;
            }
            else return false;

           
        }


        public int register(Customers customer)
        {
            int status = 0;
            if(isEmailUnique(customer.Email))
            {
                throw new InvalidOperationException("Email already Exists");
            }
            else
            {
                cmd.CommandText = @"INSERT INTO Customers (CustomerId,FirstName, LastName, Email, Phone, Address)
                VALUES (@id,@FirstName, @LastName, @Email, @Phone, @Address);";
                cmd.Parameters.AddWithValue("@id", customer.CustomerID);
                cmd.Parameters.AddWithValue("@FirstName", customer.FirstName);
                cmd.Parameters.AddWithValue("@LastName", customer.LastName);
                cmd.Parameters.AddWithValue("@Email", customer.Email);
                cmd.Parameters.AddWithValue("@Phone", customer.Phone);
                cmd.Parameters.AddWithValue("@Address", customer.Address);
                try
                {
                    cmd.Connection = sqlConnection;
                    sqlConnection.Open();
                    status = cmd.ExecuteNonQuery();
                    return status;

                }
                catch(SystemException ex)
                {
                    
                    Console.WriteLine(ex.Message);
                }
                finally { 
                    sqlConnection.Close(); }
                return status; 
                
            }
            


        }







        }
        

    }
