using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SAF.Web.Intranet.Helper
{
    public class NotificacionAdmin
    {

        SI_SOCAUDEntities modelEntity = new SI_SOCAUDEntities();

        public void grabarNotificacion(int idAuditor, string asunto, string body) {
            var infoAuditor = this.modelEntity.SAF_AUDITOR.Where(c => c.CODAUD == idAuditor).FirstOrDefault();
            modelEntity.SAF_NOTIFICACION.Add(new SAF_NOTIFICACION(){
                DESNOT = body,       
                FECREG = DateTime.Now,
                USUEMI = "SYSTEM",
                INDNOT = "N",
                USUREC = infoAuditor.NOMUSU
            });
            modelEntity.SaveChanges();
        }

        public void grabarNotificacionTodosUsuarios(string asunto, string body) {
            var auditoresInfo = this.modelEntity.SAF_AUDITOR.ToList();
            foreach (var item in auditoresInfo)
            {
                modelEntity.SAF_NOTIFICACION.Add(new SAF_NOTIFICACION()
                {
                    DESNOT = body,
                    FECREG = DateTime.Now,
                    INDNOT = "N",
                    USUEMI = "SYSTEM",
                    USUREC = item.NOMUSU
                });
                modelEntity.SaveChanges();                
            }   
        }
    }
}