using Application.Interface.LoanDocument;
using Application.Model.LoanDocument;
using Application.Model.LoanDocument.Custom;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoanDocumentController : ControllerBase
    {
        private readonly ILoanDocument _loanDocument;

        public LoanDocumentController(ILoanDocument loanDocument)
        {
            _loanDocument = loanDocument;
        }

        [Route("InsertDocument")]
        [HttpPost]
        public async Task<bool> InsertDocument(DocumentRepository model)
        {
            return await _loanDocument.InsertDocument(model);
        }

        [Route("GetUserDocuments")]
        [HttpGet]
        public async Task<List<UserDocument>> GetUserDocuments(string IDNumber)
        {
            return await _loanDocument.GetUserDocuments(IDNumber);
        }

        [Route("DeleteUserDocument")]
        [HttpGet]
        public async Task<bool> DeleteUserDocument(int DocumentRepositoryID, int DeletedByUserID)
        {
            return await _loanDocument.DeleteUserDocument(DocumentRepositoryID, DeletedByUserID);
        }

        [Route("UserDocument")]
        [HttpGet]
        public async Task<UserDocument> UserDocument(int DocumentRepositoryID)
        {
            return await _loanDocument.UserDocument(DocumentRepositoryID);
        }
    }
}
