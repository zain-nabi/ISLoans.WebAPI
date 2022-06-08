using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Application.Interface.Users;
using Application.Model.Registration;
using Microsoft.Extensions.Configuration;

namespace Application.Repository.Registration
{
    /// <inheritdoc/>
    public class RegistrationRepository : IUsers
    {
        private readonly IConfiguration _config;
        public RegistrationRepository(IConfiguration configuration)
        {
            _config = configuration;
        }

        public async Task<bool> Register(Application.Model.Registration.Users model)
        {
            using (SqlConnection sqlcon = new SqlConnection(this._config.GetConnectionString("ISLoans")))
            {
                using (SqlCommand cmd = new SqlCommand("proc_UserRegistration", sqlcon))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Fname", model.Fname);
                    cmd.Parameters.AddWithValue("@Sname", model.Sname);
                    cmd.Parameters.AddWithValue("@Age", model.Age);
                    cmd.Parameters.AddWithValue("@DOB", model.DOB);
                    cmd.Parameters.AddWithValue("@IDNumber", model.IDNumber);
                    sqlcon.Open();
                    int rowAffected = cmd.ExecuteNonQuery();
                    return true;
                }
            }
        }

        public async Task<Users> Login(string ID)
        {
            using (SqlConnection sqlcon = new SqlConnection(this._config.GetConnectionString("ISLoans")))
            {
                using (SqlCommand cmd = new SqlCommand("proc_Login", sqlcon))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IDNumber", ID);
                    sqlcon.Open();
                    int rowAffected = cmd.ExecuteNonQuery();
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        var User = new Users()
                        {
                            IDNumber = dt.Rows[0]["IDNumber"].ToString(),
                            Fname = dt.Rows[0]["Fname"].ToString(),
                            Sname = dt.Rows[0]["Sname"].ToString()
                        };

                        return User;
                    }

                }
            }
        }

        public async Task<Application.Model.Registration.Users> CheckIfIDExist(string IDNumber)
        {
            using (SqlConnection sqlcon = new SqlConnection(this._config.GetConnectionString("ISLoans")))
            {
                using (SqlCommand cmd = new SqlCommand("proc_CheckIfIDExist", sqlcon))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IDNumber", IDNumber);
                    sqlcon.Open();
                    int rowAffected = cmd.ExecuteNonQuery();
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        var User = new Users()
                        {
                            IDNumber = dt.Rows[0]["IDNumber"].ToString()
                        };

                        return User;
                    }

                }
            }
        }
    }

}
