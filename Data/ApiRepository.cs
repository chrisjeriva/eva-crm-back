using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Prospectos.Data.Interfaces;
using Prospectos.Models;

namespace Prospectos.Data
{
    public class ApiRepository : IApiRepository
    {
        private readonly DataContext _context;

        public ApiRepository(DataContext context)
        {
            _context = context;
        }

        #region [GENERICOS]
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }
        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        #endregion [GENERICOS]

        #region [USUARIOS]
        public async Task<User> GetUserByLoginAsync(string login)
        {
            var user = await _context.Users.Where(p => p.login == login).Include(p => p.Authority).FirstOrDefaultAsync();
            return user;
        }
        #endregion [USUARIOS]

        #region [ESTATUS]

        public Task<IEnumerable<Estatus>> GetEstatusAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Estatus> GetEstatusByIdAsync(int nEstatus)
        {
            var estatus = await _context.Estatus.FirstOrDefaultAsync(e => e.nEstatus == nEstatus);
            return estatus;
        }

        #endregion [ESTATUS]

        #region [PROSPECTOS

        public async Task<Prospecto> GetProspectoByIdAsync(int nProspecto)
        {
            var prospecto = await _context.Prospectos.Where(p => p.nProspecto == nProspecto).Include(p => p.Estatus).FirstOrDefaultAsync();
            var documentosQuery = _context.DocumentosProspectos.Select(d => new DocumentoProspecto {
                nDocumentoProspecto = d.nDocumentoProspecto,
                nProspecto = d.nProspecto,
                cDocumento = d.cDocumento,
                cDocumentoB64 = d.cDocumentoB64,
                bActivo = d.bActivo
            }).Where(d => d.nProspecto == nProspecto);
            prospecto.Documentos = documentosQuery.ToList();
            return prospecto;
        }

        public async Task<Prospecto> GetProspectoByNombreAsync(string cNombre)
        {
            var prospecto = await _context.Prospectos.FirstOrDefaultAsync(p => p.cNombre == cNombre);
            return prospecto;
        }

        public async Task<PaginationTable> GetProspectosAsync(Parameters parameters)
        {
            var table = new PaginationTable();
            var prospectos = await _context.Prospectos.OrderBy(p => p.nProspecto).Skip(parameters.page * parameters.size).Take(parameters.size).Include(p => p.Estatus).ToListAsync();

            table.results = prospectos;
            table.count = await _context.Prospectos.CountAsync();

            return table;
        }

        #endregion [PROSPECTOS]

        #region [DOCUMENTOS]

        public async Task<IEnumerable<DocumentoProspecto>> GetDocumentosByProspectoIdAsync(int nProspecto)
        {
            var documentosQuery = _context.DocumentosProspectos.Select(d => new DocumentoProspecto
            {
                nDocumentoProspecto = d.nDocumentoProspecto,
                nProspecto = d.nProspecto,
                cDocumento = d.cDocumento,
                cDocumentoB64 = d.cDocumentoB64,
                bActivo = d.bActivo
            }).Where(d => d.nProspecto == nProspecto);
            var documentos = documentosQuery.ToList();

            return documentos;
        }
      
        public async void DeleteDocumentoByIdAsync(int nDocumentoProspecto)
        {
            var documento = await _context.DocumentosProspectos.Where(p => p.nDocumentoProspecto == nDocumentoProspecto).FirstOrDefaultAsync();
            _context.Remove<DocumentoProspecto>(documento);
        }

        public async Task<int> AddDocumento(string sb64, int nProspecto, string fileName)
        {
            DocumentoProspecto documento = new DocumentoProspecto();
            documento.cDocumento = fileName;
            documento.cDocumentoB64 = sb64;
            documento.nProspecto = nProspecto;
            documento.bActivo = true;

            _context.Add<DocumentoProspecto>(documento);

            await _context.SaveChangesAsync();

            return documento.nDocumentoProspecto;
        }

        #endregion [DOCUMENTOS]
    }
}
