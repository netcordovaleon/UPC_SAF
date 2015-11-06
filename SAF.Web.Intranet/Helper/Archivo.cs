using SAF.Configuracion.Constantes;
using System;
using System.Linq;
using System.IO;
using System.Web;
using System.Security.Cryptography;
using System.Text;
using SAF.Web.Intranet;

namespace SAF.Web.Helper
{
    public static class Archivo
    {
        #region Miembros
        private static SI_SOCAUDEntities modelEntity = new SI_SOCAUDEntities();

        public static SAF_ARCHIVO InsertarArchivo(HttpPostedFileBase file)
        {
            var resultado = false;

            var kb = file.ContentLength / 1024f;
            if (kb > Config.MaxTamanioPorArchivo)
                throw new Exception("El archivo a subir excede al tamaño permitido");

            var archivo = new SAF_ARCHIVO
            {
                NOMBLABEL = Path.GetFileName(file.FileName),
                ARCNOMBFISICO = Path.GetFileName(file.FileName)
            };

            modelEntity.SAF_ARCHIVO.Add(archivo);
            modelEntity.SaveChanges();

            var ruta = Path.Combine(Config.RutaArchivo, archivo.ARCNOMBFISICO);

            try
            {
                file.SaveAs(ruta);
                resultado = true;
            }
            catch
            {
                modelEntity.SAF_ARCHIVO.Remove(modelEntity.SAF_ARCHIVO.FirstOrDefault(x => x.CODARC == archivo.CODARC));
                modelEntity.SaveChanges();
            }

            if (resultado)
                return archivo;
            throw new Exception("Ocurrió un error al guardar el archivo");
        }

        public static void ReemplazarArchivo(long codArchivo, HttpPostedFileBase file)
        {
            var kb = file.ContentLength / 1024f;
            if (kb > Config.MaxTamanioPorArchivo)
                throw new Exception("El archivo a subir excede al tamaño permitido");

            var archivo = modelEntity.SAF_ARCHIVO.FirstOrDefault(x => x.CODARC == codArchivo);
            var ruta1 = Path.Combine(Config.RutaArchivo, archivo.ARCNOMBFISICO);
            var stream = Archivo.HttpPostedFileBaseToBytes(file);

            try
            {
                if (!Archivo.FileEquals(ruta1, stream))
                {
                    //archivo.CARC_USR_CODIGO = HttpContext.Current.Session["User"].ToString();
                    archivo.NOMBLABEL = Path.GetFileName(file.FileName);
                    modelEntity.SaveChanges();

                    if (File.Exists(ruta1)) File.Delete(ruta1);

                    var ruta2 = Path.Combine(Config.RutaArchivo, string.Format("{0}_{1}", archivo.CODARC, file.FileName));
                    file.SaveAs(ruta2);
                }
            }
            catch
            {
            }
        }

        public static void EliminarArchivo(long codArchivo)
        {
            var archivo = modelEntity.SAF_ARCHIVO.FirstOrDefault(x => x.CODARC == codArchivo);
            //var ruta = Path.Combine(Config.FtpRutaArchivos, archivo.CARC_NOMBREFISICO);
            //var impersonator = new Impersonator();
            //try
            //{
            //    impersonator.Impersonate(Config.FtpUsuario, string.Empty, Config.FtpContrasena);
            //    if (File.Exists(ruta)) File.Delete(ruta);
            //    impersonator.Dispose();
            //}
            //catch
            //{
            //    impersonator.Dispose();
            //}
            modelEntity.SAF_ARCHIVO.Remove(archivo);
            modelEntity.SaveChanges();
        }

        public static SAF_ARCHIVO DescargarArchivo(long codArchivo)
        {
            var resultado = false;
            var archivo = modelEntity.SAF_ARCHIVO.FirstOrDefault(x => x.CODARC == codArchivo);
            var ruta = Path.Combine(Config.RutaArchivo, archivo.ARCNOMBFISICO);

            try
            {
                archivo.fileBytes = File.ReadAllBytes(ruta);
                resultado = true;
            }
            catch
            {
            }

            if (resultado)
                return archivo;
            throw new Exception("Ha ocurrido un error al intentar descargar el archivo.");
        }

        public static long? RegistrarArchivo(long? id, FileBe filebe)
        {
            if (filebe.FileData != null)
            {
                if (!filebe.NarcCodigo.HasValue)
                {
                    var arc = InsertarArchivo(filebe.FileData);
                    filebe.NarcCodigo = arc.CODARC;
                }
                else
                    ReemplazarArchivo(filebe.NarcCodigo.Value, filebe.FileData);
            }
            return filebe.NarcCodigo.HasValue ? filebe.NarcCodigo : id;
        }

        #endregion

        #region Funciones
        public static bool FileEquals(string ruta1, string ruta2)
        {
            return GetHash(ruta1) == GetHash(ruta2);
        }

        public static bool FileEquals(string ruta1, byte[] stream1)
        {
            return GetHash(ruta1) == GetHash(stream1);
        }

        public static bool FileEquals(byte[] stream1, byte[] stream2)
        {
            return GetHash(stream1) == GetHash(stream2);
        }

        public static byte[] HttpPostedFileBaseToBytes(HttpPostedFileBase file)
        {
            var target = new MemoryStream();
            file.InputStream.CopyTo(target);
            return target.ToArray();
        }

        private static string GetHash(string ruta)
        {
            var file = new FileStream(ruta, FileMode.Open);
            MD5 md5 = new MD5CryptoServiceProvider();
            var retVal = md5.ComputeHash(file);
            file.Close();
            var sb = new StringBuilder();
            foreach (var t in retVal)
            {
                sb.Append(t.ToString("x2"));
            }
            return sb.ToString();
        }

        private static string GetHash(byte[] stream)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            var retVal = md5.ComputeHash(stream);
            var sb = new StringBuilder();
            foreach (var t in retVal)
            {
                sb.Append(t.ToString("x2"));
            }
            return sb.ToString();
        }
        #endregion
    }

    public class FileBe
    {
        public FileBe()
        {
        }

        public FileBe(long? narcCodigo, string carcNombre, HttpPostedFileBase fileData)
        {
            this.NarcCodigo = narcCodigo;
            this.CarcNombre = carcNombre;
            this.FileData = fileData;
        }

        public long? NarcCodigo { get; set; }
        public string CarcNombre { get; set; }
        public HttpPostedFileBase FileData { get; set; }

    }

}