using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SAF.Web.Helper
{
    public class NotificacionAdmin
    {
        ModeloExtranet modelEntity = new ModeloExtranet();

        public void grabarNotificacionAuditor(int idAuditor, string asunto, string body)
        {
            var infoAuditor = this.modelEntity.SAF_AUDITOR.Where(c => c.CODAUD == idAuditor).FirstOrDefault();
            modelEntity.SAF_NOTIFICACION.Add(new SAF_NOTIFICACION()
            {
                DESNOT = body,
                ASUNOT = asunto,
                FECREG = DateTime.Now,
                USUEMI = "SYSTEM",
                INDNOT = "R",
                ESTNOT = "R",
                USUREC = infoAuditor.NOMUSU,
                ESTREG = "1"
            });
            modelEntity.SaveChanges();
        }

        public void grabarNotificacionSOA(int idSOA, string asunto, string body)
        {
            var infoAuditor = this.modelEntity.SAF_SOA.Where(c => c.CODSOA == idSOA).FirstOrDefault();
            modelEntity.SAF_NOTIFICACION.Add(new SAF_NOTIFICACION()
            {
                DESNOT = body,
                ASUNOT = asunto,
                FECREG = DateTime.Now,
                USUEMI = "SYSTEM",
                INDNOT = "R",
                ESTNOT = "R",
                USUREC = infoAuditor.NOMUSU,
                ESTREG = "1"
            });
            modelEntity.SaveChanges();
        }

        public void grabarNotificacionTodosUsuarios(string asunto, string body)
        {
            var auditoresInfo = this.modelEntity.SAF_AUDITOR.ToList().Where(c=>c.ESTREG == "1");
            foreach (var item in auditoresInfo)
            {
                modelEntity.SAF_NOTIFICACION.Add(new SAF_NOTIFICACION()
                {
                    DESNOT = body,
                    ASUNOT = asunto,
                    FECREG = DateTime.Now,
                    INDNOT = "R",
                    ESTNOT = "R",
                    USUEMI = "SYSTEM",
                    USUREC = item.NOMUSU,
                    ESTREG = "1"
                });
                modelEntity.SaveChanges();
            }


            var soasInfo = this.modelEntity.SAF_SOA.ToList().Where(c => c.ESTREG == "1");
            foreach (var item in soasInfo)
            {
                modelEntity.SAF_NOTIFICACION.Add(new SAF_NOTIFICACION()
                {
                    DESNOT = body,
                    ASUNOT = asunto,
                    FECREG = DateTime.Now,
                    INDNOT = "R",
                    ESTNOT = "R",
                    USUEMI = "SYSTEM",
                    USUREC = item.NOMUSU,
                    ESTREG = "1"
                });
                modelEntity.SaveChanges();
            }
        }
    }
}