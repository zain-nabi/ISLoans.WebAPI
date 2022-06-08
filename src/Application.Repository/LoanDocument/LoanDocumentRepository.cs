using Application.Interface.LoanDocument;
using Application.Model.LoanDocument;
using Application.Model.LoanDocument.Custom;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repository.LoanDocument
{
    public  class LoanDocumentRepository : ILoanDocument
    {
        private readonly IConfiguration _config;
        public LoanDocumentRepository(IConfiguration configuration)
        {
            _config = configuration;
        }

        public async Task<bool> InsertDocument(DocumentRepository model)
        {
            using (SqlConnection sqlcon = new SqlConnection(this._config.GetConnectionString("ISLoans")))
            {
                using (SqlCommand cmd = new SqlCommand("proc_Insert_DocumentRepository", sqlcon))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ImgName", model.ImgName);
                    cmd.Parameters.AddWithValue("@ImgData", model.ImgData);
                    cmd.Parameters.AddWithValue("@ImgContentType", model.ImgContentType);
                    cmd.Parameters.AddWithValue("@ImgLength", model.ImgLength);
                    cmd.Parameters.AddWithValue("@CreatedByUserID", model.CreatedByUserID);
                    sqlcon.Open();
                    int rowAffected = cmd.ExecuteNonQuery();
                    return true;
                }
            }
        }

        public async Task<List<Application.Model.LoanDocument.Custom.UserDocument>> GetUserDocuments(string IDNumber)
        {
            using (SqlConnection sqlcon = new SqlConnection(this._config.GetConnectionString("ISLoans")))
            {
                using (SqlCommand cmd = new SqlCommand("proc_UserDocument", sqlcon))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IDNumber", IDNumber);
                    sqlcon.Open();
                    int rowAffected = cmd.ExecuteNonQuery();
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        List<UserDocument> userDocuments = new List<UserDocument>();
                        foreach (DataRow dr in dt.Rows)
                        {
                            var UserDocument = new UserDocument()
                            {
                                DocumentRepositoryID = Convert.ToInt32(dr["DocumentRepositoryID"]),
                                ImgName = dr["ImgName"].ToString(),
                                ImgData = (byte[])dr["ImgData"],
                                ImgContentType = dr["ImgContentType"].ToString(),
                                ImgLength = Convert.ToInt32(dr["ImgLength"]),
                                Fname = dr["Fname"].ToString(),
                                Sname = dr["Sname"].ToString(),
                                IDNumber = dr["IDNumber"].ToString(),
                                CreatedOn = Convert.ToDateTime(dr["CreatedOn"])
                            };
                            userDocuments.Add(UserDocument);
                        }
                        return userDocuments;
                    }

                }
            }
        }

        public async Task<bool> DeleteUserDocument(int DocumentRepositoryID, int DeleteByUserID)
        {
            using (SqlConnection sqlcon = new SqlConnection(this._config.GetConnectionString("ISLoans")))
            {
                using (SqlCommand cmd = new SqlCommand("proc_DeleteDocument", sqlcon))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DocumentRepositoryID", DocumentRepositoryID);
                    cmd.Parameters.AddWithValue("@DeleteByUserID", DeleteByUserID);
                    sqlcon.Open();
                    int rowAffected = cmd.ExecuteNonQuery();
                    return true;
                }
            }
        }

        public async Task<Application.Model.LoanDocument.Custom.UserDocument> UserDocument(int DocumentRepositoryID)
        {
            using (SqlConnection sqlcon = new SqlConnection(this._config.GetConnectionString("ISLoans")))
            {
                using (SqlCommand cmd = new SqlCommand("proc_GetDocument", sqlcon))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DocumentRepositoryID", DocumentRepositoryID);
                    sqlcon.Open();
                    int rowAffected = cmd.ExecuteNonQuery();
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        var UserDocument = new UserDocument()
                        {
                            DocumentRepositoryID = Convert.ToInt32(dt.Rows[0]["DocumentRepositoryID"]),
                            ImgName = dt.Rows[0]["ImgName"].ToString(),
                            ImgData = (byte[])dt.Rows[0]["ImgData"],
                            ImgContentType = dt.Rows[0]["ImgContentType"].ToString(),
                            ImgLength = Convert.ToInt32(dt.Rows[0]["ImgLength"])
                        };
                        return UserDocument;
                    }

                }
            }
        }

    }
}
