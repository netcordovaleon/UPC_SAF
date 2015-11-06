using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAF.AccesoDatos;
using SAF.AccesoDatos.Repository;
using SAF.Negocio.Contrato;
using SAF.Configuracion;
using SAF.Configuracion.Mapeo;
using SAF.Entidad;
using SAF.DTO;
using System.Transactions;
using AutoMapper.Mappers;
using AutoMapper;
using SAF.Configuracion.Constantes;
using SAF.Configuracion.Enum;
using SAF.Configuracion.ExcepcionNegocio;

using SAF.Inteligencia.Contrato;
using SAF.Inteligencia.Implementacion;

namespace SAF.Negocio.Implementacion
{
    public class ConcursoPublicoMeritoLogic : IConcursoPublicoMeritoLogic
    {

        private readonly ISafCronogramaLogic _safCronogramaLogic;
        private readonly ISafCronoEntidadLogic _safCronoEntidadLogic;

        private readonly ISafPublicacionLogic _safPublicacionLogic;
        private readonly IVwSafPublicacionLogic _vwSafPublicacionLogic;



        private readonly ISpSafCortePublicacionLogic _spSafCortePublicacionLogic;

        private readonly ISpSafResultadoCorteLogic _spSafResultadoCorteLogic;

        public ConcursoPublicoMeritoLogic()
        {
            Mapear.Do();
            this._safCronogramaLogic = new SafCronogramaLogic();
            this._safCronoEntidadLogic = new SafCronoEntidadLogic();

            this._safPublicacionLogic = new SafPublicacionLogic();
            this._vwSafPublicacionLogic = new VwSafPublicacionLogic();

            this._spSafCortePublicacionLogic = new SpSafCortePublicacionLogic();
            this._spSafResultadoCorteLogic = new SpSafResultadoCorteLogic();
        }


        public CronogramaDTO GrabarCronograma(CronogramaDTO entidad)
        {

            using (TransactionScope tran = new TransactionScope())
            {
                try
                {
                    var cronograma = Mapper.Map<CronogramaDTO, SAF_CRONOGRAMA>(entidad);
                    var resultRegCronograma = this._safCronogramaLogic.Registrar(cronograma);
                    entidad.CODCRO = resultRegCronograma.CODCRO;
                    tran.Complete();
                    return entidad;
                }
                catch (Exception)
                {
                    tran.Dispose();
                    throw;
                }
            }
        }

        public CronoEntidadDTO GrabarCronoEntidad(CronoEntidadDTO entidad)
        {
            using (TransactionScope tran = new TransactionScope())
            {
                try
                {
                    var cronoEntidad = Mapper.Map<CronoEntidadDTO, SAF_CRONOENTIDAD>(entidad);
                    var resultRegCronoEntidad = this._safCronoEntidadLogic.Registrar(cronoEntidad);
                    entidad.CODCROENT = resultRegCronoEntidad.CODCROENT;
                    tran.Complete();
                    return entidad;
                }
                catch (Exception)
                {
                    tran.Dispose();
                    throw;
                }
            }
        }


        public IEnumerable<PublicacionViewDTO> ListarPublicacion()
        {
            var lista = this._vwSafPublicacionLogic.ListarPublicacion();
            var result = lista.Select(c => new PublicacionViewDTO() { CODPUB = c.CODPUB, CODBAS = c.CODBAS, NUMPUB = c.NUMPUB, DESBAS = c.DESBAS, ESTPUB = c.ESTPUB, NOMPAR = c.NOMPAR });
            return result;
        }


        public PublicacionDTO PublicarPublicacion(int id)
        {
            using (TransactionScope tran = new TransactionScope()) {
                try
                {
                    var publicacion = this._safPublicacionLogic.BuscarPorId(id);
                    publicacion.ESTPUB = (int)Estado.Publicacion.Publicado;
                    var entidad = this._safPublicacionLogic.Actualizar(publicacion);
                    var result = Mapper.Map<SAF_PUBLICACION, PublicacionDTO>(entidad);
                    var corte = GenerarCortePublicacion(id);

                    if (corte.EXITO.Equals(0)) {
                        tran.Dispose();
                        throw new Exception();
                    }

                    tran.Complete();
                    return result;
                }
                catch (Exception)
                {
                    tran.Dispose();
                    throw;
                }
            }
        }

        public SP_SAF_CORTEPUBLICACION_Result GenerarCortePublicacion(int idPublicacion)
        {
            return this._spSafCortePublicacionLogic.GenerarCortePublicacion(idPublicacion);
        }


        public IEnumerable<ResultadoCorteSpDTO> VerResultadoCorte(int idPublicacion)
        {
            var lista = this._spSafResultadoCorteLogic.VerResultadoCorte(idPublicacion);
            var result = (from c in lista select new ResultadoCorteSpDTO() { 
                CODAUD = c.CODAUD,
                NOMCOMAUD = c.NOMCOMAUD,
                NOMCAR = c.NOMCAR,
                CAPAPUNT = c.CAPAPUNT,
                EXPPUNT = c.EXPPUNT,
                CAPAHORGESPUB =c.CAPAHORGESPUB,
                CAPAHORAUDFIN = c.CAPAHORAUDFIN,
                EXPHORAUDFIN = c.EXPHORAUDFIN,
                EXPHORGESPUB = c.EXPHORGESPUB,
                TOTALPUNT = c.TOTALPUNT
            });
            return result;
        }
    }
}
