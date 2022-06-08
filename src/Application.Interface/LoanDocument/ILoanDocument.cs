using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface.LoanDocument
{
    public  interface ILoanDocument
    {
        Task<bool> InsertDocument(Application.Model.LoanDocument.DocumentRepository model);
        Task<List<Application.Model.LoanDocument.Custom.UserDocument>> GetUserDocuments(string IDNumber);
        Task<bool> DeleteUserDocument(int DocumentRepositoryID, int DeleteByUserID);
        Task<Application.Model.LoanDocument.Custom.UserDocument> UserDocument(int DocumentRepositoryID);
    }
}
