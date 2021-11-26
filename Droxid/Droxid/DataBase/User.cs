using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Droxid.DataBase
{
    public class User : Model
    {
        public void AddUser()
        {

            using (SqlConnection conn = new SqlConnection(ConnectionSting))
            {
                
                String query = "INSERT INTO droxid.users (name) VALUES ('@name')";

                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@name", "john");

                    conn.Open();
                    int result = command.ExecuteNonQuery();

                    // Check Error
                    if (result < 0)
                        Console.WriteLine("Error inserting data into Database!");
                }
            }

            
        }
    }
}
