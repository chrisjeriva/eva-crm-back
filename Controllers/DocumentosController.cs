using Microsoft.AspNetCore.Mvc;
using Prospectos.Data.Interfaces;
using Prospectos.Models;

namespace Prospectos.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DocumentosController : ControllerBase
    {
        private readonly IApiRepository _repository;

        public DocumentosController(IApiRepository repository)
        {
            _repository = repository;
        }

        [HttpPost("uploadfiles/{nProspecto:int}"), DisableRequestSizeLimit]
        public async Task<IActionResult> UploadFiles([FromForm] Files files, int nProspecto)
        {
            var nDocumentoProspecto = 0;
            for (int i = 0; i < files.files.Count(); i++)
            {
                if (files.files.Count() > 0)
                {
                    using (var ms = new MemoryStream())
                    {
                        files.files[i].CopyTo(ms);
                        var fileBytes = ms.ToArray();
                        string s = Convert.ToBase64String(fileBytes);
                        var sb64 = GenerateInitialString(files.files[i].ContentType, files.files[i].FileName) + s;

                        var lastInsertedDocumento = await _repository.AddDocumento(sb64, nProspecto, files.fileNames[i]);

                        if (files.files.Count() == 1)
                        {
                            nDocumentoProspecto = lastInsertedDocumento;
                        }
                        else
                        {
                            _repository.SaveAll();
                        }

                    }
                }
            }

            if (files.files.Count() == 1)
            {
                return Ok(nDocumentoProspecto);
            }
            else
            {
                return Ok(true);
            }

        }

        [HttpGet("documentos/{nProspecto:int}")]
        public async Task<IActionResult> GetDocumentsByProspectoId(int nProspecto)
        {
            var documentos = await _repository.GetDocumentosByProspectoIdAsync(nProspecto);
            return Ok(documentos);
        }

        [HttpDelete("deletefile/{nDocumentoProspecto:int}")]
        public async Task<IActionResult> DeleteDocumentoById(int nDocumentoProspecto)
        {
            _repository.DeleteDocumentoByIdAsync(nDocumentoProspecto);
            _repository.SaveAll();
            return Ok(true);
        }

        private string GenerateInitialString(string contentType, string fileName)
        {
            var inicialString = "data:" + contentType + ";base64,";

            return inicialString;
        }
    }
}
