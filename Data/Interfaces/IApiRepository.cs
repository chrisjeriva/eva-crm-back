using Prospectos.Models;

namespace Prospectos.Data.Interfaces
{
    public interface IApiRepository
    {
        #region [GENERICOS]

        void Add<T>(T entity) where T: class;
        void Update<T>(T entity) where T: class;
        void Delete<T>(T entity) where T: class;
        Task<bool> SaveAll();

        #endregion [GENERICOS]

        #region [USUARIOS]

        Task<User> GetUserByLoginAsync(string login);


        #endregion [USUARIOS]

        #region [ESTATUS]

        Task<IEnumerable<Estatus>> GetEstatusAsync();
        Task<Estatus> GetEstatusByIdAsync(int nEstatus);

        #endregion [ESTATUS]

        #region [PROSPECTOS]

        Task<PaginationTable> GetProspectosAsync(Parameters parameters);
        Task<Prospecto> GetProspectoByIdAsync(int nProspecto);
        Task<Prospecto> GetProspectoByNombreAsync(string cNombre);

        #endregion [PROSPECTOS]

        #region [DOCUMENTOS]

        Task<int> AddDocumento(string sb64, int nProspecto, string fileName);
        void DeleteDocumentoByIdAsync(int nDocumentoProspecto);
        Task<IEnumerable<DocumentoProspecto>> GetDocumentosByProspectoIdAsync(int nProspecto);

        #endregion [DOCUMENTOS]

    }
}
